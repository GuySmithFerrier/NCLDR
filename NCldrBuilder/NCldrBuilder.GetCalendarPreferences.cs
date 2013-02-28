using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using NCldr.Types;

namespace NCldr.Builder
{
    public partial class NCldrBuilder
    {
        private static CalendarPreference[] GetCalendarPreferences()
        {
            if (options != null && !options.IncludeCalendarPreferences)
            {
                return null;
            }

            List<XElement> calendarPreferenceElements = (from i in supplementalDataDocument.Elements("supplementalData")
                                                            .Elements("calendarPreferenceData").Elements("calendarPreference")
                                                         select i).ToList();
            if (calendarPreferenceElements.Count == 0)
            {
                return null;
            }

            List<CalendarPreference> calendarPreferences = new List<CalendarPreference>();
            foreach (XElement calendarPreferenceElement in calendarPreferenceElements)
            {
                string regionIds = calendarPreferenceElement.Attribute("territories").Value.ToString();
                Progress("Adding calendar preference", regionIds);

                CalendarPreference calendarPreference = new CalendarPreference();
                calendarPreference.RegionIds = regionIds.Split(' ');

                string calendarTypes = calendarPreferenceElement.Attribute("ordering").Value.ToString();
                calendarPreference.CalendarTypes = calendarTypes.Split(' ');

                calendarPreferences.Add(calendarPreference);
            }

            return calendarPreferences.ToArray();
        }
    }
}
