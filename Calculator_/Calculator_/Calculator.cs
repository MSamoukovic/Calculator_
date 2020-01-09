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
        }

        InputValidation expression = new InputValidation();
        string updatedExpression;
        Result result = new Result(); 

        private void operatorClick(object sender, EventArgs e)
        {
            Button operatorButton = (Button)sender;
            updatedExpression = expression.setOperator(operatorButton.Text);
            expressionTextBox.Text = updatedExpression;
            numberTextBox.Text = "";
        }

        private void numberClick(object sender, EventArgs e)
        {
            Button numberButton = (Button)sender;
            updatedExpression = expression.setNumber(numberButton.Text, updatedExpression);
            expressionTextBox.Text = updatedExpression;
            numberTextBox.Text = result.getResult(updatedExpression);;
        }

        private void equallyButton_Click(object sender, EventArgs e)
        {
            try 
            {
                updatedExpression = expression.setResult();
                numberTextBox.Text = result.getResult(updatedExpression);
                expression.setInputIsEmpty();
                updatedExpression = expression.setNumber(result.getResult(updatedExpression).ToString(),updatedExpression);
                expressionTextBox.Text = result.getResult(updatedExpression);;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void bracketClick(object sender, EventArgs e)
        {
            Button braceButton = (Button)sender;
            updatedExpression = expression.setBracket(char.Parse(braceButton.Text));
            expressionTextBox.Text = updatedExpression;
            numberTextBox.Text = result.getResult(updatedExpression);;
        }

        private void changeSign_Click(object sender, EventArgs e)
        {
            updatedExpression = expression.changeTheSign(updatedExpression);
            numberTextBox.Text = "";
            expressionTextBox.Text = updatedExpression;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            numberTextBox.Clear();
            expressionTextBox.Clear();
            expression.setInputIsEmpty();
            updatedExpression = "";

        }
    }
}
