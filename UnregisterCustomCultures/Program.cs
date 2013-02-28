using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnregisterCustomCultures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("UnregisterCustomCultures is a utility to unregister .NET custom cultures");
            if (args.GetLength(0) == 0)
            {
                Console.WriteLine(String.Empty);
                Console.WriteLine("Syntax:");
                Console.WriteLine("       UnregisterCustomCultures <CustomCulturesListFile>");
                Console.WriteLine("where:");
                Console.WriteLine("       <CustomCulturesListFile> is a file containing a comma-delimited list of custom cultures to unregister");
                Console.WriteLine(String.Empty);
            }
            else if (!File.Exists(args[0]))
            {
                Console.WriteLine(String.Empty);
                Console.WriteLine(String.Format("'{0}' file not found", args[0]));
            }
            else
            {
                string allText = File.ReadAllText(args[0]);
                if (String.IsNullOrEmpty(allText))
                {
                    Console.WriteLine(String.Empty);
                    Console.WriteLine(String.Format("'{0}' file does not contain any text", args[0]));
                }
                else
                {
                    string[] customCultures = allText.Split(',');
                    Console.WriteLine(String.Empty);
                    if (Unregister(customCultures))
                    {
                        Console.WriteLine(String.Empty);
                        Console.WriteLine("Done.");
                    }
                }
            }
        }

        private static bool Unregister(string[] customCultures)
        {
            try
            {
                foreach (string customCulture in customCultures)
                {
                    string customCultureName = customCulture.Trim();
                    if (!String.IsNullOrEmpty(customCultureName))
                    {
                        Console.WriteLine(String.Format("Unregistering {0}...", customCultureName));
                        CultureAndRegionInfoBuilder.Unregister(customCultureName);
                    }
                }

                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(String.Empty);
                Console.WriteLine("Failed to unregister custom culture:");
                Console.WriteLine(String.Format("Exception: {0}", exception.Message));
                return false;
            }
        }
    }
}
