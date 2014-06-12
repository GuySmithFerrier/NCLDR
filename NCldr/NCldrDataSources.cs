namespace NCldr
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// NCldrDataSources is a collection of NCLDR Data Sources
    /// </summary>
    public class NCldrDataSources
    {
        /// <summary>
        /// Gets or sets a list of Data Sources
        /// </summary>
        public static List<INCldrFileDataSource> DataSources { get; set; }

        /// <summary>
        /// Initializes static members of the NCldrDataSources class
        /// </summary>
        static NCldrDataSources()
        {
            DataSources = new List<INCldrFileDataSource>();
            DataSources.Add(new NCldrBinaryFileDataSource());
            DataSources.Add(new NCldrJsonFileDataSource());
            DataSources.Add(new NCldrBsonFileDataSource());
            DataSources.Add(new NCldrXmlFileDataSource());
        }

        /// <summary>
        /// Discover finds third party INCldrFileDataSources in a given path
        /// </summary>
        /// <param name="path">The path containing assemblies that include INCldrFileDataSources</param>
        public static void Discover(string path = null)
        {
            if (string.IsNullOrEmpty(path))
            {
                path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            }

            if (Directory.Exists(path))
            {
                string[] assemblyFilenames = Directory.GetFiles(path, "NCldr*DataSources.dll");
                foreach (string assemblyFilename in assemblyFilenames)
                {
                    INCldrFileDataSource[] dataSources = GetDataSourcesFromAssembly(assemblyFilename);
                    if (dataSources != null && dataSources.Length > 0)
                    {
                        DataSources.AddRange(dataSources);
                    }
                }
            }
        }

        /// <summary>
        /// GetDataSourcesFromAssembly gets an array of INCldrFileDataSource objects from a given assembly
        /// </summary>
        /// <param name="assemblyFilename">The filename of the assembly</param>
        /// <returns>An array of INCldrFileDataSource objects</returns>
        private static INCldrFileDataSource[] GetDataSourcesFromAssembly(string assemblyFilename)
        {
            Assembly assembly;
            try
            {
                assembly = Assembly.LoadFrom(assemblyFilename);
            }
            catch (FileLoadException)
            {
                return null;
            }

            Type[] ncldrDataSourceTypes = (from t in assembly.GetTypes()
                                           where typeof(INCldrFileDataSource).IsAssignableFrom(t)
                                           select t).ToArray();
            if (ncldrDataSourceTypes == null || ncldrDataSourceTypes.Length == 0)
            {
                return null;
            }

            List<INCldrFileDataSource> dataSources = new List<INCldrFileDataSource>();
            foreach (Type ncldrDataSourceType in ncldrDataSourceTypes)
            {
                INCldrFileDataSource dataSource = (INCldrFileDataSource)Activator.CreateInstance(ncldrDataSourceType);
                dataSources.Add(dataSource);
            }

            return dataSources.ToArray();
        }
    }
}
