using System;

namespace TerminalTest
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to ZTerminal (just a base name for it but subject to change)");
            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "exit")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                } 
                else if (cmd != null)
                {
                    CmdResult result = CmdReader.ReadCommand(cmd);
                    if(result.HasMessage && result.Success == false)
                    {
                        Console.Error.WriteLine(result.Message);
                    }
                }
            }
            
            
        }
    }
}
