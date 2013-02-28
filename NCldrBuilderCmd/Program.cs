using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCldr.Builder;

namespace NCldrBuilderCmd
{
    class Program
    {
        private static string previousSection;

        static void Main(string[] args)
        {
            Console.WriteLine("NCLDR Builder");
            Console.WriteLine("NCLDR Builder builds the NCLDR data file from CLDR data");
            Console.WriteLine(String.Empty);

            CommandArgumentsReader reader = new CommandArgumentsReader(args);
            string cldrPath = reader.GetArgumentValue("-CLDRPath");
            string ncldrPath = reader.GetArgumentValue("-NCLDRPath");
            if (String.IsNullOrEmpty(cldrPath) || String.IsNullOrEmpty(ncldrPath))
            {
                Console.WriteLine("Syntax:");
                Console.WriteLine("NCldrBuilderCmd -CLDRPath:<CLDRPath> -NCLDRPath:<NCLDRPath>");
                Console.WriteLine("where:");
                Console.WriteLine(@"<CLDRPath> is the path to the CLDR root folder e.g. C:\CLDR\Release22.1");
                Console.WriteLine(@"<NCLDRPath> is the path to the NCLDR output folder e.g. C:\Projects\NCldr\Source\NCldr\NCldrData");
            }
            else if (!Directory.Exists(cldrPath))
            {
                Console.WriteLine(String.Format("CLDRPath '{0}' does not exist", cldrPath));
            }
            else if (!Directory.Exists(ncldrPath))
            {
                Console.WriteLine(String.Format("NCLDRPath '{0}' does not exist", ncldrPath));
            }
            else
            {
                Console.WriteLine(String.Empty);
                NCldrBuilder.Build(cldrPath, ncldrPath, new NCldrBuilderProgressEventHandler(Progress));
                Console.WriteLine(String.Empty);
                Console.WriteLine("Done.");
            }
        }

        private static void Progress(object sender, NCldrBuilderProgressEventArgs args)
        {
            if (args.Section != previousSection)
            {
                Console.WriteLine(String.Empty);
                if (args.Section.StartsWith("Adding "))
                {
                    Console.WriteLine(args.Section + "s");
                }
                else
                {
                    Console.WriteLine(args.Section);
                }
            }

            Console.Write(".");
            previousSection = args.Section;
        }
    }
}
