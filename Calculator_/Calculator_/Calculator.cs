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

        Input input = new Input();
        double answer;
        string updatedInput;

        private void operatorClick(object sender, EventArgs e)
        {
            Button operatorButton = (Button)sender;
            updatedInput = input.setText(operatorButton.Text);
            expressionTextBox.Text = updatedInput;
            numberTextBox.Text = "";
        }

        private void numberClick(object sender, EventArgs e)
        {
            Button numberButton = (Button)sender;
            updatedInput = input.setNumber(numberButton.Text);
            expressionTextBox.Text = updatedInput;
            numberTextBox.ForeColor = Color.DarkGray;
            getAnswer();
        }

        private void equallyButton_Click(object sender, EventArgs e)
        {
            try
            {
                updatedInput = input.setResult();
                expressionTextBox.Text = updatedInput;
                getAnswer();
                expressionTextBox.Text = answer.ToString();
                input.setInputIsEmpty();
                updatedInput = input.setNumber(answer.ToString());
            }
            catch (Exception f)
            {
                Console.WriteLine(f.Message);
            }
        }

        private void getAnswer()
        {
           if(input.countLeftBraces()!=input.countRightBraces())
                numberTextBox.Text = "";
           else
            {
                Tokenize inputTokenize = new Tokenize(updatedInput);
                Token[] tokens = inputTokenize.getArrayOfTokens();

                ShuntingYard sy = new ShuntingYard(tokens);
                tokens = sy.getArray();

                CalculateExpression calculate = new CalculateExpression(tokens);
                answer = calculate.getAnswer();
                numberTextBox.Text = answer.ToString();
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            numberTextBox.Clear();
            expressionTextBox.Clear();
            answer = 0;
            input.setInputIsEmpty();
        }

        private void braceClick(object sender, EventArgs e)
        {
            Button braceButton = (Button)sender;
            updatedInput = input.setBraces(braceButton.Text);
            expressionTextBox.Text = updatedInput;
            if (input.countLeftBraces() > input.countRightBraces())
            {
                numberTextBox.Text = "";
                return;
            }
            else if (input.countLeftBraces() == input.countRightBraces())
                getAnswer();
        }

        private void changeSign_Click(object sender, EventArgs e)
        {
           
            Tokenize inputTokenize = new Tokenize(updatedInput);
            Token[] tokens = inputTokenize.getArrayOfTokens();

            //for (int i =0; i<tokens.Length;i++)
            //Console.WriteLine(tokens[i].getTokenValue());

            Token lastItem = tokens[tokens.Length - 1];
            Console.WriteLine(lastItem.getTokenValue());
            Console.WriteLine(lastItem.getTokenType());
           lastItem.setValues('_', Token.Associativity.Right, 1, 30);






            ShuntingYard sy = new ShuntingYard(tokens);
            tokens = sy.getArray();

            CalculateExpression calculate = new CalculateExpression(tokens);
            answer = calculate.getAnswer();
            numberTextBox.Text = answer.ToString();


        }
    }
}
