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
            updatedInput = "";
        }

        private void braceClick(object sender, EventArgs e)
        {
            Button braceButton = (Button)sender;
            updatedInput = input.setBraces(braceButton.Text);
            expressionTextBox.Text = updatedInput;

            Console.WriteLine(updatedInput);
            if (input.countLeftBraces() > input.countRightBraces())
            {
                numberTextBox.Text = "";
                return;
            }
            else if (input.countLeftBraces() == input.countRightBraces())
                getAnswer();
        }


        private string getLast()
        {
            Tokenize inputTokenize = new Tokenize(updatedInput);
            Token[] tokens = inputTokenize.getArrayOfTokens();
            Token lastItem = tokens[tokens.Length - 1];
            return lastItem.getTokenType().ToString();
        }
        private string getLastValue()
        {
            Tokenize inputTokenize = new Tokenize(updatedInput);
            Token[] tokens = inputTokenize.getArrayOfTokens();
            Token lastItem = tokens[tokens.Length - 1];
            return lastItem.getTokenValue().ToString();
        }

        private string getPenultimate()
        {
            Tokenize inputTokenize = new Tokenize(updatedInput);
            Token[] tokens = inputTokenize.getArrayOfTokens();
            Token penultmateToken = tokens[tokens.Length - 2];
            return penultmateToken.getTokenType().ToString();
        }

        private string getTheThirdFromTheEnd()
        {
            Tokenize inputTokenize = new Tokenize(updatedInput);
            Token[] tokens = inputTokenize.getArrayOfTokens();
            Token theThird = tokens[tokens.Length - 3];
            return theThird.getTokenType().ToString();
        }

        private void changeSign_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(updatedInput))
                return;
            else
            {
                Tokenize inputTokenize = new Tokenize(updatedInput);
                Token[] tokens = inputTokenize.getArrayOfTokens();

                if (tokens.Length >= 3)
                {
                     if (getTheThirdFromTheEnd() == "LeftBrace" && getPenultimate() == "Operator" && getLast()!="Operator")
                    {
                        int x = updatedInput.Length;
                        updatedInput = updatedInput.Remove(x - getLastValue().Length - 2, 2);
                        updatedInput = input.updateExpressionText(updatedInput);
                    }
                    else if (getTheThirdFromTheEnd() == "Operator" && getPenultimate() == "Number" && getLast() == "Operator")
                    {
                        updatedInput += "(-";
                        expressionTextBox.Text= updatedInput;
                        updatedInput = input.updateExpressionText(updatedInput);
                    }
                    else
                    {
                        int x = updatedInput.Length;
                        updatedInput = updatedInput.Insert(x - getLastValue().Length, "(-");
                        updatedInput = input.updateExpressionText(updatedInput);
                    }
                }
                else if (tokens.Length == 1)
                {
                    int x = updatedInput.Length;
                    updatedInput = updatedInput.Insert(x - getLastValue().Length, "(-");
                }
                updatedInput = input.updateExpressionText(updatedInput);
                expressionTextBox.Text = updatedInput;
                ShuntingYard sy = new ShuntingYard(tokens);
                tokens = sy.getArray();
                CalculateExpression calculate = new CalculateExpression(tokens);
                answer = calculate.getAnswer();
                numberTextBox.Text = answer.ToString();

                getAnswer();
                numberTextBox.Text = answer.ToString();
            }
        }





           
    }
}
