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
        string answer;
        string updatedInput;
        Result result = new Result(); 

        private void operatorClick(object sender, EventArgs e)
        {
            Button operatorButton = (Button)sender;
            updatedInput = input.setOperator(operatorButton.Text);
            expressionTextBox.Text = updatedInput;
            numberTextBox.Text = "";
        }

        private void numberClick(object sender, EventArgs e)
        {
            Button numberButton = (Button)sender;
            updatedInput = input.setNumber(numberButton.Text);
            expressionTextBox.Text = updatedInput;
            numberTextBox.ForeColor = Color.DarkGray;

            if (input.countLeftBraces() != input.countRightBraces())
                numberTextBox.Text = "";
            else
            {
                Tokenize inputTokenize = new Tokenize(updatedInput);
                Token[] tokens = inputTokenize.getArrayOfTokens();
                answer = result.getResult(tokens);
                numberTextBox.Text = answer;

               if( result.isNumberHaveADot(tokens,updatedInput,expressionTextBox)==true)
                    dotButton.Enabled = false;
               else
                    dotButton.Enabled = true;
            }
        }

        private void equallyButton_Click(object sender, EventArgs e)
        {
            try
            {
                updatedInput = input.setResult();
                Tokenize inputTokenize = new Tokenize(updatedInput);
                Token[] tokens = inputTokenize.getArrayOfTokens();
                answer = result.getResult(tokens);
                numberTextBox.Text = answer;
          
                input.setInputIsEmpty();
                updatedInput = input.setNumber(answer.ToString());
                expressionTextBox.Text = answer;

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
            answer = "";
            input.setInputIsEmpty();
            updatedInput = "";
        }

        private void bracketClick(object sender, EventArgs e)
        {
            Button braceButton = (Button)sender;
            updatedInput = input.setBracket(char.Parse(braceButton.Text));
            expressionTextBox.Text = updatedInput;

            if (input.countLeftBraces() != input.countRightBraces())
                numberTextBox.Text = "";
            else
            {
                Tokenize inputTokenize = new Tokenize(updatedInput);
                Token[] tokens = inputTokenize.getArrayOfTokens();
                answer = result.getResult(tokens);
                numberTextBox.Text = answer;
            }
        }

        private void changeSign_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(updatedInput))
                updatedInput = "(-";
            else
            {
                Tokenize inputTokenize = new Tokenize(updatedInput);
                Token[] tokens = inputTokenize.getArrayOfTokens();
                updatedInput = input.checkSign(tokens.Length, updatedInput);
            }
            updatedInput = input.updateExpressionText(updatedInput);
            expressionTextBox.Text = updatedInput;
        }
    }
}
