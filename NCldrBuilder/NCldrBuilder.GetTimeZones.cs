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
        private static TimeZoneInformation[] GetTimeZones()
        {
            if (options != null && !options.IncludeTimeZones)
            {
                return null;
            }

            XDocument bcp47Document = GetXmlDocument(@"common\bcp47\timezone.xml");

            XElement timeZoneKeyElement = (from i in bcp47Document.Elements("ldmlBCP47").Elements("keyword").Elements("key")
                                           where i.Attribute("name").Value.ToString() == "tz"
                                           select i).FirstOrDefault();

            if (timeZoneKeyElement == null)
            {
                return null;
            }

            List<XElement> timeZoneElements = (from i in timeZoneKeyElement.Elements("type")
                                               select i).ToList();
            if (timeZoneElements == null)
            {
                return null;
            }

            XDocument supplementalDocument = GetXmlDocument(@"common\supplemental\metaZones.xml");
            List<XElement> timeZonePeriodTimeZoneElements =
                (from i in supplementalDocument.Elements("supplementalData").Elements("metaZones")
                     .Elements("metazoneInfo").Elements("timezone")
                 select i).ToList();

            List<TimeZoneInformation> timeZones = new List<TimeZoneInformation>();
            foreach (XElement timeZoneElement in timeZoneElements)
            {
                string name = timeZoneElement.Attribute("name").Value.ToString();
                string id = name;
                string[] aliases = null;
                if (timeZoneElement.Attribute("alias") != null)
                {
                    aliases = timeZoneElement.Attribute("alias").Value.ToString().Split(' ');
                    id = aliases[0];
                }

                Progress("Adding time zone", id);

                TimeZoneInformation timeZone = new TimeZoneInformation();
                timeZone.Id = id;
                timeZone.ShortId = name;
                timeZone.Description = timeZoneElement.Attribute("description").Value.ToString();

                if (aliases != null && aliases.GetLength(0) > 1)
                {
                    // The first element of "aliases" is the timezone id.
                    // All remaining elements are aliases of the first element.
                    timeZone.Aliases = new string[aliases.GetLength(0) - 1];
                    for (int aliasIndex = 1; aliasIndex < aliases.GetLength(0); aliasIndex++)
                    {
                        timeZone.Aliases[aliasIndex - 1] = aliases[aliasIndex];
                    }
                }

                XElement timeZonePeriodTimeZoneElement = (from tz in timeZonePeriodTimeZoneElements
                                                          where tz.Attribute("type").Value.ToString() == timeZone.Id
                                                          select tz).FirstOrDefault();
                if (timeZonePeriodTimeZoneElement != null)
                {
                    List<XElement> timeZonePeriodElements = (from tzp in timeZonePeriodTimeZoneElement.Elements("usesMetazone")
                                                             select tzp).ToList();
                    if (timeZonePeriodElements != null)
                    {
                        List<TimeZonePeriod> timeZonePeriods = new List<TimeZonePeriod>();
                        foreach (XElement timeZonePeriodElement in timeZonePeriodElements)
                        {
                            TimeZonePeriod timeZonePeriod = new TimeZonePeriod();
                            timeZonePeriod.MetaTimeZoneId = timeZonePeriodElement.Attribute("mzone").Value.ToString();
                            XAttribute fromAttribute = timeZonePeriodElement.Attribute("from");
                            if (fromAttribute != null)
                            {
                                timeZonePeriod.From = ParseCldrDate(fromAttribute.Value.ToString()).Value;
                            }

                            XAttribute toAttribute = timeZonePeriodElement.Attribute("to");
                            if (toAttribute != null)
                            {
                                timeZonePeriod.To = ParseCldrDate(toAttribute.Value.ToString()).Value;
                            }

                            timeZonePeriods.Add(timeZonePeriod);
                        }

                        timeZone.TimeZonePeriods = timeZonePeriods.ToArray();
                    }
                }

                timeZones.Add(timeZone);
                Progress("Added time zone", id, ProgressEventType.Added, timeZone);
            }

            return timeZones.ToArray();
        }
    }
}
