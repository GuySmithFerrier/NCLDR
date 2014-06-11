namespace NCldr
{
    /// <summary>
    /// INCldrFileDataSource is an interface for single-file based NCLDR data sources
    /// </summary>
    public interface INCldrFileDataSource
    {
        /// <summary>
        /// Gets or sets the name of the data source
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets or sets the description of the data source
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets or sets the path to the NCldr data file (includes the folder name only with no filename)
        /// </summary>
        string NCldrDataPath { get; set; }

        /// <summary>
        /// Gets the data file name including the path
        /// </summary>
        string NCldrDataFilename { get; }

        /// <summary>
        /// Exists returns true if the NCldr data file exists
        /// </summary>
        /// <returns>True if the NCldr data file exists</returns>
        bool Exists();

        /// <summary>
        /// Loads loads the raw data from the NCldr data file and returns an NCldrData object
        /// </summary>
        /// <returns>An INCldrData object from the NCldr data file</returns>
        INCldrData Load();

        /// <summary>
        /// Save saves the NCldrData object to the NCldr data file
        /// </summary>
        /// <param name="ncldrData">The INCldrData object to save</param>
        void Save(INCldrData ncldrData);
    }
}
