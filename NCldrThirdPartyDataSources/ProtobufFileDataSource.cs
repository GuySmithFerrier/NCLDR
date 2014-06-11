namespace NCldr
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.Serialization;
    using ProtoBuf;
    using ProtoBuf.Meta;

    /// <summary>
    /// ProtobufFileDataSource loads/saves the raw NCLDR data from an NCldr Protocol Buffers binary data file
    /// </summary>
    /// <remarks>This class requires the protobuf-net library from https://code.google.com/p/protobuf-net/.
    /// Set the ProtobufFileDataSource.NCldrDataPath property before calling Load</remarks>
    public class ProtobufFileDataSource : INCldrFileDataSource
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
                return Path.Combine(this.NCldrDataPath, "NCldr.prb");
            }
        }

        /// <summary>
        /// Initializes static members of the ProtobufFileDataSource class
        /// </summary>
        static ProtobufFileDataSource()
        {
            Assembly assembly = Assembly.GetAssembly(typeof(NCldrData));
            Type[] ncldrTypes = (from t in assembly.GetTypes()
                                 where t.Namespace.StartsWith("NCldr.Types")
                                 select t).ToArray();

            AddProtobufType(ncldrTypes, typeof(NCldrData));

            foreach (Type type in ncldrTypes)
            {
                AddProtobufType(ncldrTypes, type);
            }
        }

        /// <summary>
        /// Adds a default protobuf data contract to the protobuf runtime model
        /// </summary>
        /// <param name="allTypes">All types available</param>
        /// <param name="type">The type to add to the model</param>
        private static void AddProtobufType(Type[] allTypes, Type type)
        {
            MetaType metaType = RuntimeTypeModel.Default.Add(type, true);

            string[] memberNames = (from pi in type.GetProperties()
                                    where pi.CanWrite
                                    select pi.Name).ToArray();

            metaType.Add(memberNames);

            int index = memberNames.Length;

            // add subtypes
            foreach (Type allType in allTypes)
            {
                if (allType.IsSubclassOf(type))
                {
                    metaType.AddSubType(++index, allType);
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the ProtobufFileDataSource class
        /// </summary>
        public ProtobufFileDataSource()
        {
            this.Name = "Protocol Buffers";
            this.Description = "Google Protocol Buffers Serializer";
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
                ncldrData = Serializer.Deserialize<NCldrData>(fileStream);
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
            try
            {
                Serializer.Serialize(fileStream, (NCldrData)ncldrData);
            }
            finally
            {
                fileStream.Close();
            }
        }
    }
}
