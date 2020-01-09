using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_.Models
{
    class Result
    {
        public Result()
        {

        }

        public string getResult(string updatedInput)
        {
            Tokenize inputTokenize = new Tokenize(updatedInput);
            Token[] tokens = inputTokenize.getArrayOfTokens();

            string answer;
            if (tokens.Length == 0 || InputValidation.countLeftBrackets(updatedInput)!=InputValidation.countRightBrackets(updatedInput))
                answer = "";
            else
            {
                ShuntingYard sy = new ShuntingYard(tokens);
                tokens = sy.getArray();
                CalculateExpression calculate = new CalculateExpression(tokens);
                answer = calculate.getAnswer().ToString();
            }
            return answer;
        }

    }

}
