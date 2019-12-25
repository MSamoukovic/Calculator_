﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_.Models
{
    class DivideExpr : Expr
    {
        public override double getResult(Operand firstOperand, Operand secondOperand)
        {
            double result = firstOperand.getNumber() / secondOperand.getNumber();
            return result;
        }
    }
}