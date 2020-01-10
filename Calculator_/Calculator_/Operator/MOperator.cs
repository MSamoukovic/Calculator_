using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_.Models
{
    class MOperator : Oper
    {
        public MOperator()
        {
            Symbol = 'M';
            Precedence = 40;
            ParameterCount = 2;
        }
        public override Token getResult(Token firstOperator, Token secondOperator)
        {
            Token token = new Token();
            token.TokenValue = firstOperator.getTokenValue() * secondOperator.getTokenValue() + secondOperator.getTokenValue();
            return token;
        }
    }
}
