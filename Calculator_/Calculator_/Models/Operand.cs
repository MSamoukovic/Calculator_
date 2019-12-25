using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_.Models
{
    class Operand
    {
        public double Number = 0.0;

        public Operand(double number)
        {
            Number = number;
        }
        public Operand(string numberText)
        {
            if (String.IsNullOrEmpty(numberText))
            {
                Number = 0.0;
            }
            else
            {
                Number = Double.Parse(numberText);
            }
        }
        public double getNumber()
        {
            return Number;
        }
        public void setNumber(Double Number)
        {
            this.Number = Number;
        }
    }
}
