namespace NCldr.Types
{
    using System;

    /// <summary>
    /// TimeZoneInformation is an encapsulation of information about a time zone
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Supplemental_Timezone_Data </remarks>
    [Serializable]
    public class TimeZoneInformation
    {
        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the short identifier
        /// </summary>
        public string ShortId { get; set; }

        /// <summary>
        /// Gets or sets an array of aliases
        /// </summary>
        public string[] Aliases { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets an array of periods for which time zones are/were in use
        /// </summary>
        public TimeZonePeriod[] TimeZonePeriods { get; set; }
    }
}
