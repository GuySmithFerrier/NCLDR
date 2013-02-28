namespace NCldr.Types
{
    using System;

    /// <summary>
    /// MinDays indicates the minimum number of days to count as the first week (of a month or year)
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Supplemental_Calendar_Data </remarks>
    [Serializable]
    public class MinDaysCount
    {
        /// <summary>
        /// Gets or sets the regions for which the count applies
        /// </summary>
        public string[] RegionIds { get; set; }

        /// <summary>
        /// Gets or sets the minimum number of days to count as the first week (of a month or year)
        /// </summary>
        public int Count { get; set; }
    }
}
