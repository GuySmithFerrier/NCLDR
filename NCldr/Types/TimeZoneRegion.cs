namespace NCldr.Types
{
    using System;

    /// <summary>
    /// TimeZoneRegion provides the time zone used by a region
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Supplemental_Timezone_Data </remarks>
    [Serializable]
    public class TimeZoneRegion
    {
        /// <summary>
        /// Gets or sets the region Id
        /// </summary>
        public string RegionId { get; set; }

        /// <summary>
        /// Gets or sets the timezone Id
        /// </summary>
        public string TimeZoneId { get; set; }
    }
}
