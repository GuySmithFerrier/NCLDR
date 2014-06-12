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
    /// NCldrJsonFileDataSourceBase is a base class for NewtonSoft's JSON and BSON data files
    /// </summary>
    public abstract class NCldrJsonFileDataSourceBase
    {
        /// <summary>
        /// Gets or sets the name of the data source
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Gets or sets the description of the data source
        /// </summary>
        public string Description { get; protected set; }

        /// <summary>
        /// Gets or sets the path to the NCldr data file (includes the folder name only with no filename)
        /// </summary>
        public string NCldrDataPath { get; set; }

        /// <summary>
        /// Gets the data file name including the path
        /// </summary>
        public abstract string NCldrDataFilename { get; }

        /// <summary>
        /// Exists returns true if the NCldr data file exists
        /// </summary>
        /// <returns>True if the NCldr data file exists</returns>
        public bool Exists()
        {
            return File.Exists(this.NCldrDataFilename);
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
