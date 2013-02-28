namespace NCldr.Types
{
    using System;

    /// <summary>
    /// ListPattern is a specification for one part of a list
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#ListPatterns </remarks>
    [Serializable]
    public class ListPattern
    {
        /// <summary>
        /// Gets or sets the pattern's identifier (that identifier which part of the list that the pattern belongs to)
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the pattern used by the part of the list
        /// </summary>
        public string Pattern { get; set; }
    }
}
