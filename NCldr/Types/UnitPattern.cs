namespace NCldr.Types
{
    using System;

    /// <summary>
    /// UnitPattern is a display format for a currency for a given 'count' of the currency
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Currencies </remarks>
    [Serializable]
    public class UnitPattern
    {
        /// <summary>
        /// Gets or sets the 'count' for which the pattern is used
        /// </summary>
        public PatternCount Count { get; set; }

        /// <summary>
        /// Gets or sets the pattern
        /// </summary>
        public string Pattern { get; set; }

        /// <summary>
        /// Gets or sets the alt value
        /// </summary>
        public string Alt { get; set; }
    }
}
