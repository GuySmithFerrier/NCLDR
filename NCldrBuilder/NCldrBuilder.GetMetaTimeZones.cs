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
        private static MetaTimeZone[] GetMetaTimeZones()
        {
            if (options != null && !options.IncludeMetaTimeZones)
            {
                return null;
            }

            return GetMetaTimeZones("metaZones", "metaZones", "meta time zone");
        }

        private static MetaTimeZone[] GetWindowsMetaTimeZones()
        {
            if (options != null && !options.IncludeWindowsMetaTimeZones)
            {
                return null;
            }

            return GetMetaTimeZones("windowsZones", "windowsZones", "Windows meta time zone");
        }

        private static MetaTimeZone[] GetMetaTimeZones(string filename, string elementsName, string progressName)
        {
            XDocument supplementalDocument = GetXmlDocument(String.Format(@"common\supplemental\{0}.xml", filename));
            List<XElement> metaTimeZoneElements =
                (from i in supplementalDocument.Elements("supplementalData").Elements(elementsName)
                     .Elements("mapTimezones").Elements("mapZone")
                     orderby i.Attribute("other").Value.ToString()
                 select i).ToList();

            List<MetaTimeZone> metaTimeZones = new List<MetaTimeZone>();
            int metaTimeZoneIndex = 0;
            while(metaTimeZoneIndex < metaTimeZoneElements.Count)
            {
                XElement metaTimeZoneElement = metaTimeZoneElements[metaTimeZoneIndex];

                string metaTimeZoneId = metaTimeZoneElement.Attribute("other").Value.ToString();

                Progress(String.Format("Adding {0}", progressName), metaTimeZoneId);

                MetaTimeZone metaTimeZone = new MetaTimeZone();
                metaTimeZone.Id = metaTimeZoneId;

                List<TimeZoneRegion> timeZoneRegions = new List<TimeZoneRegion>();
                while (metaTimeZoneIndex < metaTimeZoneElements.Count
                    && metaTimeZoneElement.Attribute("other").Value.ToString() == metaTimeZoneId)
                {
                    TimeZoneRegion timeZoneRegion = new TimeZoneRegion();
                    timeZoneRegion.RegionId = metaTimeZoneElement.Attribute("territory").Value.ToString();
                    timeZoneRegion.TimeZoneId = metaTimeZoneElement.Attribute("type").Value.ToString();
                    timeZoneRegions.Add(timeZoneRegion);

                    metaTimeZoneIndex++;
                    if (metaTimeZoneIndex < metaTimeZoneElements.Count)
                    {
                        metaTimeZoneElement = metaTimeZoneElements[metaTimeZoneIndex];
                    }
                }

                metaTimeZone.TimeZoneRegions = timeZoneRegions.ToArray();

                metaTimeZones.Add(metaTimeZone);
                Progress(string.Format("Added {0}", progressName), metaTimeZoneId, ProgressEventType.Added, metaTimeZone);
            }

            return metaTimeZones.ToArray();
        }
    }
}
