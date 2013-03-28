namespace NCldr
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;

    /// <summary>
    /// NCldrDataSource loads/saves the raw NCLDR data from an NCldr data file
    /// </summary>
    /// <remarks>Set the NCldrDataSource.NCldrDataPath property before calling NCldrDataSource.Load</remarks>
    public class NCldrDataSource
    {
        /// <summary>
        /// Gets or sets the path to the NCldr data file (includes the folder name only with no filename)
        /// </summary>
        public static string NCldrDataPath { get; set; }

        /// <summary>
        /// Gets the data file name including the path
        /// </summary>
        public static string NCldrDataFilename
        {
            get
            {
                return Path.Combine(NCldrDataPath, "NCldr.dat");
            }
        }

        /// <summary>
        /// Exists returns true if the NCldr data file exists
        /// </summary>
        /// <returns>True if the NCldr data file exists</returns>
        public static bool Exists()
        {
            return File.Exists(NCldrDataFilename);
        }

        /// <summary>
        /// Loads loads the raw data from the NCldr data file and returns an NCldrData object
        /// </summary>
        /// <returns>An INCldrData object from the NCldr data file</returns>
        public static INCldrData Load()
        {
            if (!Exists())
            {
                return null;
            }

            NCldrData ncldrData = null;
            FileStream fileStream = new FileStream(NCldrDataFilename, FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                ncldrData = (NCldrData)formatter.Deserialize(fileStream);
            }
            catch (SerializationException exception)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + exception.Message);
                throw;
            }
            finally
            {
                fileStream.Close();
            }

            return ncldrData;
        }

        /// <summary>
        /// Save saves the NCldrData object to the NCldr data file
        /// </summary>
        /// <param name="ncldrData">The INCldrData object to save</param>
        public static void Save(INCldrData ncldrData)
        {
            FileStream fileStream = new FileStream(NCldrDataFilename, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fileStream, ncldrData);
            }
            finally
            {
                fileStream.Close();
            }
        }
    }
}
