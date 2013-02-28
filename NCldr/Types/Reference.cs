namespace NCldr.Types
{
    using System;

    /// <summary>
    /// Reference is a CLDR reference to an information source
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Reference_Elements </remarks>
    [Serializable]
    public class Reference
    {
        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the URI to the reference
        /// </summary>
        public string Uri { get; set; }

        /// <summary>
        /// Gets or sets the name of the reference
        /// </summary>
        public string Value { get; set; }
    }
}
