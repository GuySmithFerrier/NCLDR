namespace NCldr
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// NCldrJsonFileDataSource loads/saves the raw NCLDR data from an NCldr JSON data file
    /// </summary>
    /// <remarks>Set the NCldrJsonFileDataSource.NCldrDataPath property before calling NCldrJsonFileDataSource.Load</remarks>
    public class NCldrJsonFileDataSource : NCldrJsonFileDataSourceBase, INCldrFileDataSource
    {
        /// <summary>
        /// Gets or sets the formatting used to write the JSON
        /// </summary>
        /// <remarks>None means no special formatting, Indented means child objects are indented</remarks>
        public Formatting JsonFormatting { get; set; }

        /// <summary>
        /// Gets the data file name including the path
        /// </summary>
        public override string NCldrDataFilename
        {
            get
            {
                return Path.Combine(this.NCldrDataPath, "NCldr.json");
            }
        }

        /// <summary>
        /// Initializes a new instance of the NCldrJsonFileDataSource class
        /// </summary>
        public NCldrJsonFileDataSource()
        {
            this.Name = "JSON";
            this.Description = "Newtonsoft JSON Serializer";
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
            string data = File.ReadAllText(this.NCldrDataFilename);

            try
            {
                ncldrData = JsonConvert.DeserializeObject<NCldrData>(data);
            }
            catch (SerializationException exception)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + exception.Message);
                throw;
            }

            return ncldrData;
        }

        /// <summary>
        /// Save saves the NCldrData object to the NCldr data file
        /// </summary>
        /// <param name="ncldrData">The INCldrData object to save</param>
        public void Save(INCldrData ncldrData)
        {
            using (StreamWriter writer = new StreamWriter(this.NCldrDataFilename))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.ContractResolver = new IgnoreReadOnlyPropertiesContractResolver();

                if (this.JsonFormatting != Formatting.None)
                {
                    serializer.Formatting = this.JsonFormatting;
                }

                serializer.Serialize(writer, ncldrData);
            }
        }
    }
}
