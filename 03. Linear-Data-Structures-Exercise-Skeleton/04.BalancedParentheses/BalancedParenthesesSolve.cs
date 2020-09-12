namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        private Stack<char> stack = new Stack<char>();


        public bool AreBalanced(string parentheses)
        {

            for (int i = 0; i < parentheses.Length; i++)
            {
                if (parentheses[i] == '(' || parentheses[i] == '{' || parentheses[i] == '[')
                {
                    stack.Push(parentheses[i]);
                }
                else if (parentheses[i] == ')' || parentheses[i] == '}' || parentheses[i] == ']')
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }
                    else if (parentheses[i] == ')')
                    {
                        if (stack.Pop() != '(')
                        {
                            return false;
                        }

                    }
                    else if (parentheses[i] == ']')
                    {
                        if (stack.Pop() != '[')
                        {
                            return false;
                        }


                    }
                    else if (parentheses[i] == '}')
                    {
                        if (stack.Pop() != '{')
                        {
                            return false;
                        }

                    }
                }


            }
            return true;
        }
    }
}
