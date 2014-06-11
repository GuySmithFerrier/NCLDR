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
    public class NCldrJsonFileDataSource : INCldrFileDataSource
    {
        /// <summary>
        /// Gets or sets the name of the data source
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets or sets the description of the data source
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets or sets the formatting used to write the JSON
        /// </summary>
        /// <remarks>None means no special formatting, Indented means child objects are indented</remarks>
        public Formatting JsonFormatting { get; set; }

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

        /// <summary>
        /// IgnoreReadOnlyPropertiesContractResolver is a JsonSerializer ContractResolver that ignores read-only properties
        /// </summary>
        internal class IgnoreReadOnlyPropertiesContractResolver : DefaultContractResolver
        {
            /// <summary>
            /// CreateProperties creates a list of properties to serialize that excludes properties that are read-only
            /// </summary>
            /// <param name="type">The type</param>
            /// <param name="memberSerialization">The MemberSerialization</param>
            /// <returns>A list of properties to serialize that excludes properties that are read-only</returns>
            protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
            {
                return (from property in base.CreateProperties(type, memberSerialization)
                        where property.Writable
                        select property).ToList();
            }
        }
    }
}
