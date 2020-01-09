using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_.Models
{
    class DivisionOperator : Oper
    {
        public DivisionOperator()
        {
            Symbol = '/';
            precedence = 20;
            parameterCount = 2;
        }
    }
}
