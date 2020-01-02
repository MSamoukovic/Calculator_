using Calculator_.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();         
        }

        public double answer { get; set; }

        private void operatorClick(object sender, EventArgs e)
        {
            Button operatorButton = (Button)sender;
            if (expressionTextBox.Text.Length == 0)
            {
                addText("0");
                expressionTextBox.Text+=operatorButton.Text;
            }
            else 
            {
                string lastCharacter = expressionTextBox.Text.Substring(expressionTextBox.Text.Length - 1);
                           
                if (lastCharacter == "+" || lastCharacter == "-" || lastCharacter == "*" || lastCharacter == "/")
                {
                    string penultimateCharacter = expressionTextBox.Text.Substring(expressionTextBox.Text.Length - 2,1);
                    if ((lastCharacter == "+" || lastCharacter == "-") && penultimateCharacter == "(" && (operatorButton.Text=="*" || operatorButton.Text=="/"))
                       return;
                    expressionTextBox.Text = expressionTextBox.Text.Remove(expressionTextBox.Text.Length - 1, 1);
                    expressionTextBox.Text += operatorButton.Text;
                }
                else if (lastCharacter == "(" && (operatorButton.Text == "*" || operatorButton.Text == "/"))
                    expressionTextBox.Text = expressionTextBox.Text;
                else
                    expressionTextBox.Text += operatorButton.Text;
            }
        }

        private void numberClick(object sender, EventArgs e)
        {
            Button numberButton = (Button)sender;
            addText(numberButton.Text);          
        }

        public void addText(string numberText)
        {
            numberTextBox.Text = numberText;
            expressionTextBox.Text += numberText;
        }

        private void equallyButton_Click(object sender, EventArgs e)
        {
            int countRightBrace = 0, countLeftBrace = 0;
            countBraces(out countRightBrace, out countLeftBrace);

            try
            {
                if (countLeftBrace > countRightBrace)
                {
                    for (int i = 0; i < countLeftBrace - countRightBrace; i++)
                        expressionTextBox.Text += ")";
                }
             
               
                Tokenize inputTokenize = new Tokenize(expressionTextBox.Text);
                Token[] tokens = inputTokenize.getArrayOfTokens();
 
                ShuntingYard  sy = new ShuntingYard(tokens);
                tokens = sy.getArray();

                CalculateExpression calculate = new CalculateExpression(tokens);
                answer = calculate.getAnswer();

                numberTextBox.Text = answer.ToString();

            }
            catch (Exception f)
            {
                Console.WriteLine(f.Message);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            numberTextBox.Clear();
            expressionTextBox.Clear();
            answer = 0;
        }

        private void braceClick(object sender, EventArgs e)
        {
            Button braceButton = (Button)sender;
            int countRightBrace, countLeftBrace;
            countBraces(out countRightBrace, out countLeftBrace);

            if (expressionTextBox.Text.Length != 0)
            {
                string lastCharacter = expressionTextBox.Text.Substring(expressionTextBox.Text.Length - 1);

                if (lastCharacter == numberTextBox.Text && braceButton.Text == "(")
                    expressionTextBox.Text += "*";
                else if (lastCharacter == "(" && braceButton.Text == ")") //ako imamo ()
                {
                    expressionTextBox.Text = expressionTextBox.Text.Remove(expressionTextBox.Text.Length - 1, 1);
                    return;
                }
                else if (braceButton.Text == ")" && countLeftBrace == countRightBrace)
                    return;
            }
            expressionTextBox.Text += braceButton.Text;
        }

        private void countBraces(out int countRightBrace, out int countLeftBrace)
        {
            countRightBrace = 0;
            countLeftBrace = 0;
            foreach (char c in expressionTextBox.Text)
            {
                if (c == ')')
                    countRightBrace++;
                else if (c == '(')
                    countLeftBrace++;
            }
        }
    }
}
