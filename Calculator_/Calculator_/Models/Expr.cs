using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_.Models
{
    abstract class Expr
    {
        public Operand firstNumber { get; set; }
        public Operand secondNumber { get; set; }

        public abstract double getResult(Operand first, Operand second);
    }
}
