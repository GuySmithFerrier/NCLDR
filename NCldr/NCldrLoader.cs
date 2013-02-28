namespace NCldr
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;

    /// <summary>
    /// NCldrLoader loads the raw NCLDR data from an NCldr.data file
    /// </summary>
    /// <remarks>Set the NCldrLoader.NCldrDataPath property before calling NCldrLoader.Load</remarks>
    public class NCldrLoader
    {
        /// <summary>
        /// Gets or sets the path to the NCldr.dat file (includes the folder name only with no filename)
        /// </summary>
        public static string NCldrDataPath { get; set; }

        /// <summary>
        /// Loads loads the raw data from the NCldr.dat file and returns an NCldrData object
        /// </summary>
        /// <returns>An INCldrData object from the NCldr.dat file</returns>
        public static INCldrData Load()
        {
            string ncldrDataFilename = Path.Combine(NCldrDataPath, "NCldr.dat");
            if (!File.Exists(ncldrDataFilename))
            {
                return null;
            }

            NCldrData ncldrData = null;
            FileStream fileStream = new FileStream(ncldrDataFilename, FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // Deserialize the hashtable from the file and  
                // assign the reference to the local variable.
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
    }
}
