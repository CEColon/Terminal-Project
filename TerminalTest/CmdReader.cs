using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalTest
{
    internal class CmdReader
    {
        public static readonly string[] ValidCommands = ["say", "dircreate", "filecreate"];
        public static CmdResult ReadCommand(string cmd)
        {
            string[] splitArgs = cmd.Split([' ']);
            int argCounter = 0;
            int maxArgs = splitArgs.Length;
            int argSkips = 0;
            List<string> parsedArgs = new List<string>();
            foreach (string s in splitArgs)
            {
                if (argSkips > 0)
                {
                    argSkips--;
                    continue;
                }
                if (s[0] == '"')
                {
                    var builder = new StringBuilder();
                    for (int i = argCounter; i < maxArgs; i++)
                    {
                        builder.Append(splitArgs[i]);
                        if (splitArgs[i][splitArgs[i].Length - 1] == '"')
                        {
                            parsedArgs.Add(builder.ToString());
                            argCounter += i - argCounter;
                            argSkips = i - argCounter;
                            break;
                        }
                        else if (splitArgs[i].Contains('"') && i != argCounter)
                        {
                            return new CmdResult(false, "String Parse Error. Invalid token when parsing String");
                        }
                        if(i == maxArgs - 1)
                        {
                            return new CmdResult(false, "String Parse Error. Missing '\"' at the end of string");
                        }
                    }
                }
                else
                {
                    parsedArgs.Add(s);
                    argCounter++;
                }
            }

            if (Array.Find(ValidCommands, elem => elem.Equals(parsedArgs.ElementAt(0))) == null)
            {
                return new CmdResult(false, "Invalid Command Error. The command you provided is not within the list of valid commands.");
            } 
            else
            {
                switch (parsedArgs.ElementAt(0))
                {
                    case "say":
                        return sayCommand(parsedArgs.GetRange(1, parsedArgs.Count - 1).ToArray());
                    default:
                        return new CmdResult(false, "No Command Behavior Error. The command " + parsedArgs.ElementAt(0) + " does not have any behavior associated with it");

                }
            }
        }

        public static CmdResult sayCommand(string[] args)
        {
            int[] possibleArgCounts = {1};
            if(possibleArgCounts.Contains(args.Length))
            {
                Console.WriteLine(args[0]);
            }
            else
            {
                return new CmdResult(false, "Invalid Argument Error. The number of arguments provided is not valid within the given context. Expected 1, Found " + args.Length);
            }
            return new CmdResult(true, "");
        }

        public static CmdResult directoryCreateCommand(string[] args)
        {
            return new CmdResult(false, "No Command Behavior Error. This command does not have any behavior associated with it");
        }
    }
}
