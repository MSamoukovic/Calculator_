﻿using System;
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

        TokenType tokenType = TokenType.Nothing;

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
        public int precedence { get; set; }
        public int parameterCount { get; set; }


        public  TokenType getTokenType()
        {
            return tokenType;
        }

        public Associativity Assoc
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
        public Associativity getAssociativity()
        {
            return assoc;
        }
        public int getPrecedence()
        {
            return precedence;
        }

        public int getParameterCount()
        {
            return parameterCount;
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
            this.precedence = precedence;
            this.parameterCount = parameterCount;
        }

        public static Token stringToToken(string str)
        {
            Token token = new Token();
            if (double.TryParse(str, out token.tokenValue))
            {
                token.tokenType = TokenType.Number;
            }
            else if (str == "(")
            {
                token.tokenType = TokenType.LeftBracket;
            }
            else if (str == ")")
            {
                token.tokenType = TokenType.RightBracket;
            }
            else
            {
                token = new Oper();
                ExpressionFactory.getExpression(str);
                //switch (str)
                //{
                //    case "+":
                //        token.tokenType = TokenType.Operator;
                //        token.symbol = '+';
                //        token.assoc = Associativity.Left;
                //        token.precedence = 10;
                //        token.parameterCount = 2;
                //        break;
                //    case "-":
                //        token.tokenType = TokenType.Operator;
                //        token.symbol = '-';
                //        token.assoc = Associativity.Left;
                //        token.precedence = 10;
                //        token.parameterCount = 2;
                //        break;
                //    case "*":
                //        token.tokenType = TokenType.Operator;
                //        token.symbol = '*';
                //        token.assoc = Associativity.Left;
                //        token.precedence = 20;
                //        token.parameterCount = 2;
                //        break;
                //    case "/":
                //        token.tokenType = TokenType.Operator;
                //        token.symbol = '/';
                //        token.assoc = Associativity.Left;
                //        token.precedence = 20;
                //        token.parameterCount = 2;
                //        break;
                //    default:
                //        token.tokenType = TokenType.Nothing;
                //        break;
                //}
            }
            return token;
        }
    }
}
