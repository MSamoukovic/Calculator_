using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_.Models
{
    class Operator
    {
        public string operation;
        public Operator()
        {

        }
        public Operator(string operatorButtonText)
        {
            if (String.IsNullOrEmpty(operatorButtonText))
            {
                operation = "+";
            }
            else
            {
                operation = operatorButtonText;
            }
        }
        public string getOperator()
        {
            return operation;
        }     
    }
}
