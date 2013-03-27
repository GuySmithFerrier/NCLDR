namespace NCldr.Extensions
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Types;

    /// <summary>
    /// RegionInfoExtensions is a collection of extension methods for the RegionInfo class to access CLDR data as well as static methods to access CLDR data from region names
    /// </summary>
    public static class RegionInfoExtensions
    {
        /// <summary>
        /// GetPostcodeRegex gets the postal code regular expression for the RegionInfo
        /// </summary>
        /// <param name="regionInfo">The RegionInfo to get the postal code regular expression for</param>
        /// <returns>The postal code regular expression for the RegionInfo</returns>
        public static string GetPostcodeRegex(this RegionInfo regionInfo)
        {
            return RegionExtensions.GetPostcodeRegex(regionInfo.Name);
        }

        /// <summary>
        /// GetTelephoneCodes gets an array of telephone codes used by the RegionInfo
        /// </summary>
        /// <param name="regionInfo">The RegionInfo to get the telephone codes for</param>
        /// <returns>An array of telephone codes used by the RegionInfo</returns>
        public static string[] GetTelephoneCodes(this RegionInfo regionInfo)
        {
            return RegionExtensions.GetTelephoneCodes(regionInfo.Name);
        }

        /// <summary>
        /// GetTelephoneCode gets the telephone code used by the RegionInfo
        /// </summary>
        /// <param name="regionInfo">The RegionInfo to get the telephone code for</param>
        /// <returns>The telephone code used by the RegionInfo</returns>
        /// <remarks>GetTelephoneCode gets only the first telephone code used by the region.
        /// There is only one telephone code when a region is a country/region. Only when a region
        /// is larger than a country/region (e.g. The World) will it have more than one telephone code.</remarks>
        public static string GetTelephoneCode(this RegionInfo regionInfo)
        {
            return RegionExtensions.GetTelephoneCode(regionInfo.Name);
        }

        /// <summary>
        /// GetRegionCode gets the RegionCode for the RegionInfo
        /// </summary>
        /// <param name="regionInfo">The RegionInfo to get the RegionCode for</param>
        /// <returns>The RegionCode for the RegionInfo</returns>
        public static RegionCode GetRegionCode(this RegionInfo regionInfo)
        {
            return RegionExtensions.GetRegionCode(regionInfo.Name);
        }

        /// <summary>
        /// GetRegionInformation gets the RegionInformation for the RegionInfo
        /// </summary>
        /// <param name="regionInfo">The RegionInfo to get the RegionInformation for</param>
        /// <returns>The RegionInformation for the RegionInfo</returns>
        public static RegionInformation GetRegionInformation(this RegionInfo regionInfo)
        {
            return RegionExtensions.GetRegionInformation(regionInfo.Name);
        }

        /// <summary>
        /// GetMeasurementSystem gets the MeasurementSystem for the RegionInfo
        /// </summary>
        /// <param name="regionInfo">The RegionInfo to get the MeasurementSystem for</param>
        /// <returns>The MeasurementSystem for the RegionInfo</returns>
        public static RegionMeasurementSystem GetMeasurementSystem(this RegionInfo regionInfo)
        {
            return RegionExtensions.GetMeasurementSystem(regionInfo.Name);
        }

        /// <summary>
        /// GetPaperSize gets the RegionPaperSize for the RegionInfo
        /// </summary>
        /// <param name="regionInfo">The RegionInfo to get the RegionPaperSize for</param>
        /// <returns>The RegionPaperSize for the RegionInfo</returns>
        public static RegionPaperSize GetPaperSize(this RegionInfo regionInfo)
        {
            return RegionExtensions.GetPaperSize(regionInfo.Name);
        }

        /// <summary>
        /// GetDayOfWeek gets the first DayOfWeek for the RegionInfo
        /// </summary>
        /// <param name="regionInfo">The RegionInfo to get the first DayOfWeek for</param>
        /// <returns>The first DayOfWeek for the RegionInfo</returns>
        public static DayOfWeek GetDayOfWeek(this RegionInfo regionInfo)
        {
            return RegionExtensions.GetFirstDayOfWeek(regionInfo.Name);
        }

        /// <summary>
        /// GetHour gets the RegionHour for the RegionInfo
        /// </summary>
        /// <param name="regionInfo">The RegionInfo to get the RegionHour for</param>
        /// <returns>The RegionHour for the RegionInfo</returns>
        public static RegionHour GetHour(this RegionInfo regionInfo)
        {
            return RegionExtensions.GetHour(regionInfo.Name);
        }
    }
}
