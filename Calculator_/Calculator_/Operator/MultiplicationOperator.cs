﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_.Models
{
    class MultiplicationOperator : Oper
    {
        public MultiplicationOperator()
        {
            Symbol = '*';
            Precedence = 20;
            ParameterCount = 2;
        }

        public override Token getResult(Token firstOperator, Token secondOperator)
        {
            Token token = new Token();
            token.TokenValue = firstOperator.getTokenValue() * secondOperator.getTokenValue();
            return token;
        }
    }
}
