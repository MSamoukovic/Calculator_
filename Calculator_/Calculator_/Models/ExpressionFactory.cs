using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_.Models
{
    class ExpressionFactory
    {
        public static Expr getExpression(string operation)
        {
            switch (operation)
            {
                case "+":
                    return new AddExpr();
                case "-":
                    return new SubtractExpr();
                case "*":
                    return new MultiplyExpr();
                default:
                    return new DivideExpr();
            }
        }
    }
}
