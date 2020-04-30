﻿using System;
using System.Collections.Generic;
using System.Text;

namespace piaine
{
    public class Parser
    {
        List<Token> tokens;
        List<string> outputStrings;

        public Parser(List<Token> desTokens)
        {
            tokens = desTokens;
            outputStrings = new List<string>();
        }

        public List<string> writeVariablesInSource(string source, List<Variable> variables)
        {

            foreach (Token t in tokens)
            {
                if (t.type == TokenType.Unscoped)
                {
                    outputStrings.Add(t.literal.ToString());
                }
                else if (t.type == TokenType.Variable)
                {
                    foreach(Variable v in variables)
                    {
                        if (t.literal.ToString() == v.name)
                        {
                            outputStrings.Add(v.literal);
                            break;
                        }
                    }
                    //outputStrings.Add(t.literal.ToString());
                }
            }

            return outputStrings;
        }

        public List<string> writeVariablesInSource(string source, List<Post> posts)
        {
            outputStrings.Clear();

            foreach (Token t in tokens)
            {
                if (t.type == TokenType.Unscoped)
                {
                    outputStrings.Add(t.literal.ToString());
                }
                else if (t.type == TokenType.Variable)
                {
                    int counter = 0;
                    if (t.literal.ToString() == "post")
                    {
                        foreach (Post p in posts)
                        {
                            String outputLink = "<div>{0}  -  <a href='{1}'>{2}</a></div>";

                            outputLink = outputLink.Replace("{0}", p.date.ToShortDateString());
                            outputLink = outputLink.Replace("{1}", p.path);
                            outputLink = outputLink.Replace("{2}", p.name);

                            counter++;
                            outputStrings.Add(outputLink);
                        }
                    }
                    //outputStrings.Add(t.literal.ToString());
                }
            }

            return outputStrings;
        }


        /// <summary>
        /// Use this to change a variable from the token list to the string of the variable from the source file.
        /// </summary>
        /// <param name="tokenToWrite"></param>
        /// <returns></returns>
        public string writeVariable(Token tokenToWrite)
        {
            return tokenToWrite.literal.ToString();
        }
    }
}
