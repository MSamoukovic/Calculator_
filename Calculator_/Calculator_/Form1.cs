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
            Token[] tokens = Tokenize(textBox.Text);
            tokens = ShuntingYard(tokens); // parametar je tokenize tokens ( niz tih tokenize tokena)


        }

        private Token[] ShuntingYard(Token[] tokens)
        {
            int index = 0;
            

        }

        private string[] SplitForTokenize(string str)
        {
            str = str.Replace("*", " * ");
            str = str.Replace("/", " / ");
            str = str.Replace("+", " + ");
            str = str.Replace("-", " - ");
            str = str.Replace("(", " ( ");
            str = str.Replace(")", " ) ");
            str = str.Trim();
            while (str.Contains("  "))
            {
                str = str.Replace("  ", " ");
            }
            return str.Split(' ');
        }
        private Token[] Tokenize(string str) //vrati citavu lostu tokena
        {
            string[] split = SplitForTokenize(str); //split cijeli izraz 
            List<Token> tokens = new List<Token>();
            foreach (string s in split) 
            {
                Token t = Token.stringToToken(s); //citamo svaki 

                if (s == "-") // ako je minus, gledamo je li binary or unary
                {
                    if (tokens.Count == 0 || tokens[tokens.Count - 1].GetTokenType == Token.TokenType.LeftBrace ||
                        tokens[tokens.Count - 1].GetTokenType == Token.TokenType.Operator)
                    {
                        t.setValues('_', Token.Associativity.Right, 30, 1);
                        //ne znam zasto underscore, 
                        //assoc- right ( kucamo associativity c# i vidimo listu za svaki operator i  vidimo da je desna za minus 
                        //prioritet je veci od * i / , tamo je 20, pa ovdje stavimo 30 
                        //prec-1 jer je ovo samo unary oper.

                    }
                }
                tokens.Add(t);
            }
            return tokens.ToArray();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            numberTextBox.Clear();
            exprTextBox.Clear();
        }
    }
}
