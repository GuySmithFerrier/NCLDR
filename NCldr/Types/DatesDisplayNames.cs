namespace NCldr.Types
{
    using System;

    /// <summary>
    /// DatesDisplayNames is a collection of localized strings for use with calendars
    /// </summary>
    [Serializable]
    public class DatesDisplayNames
    {
        /// <summary>
        /// Gets or sets the localized string for an era
        /// </summary>
        public string Era { get; set; }

        /// <summary>
        /// Gets or sets the localized string for a year
        /// </summary>
        public string Year { get; set; }

        /// <summary>
        /// Gets or sets the localized string for a month
        /// </summary>
        public string Month { get; set; }

        /// <summary>
        /// Gets or sets the localized string for a day
        /// </summary>
        public string Day { get; set; }

        /// <summary>
        /// Gets or sets the localized string for yesterday
        /// </summary>
        public string Yesterday { get; set; }

        /// <summary>
        /// Gets or sets the localized string for today
        /// </summary>
        public string Today { get; set; }

        /// <summary>
        /// Gets or sets the localized string for tomorrow
        /// </summary>
        public string Tomorrow { get; set; }

        /// <summary>
        /// Gets or sets the localized string for a week
        /// </summary>
        public string Week { get; set; }

        /// <summary>
        /// Gets or sets the localized string for a week day
        /// </summary>
        public string WeekDay { get; set; }

        /// <summary>
        /// Gets or sets the localized string for a day period
        /// </summary>
        public string DayPeriod { get; set; }

        /// <summary>
        /// Gets or sets the localized string for an hour
        /// </summary>
        public string Hour { get; set; }

        /// <summary>
        /// Gets or sets the localized string for a minute
        /// </summary>
        public string Minute { get; set; }

        /// <summary>
        /// Gets or sets the localized string for a second
        /// </summary>
        public string Second { get; set; }

        /// <summary>
        /// Gets or sets the localized string for a zone
        /// </summary>
        public string Zone { get; set; }
    }
}
