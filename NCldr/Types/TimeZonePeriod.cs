namespace NCldr.Types
{
    using System;

    /// <summary>
    /// TimeZonePeriod represents a time period in which a time zone is/was in use
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Supplemental_Timezone_Data </remarks>
    [Serializable]
    public class TimeZonePeriod
    {
        /// <summary>
        /// Gets or sets the Id of the MetaTimeZone
        /// </summary>
        public string MetaTimeZoneId { get; set; }

        /// <summary>
        /// Gets or sets the starting time of the timezone period
        /// </summary>
        public DateTime? From { get; set; }

        /// <summary>
        /// Gets or sets the ending time of the timezone period
        /// </summary>
        public DateTime? To { get; set; }
    }
}
