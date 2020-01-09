using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_.Models
{
    class CalculateExpression
    {
        Stack<Token> operandStack = new Stack<Token>();
        double result;
        public CalculateExpression(Token[] tokens)
        {
            int index = 0;

            while (index < tokens.Count())
            {
                Token token = tokens[index];
                if (token.isNumber())
                    operandStack.Push(token);
                else
                {
                    if (operandStack.Count < token.getParameterCount())
                    {
                        //throw new Exception("user has not input sufficient values  in  the expression");
                        return;
                    }
                    List<Token> operands = new List<Token>();
                    for (int i = 0; i < token.getParameterCount(); i++)
                    {
                        operands.Add(operandStack.Pop());
                    }
                    operandStack.Push(EvaluateOperator(token, operands));
                }
                index++;
            }
            if (operandStack.Count == 1)
            {
                 result =operandStack.Pop().getTokenValue();
            }
            else
            {
                //throw new Exception("ddd");
                return;
            }
        } 
        public double getAnswer()
        {
            return result;
        }
         
        private Token EvaluateOperator(Token oper, List<Token> operands)
        {   
            switch (oper.Symbol)
            {
                case '+':                 
                      operands[0].TokenValue += operands[1].getTokenValue();              
                    break;
                case '-':
                    operands[0].TokenValue = operands[1].getTokenValue() - operands[0].getTokenValue();
                    break;
                case '*':
                    operands[0].TokenValue *= operands[1].getTokenValue();
                    break;
                case '/':
                    operands[0].TokenValue = operands[1].getTokenValue() / operands[0].getTokenValue();
                    break;
                case '_':
                    operands[0].TokenValue = -operands[0].getTokenValue();
                    break;

                default:
                    throw new Exception("unknown operator");
            }

            return operands[0];
        }
    }
}

