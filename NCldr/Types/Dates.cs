namespace NCldr.Types
{
    using System;

    /// <summary>
    /// Dates represents the calendars used by a region
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Date_Elements </remarks>
    [Serializable]
    public class Dates : ICloneable
    {
        /// <summary>
        /// Gets or sets the Id of the calendar which is the default for the Culture
        /// </summary>
        public string DefaultCalendarId { get; set; }

        /// <summary>
        /// Gets or sets an array of Calendars for the Culture
        /// </summary>
        public Calendar[] Calendars { get; set; }

        /// <summary>
        /// Clone clones the object
        /// </summary>
        /// <returns>A cloned copy of the object</returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
