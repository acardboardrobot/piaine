﻿using System;
using System.Collections.Generic;
using System.Text;

namespace piaine
{
    public class PageConsumer
    {
        public List<Variable> variablesInPage;
        bool body = false;

        public PageConsumer(List<string> inputLines)
        {
            variablesInPage = new List<Variable>();
            int currentLine = 0;

            foreach (string s in inputLines)
            {
                if (s.Length > 0)
                {
                    if (s[0] == '-')
                    {
                        string[] splitString = s.Split(':');
                        Variable v = new Variable(splitString[0], splitString[1]);
                        v.name = v.name.Trim();
                        v.name = v.name.Remove(0, 1);
                        v.literal = v.literal.Trim();
                        variablesInPage.Add(v);
                        if (v.name == "body")
                        {
                            for (int i = currentLine + 1; i < inputLines.Count; i++)
                            {
                                v.literal += "\n";
                                v.literal += inputLines[i];
                            }
                            break;
                        }
                        currentLine++;
                    }
                }
            }

            foreach (Variable v in variablesInPage)
            {
                if (v.name == "body")
                {
                    //use markdown parser to output html that will be saved as the literal.
                    textParser textParser = new textParser();
                    v.literal = textParser.parseString(v.literal);
                }
            }
        }

        public string getPageTitle()
        {
            foreach (Variable v in variablesInPage)
            {
                if (v.name == "title")
                {
                    return v.literal;
                }
            }

            return null;
        }

        public DateTime getPageDate()
        {
            foreach (Variable v in variablesInPage)
            {
                if (v.name == "date")
                {
                    DateTime returnDate = DateTime.Parse(v.literal);
                    return returnDate;
                }
            }

            return DateTime.Today;
        }
    }
}
