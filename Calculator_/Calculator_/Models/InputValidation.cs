using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_.Models
{
    class InputValidation
    {
        string expressionText;

        public InputValidation()
        {
        }

        public string setNumber(string number, string updatedInput)
        {
            if (number == ".")
            {
                if (String.IsNullOrEmpty(updatedInput))
                    addToExpression("0.");
                else if (getLastTokenType(updatedInput) == "Operator" || getLastTokenType(updatedInput) == "LeftBracket")
                    addToExpression("0.");
                else if (getLastTokenType(updatedInput) == "RightBracket")
                    addToExpression("*0.");
                else if (getLastCharacter() == '.') { }
                else
                {
                    string regexForDecimalNumber = Regex.Match(updatedInput, @"\d(.)\d+$").Value;
                    if (regexForDecimalNumber.Contains(".")) { }
                    else
                        addToExpression(number);
                }
            }
            else
            {
                if (itStartAtZero(number)) { }
                else if (!isExpressionEmpty() && isRightBracket(getLastCharacter()))
                    addToExpression("*" + number);
                else
                    addToExpression(number);
            }
            return expressionText;
        }

        public string setResult()
        {
            int leftBraces = countLeftBrackets(expressionText);
            int rightBraces = countRightBrackets(expressionText);

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

        public string checkSign(Token[] tokens, string updatedInput)
        {
            string newInput;
            int inputLength = updatedInput.Length;

            if (tokens.Length == 1)
                newInput = addADifferentSignBeforeIntLastumber(updatedInput);
            else
            {
                if (isOnlyNegativNumberInExpression(tokens, updatedInput))
                    newInput = updatedInput.Replace('-', '+');
                else if (getLastTokenType(updatedInput) == "Number" && isPenultimateTokenPlus(updatedInput)) // ...+25
                    newInput = addADifferentSignBeforeIntLastumber(updatedInput);
                else if (getPenultimateTokenType(tokens) == "LeftBracket" && getLastCharacter() == '-') // ...(-
                    newInput = updatedInput.Remove(inputLength - 2, 2);

                else if (getLastTokenType(updatedInput) == "Number" && getThirdBeforLastTokenType(tokens) == "LeftBracket"
                    && isPenultimateTokenMinus(updatedInput)) //... (-25

                    newInput = updatedInput.Remove(inputLength - 2 - getLastTokenValue(updatedInput).Length, 2);

                else if (getLastTokenType(updatedInput) == "Number")
                    newInput = addADifferentSignBeforeIntLastumber(updatedInput);
                else if (getLastTokenType(updatedInput) == "RightBracket")
                    newInput = updatedInput + "*(-";
                else
                {
                    updatedInput += "(-";
                    newInput = updatedInput;
                }
            }
            return newInput;
        }

        public string checkSignOfDecimalToken(Token[] tokens, string updatedInput,int lastTokenLength)
        {
            string newInput;
            int inputLength = updatedInput.Length;
            if (tokens.Length == 1)
                newInput = updatedInput.Insert(0, "(-");
            else if (updatedInput[inputLength - lastTokenLength - 1] == '-' && getThirdBeforLastTokenType(tokens) == "LeftBracket")
                 newInput = updatedInput.Remove(inputLength - 2 - lastTokenLength, 2);
            else
                 newInput = updatedInput.Insert(inputLength - lastTokenLength, "(-");
            return newInput;
        }
        public string checkIsExpressionEmpty(string updatedExpression)
        {
            string newInput="";
            if (String.IsNullOrEmpty(updatedExpression))
                newInput = updatedExpression + "(-";
            return newInput;
        }

        public string getPenultimateTokenType(Token[] tokens)
        {
            return tokens[tokens.Length-2].getTokenType().ToString();
        }
        public string getThirdBeforLastTokenType(Token[] tokens)
        {
            return tokens[tokens.Length - 3].getTokenType().ToString();
        }

        public bool isNumberHaveADot(Token[] tokens, string updatedInput, TextBox expressionTextBox)
        {
            for (int i = 0; i < tokens.Length; i++)
            {
                if ((getLastTokenValue(updatedInput).Contains(".") && getLastTokenType(updatedInput) == "Number") || expressionTextBox.Text.EndsWith("."))
                    return true;
            }
            return false;
        }

        public string changeTheSign(string updatedExpression)
        {
            if (String.IsNullOrEmpty(updatedExpression))
                updatedExpression = "(-";
            else
            {
                Tokenize inputTokenize = new Tokenize(updatedExpression);
                Token[] tokens = inputTokenize.getArrayOfTokens();

                string lastDecimalToken = Regex.Match(updatedExpression, @"(\d+\.\d+)$").Value;
                if (!string.IsNullOrEmpty(lastDecimalToken))
                    updatedExpression = checkSignOfDecimalToken(tokens, updatedExpression, lastDecimalToken.Length);
                else
                    updatedExpression = checkSign(tokens, updatedExpression);
            }
            expressionText = updatedExpression;
            return expressionText;

        }

        public void setInputIsEmpty()
        {
            expressionText = "";
        }

        public static int countLeftBrackets(string text)
        {
            int countLeftBraces = 0;
            foreach (char c in text)
            {
                if (c == '(')
                    countLeftBraces++;
            }
            return countLeftBraces;
        }

        public static int countRightBrackets(string text)
        {
            int countRightBraces = 0;
            foreach (char c in text)
            {
                if (c == ')')
                    countRightBraces++;
            }
            return countRightBraces;
        }

        public string setBracket(char bracket)
        {
            if (!isExpressionEmpty())
            {
                char lastCharacter = getLastCharacter();
                if (isLeftBracket(bracket))
                {
                    if (isNumberTheLastCharacter(lastCharacter) || isRightBracket(lastCharacter) || lastCharacter == '.')
                        addToExpression("*");
                    addToExpression("(");
                }
                else if (isRightBracket(bracket))
                {
                    if (isLeftBracket(lastCharacter))
                        removeLastCharacter();
                    else if (countLeftBrackets(expressionText) >= countRightBrackets(expressionText) && !isNumberTheLastCharacter(lastCharacter) && !isRightBracket(lastCharacter)) { }
                    else if (countLeftBrackets(expressionText) == 0) { }
                    else if (countLeftBrackets(expressionText) > countRightBrackets(expressionText))
                        addToExpression(")");
                }
                else
                    addToExpression(bracket.ToString());
                return expressionText;
            }
            else if (isExpressionEmpty() && isRightBracket(bracket))
                return expressionText = String.Empty;
            else
                return expressionText += bracket;
        }

        private static bool isOnlyNegativNumberInExpression(Token[] tokens, string updatedInput)
        {
            return tokens.Length == 2 && updatedInput[0] == '-';
        }

        private string addADifferentSignBeforeIntLastumber(string updatedInput)
        {
            updatedInput = updatedInput.Insert(updatedInput.Length - getLastTokenValue(updatedInput).Length, "(-");
            return updatedInput;
        }

        private bool isPenultimateTokenPlus(string updatedInput)
        {
            return updatedInput[updatedInput.Length - getLastTokenValue(updatedInput).Length - 1] == '+';

        }

        private bool isPenultimateTokenMinus(string updatedInput)
        {
            return updatedInput[updatedInput.Length - getLastTokenValue(updatedInput).Length - 1] == '-';

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
