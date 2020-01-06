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

                numberTextBox.Text = result.getResult(tokens);
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
                Tokenize inputTokenize = new Tokenize(updatedInput);
                Token[] tokens = inputTokenize.getArrayOfTokens();
                updatedInput = input.setResult();
                getAnswer();
                input.setInputIsEmpty();
                updatedInput = input.setNumber(answer.ToString());
                expressionTextBox.Text = answer;

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
                answer = result.getResult(tokens);
                numberTextBox.Text = answer;
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

        private void braceClick(object sender, EventArgs e)
        {
            Button braceButton = (Button)sender;
            updatedInput = input.setBracket(char.Parse(braceButton.Text));
            expressionTextBox.Text = updatedInput;
            getAnswer();
        }

        private string getLastTokenType()
        {
            Tokenize inputTokenize = new Tokenize(updatedInput);
            Token[] tokens = inputTokenize.getArrayOfTokens();
            Token lastItem = tokens[tokens.Length - 1];
            return lastItem.getTokenType().ToString();
        }

        private string getLastTokenValue()
        {
            Tokenize inputTokenize = new Tokenize(updatedInput);
            Token[] tokens = inputTokenize.getArrayOfTokens();
            Token lastItem = tokens[tokens.Length - 1];
            return lastItem.getTokenValue().ToString();
        }

        private string getPenultimateTokenType()
        {
            Tokenize inputTokenize = new Tokenize(updatedInput);
            Token[] tokens = inputTokenize.getArrayOfTokens();
            Token penultmateToken = tokens[tokens.Length - 2];
            return penultmateToken.getTokenType().ToString();
        }

        private string getTheThirdFromTheEndTokenType()
        {
            Tokenize inputTokenize = new Tokenize(updatedInput);
            Token[] tokens = inputTokenize.getArrayOfTokens();
            Token theThird = tokens[tokens.Length - 3];
            return theThird.getTokenType().ToString();
        }

        private void changeSign_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(updatedInput))
                updatedInput = "(-";
            else
            {
                Tokenize inputTokenize = new Tokenize(updatedInput);
                Token[] tokens = inputTokenize.getArrayOfTokens();
                int inputLength = updatedInput.Length;

                if (tokens.Length == 1)
                   addADifferentSignBeforeALastumber();

                else if (getPenultimateTokenType() == "LeftBracket" && getLastTokenValue()=="")
                    updatedInput = updatedInput.Remove(inputLength - 2, 2);

                else if (getLastTokenType() == "Number" && isPenultimateTokenPlus())
                    addADifferentSignBeforeALastumber();

                else if (getLastTokenType() == "Number" && getTheThirdFromTheEndTokenType() == "LeftBracket")
                    updatedInput = updatedInput.Remove(inputLength - 2-getLastTokenValue().Length, 2);

                else if (getLastTokenType() == "Number")
                    addADifferentSignBeforeALastumber();

                else
                {
                    updatedInput += "(-";
                    numberTextBox.Text = result.getResult(tokens);
                }

            }
            updatedInput = input.updateExpressionText(updatedInput);
            expressionTextBox.Text = updatedInput;
        }

        private string addADifferentSignBeforeALastumber()
        {
            updatedInput= updatedInput.Insert(updatedInput.Length - getLastTokenValue().Length, "(-");
            return updatedInput;
        }

        private bool isPenultimateTokenPlus()
        {
            return updatedInput[updatedInput.Length - 2] == '+';
        }

        private bool isLastTokenMinus()
        {
            return updatedInput[updatedInput.Length - 1] == '-';
        }
    }
}
