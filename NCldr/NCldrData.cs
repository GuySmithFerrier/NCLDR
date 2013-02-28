namespace NCldr
{
    using System;
    using Types;

    /// <summary>
    /// NCldrData represents the 'raw' CLDR data
    /// </summary>
    /// <remarks>In general use the NCldr class instead of this class</remarks>
    [Serializable]
    public class NCldrData : INCldrData
    {
        /// <summary>
        /// Gets or sets the array of CalendarFallback objects
        /// </summary>
        public CharacterFallback[] CharacterFallbacks { get; set; }

        /// <summary>
        /// Gets or sets the array of names of cultures
        /// </summary>
        public string[] CultureNames { get; set; }

        /// <summary>
        /// Gets or sets the array of CultureData objects
        /// </summary>
        public CultureData[] CultureDatas { get; set; }

        /// <summary>
        /// Gets or sets the array of Currency objects
        /// </summary>
        public Currency[] Currencies { get; set; }

        /// <summary>
        /// Gets or sets the array of CurrencyFraction objects
        /// </summary>
        public CurrencyFraction[] CurrencyFractions { get; set; }

        /// <summary>
        /// Gets or sets the array of CalendarType objects
        /// </summary>
        public CalendarType[] CalendarTypes { get; set; }

        /// <summary>
        /// Gets or sets the array of CalendarPreference objects
        /// </summary>
        public CalendarPreference[] CalendarPreferences { get; set; }

        /// <summary>
        /// Gets or sets the array of DayPeriodRuleSet objects
        /// </summary>
        public DayPeriodRuleSet[] DayPeriodRuleSets { get; set; }

        /// <summary>
        /// Gets or sets the array of GenderList objects
        /// </summary>
        public GenderList[] GenderLists { get; set; }

        /// <summary>
        /// Gets or sets the array of LanguageMatch objects
        /// </summary>
        public LanguageMatch[] LanguageMatches { get; set; }

        /// <summary>
        /// Gets or sets the array of LikelySubTag objects
        /// </summary>
        public LikelySubTag[] LikelySubTags { get; set; }

        /// <summary>
        /// Gets or sets the MeasurementData object
        /// </summary>
        public MeasurementData MeasurementData { get; set; }

        /// <summary>
        /// Gets or sets the array of MetaTimeZone objects
        /// </summary>
        public MetaTimeZone[] MetaTimeZones { get; set; }

        /// <summary>
        /// Gets or sets the array of NumberingSystemType objects
        /// </summary>
        public NumberingSystemType[] NumberingSystems { get; set; }

        /// <summary>
        /// Gets or sets the array of PluralRuleSet objects used for ordinal rules
        /// </summary>
        public PluralRuleSet[] OrdinalRuleSets { get; set; }

        /// <summary>
        /// Gets or sets the array of ParentCulture objects used to determine parents of cultures that do
        /// not obey the naming convention culture inheritance
        /// </summary>
        public ParentCulture[] ParentCultures { get; set; }

        /// <summary>
        /// Gets or sets the array of PluralRuleSet objects used for plural rules
        /// </summary>
        public PluralRuleSet[] PluralRuleSets { get; set; }

        /// <summary>
        /// Gets or sets the array of PostcodeRegex objects for all regions
        /// </summary>
        public PostcodeRegex[] PostcodeRegexes { get; set; }

        /// <summary>
        /// Gets or sets the array of CLDR references
        /// </summary>
        public Reference[] References { get; set; }

        /// <summary>
        /// Gets or sets the array of RegionCode objects
        /// </summary>
        public RegionCode[] RegionCodes { get; set; }

        /// <summary>
        /// Gets or sets the array of RegionGroup objects that indicate which regions own other regions
        /// </summary>
        public RegionGroup[] RegionGroups { get; set; }

        /// <summary>
        /// Gets or sets the array of RegionInformation objects
        /// </summary>
        public RegionInformation[] RegionInformations { get; set; }

        /// <summary>
        /// Gets or sets the array of RegionTelephoneCode objects
        /// </summary>
        public RegionTelephoneCode[] RegionTelephoneCodes { get; set; }

        /// <summary>
        /// Gets or sets the array of TimeZoneInformation objects
        /// </summary>
        public TimeZoneInformation[] TimeZones { get; set; }

        /// <summary>
        /// Gets or sets the WeekData object
        /// </summary>
        public WeekData WeekData { get; set; }

        /// <summary>
        /// Gets or sets the array of Windows MetaTimeZone objects
        /// </summary>
        public MetaTimeZone[] WindowsMetaTimeZones { get; set; }

        /// <summary>
        /// Gets the Unicode Licence Agreement (see http://www.unicode.org/copyright.html#Exhibit1)
        /// </summary>
        public string UnicodeLicenseAgreement
        {
            get
            {
                return @"
UNICODE, INC. LICENSE AGREEMENT - DATA FILES AND SOFTWARE


Unicode Data Files include all data files under the directories http://www.unicode.org/Public/, http://www.unicode.org/reports/, and  http://www.unicode.org/cldr/data/. Unicode Data Files do not include PDF online code charts under the directory http://www.unicode.org/Public/. Software includes any source code published in the Unicode Standard or under the directories http://www.unicode.org/Public/, http://www.unicode.org/reports/, and  http://www.unicode.org/cldr/data/.

NOTICE TO USER: Carefully read the following legal agreement. BY DOWNLOADING, INSTALLING, COPYING OR OTHERWISE USING UNICODE INC.'S DATA FILES (""DATA FILES""), AND/OR SOFTWARE (""SOFTWARE""), YOU UNEQUIVOCALLY ACCEPT, AND AGREE TO BE BOUND BY, ALL OF THE TERMS AND CONDITIONS OF THIS AGREEMENT. IF YOU DO NOT AGREE, DO NOT DOWNLOAD, INSTALL, COPY, DISTRIBUTE OR USE THE DATA FILES OR SOFTWARE.

COPYRIGHT AND PERMISSION NOTICE

Copyright © 1991-2012 Unicode, Inc. All rights reserved. Distributed under the Terms of Use in http://www.unicode.org/copyright.html.

Permission is hereby granted, free of charge, to any person obtaining a copy of the Unicode data files and any associated documentation (the ""Data Files"") or Unicode software and any associated documentation (the ""Software"") to deal in the Data Files or Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, and/or sell copies of the Data Files or Software, and to permit persons to whom the Data Files or Software are furnished to do so, provided that (a) the above copyright notice(s) and this permission notice appear with all copies of the Data Files or Software, (b) both the above copyright notice(s) and this permission notice appear in associated documentation, and (c) there is clear notice in each modified Data File or in the Software as well as in the documentation associated with the Data File(s) or Software that the data or software has been modified.

THE DATA FILES AND SOFTWARE ARE PROVIDED ""AS IS"", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT OF THIRD PARTY RIGHTS. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR HOLDERS INCLUDED IN THIS NOTICE BE LIABLE FOR ANY CLAIM, OR ANY SPECIAL INDIRECT OR CONSEQUENTIAL DAMAGES, OR ANY DAMAGES WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THE DATA FILES OR SOFTWARE.

Except as contained in this notice, the name of a copyright holder shall not be used in advertising or otherwise to promote the sale, use or other dealings in these Data Files or Software without prior written authorization of the copyright holder.";
            }
        }
    }
}
