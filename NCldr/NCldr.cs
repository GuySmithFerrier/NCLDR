namespace NCldr
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Types;

    /// <summary>
    /// NCldr provides access to all of the data in an NCldrData object
    /// </summary>
    public class NCldr
    {
        /// <summary>
        /// Gets or sets the NCldrData object containing the raw CLDR data
        /// </summary>
        private static INCldrData ncldrData;

        /// <summary>
        /// Gets the RegionId that represents the whole world
        /// </summary>
        /// <remarks>In some cases this can be seen as the ultimate fallback for all regions</remarks>
        public const string RegionIdForTheWorld = "001";

        /// <summary>
        /// Gets or sets the array of Culture objects used by the Cultures property
        /// </summary>
        private static Culture[] cultures;

        /// <summary>
        /// Gets a value indicating whether the NCLDR data has been loaded
        /// </summary>
        public static bool IsDataLoaded
        {
            get
            {
                return ncldrData != null;
            }
        }

        /// <summary>
        /// Gets or sets the NCldrData object containing the raw CLDR data
        /// </summary>
        /// <remarks>This property must be set before NCLDR can be used. Typically it is set using
        /// the NCldrDataSource class.</remarks>
        public static INCldrData NCldrData
        {
            get
            {
                if (ncldrData == null)
                {
                    throw new ArgumentException("NCldr.NCldrData must be initialized before NCLDR can be used");
                }

                return ncldrData;
            }

            set
            {
                ncldrData = value;
            }
        }

        /// <summary>
        /// Gets the Unicode Licence Agreement (see http://www.unicode.org/copyright.html#Exhibit1)
        /// </summary>
        public static string UnicodeLicenseAgreement
        {
            get
            {
                return NCldrData.UnicodeLicenseAgreement;
            }
        }

        /// <summary>
        /// Gets the array of CalendarType objects
        /// </summary>
        public static CalendarType[] CalendarTypes
        {
            get
            {
                return NCldrData.CalendarTypes;
            }
        }

        /// <summary>
        /// Gets the array of CalendarPreference objects
        /// </summary>
        public static CalendarPreference[] CalendarPreferences
        {
            get
            {
                return NCldrData.CalendarPreferences;
            }
        }

        /// <summary>
        /// Gets the array of CalendarFallback objects
        /// </summary>
        public static CharacterFallback[] CharacterFallbacks
        {
            get
            {
                return NCldrData.CharacterFallbacks;
            }
        }

        /// <summary>
        /// Gets the array of names of cultures
        /// </summary>
        public static string[] CultureNames
        {
            get
            {
                return NCldrData.CultureNames;
            }
        }

        /// <summary>
        /// Gets the array of CultureData objects representing the raw CLDR data for cultures
        /// </summary>
        /// <remarks>In general use the NCldr.Cultures array instead of the raw data</remarks>
        public static CultureData[] CultureDatas
        {
            get
            {
                return NCldrData.CultureDatas;
            }
        }

        /// <summary>
        /// Gets the array of Culture objects
        /// </summary>
        /// <remarks>Use this property in preference to the NCldr.CultureDatas property.
        /// The Culture class represents a culture that has been fully resolved with its parents' data
        /// whereas the CultureData class is simply the data for a single culture without being
        /// resolved with its parents.</remarks>
        public static Culture[] Cultures
        {
            get
            {
                if (cultures == null)
                {
                    InitializeCultures();
                }

                return cultures;
            }
        }

        /// <summary>
        /// Gets the array of Currency objects
        /// </summary>
        public static Currency[] Currencies
        {
            get
            {
                return NCldrData.Currencies;
            }
        }

        /// <summary>
        /// Gets the array of CurrencyFraction objects
        /// </summary>
        public static CurrencyFraction[] CurrencyFractions
        {
            get
            {
                return NCldrData.CurrencyFractions;
            }
        }

        /// <summary>
        /// Gets the array of DayPeriodRuleSet objects
        /// </summary>
        public static DayPeriodRuleSet[] DayPeriodRuleSets
        {
            get
            {
                return NCldrData.DayPeriodRuleSets;
            }
        }

        /// <summary>
        /// Gets the array of GenderList objects
        /// </summary>
        public static GenderList[] GenderLists
        {
            get
            {
                return NCldrData.GenderLists;
            }
        }

        /// <summary>
        /// Gets the array of LanguageMatch objects
        /// </summary>
        public static LanguageMatch[] LanguageMatches
        {
            get
            {
                return NCldrData.LanguageMatches;
            }
        }

        /// <summary>
        /// Gets the array of LikelySubTag objects
        /// </summary>
        public static LikelySubTag[] LikelySubTags
        {
            get
            {
                return NCldrData.LikelySubTags;
            }
        }

        /// <summary>
        /// Gets the MeasurementData object
        /// </summary>
        public static MeasurementData MeasurementData
        {
            get
            {
                return NCldrData.MeasurementData;
            }
        }

        /// <summary>
        /// Gets the array of MetaTimeZone objects
        /// </summary>
        public static MetaTimeZone[] MetaTimeZones
        {
            get
            {
                return NCldrData.MetaTimeZones;
            }
        }

        /// <summary>
        /// Gets the array of NumberingSystemType objects
        /// </summary>
        public static NumberingSystemType[] NumberingSystems
        {
            get
            {
                return NCldrData.NumberingSystems;
            }
        }

        /// <summary>
        /// Gets the array of PluralRuleSet objects used for ordinal rules
        /// </summary>
        public static PluralRuleSet[] OrdinalRuleSets
        {
            get
            {
                return NCldrData.OrdinalRuleSets;
            }
        }

        /// <summary>
        /// Gets the array of ParentCulture objects used to determine parents of cultures that do
        /// not obey the naming convention culture inheritance
        /// </summary>
        public static ParentCulture[] ParentCultures
        {
            get
            {
                return NCldrData.ParentCultures;
            }
        }

        /// <summary>
        /// Gets the array of PluralRuleSet objects used for plural rules
        /// </summary>
        public static PluralRuleSet[] PluralRuleSets
        {
            get
            {
                return NCldrData.PluralRuleSets;
            }
        }

        /// <summary>
        /// Gets the array of PostcodeRegex objects for all regions
        /// </summary>
        public static PostcodeRegex[] PostcodeRegexes
        {
            get
            {
                return NCldrData.PostcodeRegexes;
            }
        }

        /// <summary>
        /// Gets the array of CLDR references
        /// </summary>
        public static Reference[] References
        {
            get
            {
                return NCldrData.References;
            }
        }

        /// <summary>
        /// Gets the array of RegionCode objects
        /// </summary>
        public static RegionCode[] RegionCodes
        {
            get
            {
                return NCldrData.RegionCodes;
            }
        }

        /// <summary>
        /// Gets the array of RegionGroup objects that indicate which regions own other regions
        /// </summary>
        public static RegionGroup[] RegionGroups
        {
            get
            {
                return NCldrData.RegionGroups;
            }
        }

        /// <summary>
        /// Gets the array of RegionInformation objects
        /// </summary>
        public static RegionInformation[] RegionInformations
        {
            get
            {
                return NCldrData.RegionInformations;
            }
        }

        /// <summary>
        /// Gets the array of RegionTelephoneCode objects
        /// </summary>
        public static RegionTelephoneCode[] RegionTelephoneCodes
        {
            get
            {
                return NCldrData.RegionTelephoneCodes;
            }
        }

        /// <summary>
        /// Gets the TimeData object
        /// </summary>
        public static TimeData TimeData
        {
            get
            {
                return NCldrData.TimeData;
            }
        }

        /// <summary>
        /// Gets the array of TimeZoneInformation objects
        /// </summary>
        public static TimeZoneInformation[] TimeZones
        {
            get
            {
                return NCldrData.TimeZones;
            }
        }

        /// <summary>
        /// Gets the WeekData object
        /// </summary>
        public static WeekData WeekData
        {
            get
            {
                return NCldrData.WeekData;
            }
        }

        /// <summary>
        /// Gets the array of Windows MetaTimeZone objects
        /// </summary>
        public static MetaTimeZone[] WindowsMetaTimeZones
        {
            get
            {
                return NCldrData.WindowsMetaTimeZones;
            }
        }

        /// <summary>
        /// GetCurrencyFraction gets a CurrencyFraction for a given currency Id
        /// </summary>
        /// <param name="currencyId">The currency Id to get the CurrencyFraction for</param>
        /// <returns>A CurrencyFraction for a given currency Id</returns>
        public static CurrencyFraction GetCurrencyFraction(string currencyId)
        {
            if (NCldr.CurrencyFractions == null)
            {
                return null;
            }

            CurrencyFraction currencyFraction = (from cf in NCldr.CurrencyFractions
                                                 where string.Compare(cf.Id, currencyId, StringComparison.InvariantCulture) == 0
                                                 select cf).FirstOrDefault();
            if (currencyFraction != null)
            {
                return currencyFraction;
            }

            // return the default
            return (from cf in NCldr.CurrencyFractions
                    where string.Compare(cf.Id, "DEFAULT", StringComparison.InvariantCulture) == 0
                    select cf).FirstOrDefault();
        }

        /// <summary>
        /// InitializeCultures initializes the array of Cultures
        /// </summary>
        private static void InitializeCultures()
        {
            List<Culture> cultureList = new List<Culture>();
            foreach (CultureData cultureData in CultureDatas)
            {
                cultureList.Add(new Culture(cultureData));
            }

            cultures = cultureList.ToArray();
        }
    }
}
