using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_.Models
{
     class Token
    {
        public enum TokenType 
        { 
            Number,
            Operator,
            LeftBrace, 
            RightBrace,
            Nothing
        }
        TokenType tokenType = TokenType.Nothing;

        public enum Associativity
        {
            Left,
            Right
        }
        Associativity assoc = Associativity.Left;

        double tokenValue = 0;
        char symbol = ' ';
        int precedence;
        int parameterCount;
        public Token()
        {
                
        }
        public TokenType GetTokenType
        {
            get
            {
                return tokenType;
            }
        }

        public bool isNumber()
        {
            if (tokenType == TokenType.Number)
                return true;
            return false;
        }
        public bool isOperator()
        {
            if (tokenType == TokenType.Operator)
                return true;
            return false;
        }
        public bool isLeftBrace()
        {
            if (tokenType == TokenType.LeftBrace)
                return true;
            return false;
        }

        public bool isRightBrace()
        {
            if (tokenType == TokenType.RightBrace)
                return true;
            return false;
        }
        public char Symbol
        {
            get
            {
                return symbol;
            }
        }
        public int ParamCount
        {
            get
            {
                return parameterCount;
            }
        }
        public int Precedence
        {
            get
            {
                return precedence;
            }
        }
        public Associativity Assoc
        {
            get
            {
                return assoc;
            }
        }
        public double TokenValue
        {
            get
            {
                return tokenValue;
            }
            set
            {
                tokenValue = value;
            }
        }

        public void setValues(char symbol, Associativity assoc, int paramCount, int prec)
        {
            this.symbol = symbol;
            this.assoc = assoc;
            this.precedence = prec;
            this.parameterCount = paramCount;
        }
        public static Token stringToToken(string str) // ovjd eposaljemo citav input i izracunamo
        {
            Token token = new Token();
            if (double.TryParse(str, out token.tokenValue))
            {
                token.tokenType = TokenType.Number;
            }
            else if (str == "(")
            {
                token.tokenType = TokenType.LeftBrace;
            }
            else if (str == ")")
            {
                token.tokenType = TokenType.RightBrace;
            }
            else
            {
                switch (str)
                {
                    case "+":
                        token.tokenType = TokenType.Operator;
                        token.symbol = '+';
                        token.assoc = Associativity.Left;
                        token.precedence = 10;
                        token.parameterCount = 2;
                        break;
                    case "-":
                        token.tokenType = TokenType.Operator;
                        token.symbol = '-';
                        token.assoc = Associativity.Left;
                        token.precedence = 10;
                        token.parameterCount = 2;
                        break;
                    case "*":
                        token.tokenType = TokenType.Operator;
                        token.symbol = '*';
                        token.assoc = Associativity.Left;
                        token.precedence = 20;
                        token.parameterCount = 2;
                        break;
                    case "/":
                        token.tokenType = TokenType.Operator;
                        token.symbol = '/';
                        token.assoc = Associativity.Left;
                        token.precedence = 20;
                        token.parameterCount = 2;
                        break;
                    default:
                        token.tokenType = TokenType.Nothing;
                        break;
                }
            }
            return token;
        }
    }
}
