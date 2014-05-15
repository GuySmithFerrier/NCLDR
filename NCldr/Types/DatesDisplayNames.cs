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
        /// Gets or sets a set of RelativeTimeRules for future days
        /// </summary>
        public RelativeTimeRuleSet DayFutureRelativeTimeRules { get; set; }

        /// <summary>
        /// Gets or sets a set of RelativeTimeRules for past days
        /// </summary>
        public RelativeTimeRuleSet DayPastRelativeTimeRules { get; set; }

        /// <summary>
        /// Gets or sets a set of RelativeTimeRules for future weeks
        /// </summary>
        public RelativeTimeRuleSet WeekFutureRelativeTimeRules { get; set; }

        /// <summary>
        /// Gets or sets a set of RelativeTimeRules for past weeks
        /// </summary>
        public RelativeTimeRuleSet WeekPastRelativeTimeRules { get; set; }

        /// <summary>
        /// Gets or sets a set of RelativeTimeRules for future months
        /// </summary>
        public RelativeTimeRuleSet MonthFutureRelativeTimeRules { get; set; }

        /// <summary>
        /// Gets or sets a set of RelativeTimeRules for past months
        /// </summary>
        public RelativeTimeRuleSet MonthPastRelativeTimeRules { get; set; }

        /// <summary>
        /// Gets or sets a set of RelativeTimeRules for future years
        /// </summary>
        public RelativeTimeRuleSet YearFutureRelativeTimeRules { get; set; }

        /// <summary>
        /// Gets or sets a set of RelativeTimeRules for past years
        /// </summary>
        public RelativeTimeRuleSet YearPastRelativeTimeRules { get; set; }

        /// <summary>
        /// Gets or sets a set of RelativeTimeRules for future seconds
        /// </summary>
        public RelativeTimeRuleSet SecondFutureRelativeTimeRules { get; set; }

        /// <summary>
        /// Gets or sets a set of RelativeTimeRules for past seconds
        /// </summary>
        public RelativeTimeRuleSet SecondPastRelativeTimeRules { get; set; }

        /// <summary>
        /// Gets or sets a set of RelativeTimeRules for future minutes
        /// </summary>
        public RelativeTimeRuleSet MinuteFutureRelativeTimeRules { get; set; }

        /// <summary>
        /// Gets or sets a set of RelativeTimeRules for past minutes
        /// </summary>
        public RelativeTimeRuleSet MinutePastRelativeTimeRules { get; set; }

        /// <summary>
        /// Gets or sets a set of RelativeTimeRules for future hours
        /// </summary>
        public RelativeTimeRuleSet HourFutureRelativeTimeRules { get; set; }

        /// <summary>
        /// Gets or sets a set of RelativeTimeRules for past hours
        /// </summary>
        public RelativeTimeRuleSet HourPastRelativeTimeRules { get; set; }

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

        /// <summary>
        /// Combine combines a child with a parent as necessary and returns the combined object
        /// </summary>
        /// <param name="combinedDatesDisplayNames">The child object</param>
        /// <param name="parentDatesDisplayNames">The parent object</param>
        /// <returns>The combined object</returns>
        public static DatesDisplayNames Combine(DatesDisplayNames combinedDatesDisplayNames, DatesDisplayNames parentDatesDisplayNames)
        {
            if (combinedDatesDisplayNames.Era == null)
            {
                combinedDatesDisplayNames.Era = parentDatesDisplayNames.Era;
            }

            if (combinedDatesDisplayNames.Year == null)
            {
                combinedDatesDisplayNames.Year = parentDatesDisplayNames.Year;
            }

            if (combinedDatesDisplayNames.Month == null)
            {
                combinedDatesDisplayNames.Month = parentDatesDisplayNames.Month;
            }

            if (combinedDatesDisplayNames.Day == null)
            {
                combinedDatesDisplayNames.Day = parentDatesDisplayNames.Day;
            }

            if (combinedDatesDisplayNames.Yesterday == null)
            {
                combinedDatesDisplayNames.Yesterday = parentDatesDisplayNames.Yesterday;
            }

            if (combinedDatesDisplayNames.Today == null)
            {
                combinedDatesDisplayNames.Today = parentDatesDisplayNames.Today;
            }

            if (combinedDatesDisplayNames.Tomorrow == null)
            {
                combinedDatesDisplayNames.Tomorrow = parentDatesDisplayNames.Tomorrow;
            }

            if (combinedDatesDisplayNames.Week == null)
            {
                combinedDatesDisplayNames.Week = parentDatesDisplayNames.Week;
            }

            if (combinedDatesDisplayNames.WeekDay == null)
            {
                combinedDatesDisplayNames.WeekDay = parentDatesDisplayNames.WeekDay;
            }

            if (combinedDatesDisplayNames.Hour == null)
            {
                combinedDatesDisplayNames.Hour = parentDatesDisplayNames.Hour;
            }

            if (combinedDatesDisplayNames.Minute == null)
            {
                combinedDatesDisplayNames.Minute = parentDatesDisplayNames.Minute;
            }

            if (combinedDatesDisplayNames.Second == null)
            {
                combinedDatesDisplayNames.Second = parentDatesDisplayNames.Second;
            }

            if (combinedDatesDisplayNames.Zone == null)
            {
                combinedDatesDisplayNames.Zone = parentDatesDisplayNames.Zone;
            }

            return combinedDatesDisplayNames;
        }
    }
}
