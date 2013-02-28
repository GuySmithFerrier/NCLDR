namespace NCldr.Types
{
    using System;

    /// <summary>
    /// LikelySubTag provides the most like 'child' culture from a specific 'parent' culture
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Likely_Subtags </remarks>
    [Serializable]
    public class LikelySubTag
    {
        /// <summary>
        /// Gets or sets the 'parent' culture
        /// </summary>
        public string FromCultureId { get; set; }

        /// <summary>
        /// Gets or sets the 'child' culture
        /// </summary>
        public string ToCultureId { get; set; }
    }
}
