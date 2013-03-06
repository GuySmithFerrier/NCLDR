namespace NCldr.Extensions
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Types;

    /// <summary>
    /// CultureInfoExtensions is a collection of extension methods for the CultureInfo class to access CLDR data as well as static methods to access CLDR data from culture names
    /// </summary>
    public static class CultureInfoExtensions
    {
        /// <summary>
        /// GetCurrency gets the CLDR currency for a CultureInfo
        /// </summary>
        /// <param name="cultureInfo">The CultureInfo to get the CLDR currency for</param>
        /// <returns>The CLDR currency for a CultureInfo</returns>
        public static string GetCurrency(this CultureInfo cultureInfo)
        {
            return CultureExtensions.GetCurrency(GetNCldrCultureName(cultureInfo));
        }

                /// <summary>
        /// GetCurrencyPeriods gets an array of CurrencyPeriods for a CultureInfo
        /// </summary>
        /// <param name="cultureInfo">The CultureInfo to get the CurrencyPeriods for</param>
        /// <returns>An array of CurrencyPeriods for a CultureInfo</returns>
        public static CurrencyPeriod[] GetCurrencyPeriods(this CultureInfo cultureInfo)
        {
            return CultureExtensions.GetCurrencyPeriods(GetNCldrCultureName(cultureInfo));
        }

        /// <summary>
        /// GetCurrencyPeriods gets an array of CurrencyPeriods for a CultureInfo for a given datetime
        /// </summary>
        /// <param name="cultureInfo">The CultureInfo to get the CurrencyPeriods for</param>
        /// <param name="dateTime">The DateTime to get the CurrencyPeriods for</param>
        /// <returns>An array of CurrencyPeriods for a CultureInfo for a given datetime</returns>
        public static CurrencyPeriod[] GetCurrencyPeriods(this CultureInfo cultureInfo, DateTime dateTime)
        {
            return CultureExtensions.GetCurrencyPeriods(GetNCldrCultureName(cultureInfo), dateTime);
        }

        /// <summary>
        /// GetCasing gets the CLDR Casing for the CultureInfo
        /// </summary>
        /// <param name="cultureInfo">The CultureInfo to get the CLDR Casing for</param>
        /// <returns>The CLDR Casing for the CultureInfo</returns>
        public static Casing GetCasing(this CultureInfo cultureInfo)
        {
            return CultureExtensions.GetCasing(GetNCldrCultureName(cultureInfo));
        }

        /// <summary>
        /// GetCharacters gets the CLDR Characters for the CultureInfo
        /// </summary>
        /// <param name="cultureInfo">The CultureInfo to get the CLDR Characters for</param>
        /// <returns>The CLDR Characters for the CultureInfo</returns>
        public static Characters GetCharacters(this CultureInfo cultureInfo)
        {
            return CultureExtensions.GetCharacters(GetNCldrCultureName(cultureInfo));
        }

        /// <summary>
        /// GetDayPeriodRules gets the CLDR DayPeriodRules for the CultureInfo
        /// </summary>
        /// <param name="cultureInfo">The CultureInfo to get the CLDR DayPeriodRules for</param>
        /// <returns>The CLDR DayPeriodRules for the CultureInfo</returns>
        public static DayPeriodRule[] GetDayPeriodRules(this CultureInfo cultureInfo)
        {
            return CultureExtensions.GetDayPeriodRules(GetNeutralCultureInfo(cultureInfo).Name);
        }

        /// <summary>
        /// GetDelimiters gets the CLDR Delimiters for the CultureInfo
        /// </summary>
        /// <param name="cultureInfo">The CultureInfo to get the CLDR Delimiters for</param>
        /// <returns>The CLDR Delimiters for the CultureInfo</returns>
        public static Delimiters GetDelimiters(this CultureInfo cultureInfo)
        {
            return CultureExtensions.GetDelimiters(GetNCldrCultureName(cultureInfo));
        }

        /// <summary>
        /// GetGenderListId gets the CLDR GenderList identifier for the CultureInfo
        /// </summary>
        /// <param name="cultureInfo">The CultureInfo to get the CLDR DayPeriodRules for</param>
        /// <returns>The CLDR GenderList identifier for the CultureInfo</returns>
        public static string GetGenderListId(this CultureInfo cultureInfo)
        {
            return CultureExtensions.GetGenderListId(GetNeutralCultureInfo(cultureInfo).Name);
        }

        /// <summary>
        /// GetLikelySubTag gets the most likely child culture name from a parent CultureInfo
        /// </summary>
        /// <param name="cultureInfo">The CultureInfo to get the sub tag for</param>
        /// <returns>The most likely child culture name for the parent CultureInfo</returns>
        public static string GetLikelySubTag(this CultureInfo cultureInfo)
        {
            return CultureExtensions.GetLikelySubTag(GetNCldrCultureName(cultureInfo));
        }

        /// <summary>
        /// GetListPatterns gets the CLDR ListPatterns for the CultureInfo
        /// </summary>
        /// <param name="cultureInfo">The CultureInfo to get the CLDR ListPatterns for</param>
        /// <returns>The CLDR ListPatterns for the CultureInfo</returns>
        public static ListPattern[] GetListPatterns(this CultureInfo cultureInfo)
        {
            return CultureExtensions.GetListPatterns(GetNCldrCultureName(cultureInfo));
        }

        /// <summary>
        /// GetNumbers gets the CLDR Numbers for the CultureInfo
        /// </summary>
        /// <param name="cultureInfo">The CultureInfo to get the Numbers</param>
        /// <returns>The CLDR Numbers for the CultureInfo</returns>
        public static Numbers GetNumbers(this CultureInfo cultureInfo)
        {
            return CultureExtensions.GetNumbers(GetNCldrCultureName(cultureInfo));
        }

        /// <summary>
        /// GetPluralRules gets the CLDR PluralRules for the CultureInfo
        /// </summary>
        /// <param name="cultureInfo">The CultureInfo to get the CLDR PluralRules for</param>
        /// <returns>The CLDR PluralRules for the CultureInfo</returns>
        public static PluralRule[] GetPluralRules(this CultureInfo cultureInfo)
        {
            return CultureExtensions.GetPluralRules(GetNCldrCultureName(GetNeutralCultureInfo(cultureInfo)));
        }

        /// <summary>
        /// GetPluralRule gets the CLDR PluralRule for the integer for the CultureInfo
        /// </summary>
        /// <param name="cultureInfo">The CultureInfo to get the CLDR PluralRule for</param>
        /// <param name="value">The integer to get the PluralRule for</param>
        /// <returns>The CLDR PluralRule for the integer for the CultureInfo</returns>
        public static PluralRule GetPluralRule(this CultureInfo cultureInfo, int value)
        {
            return CultureExtensions.GetPluralRule(GetNCldrCultureName(GetNeutralCultureInfo(cultureInfo)), value);
        }

        /// <summary>
        /// GetOrdinalRules gets the CLDR ordinal PluralRules for the CultureInfo
        /// </summary>
        /// <param name="cultureInfo">The CultureInfo to get the CLDR ordinal PluralRules for</param>
        /// <returns>The CLDR ordinal PluralRules for the CultureInfo</returns>
        public static PluralRule[] GetOrdinalRules(this CultureInfo cultureInfo)
        {
            return CultureExtensions.GetOrdinalRules(GetNCldrCultureName(GetNeutralCultureInfo(cultureInfo)));
        }

        /// <summary>
        /// GetOrdinalRule gets the CLDR ordinal PluralRule for the integer for the CultureInfo
        /// </summary>
        /// <param name="cultureInfo">The CultureInfo to get the CLDR ordinal PluralRule for</param>
        /// <param name="value">The integer to get the ordinal PluralRule for</param>
        /// <returns>The CLDR ordinal PluralRule for the integer for the CultureInfo</returns>
        public static PluralRule GetOrdinalRule(this CultureInfo cultureInfo, int value)
        {
            return CultureExtensions.GetOrdinalRule(GetNCldrCultureName(GetNeutralCultureInfo(cultureInfo)), value);
        }

        /// <summary>
        /// GetPostcodeRegex gets the postal code regular expression for the CultureInfo
        /// </summary>
        /// <param name="cultureInfo">The CultureInfo to get the postal code regular expression for</param>
        /// <returns>The postal code regular expression for the CultureInfo</returns>
        public static string GetPostcodeRegex(this CultureInfo cultureInfo)
        {
            AssertHasRegionInfo(cultureInfo);
            RegionInfo regionInfo = new RegionInfo(cultureInfo.Name);
            return RegionExtensions.GetPostcodeRegex(regionInfo.TwoLetterISORegionName);
        }

        /// <summary>
        /// GetRegionInformation gets the RegionInformation for the CultureInfo
        /// </summary>
        /// <param name="cultureInfo">The CultureInfo to get the RegionInformation for</param>
        /// <returns>The RegionInformation for the CultureInfo</returns>
        public static RegionInformation GetRegionInformation(this CultureInfo cultureInfo)
        {
            AssertHasRegionInfo(cultureInfo);
            RegionInfo regionInfo = new RegionInfo(cultureInfo.Name);
            return RegionExtensions.GetRegionInformation(regionInfo.TwoLetterISORegionName);
        }

        /// <summary>
        /// GetUnitPatternSets gets the CLDR UnitPatternSets for the CultureInfo
        /// </summary>
        /// <param name="cultureInfo">The CultureInfo to get the UnitPatternSets for</param>
        /// <returns>The CLDR UnitPatternSets for the CultureInfo</returns>
        public static UnitPatternSet[] GetUnitPatternSets(this CultureInfo cultureInfo)
        {
            return CultureExtensions.GetUnitPatternSets(GetNCldrCultureName(cultureInfo));
        }

        /// <summary>
        /// GetRuleBasedNumberFormatting gets the CLDR RuleBasedNumberFormatting for the CultureInfo
        /// </summary>
        /// <param name="cultureInfo">The CultureInfo to get the RuleBasedNumberFormatting for</param>
        /// <returns>The CLDR RuleBasedNumberFormatting for the CultureInfo</returns>
        public static RuleBasedNumberFormatting GetRuleBasedNumberFormatting(this CultureInfo cultureInfo)
        {
            return CultureExtensions.GetRuleBasedNumberFormatting(GetNCldrCultureName(cultureInfo));
        }

        /// <summary>
        /// GetYes gets the localized 'Yes' string for the CultureInfo
        /// </summary>
        /// <param name="cultureInfo">The CultureInfo to get the localized 'Yes' string for</param>
        /// <returns>The localized 'Yes' string for the CultureInfo</returns>
        public static string GetYes(this CultureInfo cultureInfo)
        {
            return CultureExtensions.GetYes(GetNCldrCultureName(cultureInfo));
        }

        /// <summary>
        /// GetYes gets the localized short 'Yes' string for the CultureInfo
        /// </summary>
        /// <param name="cultureInfo">The CultureInfo to get the localized short 'Yes' string for</param>
        /// <returns>The localized short 'Yes' string for the CultureInfo</returns>
        public static string GetYesShort(this CultureInfo cultureInfo)
        {
            return CultureExtensions.GetYesShort(GetNCldrCultureName(cultureInfo));
        }

        /// <summary>
        /// GetNo gets the localized 'No' string for the CultureInfo
        /// </summary>
        /// <param name="cultureInfo">The CultureInfo to get the localized 'No' string for</param>
        /// <returns>The localized 'No' string for the CultureInfo</returns>
        public static string GetNo(this CultureInfo cultureInfo)
        {
            return CultureExtensions.GetNo(GetNCldrCultureName(cultureInfo));
        }

        /// <summary>
        /// GetNo gets the localized short 'No' string for the CultureInfo
        /// </summary>
        /// <param name="cultureInfo">The CultureInfo to get the localized short 'No' string for</param>
        /// <returns>The localized short 'No' string for the CultureInfo</returns>
        public static string GetNoShort(this CultureInfo cultureInfo)
        {
            return CultureExtensions.GetNoShort(GetNCldrCultureName(cultureInfo));
        }

        /// <summary>
        /// GetNeutralCultureInfo gets the neutral culture that the CultureInfo falls back to
        /// </summary>
        /// <param name="cultureInfo">The CultureInfo to get the neutral culture for</param>
        /// <returns>The neutral culture that the CultureInfo falls back to</returns>
        private static CultureInfo GetNeutralCultureInfo(CultureInfo cultureInfo)
        {
            if (cultureInfo.IsNeutralCulture || cultureInfo == CultureInfo.InvariantCulture || cultureInfo.Parent == null)
            {
                return cultureInfo;
            }

            return GetNeutralCultureInfo(cultureInfo.Parent);
        }

        /// <summary>
        /// AssertHasRegionInfo throws an exception if the CultureInfo does not have a region
        /// </summary>
        /// <param name="cultureInfo">The CultureInfo to check</param>
        private static void AssertHasRegionInfo(CultureInfo cultureInfo)
        {
            if (cultureInfo.IsNeutralCulture)
            {
                throw new ArgumentException("CultureInfo must have a region to get a RegionInformation");
            }
        }

        /// <summary>
        /// GetNCldrCultureName gets an NCLDR culture name from a .NET culture name
        /// </summary>
        /// <param name="cultureInfo">The CultureInfo to get the NCLDR culture name for</param>
        /// <returns>An NCLDR culture name from a .NET culture name</returns>
        private static string GetNCldrCultureName(CultureInfo cultureInfo)
        {
            if (cultureInfo.Equals(CultureInfo.InvariantCulture))
            {
                // The CLDR equivalent to .NET's Invariant Culture is the "root" culture
                return "root";
            }

            return cultureInfo.Name;
        }
    }
}
