using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using NCldr.Types;

namespace NCldr.Builder
{
    public partial class NCldrBuilder
    {
        private static string cldrPath;
        private static string ncldrPath;
        private static NCldrBuilderProgressEventHandler progress;
        private static NCldrBuilderOptions options;
        private static XDocument supplementalDataDocument;

        public static void Build(
            string cldrPath, 
            string ncldrPath, 
            NCldrBuilderProgressEventHandler progress = null,
            NCldrBuilderOptions options = null)
        {
            NCldrBuilder.options = options;
            NCldrBuilder.progress = progress;
            NCldrBuilder.cldrPath = cldrPath;
            NCldrBuilder.ncldrPath = ncldrPath;

            supplementalDataDocument = GetXmlDocument(@"Core\common\supplemental\supplementalData.xml");

            NCldrData ncldrData = new NCldrData();
            ncldrData.CultureNames = GetCultureNames();
            ncldrData.CultureDatas = GetCultures();
            ncldrData.CalendarPreferences = GetCalendarPreferences();
            ncldrData.CalendarTypes = GetCalendarTypes();
            ncldrData.CharacterFallbacks = GetCharacterFallbacks();
            ncldrData.Currencies = GetDescriptions<Currency>("currency", "cu", "currency");
            ncldrData.CurrencyFractions = GetCurrencyFractions();
            ncldrData.DayPeriodRuleSets = GetDayPeriodRuleSets();
            ncldrData.GenderLists = GetGenderLists();
            ncldrData.LanguageMatches = GetLanguageMatches();
            ncldrData.LikelySubTags = GetLikelySubTags();
            ncldrData.MeasurementData = GetMeasurementData();
            ncldrData.MetaTimeZones = GetMetaTimeZones();
            ncldrData.NumberingSystems = GetNumberingSystems();
            ncldrData.OrdinalRuleSets = GetPluralRuleSets(true);
            ncldrData.ParentCultures = GetParentCultures();
            ncldrData.PluralRuleSets = GetPluralRuleSets(false);
            ncldrData.PostcodeRegexes = GetPostcodeRegexes();
            ncldrData.References = GetReferences();
            ncldrData.RegionCodes = GetRegionCodes();
            ncldrData.RegionGroups = GetRegionGroups();
            ncldrData.RegionInformations = GetRegionInformations();
            ncldrData.RegionTelephoneCodes = GetRegionTelephoneCodes();
            ncldrData.TimeZones = GetTimeZones();
            ncldrData.WeekData = GetWeekData();
            ncldrData.WindowsMetaTimeZones = GetWindowsMetaTimeZones();

            Build(ncldrData);
        }

        private static void Progress(
            string section, 
            string item, 
            ProgressEventType progressEventType = ProgressEventType.Adding,
            object addedObject = null)
        {
            if (progress != null)
            {
                NCldrBuilderProgressEventArgs args = new NCldrBuilderProgressEventArgs();
                args.Section = section;
                args.Item = item;
                args.ProgressEventType = progressEventType;
                args.AddedObject = addedObject;
                progress(null, args);
            }
        }

        private static Identity GetIdentity(XDocument document)
        {
            IEnumerable<XElement> ldmlElements = document.Elements("ldml");
            XElement identityData = (from item in ldmlElements.Elements("identity")
                                     select item).FirstOrDefault();
            if (identityData != null)
            {
                Identity identity = new Identity();
                string languageId = identityData.Element("language").Attribute("type").Value.ToString();
                identity.Language = new Language() { Id = languageId };
                if (identityData.Element("territory") != null)
                {
                    string territoryId = identityData.Element("territory").Attribute("type").Value.ToString();
                    identity.Region = new Region() { Id = territoryId };
                }

                if (identityData.Element("script") != null)
                {
                    string scriptId = identityData.Element("script").Attribute("type").Value.ToString();
                    identity.Script = new Script() { Id = scriptId };
                }

                if (identityData.Element("variant") != null)
                {
                    string variantId = identityData.Element("variant").Attribute("type").Value.ToString();
                    identity.Variant = new Variant() { Id = variantId };
                }

                return identity;
            }

            return null;
        }

        private static XDocument GetXmlDocument(string filename)
        {
            string path = Path.Combine(cldrPath, filename);
            string xml = File.ReadAllText(path);
            return XDocument.Parse(xml);
        }

        private static string[] GetFilenames(string folderName)
        {
            string path = Path.Combine(cldrPath, folderName);
            string[] xmlFilenames = Directory.GetFiles(path, "*.xml");
            List<string> filenames = new List<string>();
            foreach (string xmlFilename in xmlFilenames)
            {
                filenames.Add(Path.GetFileNameWithoutExtension(xmlFilename));
            }

            return filenames.ToArray();
        }

        private static string[] GetCultureNames()
        {
            if (options != null && !options.IncludeCultureNames)
            {
                return null;
            }

            string[] cldrCultureNames = GetFilenames(@"Core\common\main");
            List<string> dotNetCultureNames = new List<string>();
            foreach (string cldrCultureName in cldrCultureNames)
            {
                dotNetCultureNames.Add(GetDotNetCultureName(cldrCultureName));
            }

            return dotNetCultureNames.ToArray();
        }

        private static string GetDotNetCultureName(string cldrCultureName)
        {
            if (cldrCultureName.IndexOf("_") > 0)
            {
                return cldrCultureName.Replace("_", "-");
            }

            return cldrCultureName;
        }

        private static void Build(NCldrData ncldrData)
        {
            string ncldrFile = Path.Combine(ncldrPath, "NCldr.dat");
            Progress("Writing data file", ncldrFile, ProgressEventType.Writing);

            FileStream fileStream = new FileStream(ncldrFile, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fileStream, ncldrData);
            }
            catch (SerializationException exception)
            {
                Console.WriteLine("Failed to serialize. Reason: " + exception.Message);
                throw;
            }
            finally
            {
                fileStream.Close();
            }
        }

        public static DateTime? ParseCldrDate(string cldrDate)
        {
            DateTime? date = null;
            if (!String.IsNullOrEmpty(cldrDate))
            {
                string dateFormat = "yyyy-MM-dd HH:mm".Substring(0, cldrDate.Length);
                date = DateTime.ParseExact(cldrDate, dateFormat, CultureInfo.InvariantCulture);
            }

            return date;
        }
    }
}
