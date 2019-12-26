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
                Token[] tokens = Tokenize(textBox.Text);
                tokens = ShuntingYard(tokens);
                double answer = CalculatorExpression(tokens);

                textBox.Text = answer.ToString();
            }
            catch (Exception f)
            {
                Console.WriteLine(f.Message);
            }

        }
        private double CalculatorExpression(Token[] tokens)
        {
            int index = 0;
            Stack<Token> operandStack = new Stack<Token>();
            while (index < tokens.Count())
            {
                Token t = tokens[index];
                if (t.GetTokenType == Token.TokenType.Number)
                    operandStack.Push(t);
                else
                {
                    if (operandStack.Count < t.ParamCount)
                    {
                        throw new Exception("user has not input sufficient values  in  the expression");
                    }
                    List<Token> operands = new List<Token>();
                    for (int i = 0; i < t.ParamCount; i++)
                    {
                        operands.Add(operandStack.Pop());
                    }
                    operandStack.Push(EvaluateOperator(t, operands)); //na stack push rezutat ( to nam vrati funkcija evaluateOperattor
                }
                index++;
            }
            if (operandStack.Count == 1)
            {
                return operandStack.Pop().Val;
            }
            else
            {
                throw new Exception("ddd");
            }

        }
        private Token EvaluateOperator(Token oper, List<Token> operands)
        {
            switch (oper.Symbol)
            {
                case '+':
                    operands[0].Val += operands[1].Val;
                    break;
                case '-':
                    operands[0].Val = operands[1].Val- operands[0].Val;
                    break;
                case '*':
                    operands[0].Val *= operands[1].Val;
                    break;
                case '/':
                    operands[0].Val = operands[1].Val/ operands[0].Val;
                    break;
                case '_':
                    operands[0].Val = -operands[0].Val;
                    break;

                default:
                    throw new Exception("unknown operator");
            }

            return operands[0];
        }

        private Token[] ShuntingYard(Token[] tokens) //vrati nam niz tokena i sada na taj niz racunamo pomocu fje calculateWxpression
        {
            int index = 0;
            Queue<Token> outputQueue = new Queue<Token>();
            Stack<Token> operatorStack = new Stack<Token>();
            while (index < tokens.Count()) //prodjemo ktoz citavu listu
            {
                Token t = tokens[index]; 
                if (t.GetTokenType == Token.TokenType.Number)
                {
                    outputQueue.Enqueue(t);
                }
                else if (t.GetTokenType == Token.TokenType.Operator) // ako je token operator
                {
                    while (operatorStack.Count != 0) //ako nije prvi operator
                    {
                        Token o2 = operatorStack.Peek(); //o2 je prvi sa steka 
                        if (o2.GetTokenType != Token.TokenType.Operator) 
                            break;
                        else if ((t.Assoc == Token.Associativity.Left && t.Precedence == o2.Precedence) || (t.Precedence < o2.Precedence))
                        {//ako su istog prioriteta ili je ovaj sa steka veceg prioriteta, skinem operator sa steka i dodam ga na red
                            outputQueue.Enqueue(operatorStack.Pop());
                        }
                        else
                            break;
                    }
                    operatorStack.Push(t); // ako je to prvi operator, dodamo ga na stek
                }
                else if (t.GetTokenType == Token.TokenType.LeftBrace)
                {
                    operatorStack.Push(t);
                }
                else if (t.GetTokenType == Token.TokenType.RightBrace) //desna zagrada
                {
                    while (operatorStack.Peek().GetTokenType != Token.TokenType.LeftBrace)
                    {
                        outputQueue.Enqueue(operatorStack.Pop());
                        if (operatorStack.Count == 0)
                        {
                            throw new Exception("Mismatched parentheses"); // neuskladjene zagrade
                        }
                    }
                    operatorStack.Pop();
                }
                index++;
            }
            while (operatorStack.Count != 0)
            {
                if (operatorStack.Peek().GetTokenType == Token.TokenType.LeftBrace ||
                    operatorStack.Peek().GetTokenType == Token.TokenType.RightBrace)
                {
                    throw new Exception("Mismatched parentheses");
                }
                outputQueue.Enqueue(operatorStack.Pop());
            }
            return outputQueue.ToArray();
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
                        t.setValues('_', Token.Associativity.Right, 1, 30);
                        //stavimo bilo koji znak da znako na sta se to odnosi jer cemo kasnije u evaluate funckiji to koristiti 
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
            textBox.Clear();
        }
    }
}
