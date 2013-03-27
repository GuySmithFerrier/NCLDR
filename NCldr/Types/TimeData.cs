namespace NCldr.Types
{
    using System;

    /// <summary>
    /// MeasurementData provides the preferred time cycle in the regions, as well as all time cycles that are considered acceptable in the regions
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/tr35-dates.html#Time_Data </remarks>
    [Serializable]
    public class TimeData
    {
        /// <summary>
        /// Gets or sets the preferred time cycles and allowed time cycles used by regions
        /// </summary>
        public RegionHour[] Hours { get; set; }
    }
}
