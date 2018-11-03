﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.BalancedParenthesis
{
    class BalancedParenthesis
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToArray();

            Stack<char> chars = new Stack<char>();

            bool isBalanced = true;

            foreach (var item in input)
            {
                if (item == '(' || item == '[' || item == '{')
                {
                    chars.Push(item);
                }
                else if (item == ')')
                {
                    if (chars.Count == 0)
                    {
                        isBalanced = false;
                        break;
                    }

                    if (chars.Peek() == '(')
                    {
                        if (chars.Count > 0)
                        {
                            chars.Pop();
                        }
                        else
                        {
                            isBalanced = false;
                            break;
                        }
                    }
                    else
                    {
                        isBalanced = false;
                        break;
                    }
                }
                else if(item == ']')
                {
                    if (chars.Count ==  0)
                    {
                        isBalanced = false;
                        break;
                    }

                    if (chars.Peek() == '[')
                    {
                        if (chars.Count > 0)
                        {
                            chars.Pop();
                        }
                        else
                        {
                            isBalanced = false;
                            break;
                        }
                    }
                    else
                    {
                        isBalanced = false;
                        break;
                    }
                }
                else if (item == '}')
                {
                    if (chars.Count == 0)
                    {
                        isBalanced = false;
                        break;
                    }

                    if (chars.Peek() == '{')
                    {
                        if (chars.Count > 0)
                        {
                            chars.Pop();
                        }
                        else
                        {
                            isBalanced = false;
                            break;
                        }
                    }
                    else
                    {
                        isBalanced = false;
                        break;
                    }
                }
            }

            if (isBalanced && chars.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}