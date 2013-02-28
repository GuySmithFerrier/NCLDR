namespace NCldr.Types
{
    using System;

    /// <summary>
    /// DisplayName is a localized name intended for viewing by an end user
    /// </summary>
    [Serializable]
    public class DisplayName
    {
        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the localized name
        /// </summary>
        public string Name { get; set; }
    }
}
