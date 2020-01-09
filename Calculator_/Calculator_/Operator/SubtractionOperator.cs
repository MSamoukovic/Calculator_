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
            precedence = 10;
            parameterCount = 2;
        }
    }
}
