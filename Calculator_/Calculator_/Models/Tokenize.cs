using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_.Models
{
    class Tokenize
    {
        List<Token> tokens = new List<Token>();

        public Tokenize(string input)
        {
            string[] splitString = SplitForTokenize(input);
            foreach (string s in splitString)
            {
                Token token = Token.stringToToken(s); //citamo svaki token
                if (s == "-") 
                {
                    if (isTokenListEmpty() || isPenultimateTokenInListLeftBrace() || isPenultimateTokenInInListOperator())
                    {
                        token.setValues('_', Token.Associativity.Right, 1, 30);                     
                    }
                }
                tokens.Add(token);
            }
        }

        private bool isPenultimateTokenInInListOperator()
        {
            return tokens[tokens.Count - 1].GetTokenType == Token.TokenType.Operator;
        }

        private bool isPenultimateTokenInListLeftBrace()
        {
            return tokens[tokens.Count - 1].GetTokenType == Token.TokenType.LeftBrace;
        }

        private bool isTokenListEmpty()
        {
            return tokens.Count == 0;
        }

        public Token[] getArrayOfTokens()
        {
            return tokens.ToArray();
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
    }
}
