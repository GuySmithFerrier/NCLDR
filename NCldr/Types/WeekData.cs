namespace NCldr.Types
{
    using System;

    /// <summary>
    /// WeekData provides information on how a calendar is used in a region
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Supplemental_Calendar_Data </remarks>
    [Serializable]
    public class WeekData
    {
        /// <summary>
        /// Gets or sets the minimum number of days to count as the first week (of a month or year)
        /// </summary>
        public MinDaysCount[] MinDaysCounts { get; set; }

        /// <summary>
        /// Gets or sets the first day of the week in a calendar view
        /// </summary>
        public RegionDayOfWeek[] FirstDayOfWeeks { get; set; }

        /// <summary>
        /// Gets or sets the first day of the weekend
        /// </summary>
        public RegionDayOfWeek[] WeekendStarts { get; set; }

        /// <summary>
        /// Gets or sets the last day of the weekend
        /// </summary>
        public RegionDayOfWeek[] WeekendEnds { get; set; }
    }
}
