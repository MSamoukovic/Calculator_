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
                    if (operandStack.Count < token.ParamCount)
                    {
                        throw new Exception("user has not input sufficient values  in  the expression");
                    }
                    List<Token> operands = new List<Token>();
                    for (int i = 0; i < token.ParamCount; i++)
                    {
                        operands.Add(operandStack.Pop());
                    }
                    operandStack.Push(EvaluateOperator(token, operands));
                }
                index++;
            }
            if (operandStack.Count == 1)
            {
                 result =operandStack.Pop().TokenValue;
            }
            else
            {
                throw new Exception("ddd");
            }
        } 
        public double getAnswer()
        {
            return result;
        }
         
        private Token EvaluateOperator(Token oper, List<Token> operands)
        {   
            switch (oper.Symbol.ToString())
            {
                case "+":                 
                      operands[0].TokenValue += operands[1].TokenValue;              
                    break;
                case "-":
                    operands[0].TokenValue = operands[1].TokenValue - operands[0].TokenValue;
                    break;
                case "*":
                    operands[0].TokenValue *= operands[1].TokenValue;
                    break;
                case "/":
                    operands[0].TokenValue = operands[1].TokenValue / operands[0].TokenValue;
                    break;
                case "_":
                    operands[0].TokenValue = -operands[0].TokenValue;
                    break;

                default:
                    throw new Exception("unknown operator");
            }

            return operands[0];
        }
    }

    }

