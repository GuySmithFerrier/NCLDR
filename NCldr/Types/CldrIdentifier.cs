namespace NCldr.Types
{
    using System;

    /// <summary>
    /// CldrIdentifier is an identifier used by CLDR in an Identity
    /// </summary>
    [Serializable]
    public class CldrIdentifier
    {
        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the references
        /// </summary>
        public string References { get; set; }

        /// <summary>
        /// Gets or sets the alt value
        /// </summary>
        public string Alt { get; set; }

        /// <summary>
        /// Gets or sets the value
        /// </summary>
        public string Value { get; set; }
    }
}
