namespace NCldr.Types
{
    /// <summary>
    /// IDescription is an interface for a description
    /// </summary>
    public interface IDescription
    {
        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        string Description { get; set; }
    }
}
