using Calculator_.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
            string x = "0.020";
            Console.WriteLine(x.Length);
        }

        InputValidation validationInput = new InputValidation();
        string answer;
        string updatedInput;
        Result result = new Result(); 

        private void operatorClick(object sender, EventArgs e)
        {
            Button operatorButton = (Button)sender;
            updatedInput = validationInput.setOperator(operatorButton.Text);
            expressionTextBox.Text = updatedInput;
            numberTextBox.Text = "";
        }

        private void numberClick(object sender, EventArgs e)
        {
            Button numberButton = (Button)sender;
            updatedInput = validationInput.setNumber(numberButton.Text, updatedInput);
            expressionTextBox.Text = updatedInput;
            numberTextBox.ForeColor = Color.DarkGray;

            Tokenize inputTokenize = new Tokenize(updatedInput);
            Token[] tokens = inputTokenize.getArrayOfTokens();
            answer = result.getResult(tokens, updatedInput);
            numberTextBox.Text = answer;
        }

        private void equallyButton_Click(object sender, EventArgs e)
        {
            try
            {
                updatedInput = validationInput.setResult();
                Tokenize inputTokenize = new Tokenize(updatedInput);
                Token[] tokens = inputTokenize.getArrayOfTokens();

                answer = result.getResult(tokens, updatedInput);
                numberTextBox.Text = answer;
          
                validationInput.setInputIsEmpty();
                updatedInput = validationInput.setNumber(answer.ToString(),updatedInput);
                expressionTextBox.Text = answer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void bracketClick(object sender, EventArgs e)
        {
            Button braceButton = (Button)sender;
            updatedInput = validationInput.setBracket(char.Parse(braceButton.Text));
            expressionTextBox.Text = updatedInput;

            if (InputValidation.countLeftBrackets(expressionTextBox.Text) != InputValidation.countRightBrackets(expressionTextBox.Text))
                numberTextBox.Text = "";
            else
            {
                Tokenize inputTokenize = new Tokenize(updatedInput);
                Token[] tokens = inputTokenize.getArrayOfTokens();

                answer = result.getResult(tokens, updatedInput);
                numberTextBox.Text = answer;
            }
        }

        private void changeSign_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(updatedInput))
                updatedInput = "(-";
            else
            {
                //uraditi da checkSign vraca novi niz tokena 
                //tokens = novi niz tokena 
                Tokenize inputTokenize = new Tokenize(updatedInput);
                Token[] tokens = inputTokenize.getArrayOfTokens();
                updatedInput = validationInput.checkSign(tokens, updatedInput);
                numberTextBox.Text = "";
            }
            updatedInput = validationInput.updateExpressionText(updatedInput);
            expressionTextBox.Text = updatedInput;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            numberTextBox.Clear();
            expressionTextBox.Clear();
            answer = "";
            validationInput.setInputIsEmpty();
            updatedInput = "";

        }
    }
}
