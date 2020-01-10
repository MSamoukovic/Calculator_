using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_.Models
{
    class SubtractionOperator : Oper
    {
        public SubtractionOperator()
        {
            Symbol = '-';
            Precedence = 10;
            ParameterCount = 2;
        }

        public override Token getResult(Token firstOperator, Token secondOperator)
        {
            Token token = new Token();
            token.TokenValue = secondOperator.getTokenValue() - firstOperator.getTokenValue();
            return token;
        }
    }
}
