using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_.Models
{
    class ExpressionFactory
    {
        public static Oper getExpression(string operation)
        {
            switch (operation)
            {
                case "+":
                    return new AdditionOperator();
                case "-":
                    return new SubtractionOperator();
                case "*":
                    return new MultiplicationOperator();
                default:
                    return new DivisionOperator();
            }
        }
    }
}
