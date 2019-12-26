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
        TokenType tokenType = TokenType.Nothing; //for all tokens
        public enum Associativity
        {
            Left,
            Right
        }
        Associativity assoc = Associativity.Left;
        double val = 0;
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
        public double Val
        {
            get
            {
                return val;
            }
            set
            {
                val = value;
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
            Token t = new Token();
            if (double.TryParse(str, out t.val))
            {
                t.tokenType = TokenType.Number;
            }
            else if (str == "(")
            {
                t.tokenType = TokenType.LeftBrace;
            }
            else if (str == ")")
            {
                t.tokenType = TokenType.RightBrace;
            }
            else
            {
                switch (str)
                {
                    case "+":
                        t.tokenType = TokenType.Operator;
                        t.symbol = '+';
                        t.assoc = Associativity.Left;
                        t.precedence = 10;
                        t.parameterCount = 2;
                        break;
                    case "-":
                        t.tokenType = TokenType.Operator;
                        t.symbol = '-';
                        t.assoc = Associativity.Left;
                        t.precedence = 10;
                        t.parameterCount = 2;
                        break;
                    case "*":
                        t.tokenType = TokenType.Operator;
                        t.symbol = '*';
                        t.assoc = Associativity.Left;
                        t.precedence = 20;
                        t.parameterCount = 2;
                        break;
                    case "/":
                        t.tokenType = TokenType.Operator;
                        t.symbol = '/';
                        t.assoc = Associativity.Left;
                        t.precedence = 20;
                        t.parameterCount = 2;
                        break;
                    default:
                        t.tokenType = TokenType.Nothing;
                        break;
                }
            }
            return t;
        }
    }
}
