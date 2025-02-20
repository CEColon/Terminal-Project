using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TerminalTest
{
    internal class CmdResult
    {
        private bool success;
        private string message;
        public CmdResult(bool success, string message) 
        {
            this.success = success;
            this.message = message;
        }

        public bool Success { get { return success; } }
        public string Message { get { return message; } }
        public bool HasMessage { get { return message != null; } }
    }
}
