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
        public string setText(string operatorButtonText)
        {
            if (String.IsNullOrEmpty(expressionText))
                expressionText += "0" + operatorButtonText;
            else
            {
                string lastCharacter = expressionText.Substring(expressionText.Length - 1);
                if (lastCharacter == "+" || lastCharacter == "-" || lastCharacter == "*" || lastCharacter == "/")
                {
                    string penultimateCharacter = expressionText.Substring(expressionText.Length - 2, 1);
                    if ((lastCharacter == "+" || lastCharacter == "-") && penultimateCharacter == "(" && (operatorButtonText == "*" || operatorButtonText == "/"))
                         return expressionText ;

                        expressionText = expressionText.Remove(expressionText.Length - 1, 1);
                        expressionText += operatorButtonText;
                    
                }
                else if (lastCharacter == "(" && (operatorButtonText == "*" || operatorButtonText == "/"))
                     return expressionText;
                else
                    expressionText += operatorButtonText;
            }
            return expressionText;
        }

        public string setBraces(string braceButtonText)
        {
            if (!String.IsNullOrEmpty(expressionText))
            {
                string lastCharacter = expressionText.Substring(expressionText.Length - 1);

                if (lastCharacter == isNumberTheLastCharacter(char.Parse(lastCharacter)) && braceButtonText == "(") // 3( ----> 3*(
                    expressionText += "*(";

                else if (lastCharacter == "(" && braceButtonText == ")") //ako imamo ()
                    expressionText = expressionText.Remove(expressionText.Length - 1, 1);
                else if (lastCharacter == ")" && countLeftBraces() > countRightBraces())
                    expressionText += ")";
                else if (braceButtonText == ")" && countLeftBraces() >= countRightBraces() && lastCharacter != isNumberTheLastCharacter(char.Parse(lastCharacter))) { }

                else if (braceButtonText == ")" && countLeftBraces() == 0) { }

                else if (lastCharacter != isNumberTheLastCharacter(char.Parse(lastCharacter)) && braceButtonText == "(")
                    expressionText += "(";
                else
                    expressionText += braceButtonText;

                return expressionText;
            }
            else if (String.IsNullOrEmpty(expressionText) && braceButtonText == ")")
                return expressionText=String.Empty;
            else
            return expressionText += braceButtonText;
        }

        public string setNumber(string numberButtonText)
        {
            expressionText += numberButtonText;
            return expressionText;
        }

        public string updateExpressionText(string updateString)
        {
            return expressionText = updateString;
        }

        public string setResult()
        {
            int leftBraces = countLeftBraces();
            int rightBraces = countRightBraces();

            if (!String.IsNullOrEmpty(expressionText))
            {
                string lastCharacter = expressionText.Substring(expressionText.Length - 1);
                if (lastCharacter != isNumberTheLastCharacter(char.Parse(lastCharacter)) && lastCharacter!=")")
                     expressionText += "0";
                 if (leftBraces > rightBraces)
                {
                    for (int i = 0; i < leftBraces - rightBraces; i++)
                         expressionText += ")";
                }
                 if(expressionText.Contains("(+"))
                    expressionText = expressionText.Replace("(+","(0+"); 
            }
            return expressionText;
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
            return countLeftBraces++; 
        }

        public int countRightBraces( )
        {
            int countRightBraces = 0;
            foreach (char c in expressionText)
            {
                if (c == ')')
                    countRightBraces++;
            }
            return countRightBraces++;
        }

        private string isNumberTheLastCharacter(char lastCharacter)
        {
            if (lastCharacter >= '0' && lastCharacter <= '9')
                return lastCharacter.ToString();          
            return "";

        }
    }
}
