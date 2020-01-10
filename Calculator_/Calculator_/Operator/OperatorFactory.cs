using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_.Models
{
    class OperatorFactory
    {
        public static Oper getInstance(string operation)
        {
            switch (operation)
            {
                case "+":
                    return new AdditionOperator();
                case "-":
                    return new SubtractionOperator();
                case "*":
                    return new MultiplicationOperator();
                case "/":
                    return new DivisionOperator();
                case "M":
                    return new MOperator();
                default :
                    throw new Exception("Unknown operator");
            }
        }

        public static string[] getOperators()
        {
            string[] operators = new[] { "+", "-", "*", "/", "M" };
            return operators;
        }
    }
}

