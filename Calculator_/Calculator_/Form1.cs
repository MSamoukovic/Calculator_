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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();         
        }

      
        private void operatorClick(object sender, EventArgs e)
        {
            Button operatorButton = (Button)sender;
            exprTextBox.Text += operatorButton.Text;
            textBox.Text+=operatorButton.Text;
        }

        private void numberClick(object sender, EventArgs e)
        {
            Button numberButton = (Button)sender;
            addText(numberButton.Text);
            textBox.Text += numberButton.Text;

        }

        public void addText(string numberText)
        {
            numberTextBox.Text = numberText;
            exprTextBox.Text += numberText;
        }

        private void equallyButton_Click(object sender, EventArgs e)
        {
            numberTextBox.Clear();
            try
            {
                Tokenize listOfTokens = new Tokenize(textBox.Text);
                Token[] tokens = listOfTokens.getArrayOfTokens();
 
                ShuntingYard  sy = new ShuntingYard(tokens);
                tokens = sy.getArray();

                CalculateExpression calculate = new CalculateExpression(tokens);
                double answer = calculate.getAnswer();

                textBox.Text = answer.ToString();
            }
            catch (Exception f)
            {
                Console.WriteLine(f.Message);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            numberTextBox.Clear();
            exprTextBox.Clear();
            textBox.Clear();
        }
    }
}
