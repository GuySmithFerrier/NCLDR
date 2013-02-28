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
        private static WeekData GetWeekData()
        {
            if (options != null && !options.IncludeWeekData)
            {
                return null;
            }

            XElement weekDataElement = (from i in supplementalDataDocument.Elements("supplementalData").Elements("weekData")
                                        select i).FirstOrDefault();
            if (weekDataElement == null)
            {
                return null;
            }

            Progress("Adding week data", String.Empty);

            WeekData weekData = new WeekData();

            List<XElement> minDaysCountElements = weekDataElement.Elements("minDays").ToList();
            if (minDaysCountElements.Count > 0)
            {
                List<MinDaysCount> minDaysCounts = new List<MinDaysCount>();
                foreach (XElement minDaysCountElement in minDaysCountElements)
                {
                    MinDaysCount minDaysCount = new MinDaysCount();
                    minDaysCount.Count = int.Parse(minDaysCountElement.Attribute("count").Value.ToString());
                    minDaysCount.RegionIds = minDaysCountElement.Attribute("territories").Value.ToString().Split(' ');
                    minDaysCounts.Add(minDaysCount);
                }

                weekData.MinDaysCounts = minDaysCounts.ToArray();
            }

            weekData.FirstDayOfWeeks = GetRegionDayOfWeeks(weekDataElement, "firstDay");

            weekData.WeekendStarts = GetRegionDayOfWeeks(weekDataElement, "weekendStart");

            weekData.WeekendEnds = GetRegionDayOfWeeks(weekDataElement, "weekendEnd");

            return weekData;
        }

        private static RegionDayOfWeek[] GetRegionDayOfWeeks(XElement weekDataElement, string elementName)
        {
            List<XElement> firstDaysCountElements = weekDataElement.Elements(elementName).ToList();
            if (firstDaysCountElements.Count > 0)
            {
                List<RegionDayOfWeek> firstDaysCounts = new List<RegionDayOfWeek>();
                foreach (XElement firstDaysCountElement in firstDaysCountElements)
                {
                    RegionDayOfWeek regionDayOfWeek = new RegionDayOfWeek();
                    regionDayOfWeek.DayOfWeek = GetDayOfWeek(firstDaysCountElement.Attribute("day").Value.ToString());
                    regionDayOfWeek.RegionIds = firstDaysCountElement.Attribute("territories").Value.ToString().Split(' ');

                    if (firstDaysCountElement.Attribute("alt") != null)
                    {
                        regionDayOfWeek.Alt = firstDaysCountElement.Attribute("alt").Value.ToString();
                    }

                    if (firstDaysCountElement.Attribute("references") != null)
                    {
                        regionDayOfWeek.References = firstDaysCountElement.Attribute("references").Value.ToString();
                    }

                    firstDaysCounts.Add(regionDayOfWeek);
                }

                return firstDaysCounts.ToArray();
            }

            return null;
        }

        private static DayOfWeek GetDayOfWeek(string dayOfWeek)
        {
            if (dayOfWeek == "mon")
            {
                return DayOfWeek.Monday;
            }
            else if (dayOfWeek == "tue")
            {
                return DayOfWeek.Tuesday;
            }
            else if (dayOfWeek == "wed")
            {
                return DayOfWeek.Wednesday;
            }
            else if (dayOfWeek == "thu")
            {
                return DayOfWeek.Thursday;
            }
            else if (dayOfWeek == "fri")
            {
                return DayOfWeek.Friday;
            }
            else if (dayOfWeek == "sat")
            {
                return DayOfWeek.Saturday;
            }
            else if (dayOfWeek == "sun")
            {
                return DayOfWeek.Sunday;
            }

            throw new ArgumentException(dayOfWeek);
        }
    }
}
