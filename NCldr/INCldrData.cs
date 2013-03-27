namespace NCldr
{
    using Types;

    /// <summary>
    /// INCldrData represents an interface for the 'raw' CLDR data
    /// </summary>
    public interface INCldrData
    {
        /// <summary>
        /// Gets or sets the array of CalendarFallback objects
        /// </summary>
        CharacterFallback[] CharacterFallbacks { get; set; }

        /// <summary>
        /// Gets or sets the array of names of cultures
        /// </summary>
        string[] CultureNames { get; set; }

        /// <summary>
        /// Gets or sets the array of CultureData objects
        /// </summary>
        CultureData[] CultureDatas { get; set; }

        /// <summary>
        /// Gets or sets the array of Currency objects
        /// </summary>
        Currency[] Currencies { get; set; }

        /// <summary>
        /// Gets or sets the array of CurrencyFraction objects
        /// </summary>
        CurrencyFraction[] CurrencyFractions { get; set; }

        /// <summary>
        /// Gets or sets the array of CalendarType objects
        /// </summary>
        CalendarType[] CalendarTypes { get; set; }

        /// <summary>
        /// Gets or sets the array of CalendarPreference objects
        /// </summary>
        CalendarPreference[] CalendarPreferences { get; set; }

        /// <summary>
        /// Gets or sets the array of DayPeriodRuleSet objects
        /// </summary>
        DayPeriodRuleSet[] DayPeriodRuleSets { get; set; }

        /// <summary>
        /// Gets or sets the array of GenderList objects
        /// </summary>
        GenderList[] GenderLists { get; set; }

        /// <summary>
        /// Gets or sets the array of LanguageMatch objects
        /// </summary>
        LanguageMatch[] LanguageMatches { get; set; }

        /// <summary>
        /// Gets or sets the array of LikelySubTag objects
        /// </summary>
        LikelySubTag[] LikelySubTags { get; set; }

        /// <summary>
        /// Gets or sets the MeasurementData object
        /// </summary>
        MeasurementData MeasurementData { get; set; }

        /// <summary>
        /// Gets or sets the array of MetaTimeZone objects
        /// </summary>
        MetaTimeZone[] MetaTimeZones { get; set; }

        /// <summary>
        /// Gets or sets the array of NumberingSystemType objects
        /// </summary>
        NumberingSystemType[] NumberingSystems { get; set; }

        /// <summary>
        /// Gets or sets the array of PluralRuleSet objects used for ordinal rules
        /// </summary>
        PluralRuleSet[] OrdinalRuleSets { get; set; }

        /// <summary>
        /// Gets or sets the array of ParentCulture objects used to determine parents of cultures that do
        /// not obey the naming convention culture inheritance
        /// </summary>
        ParentCulture[] ParentCultures { get; set; }

        /// <summary>
        /// Gets or sets the array of PluralRuleSet objects used for plural rules
        /// </summary>
        PluralRuleSet[] PluralRuleSets { get; set; }

        /// <summary>
        /// Gets or sets the array of PostcodeRegex objects for all regions
        /// </summary>
        PostcodeRegex[] PostcodeRegexes { get; set; }

        /// <summary>
        /// Gets or sets the array of CLDR references
        /// </summary>
        Reference[] References { get; set; }

        /// <summary>
        /// Gets or sets the array of RegionCode objects
        /// </summary>
        RegionCode[] RegionCodes { get; set; }

        /// <summary>
        /// Gets or sets the array of RegionGroup objects that indicate which regions own other regions
        /// </summary>
        RegionGroup[] RegionGroups { get; set; }

        /// <summary>
        /// Gets or sets the array of RegionInformation objects
        /// </summary>
        RegionInformation[] RegionInformations { get; set; }

        /// <summary>
        /// Gets or sets the array of RegionTelephoneCode objects
        /// </summary>
        RegionTelephoneCode[] RegionTelephoneCodes { get; set; }

        /// <summary>
        /// Gets or sets the TimeData object
        /// </summary>
        TimeData TimeData { get; set; }

        /// <summary>
        /// Gets or sets the array of TimeZoneInformation objects
        /// </summary>
        TimeZoneInformation[] TimeZones { get; set; }

        /// <summary>
        /// Gets or sets the WeekData object
        /// </summary>
        WeekData WeekData { get; set; }

        /// <summary>
        /// Gets or sets the array of Windows MetaTimeZone objects
        /// </summary>
        MetaTimeZone[] WindowsMetaTimeZones { get; set; }

        /// <summary>
        /// Gets the Unicode Licence Agreement (see http://www.unicode.org/copyright.html#Exhibit1)
        /// </summary>
        string UnicodeLicenseAgreement { get; }
    }
}
