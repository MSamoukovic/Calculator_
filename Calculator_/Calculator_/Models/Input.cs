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
                expressionText = "0" + number;
            else if (itStartAtZero(number)) { }
            else if (!isExpressionEmpty() && isRightBracket(getLastCharacter()))
                addToExpression("*"+number);
            else
                addToExpression(number);
            return expressionText;
        }

        public string setResult()
        {
            int leftBraces = countLeftBraces();
            int rightBraces = countRightBraces();

            if (!isExpressionEmpty())
            {
                char lastCharacter = getLastCharacter();
                if (!isNumberTheLastCharacter(lastCharacter) && !isRightBracket(lastCharacter))
                   addToExpression("0");
                if (leftBraces > rightBraces)
                {
                    for (int i = 0; i < leftBraces - rightBraces; i++)
                        addToExpression(")");
                }
                if (expressionText.Contains("(+"))
                    expressionText = expressionText.Replace("(+", "(0+");
            }
            return expressionText;
        }

        public string setOperator(string op)
        {
            if (isExpressionEmpty())
            addToExpression("0"+op);
            else
            {
                char lastCharacter = getLastCharacter();
                if (isOperator(lastCharacter))
                {
                    char penultimateCharacter = getPenultimateCharacter();
                    if (isPlusOrMinus(lastCharacter) && isLeftBracket(penultimateCharacter) && isTimesOrDivided(op))
                        return expressionText;
                    else
                    {
                        removeLastCharacter();
                        addToExpression(op);
                    }
                }
                else if (isLeftBracket(lastCharacter) && isTimesOrDivided(op))
                    return expressionText;
                else
                    addToExpression(op);
            }
            return expressionText;
        }
        public string checkSign(double tokensLength, string updatedInput)
        {
            string newInput;
                int inputLength = updatedInput.Length;
                if (tokensLength == 1)
                    newInput = addADifferentSignBeforeALastumber(updatedInput);

                else if (getPenultimateTokenType(updatedInput) == "LeftBracket" && isLastTokenMinus(updatedInput))
                    newInput = updatedInput.Remove(inputLength - 2, 2);

                else if (getLastTokenType(updatedInput) == "Number" && isPenultimateTokenPlus(updatedInput))
                    newInput = addADifferentSignBeforeALastumber(updatedInput);

                else if (getLastTokenType(updatedInput) == "Number" && getTheThirdFromTheEndTokenType(updatedInput) == "LeftBracket")
                    newInput = updatedInput.Remove(inputLength - 2 - getLastTokenValue(updatedInput).Length, 2);

                else if (getLastTokenType(updatedInput) == "Number")
                    newInput = addADifferentSignBeforeALastumber(updatedInput);
                else
                {
                    updatedInput += "(-";
                    newInput = updatedInput;
                }
            return newInput;
        }
        private string addADifferentSignBeforeALastumber(string updatedInput)
        {
            updatedInput = updatedInput.Insert(updatedInput.Length - getLastTokenValue(updatedInput).Length, "(-");
            return updatedInput;
        }

        private bool isPenultimateTokenPlus(string updatedInput)
        {
            return updatedInput[updatedInput.Length - 2] == '+';
        }

        private bool isLastTokenMinus(string updatedInput)
        {
            return updatedInput[updatedInput.Length - 1] == '-';
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

        private string getPenultimateTokenType(string updatedInput)
        {
            Tokenize inputTokenize = new Tokenize(updatedInput);
            Token[] tokens = inputTokenize.getArrayOfTokens();
            Token penultmateToken = tokens[tokens.Length - 2];
            return penultmateToken.getTokenType().ToString();
        }

        private string getTheThirdFromTheEndTokenType(string updatedInput)
        {
            Tokenize inputTokenize = new Tokenize(updatedInput);
            Token[] tokens = inputTokenize.getArrayOfTokens();
            Token theThird = tokens[tokens.Length - 3];
            return theThird.getTokenType().ToString();
        }







        public string setBracket(char bracket)
        {
            if (!isExpressionEmpty())
            {
                char lastCharacter = getLastCharacter();
                if(isLeftBracket(bracket))
                {
                    if (isNumberTheLastCharacter(lastCharacter) || isRightBracket(lastCharacter))
                        addToExpression("*");
                    addToExpression("(");
                }
                else if(isRightBracket(bracket))
                {
                    if (isLeftBracket(lastCharacter))
                        removeLastCharacter();
                    else if (countLeftBraces() >= countRightBraces() && !isNumberTheLastCharacter(lastCharacter) && !isRightBracket(lastCharacter)) { }
                    else if ( countLeftBraces() == 0) { }
                    else if(countLeftBraces() > countRightBraces())
                        addToExpression(")");
                }
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
        private char getPenultimateCharacter()
        {
            return char.Parse(expressionText.Substring(expressionText.Length - 2, 1));
        }
    }
}
