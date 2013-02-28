namespace NCldr.Types
{
    using System;
    using System.Text;

    /// <summary>
    /// DayPeriodRule is a rule that determines a period of a day (e.g. morning, afternoon, twilight)
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#DayPeriodRules.
    /// There is exactly one of {At, From, After} and exactly one of {At, To, Before} for each DayPeriodRule.
    /// </remarks> 
    [Serializable]
    public class DayPeriodRule
    {
        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the exact time at which the period occurs
        /// </summary>
        /// <remarks> The use of At means that the starting time and the end time are the same</remarks>
        public string At { get; set; }

        /// <summary>
        /// Gets or sets the time after which the period occurs
        /// </summary>
        public string After { get; set; }

        /// <summary>
        /// Gets or sets the starting time of the period
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// Gets or sets the time before which the period occurs
        /// </summary>
        public string Before { get; set; }

        /// <summary>
        /// Gets or sets the ending time of the period
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// ToString returns a string representation of the DayPeriodRule
        /// </summary>
        /// <returns>A string representation of the DayPeriodRule</returns>
        public new string ToString()
        {
            StringBuilder builder = new StringBuilder(string.Format("Id: {0}", this.Id));

            if (!string.IsNullOrEmpty(this.From))
            {
                builder.Append(string.Format(", From: {0}", this.From));
            }

            if (!string.IsNullOrEmpty(this.At))
            {
                builder.Append(string.Format(", At: {0}", this.At));
            }

            if (!string.IsNullOrEmpty(this.After))
            {
                builder.Append(string.Format(", After: {0}", this.After));
            }

            if (!string.IsNullOrEmpty(this.Before))
            {
                builder.Append(string.Format(", Before: {0}", this.Before));
            }

            return builder.ToString();
        }
    }
}
