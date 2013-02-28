namespace NCldr.Types
{
    using System;

    /// <summary>
    /// CalendarPreference is a collection of regions and their preferred CalendarTypes
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Calendar_Preference_Data </remarks>
    [Serializable]
    public class CalendarPreference
    {
        /// <summary>
        /// Gets or sets an array of region Ids for which the CalendarTypes apply
        /// </summary>
        public string[] RegionIds { get; set; }

        /// <summary>
        /// Gets or sets an array of CalendarTypes that apply to the corresponding region Ids
        /// </summary>
        public string[] CalendarTypes { get; set; }
    }
}
