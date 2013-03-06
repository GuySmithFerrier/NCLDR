namespace NCldr.Extensions
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Types;

    /// <summary>
    /// CultureExtensions is a set of methods that provide easy access to NCLDR data for cultures
    /// </summary>
    public static class CultureExtensions
    {
        /// <summary>
        /// GetCurrencyDisplayName gets the localized display name of a currency in a given language
        /// </summary>
        /// <param name="currencyName">The currency to get the localized display name for</param>
        /// <param name="languageId">The language in which to get the localized display name</param>
        /// <returns>The localized display name of a currency in a given language</returns>
        public static string GetCurrencyDisplayName(string currencyName, string languageId)
        {
            Culture culture = Culture.GetCulture(languageId);
            if (culture == null || culture.Numbers == null || culture.Numbers.CurrencyDisplayNameSets == null)
            {
                return null;
            }

            CurrencyDisplayNameSet currencyDisplayNameSet =
                (from cdns in culture.Numbers.CurrencyDisplayNameSets
                 where string.Compare(cdns.Id, currencyName, false, CultureInfo.InvariantCulture) == 0
                 select cdns).FirstOrDefault();

            if (currencyDisplayNameSet != null)
            {
                CurrencyDisplayName currencyDisplayName = (from cdn in currencyDisplayNameSet.CurrencyDisplayNames
                                                           where cdn.Id == null
                                                           select cdn).FirstOrDefault();
                if (currencyDisplayName != null)
                {
                    return currencyDisplayName.Name;
                }
            }

            return null;
        }

        /// <summary>
        /// GetCurrency gets the current CLDR currency Id for the given culture
        /// </summary>
        /// <param name="cultureName">The name of the culture to get the currency for</param>
        /// <returns>The current CLDR currency Id for the given culture</returns>
        public static string GetCurrency(string cultureName)
        {
            CurrencyPeriod[] currencyPeriods = GetCurrencyPeriods(cultureName, DateTime.Now);
            if (currencyPeriods == null || currencyPeriods.GetLength(0) == 0)
            {
                return null;
            }

            return currencyPeriods[0].Id;
        }

        /// <summary>
        /// GetCurrencyPeriods gets an array of CurrencyPeriods for a culture
        /// </summary>
        /// <param name="cultureName">The culture name to get the CurrencyPeriods for</param>
        /// <returns>An array of CurrencyPeriods for a culture</returns>
        public static CurrencyPeriod[] GetCurrencyPeriods(string cultureName)
        {
            CultureData culture = CultureData.GetCulture(cultureName);
            if (culture != null && culture.Numbers != null && culture.Numbers.CurrencyPeriods != null)
            {
                return culture.Numbers.CurrencyPeriods;
            }

            return null;
        }

        /// <summary>
        /// GetCurrencyPeriods gets an array of CurrencyPeriods for a culture for a given datetime
        /// </summary>
        /// <param name="cultureName">The culture name to get the CurrencyPeriods for</param>
        /// <param name="dateTime">The DateTime to get the CurrencyPeriods for</param>
        /// <returns>An array of CurrencyPeriods for a culture for a given datetime</returns>
        public static CurrencyPeriod[] GetCurrencyPeriods(string cultureName, DateTime dateTime)
        {
            CultureData culture = CultureData.GetCulture(cultureName);
            if (culture != null && culture.Numbers != null && culture.Numbers.CurrencyPeriods != null)
            {
                return (from cp in culture.Numbers.CurrencyPeriods
                        where (cp.From == null || cp.From < dateTime)
                        && (cp.To == null || cp.To > dateTime)
                        select cp).ToArray();
            }

            return null;
        }

        /// <summary>
        /// GetCasing gets the CLDR Casing for the culture
        /// </summary>
        /// <param name="cultureName">The culture name to get the CLDR Casing for</param>
        /// <returns>The CLDR Casing for the culture</returns>
        public static Casing GetCasing(string cultureName)
        {
            Culture culture = Culture.GetCulture(cultureName);
            if (culture == null)
            {
                return null;
            }

            return culture.Casing;
        }

        /// <summary>
        /// GetCharacters gets the CLDR Characters for the culture
        /// </summary>
        /// <param name="cultureName">The culture name to get the CLDR Characters for</param>
        /// <returns>The CLDR Characters for the culture</returns>
        public static Characters GetCharacters(string cultureName)
        {
            Culture culture = Culture.GetCulture(cultureName);
            if (culture == null)
            {
                return null;
            }

            return culture.Characters;
        }

        /// <summary>
        /// GetDayPeriodRules gets the CLDR DayPeriodRules for the culture
        /// </summary>
        /// <param name="cultureName">The culture name to get the CLDR DayPeriodRules for</param>
        /// <returns>The CLDR DayPeriodRules for the culture</returns>
        public static DayPeriodRule[] GetDayPeriodRules(string cultureName)
        {
            string language = GetLanguage(cultureName);

            foreach (DayPeriodRuleSet dayPeriodRuleSet in NCldr.DayPeriodRuleSets)
            {
                string[] cultures = dayPeriodRuleSet.CultureNames;
                if (cultures.Contains(language))
                {
                    return dayPeriodRuleSet.DayPeriodRules;
                }
            }

            // default to the "root"
            return (from dprs in NCldr.DayPeriodRuleSets
                    where dprs.CultureNames.GetLength(0) == 1 && string.Compare(dprs.CultureNames[0], "root", false, CultureInfo.InvariantCulture) == 0
                    select dprs.DayPeriodRules).FirstOrDefault();
        }

        /// <summary>
        /// GetDelimiters gets the CLDR Delimiters for the culture
        /// </summary>
        /// <param name="cultureName">The culture name to get the CLDR Delimiters for</param>
        /// <returns>The CLDR Delimiters for the culture</returns>
        public static Delimiters GetDelimiters(string cultureName)
        {
            Culture culture = Culture.GetCulture(cultureName);
            if (culture == null)
            {
                return null;
            }

            return culture.Delimiters;
        }

        /// <summary>
        /// GetGenderListId gets the CLDR GenderList identifier for the culture
        /// </summary>
        /// <param name="cultureName">The culture name to get the CLDR GenderList identifier for</param>
        /// <returns>The CLDR GenderList identifier for the culture</returns>
        public static string GetGenderListId(string cultureName)
        {
            if (NCldr.GenderLists == null)
            {
                return null;
            }

            string language = GetLanguage(cultureName);

            return (from gl in NCldr.GenderLists
                    where gl.CultureIds.Contains(language)
                    select gl.Id).FirstOrDefault();
        }

        /// <summary>
        /// GetLikelySubTag gets the most likely child culture name from a parent culture name
        /// </summary>
        /// <param name="cultureName">The culture name to get the sub tag for</param>
        /// <returns>The most likely child culture name for the parent culture name</returns>
        public static string GetLikelySubTag(string cultureName)
        {
            if (NCldr.LikelySubTags == null)
            {
                return null;
            }

            return (from lst in NCldr.LikelySubTags
                    where string.Compare(lst.FromCultureId, cultureName, true, CultureInfo.InvariantCulture) == 0
                    select lst.ToCultureId).FirstOrDefault();
        }

        /// <summary>
        /// GetListPatterns gets the CLDR ListPatterns for the culture
        /// </summary>
        /// <param name="cultureName">The culture name to get the CLDR ListPatterns for</param>
        /// <returns>The CLDR ListPatterns for the culture</returns>
        public static ListPattern[] GetListPatterns(string cultureName)
        {
            Culture culture = Culture.GetCulture(cultureName);
            if (culture == null)
            {
                return null;
            }

            return culture.ListPatterns;
        }

        /// <summary>
        /// GetNumbers gets the CLDR Numbers for the culture
        /// </summary>
        /// <param name="cultureName">The culture name to get the CLDR Numbers for</param>
        /// <returns>The CLDR Numbers for the culture</returns>
        public static Numbers GetNumbers(string cultureName)
        {
            Culture culture = Culture.GetCulture(cultureName);
            if (culture == null)
            {
                return null;
            }

            return culture.Numbers;
        }

        /// <summary>
        /// GetPluralRules gets the CLDR PluralRules for the culture
        /// </summary>
        /// <param name="cultureName">The culture name to get the CLDR PluralRules for</param>
        /// <returns>The CLDR PluralRules for the culture</returns>
        public static PluralRule[] GetPluralRules(string cultureName)
        {
            return GetPluralRules(NCldr.PluralRuleSets, cultureName);
        }

        /// <summary>
        /// GetOrdinalRules gets the CLDR ordinal PluralRules for the culture
        /// </summary>
        /// <param name="cultureName">The culture name to get the CLDR ordinal PluralRules for</param>
        /// <returns>The CLDR ordinal PluralRules for the culture</returns>
        public static PluralRule[] GetOrdinalRules(string cultureName)
        {
            return GetPluralRules(NCldr.OrdinalRuleSets, cultureName);
        }

        /// <summary>
        /// GetPluralRule gets the CLDR PluralRule for the integer for the culture
        /// </summary>
        /// <param name="cultureName">The culture name to get the CLDR PluralRule for</param>
        /// <param name="value">The integer to get the PluralRule for</param>
        /// <returns>The CLDR PluralRule for the integer for the culture</returns>
        public static PluralRule GetPluralRule(string cultureName, int value)
        {
            return GetPluralRule(GetPluralRules(cultureName), value);
        }

        /// <summary>
        /// GetOrdinalRule gets the CLDR ordinal PluralRule for the integer for the culture
        /// </summary>
        /// <param name="cultureName">The culture name to get the CLDR ordinal PluralRule for</param>
        /// <param name="value">The integer to get the ordinal PluralRule for</param>
        /// <returns>The CLDR ordinal PluralRule for the integer for the culture</returns>
        public static PluralRule GetOrdinalRule(string cultureName, int value)
        {
            return GetPluralRule(GetOrdinalRules(cultureName), value);
        }

        /// <summary>
        /// GetRuleBasedNumberFormatting gets the CLDR RuleBasedNumberFormatting for the culture
        /// </summary>
        /// <param name="cultureName">The culture name to get the CLDR RuleBasedNumberFormatting for</param>
        /// <returns>The CLDR RuleBasedNumberFormatting for the culture</returns>
        public static RuleBasedNumberFormatting GetRuleBasedNumberFormatting(string cultureName)
        {
            Culture culture = Culture.GetCulture(cultureName);
            if (culture == null)
            {
                return null;
            }

            return culture.RuleBasedNumberFormatting;
        }

        /// <summary>
        /// GetUnitPatternSets gets the CLDR UnitPatternSets for the culture
        /// </summary>
        /// <param name="cultureName">The culture name to get the CLDR UnitPatternSets for</param>
        /// <returns>The CLDR UnitPatternSets for the culture</returns>
        public static UnitPatternSet[] GetUnitPatternSets(string cultureName)
        {
            Culture culture = Culture.GetCulture(cultureName);
            if (culture == null)
            {
                return null;
            }

            return culture.UnitPatternSets;
        }

        /// <summary>
        /// GetYes gets the localized 'Yes' string for the culture
        /// </summary>
        /// <param name="cultureName">The culture name to get the localized 'Yes' string for</param>
        /// <returns>The localized 'Yes' string for the culture</returns>
        public static string GetYes(string cultureName)
        {
            Culture culture = Culture.GetCulture(cultureName);
            if (culture.Messages == null)
            {
                return null;
            }

            return culture.Messages.Yes;
        }

        /// <summary>
        /// GetYes gets the localized short 'Yes' string for the culture
        /// </summary>
        /// <param name="cultureName">The culture name to get the localized short 'Yes' string for</param>
        /// <returns>The localized short 'Yes' string for the culture</returns>
        public static string GetYesShort(string cultureName)
        {
            Culture culture = Culture.GetCulture(cultureName);
            if (culture.Messages == null)
            {
                return null;
            }

            return culture.Messages.YesShort;
        }

        /// <summary>
        /// GetNo gets the localized 'No' string for the culture
        /// </summary>
        /// <param name="cultureName">The culture name to get the localized 'No' string for</param>
        /// <returns>The localized 'No' string for the culture</returns>
        public static string GetNo(string cultureName)
        {
            Culture culture = Culture.GetCulture(cultureName);
            if (culture.Messages == null)
            {
                return null;
            }

            return culture.Messages.No;
        }

        /// <summary>
        /// GetNo gets the localized short 'No' string for the culture
        /// </summary>
        /// <param name="cultureName">The culture name to get the localized short 'No' string for</param>
        /// <returns>The localized short 'No' string for the culture</returns>
        public static string GetNoShort(string cultureName)
        {
            Culture culture = Culture.GetCulture(cultureName);
            if (culture.Messages == null)
            {
                return null;
            }

            return culture.Messages.NoShort;
        }

        /// <summary>
        /// GetLanguage gets the language from a culture name
        /// </summary>
        /// <param name="cultureName">The culture name to get the language for</param>
        /// <returns>The language of the culture</returns>
        private static string GetLanguage(string cultureName)
        {
            if (cultureName.IndexOf("-") > -1)
            {
                return cultureName.Split('-')[0];
            }

            return cultureName;
        }

        /// <summary>
        /// GetPluralRules gets the PluralRules that match the language of a culture from an array of sets of PluralRules
        /// </summary>
        /// <param name="pluralRuleSets">An array of sets of PluralRules</param>
        /// <param name="cultureName">The culture name to get the PluralRules for</param>
        /// <returns>An array of PluralRules that match the language of a culture from an array of sets of PluralRules</returns>
        private static PluralRule[] GetPluralRules(PluralRuleSet[] pluralRuleSets, string cultureName)
        {
            string language = GetLanguage(cultureName);
            foreach (PluralRuleSet pluralRuleSet in pluralRuleSets)
            {
                if (pluralRuleSet.CultureNames.Contains(language))
                {
                    return pluralRuleSet.PluralRules;
                }
            }

            return null;
        }

        /// <summary>
        /// GetPluralRule gets the CLDR PluralRule for the integer from the array of PluralRules
        /// </summary>
        /// <param name="pluralRules">The array of PluralRules to get a match from</param>
        /// <param name="value">The integer to find a match for</param>
        /// <returns>The CLDR PluralRule for the integer from the array of PluralRules</returns>
        private static PluralRule GetPluralRule(PluralRule[] pluralRules, int value)
        {
            foreach (PluralRule pluralRule in pluralRules)
            {
                if (pluralRule.IsMatch(value))
                {
                    return pluralRule;
                }
            }

            return null;
        }
    }
}
