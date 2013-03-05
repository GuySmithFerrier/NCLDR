using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using NCldr.Builder;

namespace NCldrBuilderCmd
{
    public enum DisplayMode { None, Verbose, Diagnostics }

    class Program
    {
        private static string previousSection;

        private static long sectionTotalObjectSizes;

        private static DisplayMode displayMode;

        static void Main(string[] args)
        {
            Console.WriteLine("NCLDR Builder");
            Console.WriteLine("NCLDR Builder builds the NCLDR data file from CLDR data");
            Console.WriteLine(String.Empty);

            CommandArgumentsReader reader = new CommandArgumentsReader(args);
            string cldrPath = reader.GetArgumentValue("-CLDRPath");
            string ncldrPath = reader.GetArgumentValue("-NCLDRPath");
            displayMode = GetDisplayMode(reader.GetArgumentValue("-DisplayMode"));
            if (String.IsNullOrEmpty(cldrPath) || String.IsNullOrEmpty(ncldrPath))
            {
                Console.WriteLine("Syntax:");
                Console.WriteLine("NCldrBuilderCmd -CLDRPath:<CLDRPath> -NCLDRPath:<NCLDRPath> [-DisplayMode:Quiet|Verbose|Diagnostics]");
                Console.WriteLine("where:");
                Console.WriteLine(@"<CLDRPath> is the path to the CLDR root folder e.g. C:\CLDR\Release22.1");
                Console.WriteLine(@"<NCLDRPath> is the path to the NCLDR output folder e.g. C:\Projects\NCldr\Source\NCldr\NCldrData");
                Console.WriteLine(@"<DisplayMode> is either Quiet, Verbose or Diagnostics indicating the volume of progress information displayed");
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

        private static DisplayMode GetDisplayMode(string displayMode)
        {
            if (String.IsNullOrEmpty(displayMode))
            {
                return DisplayMode.None;
            }
            else if (String.Compare(displayMode, "Verbose", true, CultureInfo.InvariantCulture) == 0)
            {
                return DisplayMode.Verbose;
            }
            else if (String.Compare(displayMode, "Diagnostics", true, CultureInfo.InvariantCulture) == 0)
            {
                return DisplayMode.Diagnostics;
            }

            return DisplayMode.None;
        }

        private static void Progress(object sender, NCldrBuilderProgressEventArgs args)
        {
            if (args.ProgressEventType == ProgressEventType.Added)
            {
                if (displayMode == DisplayMode.Diagnostics)
                {
                    long objectSize = GetObjectSize(args.AddedObject);
                    Console.WriteLine(String.Format(": {0} bytes", objectSize));
                    sectionTotalObjectSizes += objectSize;
                }
            }
            else
            {
                if (args.Section != previousSection)
                {
                    if (displayMode == DisplayMode.Diagnostics && previousSection != null)
                    {
                        Console.WriteLine(string.Format("Total size: {0} bytes", sectionTotalObjectSizes));
                    }

                    Console.WriteLine(String.Empty);
                    if (args.ProgressEventType == ProgressEventType.Adding)
                    {
                        Console.WriteLine(args.Section + "s");
                    }
                    else
                    {
                        Console.WriteLine(args.Section);
                    }

                    sectionTotalObjectSizes = 0;
                }

                if (displayMode == DisplayMode.Diagnostics)
                {
                    Console.Write("    " + args.Item);
                }
                else if (displayMode == DisplayMode.Verbose)
                {
                    Console.WriteLine("    " + args.Item);
                }
                else
                {
                    Console.Write(".");
                }

                previousSection = args.Section;
            }
        }

        private static long GetObjectSize(object o)
        {
            long size = 0;
            using (Stream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, o);
                size = stream.Length;
            }

            return size;
        }
    }
}
