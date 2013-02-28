using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace NCldr.Builder
{
    public class NCldrBuilderOptions
    {
        public NCldrBuilderOptions()
        {
            this.CultureOptions = new NCldrBuilderCultureOptions();

            this.IncludeCultureNames = true;
            this.IncludeCharacterFallbacks = true;
            this.IncludeCultures = true;
            this.IncludeCurrencies = true;
            this.IncludeCurrencyFractions = true;
            this.IncludeCalendarTypes = true;
            this.IncludeCalendarPreferences = true;
            this.IncludeDayPeriodRuleSets = true;
            this.IncludeGenderLists = true;
            this.IncludeLanguageMatches = true;
            this.IncludeLikelySubTags = true;
            this.IncludeMeasurementData = true;
            this.IncludeMetaTimeZones = true;
            this.IncludeNumberingSystems = true;
            this.IncludeOrdinalRuleSets = true;
            this.IncludeParentCultures = true;
            this.IncludePluralRuleSets = true;
            this.IncludePostcodeRegexes = true;
            this.IncludeReferences = true;
            this.IncludeRegionCodes = true;
            this.IncludeRegionGroups = true;
            this.IncludeRegionInformations = true;
            this.IncludeRegionTelephoneCodes = true;
            this.IncludeTimeZones = true;
            this.IncludeWeekData = true;
            this.IncludeWindowsMetaTimeZones = true;
        }

        public NCldrBuilderCultureOptions CultureOptions { get; set; }

        public bool IncludeCharacterFallbacks { get; set; }

        public bool IncludeCultureNames { get; set; }

        public bool IncludeCultures { get; set; }

        public bool IncludeCurrencies { get; set; }

        public bool IncludeCurrencyFractions { get; set; }

        public bool IncludeCalendarTypes { get; set; }

        public bool IncludeCalendarPreferences { get; set; }

        public bool IncludeDayPeriodRuleSets { get; set; }

        public bool IncludeGenderLists { get; set; }

        public bool IncludeLanguageMatches { get; set; }

        public bool IncludeLikelySubTags { get; set; }

        public bool IncludeMeasurementData { get; set; }

        public bool IncludeMetaTimeZones { get; set; }

        public bool IncludeNumberingSystems { get; set; }

        public bool IncludeOrdinalRuleSets { get; set; }

        public bool IncludeParentCultures { get; set; }

        public bool IncludePluralRuleSets { get; set; }

        public bool IncludePostcodeRegexes { get; set; }

        public bool IncludeReferences { get; set; }

        public bool IncludeRegionCodes { get; set; }

        public bool IncludeRegionGroups { get; set; }

        public bool IncludeRegionInformations { get; set; }

        public bool IncludeRegionTelephoneCodes { get; set; }

        public bool IncludeTimeZones { get; set; }

        public bool IncludeWeekData { get; set; }

        public bool IncludeWindowsMetaTimeZones { get; set; }

        public void Save(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            FileStream fileStream = new FileStream(filename, FileMode.Create);
            try
            {
                serializer.Serialize(fileStream, this);
            }
            finally
            {
                fileStream.Close();
            }
        }

        public static NCldrBuilderOptions Load(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(NCldrBuilderOptions));
            FileStream fileStream = new FileStream(filename, FileMode.Open);
            try
            {
                return (NCldrBuilderOptions)serializer.Deserialize(fileStream);
            }
            finally
            {
                fileStream.Close();
            }
        }
    }
}
