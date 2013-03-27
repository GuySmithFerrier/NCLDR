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
        private static TimeData GetTimeData()
        {
            if (options != null && !options.IncludeTimeData)
            {
                return null;
            }

            XElement timeDataElement = (from i in supplementalDataDocument.Elements("supplementalData")
                                                   .Elements("timeData")
                                               select i).FirstOrDefault();
            if (timeDataElement == null)
            {
                return null;
            }

            Progress("Adding time data", String.Empty);

            TimeData timeData = new TimeData();

            List<XElement> hourElements = timeDataElement.Elements("hours").ToList();
            if (hourElements.Count > 0)
            {
                List<RegionHour> regionHours = new List<RegionHour>();
                foreach (XElement hourElement in hourElements)
                {
                    RegionHour regionMeasurementSystem = new RegionHour();
                    regionMeasurementSystem.Preferred = hourElement.Attribute("preferred").Value.ToString();
                    regionMeasurementSystem.Allowed = hourElement.Attribute("allowed").Value.ToString().Split(' ');
                    regionMeasurementSystem.RegionIds = hourElement.Attribute("regions").Value.ToString().Split(' ');
                    regionHours.Add(regionMeasurementSystem);
                }

                timeData.Hours = regionHours.ToArray();
            }

            Progress("Added time data", string.Empty, ProgressEventType.Added, timeData);

            return timeData;
        }
    }
}
