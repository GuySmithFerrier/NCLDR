namespace NCldr.Types
{
    using System;
    using System.Globalization;

    /// <summary>
    /// RegionHour specifies the preferred time cycle and allowed time cycles used by a region
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/tr35-dates.html#Time_Data </remarks>
    [Serializable]
    public class RegionHour
    {
        /// <summary>
        /// Gets or sets the preferred hour time cycle
        /// </summary>
        public string Preferred { get; set; }

        /// <summary>
        /// Gets or sets the allowed hour time cycles
        /// </summary>
        public string[] Allowed { get; set; }

        /// <summary>
        /// Gets or sets an array of region Ids for which the preferred and allowed time cycles apply
        /// </summary>
        public string[] RegionIds { get; set; }
    }
}
