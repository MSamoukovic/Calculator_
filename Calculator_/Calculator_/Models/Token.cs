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
            LeftBracket, 
            RightBracket,
            Nothing
        }
        public Token()
        {

        }
        TokenType tokenType = TokenType.Operator; // jer ako je nothing, uzme da je Oper Nothing

        public enum Associativity
        {
            Left,
            Right
        }

        Associativity assoc = Associativity.Left;

        double tokenValue = 0;
       // char symbol;
        //int precedence;
        //int parameterCount;

        public char Symbol { get; set; }
        public int Precedence { get; set; }
        public int ParameterCount { get; set; }

        private Associativity Assoc
        {
            get
            {
                return getAssociativity();
            }
            set
            {
                assoc = value;
            }
        }
        public double TokenValue
        {
            get
            {
                return getTokenValue();
            }
            set
            {
                tokenValue = value;
            }
        }

        public TokenType getTokenType()
        {
            return tokenType;
        }
       
        public Associativity getAssociativity()
        {
            return assoc;
        }
        public int getPrecedence()
        {
            return Precedence;
        }

        public int getParameterCount()
        {
            return ParameterCount;
        }

        public double getTokenValue()
        {
            return tokenValue;
        }

        public  bool isNumber()
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
            if (tokenType == TokenType.LeftBracket)
                return true;
            return false;
        }

        public bool isRightBrace()
        {
            if (tokenType == TokenType.RightBracket)
                return true;
            return false;
        }

        public void setValues(char symbol, Associativity assoc, int parameterCount, int precedence)
        {
            this.Symbol = symbol;
            this.assoc = assoc;
            this.Precedence = precedence;
            this.ParameterCount = parameterCount;
        }

        public static Token stringToToken(string str)
        {
            Token token = new Token();
            if (double.TryParse(str, out token.tokenValue))
                token.tokenType = TokenType.Number;

            else if (str == "(")
                token.tokenType = TokenType.LeftBracket;

            else if (str == ")")
                token.tokenType = TokenType.RightBracket;

            else
                token = OperatorFactory.getInstance(str);

            return token;
        }
    }
}
