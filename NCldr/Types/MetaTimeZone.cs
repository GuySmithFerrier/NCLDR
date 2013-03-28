namespace NCldr.Types
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Timezone_Names </remarks>
    [Serializable]
    public class MetaTimeZone
    {
        /// <summary>
        /// Gets or sets the meta time zone's identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the time zone regions for the meta time zone
        /// </summary>
        public TimeZoneRegion[] TimeZoneRegions { get; set; }
    }
}
