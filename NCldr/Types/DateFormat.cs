namespace NCldr.Types
{
    using System;

    /// <summary>
    /// DateFormat represents a CLDR date format pattern
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Calendar_Elements </remarks>
    [Serializable]
    public class DateFormat
    {
        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the CLDR date format pattern
        /// </summary>
        public string Pattern { get; set; }
    }
}
