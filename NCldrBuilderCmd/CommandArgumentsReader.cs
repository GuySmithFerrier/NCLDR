using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCldrBuilderCmd
{
    public class CommandArgumentsReader
    {
        private string[] args;

        public CommandArgumentsReader(string[] args)
        {
            this.args = args;
        }

        public string GetArgumentValue(string argumentName)
        {
            string argument = (from a in this.args
                               where String.CompareOrdinal(a, argumentName) == 0 || 
                               a.StartsWith(argumentName + ":", StringComparison.InvariantCultureIgnoreCase)
                               select a).FirstOrDefault();

            if (argument == null)
            {
                return null;
            }

            string argumentValue = argument.Substring(argumentName.Length);
            if (argumentValue.StartsWith(":"))
            {
                argumentValue = argumentValue.Substring(1);
            }

            return argumentValue;
        }
    }
}
