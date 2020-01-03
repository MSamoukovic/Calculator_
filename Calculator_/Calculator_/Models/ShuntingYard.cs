using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Calculator_.Models.Token;

namespace Calculator_.Models
{
     class ShuntingYard
    {
        Queue<Token> outputQueue = new Queue<Token>();
        Stack<Token> operatorStack = new Stack<Token>();

        public ShuntingYard(Token[] tokens)
        {
            int index = 0;
            while (index < tokens.Count()) //prodjemo ktoz citavu listu
            {
                Token token = tokens[index];

                switch (token.getTokenType())
                {
                    case TokenType.Number:
                        pushOnQueue(token);
                        break;

                    case TokenType.Operator:
                        seePriorityAndPushOnStackOrOnQueue(token);
                        break;

                    case TokenType.LeftBrace:
                        pushOnStack(token);
                        break;

                    case TokenType.RightBrace:
                        popFromStackAllTokensAndStopWhenLeftBraceAppeard();
                        break;
                    default:
                        break;
                }
                index++;
            }
            popAllTokensFromStackAndPushOnQueue();
        }
        public Token[] getArray()
        {
            return outputQueue.ToArray();
        }

        private void popAllTokensFromStackAndPushOnQueue()
        {
            while (!isStackEmpty())
            {
                if (isFirstTokenOnStackLeftBrace() || isFirstTokenOnStackRightBrace())
                {
                  //  throw new Exception("Mismatched parentheses");
                    return;
                }
                popFromStackAndPushOnQueue();
            }
        }

        private void popFromStackAllTokensAndStopWhenLeftBraceAppeard()
        {
            while (!isFirstTokenOnStackLeftBrace())
            {
                popFromStackAndPushOnQueue();

                if (isStackEmpty())
                {
                    throw new Exception("Mismatched parentheses");
                }
            }
            popFromStack();
        }

        private void seePriorityAndPushOnStackOrOnQueue(Token token)
        {
            while (!isStackEmpty())
            {
                Token firstTokenInStack = getFirstTokenFromStack();
                if (!isFirstTokenOnStackOperator(firstTokenInStack))
                    break;
                else if ((isTokenAssociativityLeft(token) && areTokensOfTheSamePriority(token, firstTokenInStack)) || (isTokenOfLesserPriorityThanSecond(token, firstTokenInStack)))
                {
                    popFromStackAndPushOnQueue();
                }
                else
                    break;
            }
            pushOnStack(token);
        }

        private Token getFirstTokenFromStack()
        {
            return operatorStack.Peek();
        }

        private void pushOnQueue(Token token)
        {
            outputQueue.Enqueue(token);
        }

        private Token popFromStack()
        {
            return operatorStack.Pop();
        }

        private void pushOnStack(Token token)
        {
            operatorStack.Push(token);
        }

        private bool isStackEmpty()
        {
            return operatorStack.Count == 0;
        }

        private void popFromStackAndPushOnQueue()
        {
            outputQueue.Enqueue(operatorStack.Pop());
        }

        private static bool isTokenOfLesserPriorityThanSecond(Token token, Token firstTokenInStack)
        {
            return token.getPrecedence() < firstTokenInStack.getPrecedence();
        }

        private static bool areTokensOfTheSamePriority(Token token, Token firstTokenInStack)
        {
            return token.getPrecedence() == firstTokenInStack.getPrecedence();
        }

        private static bool isTokenAssociativityLeft(Token token)
        {
            return token.Assoc == Token.Associativity.Left;
        }

        private static bool isFirstTokenOnStackOperator(Token firstTokenInStack)
        {
            return firstTokenInStack.getTokenType() == Token.TokenType.Operator;
        }
     
        private  bool isFirstTokenOnStackRightBrace()
        {
            return operatorStack.Peek().getTokenType() == Token.TokenType.RightBrace;
        }

        private  bool isFirstTokenOnStackLeftBrace()
        {
            return operatorStack.Peek().getTokenType() == Token.TokenType.LeftBrace;
        }
    }
}
