using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_.Models
{
    class AdditionOperator : Oper
    {
        public AdditionOperator()
        {
            Symbol = '+';
            precedence = 10;
            parameterCount = 2;
        }
        
    }
}
