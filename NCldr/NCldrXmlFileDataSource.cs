namespace NCldr
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    /// <summary>
    /// NCldrXmlFileDataSource loads/saves the raw NCLDR data from an NCldr XML data file
    /// </summary>
    /// <remarks>Set the NCldrXmlFileDataSource.NCldrDataPath property before calling NCldrXmlFileDataSource.Load</remarks>
    public class NCldrXmlFileDataSource : INCldrFileDataSource
    {
        /// <summary>
        /// Gets or sets the path to the NCldr data file (includes the folder name only with no filename)
        /// </summary>
        public string NCldrDataPath { get; set; }

        /// <summary>
        /// Gets the data file name including the path
        /// </summary>
        public string NCldrDataFilename
        {
            get
            {
                return Path.Combine(this.NCldrDataPath, "NCldr.xml");
            }
        }

        /// <summary>
        /// Exists returns true if the NCldr data file exists
        /// </summary>
        /// <returns>True if the NCldr data file exists</returns>
        public bool Exists()
        {
            return File.Exists(this.NCldrDataFilename);
        }

        /// <summary>
        /// Loads loads the raw data from the NCldr data file and returns an NCldrData object
        /// </summary>
        /// <returns>An INCldrData object from the NCldr data file</returns>
        public INCldrData Load()
        {
            if (!this.Exists())
            {
                return null;
            }

            NCldrData ncldrData = null;
            FileStream fileStream = new FileStream(this.NCldrDataFilename, FileMode.Open);
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(NCldrData));
                ncldrData = (NCldrData)serializer.Deserialize(fileStream);
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
        public void Save(INCldrData ncldrData)
        {
            FileStream fileStream = new FileStream(this.NCldrDataFilename, FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(NCldrData));
            try
            {
                serializer.Serialize(fileStream, ncldrData);
            }
            finally
            {
                fileStream.Close();
            }
        }
    }
}
