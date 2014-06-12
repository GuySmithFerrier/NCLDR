namespace NCldr
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Bson;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// NCldrBsonFileDataSource loads/saves the raw NCLDR data from an NCldr Binary JSON data file
    /// </summary>
    /// <remarks>Set the NCldrBsonFileDataSource.NCldrDataPath property before calling NCldrBsonFileDataSource.Load</remarks>
    public class NCldrBsonFileDataSource : NCldrJsonFileDataSourceBase, INCldrFileDataSource
    {
        /// <summary>
        /// Gets the data file name including the path
        /// </summary>
        public override string NCldrDataFilename
        {
            get
            {
                return Path.Combine(this.NCldrDataPath, "NCldr.bson");
            }
        }

        /// <summary>
        /// Initializes a new instance of the NCldrBsonFileDataSource class
        /// </summary>
        public NCldrBsonFileDataSource()
        {
            this.Name = "BSON";
            this.Description = "Newtonsoft Binary JSON Serializer";
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
            using (FileStream stream = File.OpenRead(this.NCldrDataFilename))
            {
                try
                {
                    BsonReader bsonReader = new BsonReader(stream);
                    JsonSerializer serializer = new JsonSerializer();
                    ncldrData = serializer.Deserialize<NCldrData>(bsonReader);
                }
                catch (SerializationException exception)
                {
                    Console.WriteLine("Failed to deserialize. Reason: " + exception.Message);
                    throw;
                }
            }

            return ncldrData;
        }

        /// <summary>
        /// Save saves the NCldrData object to the NCldr data file
        /// </summary>
        /// <param name="ncldrData">The INCldrData object to save</param>
        public void Save(INCldrData ncldrData)
        {
            using (Stream stream = new FileStream(this.NCldrDataFilename, FileMode.Create))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.ContractResolver = new IgnoreReadOnlyPropertiesContractResolver();
                BsonWriter bsonWriter = new BsonWriter(stream);
                serializer.Serialize(bsonWriter, ncldrData);
            }
        }
    }
}
