namespace NCldr.Extensions
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Types;

    /// <summary>
    /// RegionExtensions is a set of methods that provide easy access to NCLDR data for regions
    /// </summary>
    public static class RegionExtensions
    {
        /// <summary>
        /// GetPostcodeRegex gets the postal code regular expression for the region
        /// </summary>
        /// <param name="regionId">The Id of the region to get the postal code regular expression for</param>
        /// <returns>The postal code regular expression for the region</returns>
        public static string GetPostcodeRegex(string regionId)
        {
            if (NCldr.PostcodeRegexes == null)
            {
                return null;
            }

            return (from pcr in NCldr.PostcodeRegexes
                    where string.Compare(pcr.RegionId, regionId, false, CultureInfo.InvariantCulture) == 0
                    select pcr.Regex).FirstOrDefault();
        }

        /// <summary>
        /// GetTelephoneCodes gets an array of telephone codes used by the region
        /// </summary>
        /// <param name="regionId">The Id of the region to get the telephone codes for</param>
        /// <returns>An array of telephone codes used by the region</returns>
        public static string[] GetTelephoneCodes(string regionId)
        {
            if (NCldr.RegionTelephoneCodes == null)
            {
                return null;
            }

            return (from rtc in NCldr.RegionTelephoneCodes
                    where string.Compare(rtc.RegionId, regionId, false, CultureInfo.InvariantCulture) == 0
                    select rtc.TelephoneCodes).FirstOrDefault();
        }

        /// <summary>
        /// GetTelephoneCode gets the telephone code used by the region
        /// </summary>
        /// <param name="regionId">The Id of the region to get the telephone code for</param>
        /// <returns>The telephone code used by the region</returns>
        /// <remarks>GetTelephoneCode gets only the first telephone code used by the region.
        /// There is only one telephone code when a region is a country/region. Only when a region
        /// is larger than a country/region (e.g. The World) will it have more than one telephone code.</remarks>
        public static string GetTelephoneCode(string regionId)
        {
            if (NCldr.RegionTelephoneCodes == null)
            {
                return null;
            }

            string[] telephoneCodes = (from rtc in NCldr.RegionTelephoneCodes
                                       where string.Compare(rtc.RegionId, regionId, false, CultureInfo.InvariantCulture) == 0
                                       select rtc.TelephoneCodes).FirstOrDefault();
            if (telephoneCodes == null || telephoneCodes.GetLength(0) == 0)
            {
                return null;
            }

            return telephoneCodes[0];
        }

        /// <summary>
        /// GetRegionCode gets the RegionCode for the region
        /// </summary>
        /// <param name="regionId">The Id of the region to get the RegionCode for</param>
        /// <returns>The RegionCode for the region</returns>
        public static RegionCode GetRegionCode(string regionId)
        {
            if (NCldr.RegionCodes == null)
            {
                return null;
            }

            return (from rc in NCldr.RegionCodes
                    where string.Compare(rc.RegionId, regionId, false, CultureInfo.InvariantCulture) == 0
                    select rc).FirstOrDefault();
        }

        /// <summary>
        /// GetRegionInformation gets the RegionInformation for the region
        /// </summary>
        /// <param name="regionId">The Id of the region to get the RegionInformation for</param>
        /// <returns>The RegionInformation for the region</returns>
        public static RegionInformation GetRegionInformation(string regionId)
        {
            if (NCldr.RegionInformations == null)
            {
                return null;
            }

            return (from ri in NCldr.RegionInformations
                    where string.Compare(ri.Id, regionId, false, CultureInfo.InvariantCulture) == 0
                    select ri).FirstOrDefault();
        }

        /// <summary>
        /// GetMeasurementSystem gets the MeasurementSystem for the region
        /// </summary>
        /// <param name="regionId">The Id of the region to get the MeasurementSystem for</param>
        /// <returns>The MeasurementSystem for the region</returns>
        public static RegionMeasurementSystem GetMeasurementSystem(string regionId)
        {
            if (NCldr.MeasurementData == null)
            {
                return null;
            }

            RegionMeasurementSystem measurementSystem = (from ms in NCldr.MeasurementData.MeasurementSystems
                                                         where ms.RegionIds.Contains(regionId)
                                                         select ms).FirstOrDefault();

            if (measurementSystem != null)
            {
                // this region has a specific measurement system
                return measurementSystem;
            }

            // there is no specific measurement system for this region so default to the measurement system for the world ("001")
            return (from ms in NCldr.MeasurementData.MeasurementSystems
                    where ms.RegionIds.Contains(NCldr.RegionIdForTheWorld)
                    select ms).FirstOrDefault();
        }

        /// <summary>
        /// GetPaperSize gets the RegionPaperSize for the region
        /// </summary>
        /// <param name="regionId">The Id of the region to get the RegionPaperSize for</param>
        /// <returns>The RegionPaperSize for the region</returns>
        public static RegionPaperSize GetPaperSize(string regionId)
        {
            if (NCldr.MeasurementData == null)
            {
                return null;
            }

            RegionPaperSize paperSize = (from ms in NCldr.MeasurementData.PaperSizes
                                         where ms.RegionIds.Contains(regionId)
                                         select ms).FirstOrDefault();

            if (paperSize != null)
            {
                // this region has a specific paper size
                return paperSize;
            }

            // there is no specific paper size for this region so default to the paper size for the world ("001")
            return (from ms in NCldr.MeasurementData.PaperSizes
                    where ms.RegionIds.Contains(NCldr.RegionIdForTheWorld)
                    select ms).FirstOrDefault();
        }

        /// <summary>
        /// GetFirstDayOfWeek gets the first DayOfWeek for the region
        /// </summary>
        /// <param name="regionId">The Id of the region to get the first DayOfWeek for</param>
        /// <returns>The first DayOfWeek for the region</returns>
        public static DayOfWeek GetFirstDayOfWeek(string regionId)
        {
            if (NCldr.WeekData != null && NCldr.WeekData.FirstDayOfWeeks != null)
            {
                RegionDayOfWeek regionDayOfWeek = (from fdow in NCldr.WeekData.FirstDayOfWeeks
                                                   where fdow.RegionIds.Contains(regionId)
                                                   select fdow).FirstOrDefault();
                if (regionDayOfWeek != null)
                {
                    // there is a specific first day of week for this region
                    return regionDayOfWeek.DayOfWeek;
                }

                // get the first day of week default (i.e. for the world)
                regionDayOfWeek = (from fdow in NCldr.WeekData.FirstDayOfWeeks
                                   where fdow.RegionIds.Contains(NCldr.RegionIdForTheWorld)
                                   select fdow).FirstOrDefault();
                if (regionDayOfWeek != null)
                {
                    return regionDayOfWeek.DayOfWeek;
                }
            }

            return DayOfWeek.Monday;
        }
    }
}
