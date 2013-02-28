namespace NCldr.Types
{
    using System;
    using System.Globalization;

    /// <summary>
    /// CalendarSystem is CLDR's equivalent to .NET's CalendarAlgorithmType
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Supplemental_Calendar_Data </remarks>
    public enum CalendarSystem
    {
        /// <summary>
        /// A solar based calendar system
        /// </summary>
        Solar,

        /// <summary>
        /// A lunar based calendar system
        /// </summary>
        Lunar,

        /// <summary>
        /// A luni-solar based calendar system
        /// </summary>
        Lunisolar,

        /// <summary>
        /// An unknown calendar system
        /// </summary>
        Other
    }

    /// <summary>
    /// CalendarType represents a type of calendar (as opposed to a Calendar which is a calendar in a region)
    /// </summary>
    [Serializable]
    public class CalendarType
    {
        /// <summary>
        /// Gets or sets the calendar type's identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the algorithm on which the calendar is based
        /// </summary>
        /// <remarks>CalendarSystem is CLDR's equivalent to .NET's CalendarAlgorithmType</remarks>
        public CalendarSystem CalendarSystem { get; set; }

        /// <summary>
        /// Gets or sets an array of eras covered by the CalendarType
        /// </summary>
        public Era[] Eras { get; set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets the .NET CalendarAlgorithmType equivalent to CLDR's CalendarSystem
        /// </summary>
        public CalendarAlgorithmType CalendarAlgorithmType
        {
            get
            {
                if (this.CalendarSystem == CalendarSystem.Lunar)
                {
                    return CalendarAlgorithmType.LunarCalendar;
                }
                else if (this.CalendarSystem == CalendarSystem.Lunisolar)
                {
                    return CalendarAlgorithmType.LunisolarCalendar;
                }
                else if (this.CalendarSystem == CalendarSystem.Solar)
                {
                    return CalendarAlgorithmType.SolarCalendar;
                }
                else
                {
                    return CalendarAlgorithmType.Unknown;
                }
            }
        }
    }
}
