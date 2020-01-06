using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_.Models
{
    class Input
    {
        string expressionText;

        public Input()
        {
        }

        public string setNumber(string number)
        {
            if (number == "." && isExpressionEmpty())
                return expressionText = "0" + number;
            else if (itStartAtZero(number))
                return expressionText;
             else
                return expressionText += number;
        }

        public string setResult()
        {
            int leftBraces = countLeftBraces();
            int rightBraces = countRightBraces();

            if (!isExpressionEmpty())
            {
                char lastCharacter = getLastCharacter();
                if (!isNumberTheLastCharacter(lastCharacter) && !isRightBracket(lastCharacter))
                    expressionText += "0";
                if (leftBraces > rightBraces)
                {
                    for (int i = 0; i < leftBraces - rightBraces; i++)
                        expressionText += ")";
                }
                if (expressionText.Contains("(+"))
                    expressionText = expressionText.Replace("(+", "(0+");
            }
            return expressionText;
        }

        public string setOperator(string oper)
        {
            if (isExpressionEmpty())
            addToExpression("0"+oper);
            else
            {
                char lastCharacter = getLastCharacter();
                if (isOperator(lastCharacter))
                {
                    char penultimateCharacter = char.Parse(expressionText.Substring(expressionText.Length - 2, 1));
                    if (isPlusOrMinus(lastCharacter) && isLeftBracket(penultimateCharacter) && isTimesOrDivided(oper))
                        return expressionText;
                    else
                    {
                        removeLastCharacter();
                        addToExpression(oper);
                    }
                }
                else if (isLeftBracket(lastCharacter) && isTimesOrDivided(oper))
                    return expressionText;
                else
                    addToExpression(oper);
            }
            return expressionText;
        }

        public string setBracket(char bracket)
        {
            if (!isExpressionEmpty())
            {
                char lastCharacter = getLastCharacter();

                if (isNumberTheLastCharacter(lastCharacter) && isLeftBracket(bracket)) 
                addToExpression("*(");

                else if (isLeftBracket(lastCharacter) && isRightBracket(bracket))
                    removeLastCharacter();

                else if (isRightBracket(lastCharacter) && countLeftBraces() > countRightBraces())
                    addToExpression(")");


                else if (isRightBracket(bracket) && countLeftBraces() >= countRightBraces() && !isNumberTheLastCharacter(lastCharacter)) { }

                else if (isRightBracket(bracket) && countLeftBraces() == 0) { }

                else if (!isNumberTheLastCharacter(lastCharacter) && isLeftBracket(bracket))
                    addToExpression("(");

                else
                    addToExpression(bracket.ToString());

                return expressionText;
            }
            else if (isExpressionEmpty() && isRightBracket(bracket))
                return expressionText=String.Empty;
            else
            return expressionText += bracket;
        }
       
        public string updateExpressionText(string updateString)
        {
            return expressionText = updateString;
        }
        
        public void setInputIsEmpty()
        {
            expressionText = "";
        }

        public int countLeftBraces( )
        {
           int countLeftBraces = 0;
            foreach (char c in expressionText)
            {
                if (c == '(')
                    countLeftBraces++;
            }
            return countLeftBraces; 
        }

        public int countRightBraces( )
        {
            int countRightBraces = 0;
            foreach (char c in expressionText)
            {
                if (c == ')')
                    countRightBraces++;
            }
            return countRightBraces;
        }

        private void addToExpression(string text)
        {
            expressionText += text;
        }

        private void removeLastCharacter()
        {
            expressionText = expressionText.Remove(expressionText.Length - 1, 1);
        }

        private char getLastCharacter()
        {
            return char.Parse(expressionText.Substring(expressionText.Length - 1));
        }

        private bool isExpressionEmpty()
        {
            return String.IsNullOrEmpty(expressionText);
        }

        private bool itStartAtZero(string number)
        {
            return expressionText == "0" && number == "0";
        }

        private bool isNumberTheLastCharacter(char lastCharacter)
        {
            if (lastCharacter >= '0' && lastCharacter <= '9')
                return true;
            return false;

        }
        private static bool isRightBracket(char bracket)
        {
            return bracket == ')';
        }
        private static bool isLeftBracket(char bracket)
        {
            return bracket == '(';
        }

        private static bool isTimesOrDivided(string operatorButtonText)
        {
            return operatorButtonText == "*" || operatorButtonText == "/";
        }

        private static bool isPlusOrMinus(char lastCharacter)
        {
            return lastCharacter == '+' || lastCharacter == '-';
        }

        private static bool isOperator(char lastCharacter)
        {
            return lastCharacter == '+' || lastCharacter == '-' || lastCharacter == '*' || lastCharacter == '/';
        }
    }
}
