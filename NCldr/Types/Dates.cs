namespace NCldr.Types
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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
        /// Gets or sets localized display names
        /// </summary>
        public CalendarDisplayNames CalendarDisplayNames { get; set; }

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

        /// <summary>
        /// Combine combines a child with a parent as necessary and returns the combined object
        /// </summary>
        /// <param name="combinedDates">The child object</param>
        /// <param name="parentDates">The parent object</param>
        /// <returns>The combined object</returns>
        public static Dates Combine(Dates combinedDates, Dates parentDates)
        {
            if (combinedDates == null && parentDates == null)
            {
                return null;
            }
            else if (combinedDates == null)
            {
                return (Dates)parentDates.Clone();
            }
            else if (parentDates == null)
            {
                return combinedDates;
            }

            if (combinedDates.DefaultCalendarId == null)
            {
                combinedDates.DefaultCalendarId = parentDates.DefaultCalendarId;
            }

            if (combinedDates.Calendars == null)
            {
                combinedDates.Calendars = parentDates.Calendars;
            }
            else if (combinedDates.Calendars != null && parentDates.Calendars != null)
            {
                // combine the list calendars
                List<Calendar> combinedCalendars = combinedDates.Calendars.ToList();
                foreach (Calendar parentCalendar in parentDates.Calendars)
                {
                    Calendar combinedCalendar = (from c in combinedCalendars
                                                 where string.Compare(c.Id, parentCalendar.Id, StringComparison.InvariantCulture) == 0
                                                 select c).FirstOrDefault();
                    if (combinedCalendar == null)
                    {
                        combinedCalendars.Add(parentCalendar);
                    }
                    else
                    {
                        combinedCalendar = Calendar.Combine(combinedCalendar, parentCalendar);
                    }
                }

                combinedDates.Calendars = combinedCalendars.ToArray();
            }

            return combinedDates;
        }
    }
}
