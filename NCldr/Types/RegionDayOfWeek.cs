namespace NCldr.Types
{
    using System;

    /// <summary>
    /// RegionDayOfWeek represents the first day of the week for a list of regions
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Supplemental_Calendar_Data </remarks>
    [Serializable]
    public class RegionDayOfWeek
    {
        /// <summary>
        /// Gets or sets the .NET first day of the week
        /// </summary>
        public DayOfWeek DayOfWeek { get; set; }

        /// <summary>
        /// Gets or sets an array of regions for which the first day of the week applies
        /// </summary>
        public string[] RegionIds { get; set; }

        /// <summary>
        /// Gets or sets the Alt value
        /// </summary>
        public string Alt { get; set; }

        /// <summary>
        /// Gets or sets the references
        /// </summary>
        public string References { get; set; }
    }
}
