using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_.Models
{
   abstract  class Oper : Token
    {
        TokenType tokenType = TokenType.Operator;
        public abstract Token getResult(Token firstOperator, Token secondOperator);
    }
}
