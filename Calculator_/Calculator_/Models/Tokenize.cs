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
                Token token = Token.stringToToken(s);
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

        public Token[] getArrayOfTokens()
        {
            return tokens.ToArray();
        }

        private string[] SplitForTokenize(string input)
        {
            input = input.Replace("*", " * ");
            input = input.Replace("/", " / ");
            input = input.Replace("+", " + ");
            input = input.Replace("-", " - ");
            input = input.Replace("(", " ( ");
            input = input.Replace(")", " ) ");
            input = input.Trim();
            while (input.Contains("  "))
            {
                input = input.Replace("  ", " ");
            }
            return input.Split(' ');
        }

        private bool isPenultimateTokenInInListOperator()
        {
            return tokens[tokens.Count - 1].getTokenType() == Token.TokenType.Operator;
        }

        private bool isPenultimateTokenInListLeftBrace()
        {
            return tokens[tokens.Count - 1].getTokenType() == Token.TokenType.LeftBracket;
        }

        private bool isTokenListEmpty()
        {
            return tokens.Count == 0;
        }
    }
}
