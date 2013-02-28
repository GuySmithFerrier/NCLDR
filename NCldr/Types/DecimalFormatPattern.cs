namespace NCldr.Types
{
    using System;

    /// <summary>
    /// PatternCount identifies the 'count' for which the pattern is used
    /// </summary>
    public enum PatternCount
    {
        /// <summary>
        /// Item0 is unknown
        /// </summary>
        Item0,

        /// <summary>
        /// Item1 is unknown
        /// </summary>
        Item1,

        /// <summary>
        /// Zero means that the number of items is 0
        /// </summary>
        Zero,

        /// <summary>
        /// One means that the number of items is 1
        /// </summary>
        One,

        /// <summary>
        /// Two means that the number of items is 2
        /// </summary>
        Two,

        /// <summary>
        /// Few means that the number of items is 'a few'
        /// </summary>
        Few,

        /// <summary>
        /// Many means that the number of items is 'many'
        /// </summary>
        Many,

        /// <summary>
        /// Other means that the number of items is a value other than one that is matched by any other rule
        /// </summary>
        Other
    }

    /// <summary>
    /// DecimalFormatPattern is a decimal pattern for a given 'count'
    /// </summary>
    [Serializable]
    public class DecimalFormatPattern
    {
        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the PatternCount
        /// </summary>
        public PatternCount Count { get; set; }

        /// <summary>
        /// Gets or sets the CLDR format pattern
        /// </summary>
        public string Pattern { get; set; }
    }
}
