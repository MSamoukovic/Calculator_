using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_.Models
{
    class Result
    {
        public Result()
        {

        }

        public string getResult(Token[] tokens)
        {
            double answer;
            ShuntingYard sy = new ShuntingYard(tokens);
            tokens = sy.getArray();
            CalculateExpression calculate = new CalculateExpression(tokens);
            answer = calculate.getAnswer();
            return answer.ToString();
        }


        public  bool isNumberHaveADot(Token[] tokens, string updatedInput, TextBox expressionTextBox)
        {
            for (int i = 0; i < tokens.Length; i++)
            {
                Console.WriteLine("token " + tokens[i].getTokenValue());
                if ((getLastTokenValue(updatedInput).Contains(".") && getLastTokenType(updatedInput) == "Number") || expressionTextBox.Text.EndsWith("."))
                    return true;
            }
            return false;
        }

        private string getLastTokenType(string updatedInput)
        {
            Tokenize inputTokenize = new Tokenize(updatedInput);
            Token[] tokens = inputTokenize.getArrayOfTokens();
            Token lastItem = tokens[tokens.Length - 1];
            return lastItem.getTokenType().ToString();
        }

        private string getLastTokenValue(string updatedInput)
        {
            Tokenize inputTokenize = new Tokenize(updatedInput);
            Token[] tokens = inputTokenize.getArrayOfTokens();
            Token lastItem = tokens[tokens.Length - 1];
            return lastItem.getTokenValue().ToString();
        }
    }
}
