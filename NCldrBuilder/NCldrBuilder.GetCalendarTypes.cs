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
        private static CalendarType[] GetCalendarTypes()
        {
            if (options != null && !options.IncludeCalendarTypes)
            {
                return null;
            }

            List<XElement> calendarElements = (from i in supplementalDataDocument.Elements("supplementalData")
                                                   .Elements("calendarData").Elements("calendar")
                                               select i).ToList();
            if (calendarElements.Count == 0)
            {
                return null;
            }

            List<CalendarType> calendarTypes = new List<CalendarType>();
            foreach (XElement calendarTypeElement in calendarElements)
            {
                string calendarTypeId = calendarTypeElement.Attribute("type").Value.ToString();
                Progress("Adding calendar type", calendarTypeId);

                CalendarType calendarType = new CalendarType();
                calendarType.Id = calendarTypeId;

                XElement calendarSystemElement = calendarTypeElement.Elements("calendarSystem").FirstOrDefault();
                if (calendarSystemElement != null)
                {
                    calendarType.CalendarSystem = GetCalendarSystem(calendarSystemElement.Attribute("type").Value.ToString());
                }

                List<XElement> eraElements = calendarTypeElement.Elements("eras").Elements("era").ToList();
                List<Era> eras = new List<Era>();
                foreach (XElement eraElement in eraElements)
                {
                    Era era = new Era();
                    era.Id = eraElement.Attribute("type").Value.ToString();
                    if (eraElement.Attribute("start") != null)
                    {
                        era.Start = eraElement.Attribute("start").Value.ToString();
                    }

                    if (eraElement.Attribute("end") != null)
                    {
                        era.End = eraElement.Attribute("end").Value.ToString();
                    }

                    eras.Add(era);
                }

                calendarType.Eras = eras.ToArray();

                calendarTypes.Add(calendarType);
                Progress("Added calendar type", calendarTypeId, ProgressEventType.Added, calendarType);
            }

            UpdateCalendarNamesAndDescriptions(calendarTypes);

            return calendarTypes.ToArray();
        }

        private static void UpdateCalendarNamesAndDescriptions(List<CalendarType> calendarTypes)
        {
            XDocument bcp47Document = GetXmlDocument(@"Core\common\bcp47\calendar.xml");

            XElement calendarKeyElement = (from i in bcp47Document.Elements("ldmlBCP47").Elements("keyword").Elements("key")
                                           where i.Attribute("name").Value.ToString() == "ca"
                                           select i).FirstOrDefault();
            if (calendarKeyElement != null)
            {
                List<XElement> calendarTypeElements = (from i in calendarKeyElement.Elements("type")
                                                       select i).ToList();
                foreach (XElement calendarTypeElement in calendarTypeElements)
                {
                    string name = calendarTypeElement.Attribute("name").Value.ToString();
                    string alias = null;
                    if (calendarTypeElement.Attribute("alias") != null)
                    {
                        alias = calendarTypeElement.Attribute("alias").Value.ToString();
                    }

                    string calendarTypeId = alias == null ? name : alias;

                    CalendarType calendarType = (from ct in calendarTypes
                                                 where ct.Id == calendarTypeId
                                                 select ct).FirstOrDefault();
                    if (calendarType != null)
                    {
                        calendarType.Name = name;
                        calendarType.Description = calendarTypeElement.Attribute("description").Value.ToString();
                    }
                }
            }
        }

        private static CalendarSystem GetCalendarSystem(string calendarSystem)
        {
            return (CalendarSystem)Enum.Parse(typeof(CalendarSystem), calendarSystem, true);
        }
    }
}
