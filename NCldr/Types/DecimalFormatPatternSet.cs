namespace NCldr.Types
{
    using System;

    /// <summary>
    /// DecimalFormatPatternSet is a set of DecimalFormatPatterns
    /// </summary>
    [Serializable]
    public class DecimalFormatPatternSet
    {
        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the array of DecimalFormatPatterns
        /// </summary>
        public DecimalFormatPattern[] Patterns { get; set; }
    }
}
