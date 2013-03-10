using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using NCldr.Types;

namespace NCldr.Builder
{
    public partial class NCldrBuilder
    {
        private static CultureData[] GetCultures()
        {
            if (options != null && !options.IncludeCultures)
            {
                return null;
            }

            List<CultureData> cultures = new List<CultureData>();
            string[] cldrCultureNames = GetFilenames(@"common\main");
            foreach (string cldrCultureName in cldrCultureNames)
            {
                if (IncludeCulture(cldrCultureName))
                {
                    Progress("Adding culture", cldrCultureName);

                    CultureData cultureData = GetCulture(cldrCultureName);
                    cultures.Add(cultureData);

                    Progress("Added culture", cldrCultureName, ProgressEventType.Added, cultureData);
                }
            }

            return cultures.ToArray();
        }

        private static bool IncludeCulture(string cldrCultureName)
        {
            if (options == null || options.CultureOptions == null || 
                options.CultureOptions.CultureSelection == CultureSelection.All)
            {
                return true;
            }
            else if (options.CultureOptions.CultureSelection == CultureSelection.IncludeOnly)
            {
                string cultureName = GetDotNetCultureName(cldrCultureName);
                return (from c in options.CultureOptions.IncludeCultures
                        where c == cultureName
                        select c).Any();
            }
            else if (options.CultureOptions.CultureSelection == CultureSelection.AllExceptExclude)
            {
                string cultureName = GetDotNetCultureName(cldrCultureName);
                return !(from c in options.CultureOptions.ExcludeCultures
                         where c == cultureName
                         select c).Any();
            }
            else if (options.CultureOptions.CultureSelection == CultureSelection.AllNew)
            {
                string cultureName = GetDotNetCultureName(cldrCultureName);
                return !IsDotNetCulture(cultureName);
            }

            return false;
        }

        private static bool IsDotNetCulture(string cultureName)
        {
            try
            {
                new System.Globalization.CultureInfo(cultureName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static CultureData GetCulture(string cultureName)
        {
            XDocument document = GetXmlDocument(@"common\main\" + cultureName + ".xml");

            CultureData culture = new CultureData();

            culture.Identity = GetIdentity(document);

            culture.LanguageDisplayNames = GetDisplayNames<LanguageDisplayName>(document, "languages", "language");

            culture.RegionDisplayNames = GetDisplayNames<RegionDisplayName>(document, "territories", "territory");

            culture.ScriptDisplayNames = GetDisplayNames<ScriptDisplayName>(document, "scripts", "script");

            culture.Casing = GetCasing(cultureName);

            culture.Characters = GetCharacters(document);

            culture.Dates = GetDates(document);

            culture.Delimiters = GetDelimiters(document);

            culture.Layout = GetLayout(document);

            culture.ListPatterns = GetListPatterns(document);

            culture.Messages = GetMessages(document);

            culture.Numbers = GetNumbers(document, culture.Identity.Region);

            culture.RuleBasedNumberFormatting = GetRuleBasedNumberFormatting(cultureName);

            culture.UnitPatternSets = GetUnitPatternSets(document);

            return culture;
        }

        private static RuleBasedNumberFormatting GetRuleBasedNumberFormatting(string cultureName)
        {
            if (options != null && options.CultureOptions != null && !options.CultureOptions.IncludeRuleBasedNumberFormatting)
            {
                return null;
            }

            string filename = String.Format(@"common\rbnf\{0}.xml", cultureName);
            string path = Path.Combine(cldrPath, filename);

            if (!File.Exists(path))
            {
                return null;
            }

            XDocument rbnfDocument = GetXmlDocument(filename);

            List<XElement> ruleSetGroupingElements =
                (from i in rbnfDocument.Elements("ldml").Elements("rbnf").Elements("rulesetGrouping")
                 select i).ToList();

            if (ruleSetGroupingElements == null || ruleSetGroupingElements.Count == 0)
            {
                return null;
            }

            RuleBasedNumberFormatting ruleBasedNumberFormatting = new RuleBasedNumberFormatting();
            ruleBasedNumberFormatting.SpelloutRuleSets = GetRuleBasedNumberFormattingRuleSet(ruleSetGroupingElements, "SpelloutRules");
            ruleBasedNumberFormatting.OrdinalRuleSets = GetRuleBasedNumberFormattingRuleSet(ruleSetGroupingElements, "OrdinalRules");
            return ruleBasedNumberFormatting;
        }

        private static RuleBasedNumberFormattingRuleSet[] GetRuleBasedNumberFormattingRuleSet(
            List<XElement> ruleSetGroupingElements, string ruleSetId)
        {
            XElement ruleSetGroupingElement = (from rs in ruleSetGroupingElements
                                       where rs.Attribute("type").Value.ToString() == ruleSetId
                                       select rs).FirstOrDefault();
            if (ruleSetGroupingElement == null)
            {
                return null;
            }

            List<RuleBasedNumberFormattingRuleSet> ruleSets = new List<RuleBasedNumberFormattingRuleSet>();
            List<XElement> ruleSetElements = (from rs in ruleSetGroupingElement.Elements("ruleset")
                                              select rs).ToList();
            foreach (XElement ruleSetElement in ruleSetElements)
            {
                RuleBasedNumberFormattingRuleSet ruleSet = new RuleBasedNumberFormattingRuleSet();
                ruleSet.Id = ruleSetElement.Attribute("type").Value.ToString();
                if (ruleSetElement.Attribute("access") != null)
                {
                    ruleSet.Access = ruleSetElement.Attribute("access").Value.ToString();
                }

                List<RuleBasedNumberFormattingRule> rules = new List<RuleBasedNumberFormattingRule>();
                List<XElement> ruleElements = (from r in ruleSetElement.Elements("rbnfrule")
                                               select r).ToList();
                foreach (XElement ruleElement in ruleElements)
                {
                    RuleBasedNumberFormattingRule rule = new RuleBasedNumberFormattingRule();
                    rule.Value = ruleElement.Attribute("value").Value.ToString();
                    rule.Rule = ruleElement.Value.ToString();
                    rules.Add(rule);
                }

                ruleSet.RuleBasedNumberFormattingRules = rules.ToArray();

                ruleSets.Add(ruleSet);
            }

            return ruleSets.ToArray();
        }

        private static Casing GetCasing(string cultureName)
        {
            if (options != null && options.CultureOptions != null && !options.CultureOptions.IncludeCasing)
            {
                return null;
            }

            string filename = String.Format(@"common\casing\{0}.xml", cultureName);
            string path = Path.Combine(cldrPath, filename);

            if (!File.Exists(path))
            {
                return null;
            }

            XDocument casingDocument = GetXmlDocument(filename);

            List<XElement> casingElements = (from i in casingDocument.Elements("ldml").Elements("metadata").Elements("casingData")
                                                .Elements("casingItem")
                                             select i).ToList();

            if (casingElements == null || casingElements.Count == 0)
            {
                return null;
            }

            Casing casing = new Casing();
            casing.CalendarField = GetCasingType(casingElements, "calendar-field");
            casing.DayFormatExceptNarrow = GetCasingType(casingElements, "day-format-except-narrow");
            casing.DayNarrow = GetCasingType(casingElements, "day-narrow");
            casing.DayStandAloneExceptNarrow = GetCasingType(casingElements, "day-standalone-except-narrow");
            casing.DisplayName = GetCasingType(casingElements, "displayName");
            casing.DisplayNameCount = GetCasingType(casingElements, "displayName-count");
            casing.EraAbbr = GetCasingType(casingElements, "era-abbr");
            casing.EraName = GetCasingType(casingElements, "era-name");
            casing.EraNarrow = GetCasingType(casingElements, "era-narrow");
            casing.Key = GetCasingType(casingElements, "key");
            casing.Language = GetCasingType(casingElements, "language");
            casing.MetaZoneLong = GetCasingType(casingElements, "metazone-long");
            casing.MetaZoneShort = GetCasingType(casingElements, "metazone-short");
            casing.MonthFormatExceptNarrow = GetCasingType(casingElements, "month-format-except-narrow");
            casing.MonthNarrow = GetCasingType(casingElements, "month-narrow");
            casing.MonthStandAloneExceptNarrow = GetCasingType(casingElements, "day-standalone-except-narrow");
            casing.QuarterAbbreviated = GetCasingType(casingElements, "quarter-abbreviated");
            casing.Script = GetCasingType(casingElements, "script");
            casing.Symbol = GetCasingType(casingElements, "symbol");
            casing.Region = GetCasingType(casingElements, "territory");
            casing.Tense = GetCasingType(casingElements, "tense");
            casing.Type = GetCasingType(casingElements, "type");
            casing.ZoneExemplarCity = GetCasingType(casingElements, "zone-exemplarCity");
            return casing;
        }

        private static CasingType GetCasingType(List<XElement> casingElements, string casingElementName)
        {
            XElement element = (from c in casingElements
                                where c.Attribute("type").Value.ToString() == casingElementName
                                select c).FirstOrDefault();
            if (element == null)
            {
                return CasingType.None;
            }

            string casingType = element.Value;
            return (CasingType)Enum.Parse(typeof(CasingType), casingType, true);
        }

        private static Numbers GetNumbers(XDocument document, Region region)
        {
            if (options != null && options.CultureOptions != null && !options.CultureOptions.IncludeNumbers)
            {
                return null;
            }

            Numbers numbers = null;
            IEnumerable<XElement> numbersElements = document.Elements("ldml").Elements("numbers");
            if (numbersElements != null)
            {
                numbers = new Numbers();

                XElement defaultNumberingSystemElement = (from item in numbersElements.Elements("defaultNumberingSystem")
                                                          select item).FirstOrDefault();
                if (defaultNumberingSystemElement != null)
                {
                    numbers.DefaultNumberingSystemId = defaultNumberingSystemElement.Value.ToString();
                }

                List<XElement> otherNumberingSystemElements = (
                    from item in numbersElements.Elements("otherNumberingSystems").Elements()
                    select item).ToList();

                if (otherNumberingSystemElements != null && otherNumberingSystemElements.Count > 0)
                {
                    List<NumberingSystem> numberingSystems = new List<NumberingSystem>();

                    numbers.OtherNumberingSystems = new List<OtherNumberingSystem>();
                    foreach (XElement otherNumberingSystemElement in otherNumberingSystemElements)
                    {
                        numbers.OtherNumberingSystems.Add(new OtherNumberingSystem()
                        {
                            Id = otherNumberingSystemElement.Name.ToString(),
                            Value = otherNumberingSystemElement.Value.ToString()
                        });

                        numberingSystems.Add(new NumberingSystem() { Id = otherNumberingSystemElement.Value.ToString() });
                    }

                    // look to see if there is any data defined for each of the 'other' numbering systems
                    foreach (NumberingSystem numberingSystem in numberingSystems)
                    {
                        numberingSystem.Symbols = GetNumberingSystemSymbols(numbersElements, numberingSystem.Id);
                        numberingSystem.DecimalFormatPatternSets = GetDecimalFormatPatternSets(numbersElements, numberingSystem.Id);

                        numberingSystem.CurrencySpacings = GetCurrencySpacings(numbersElements, numberingSystem.Id);

                        numberingSystem.CurrencyFormatPattern = GetPattern(
                            numbersElements, numberingSystem.Id, "currencyFormats", "currencyFormatLength", "currencyFormat");

                        numberingSystem.DecimalFormatPattern = GetPattern(
                            numbersElements, numberingSystem.Id, "decimalFormats", "decimalFormatLength", "decimalFormat");

                        numberingSystem.PercentFormatPattern = GetPattern(
                            numbersElements, numberingSystem.Id, "percentFormats", "percentFormatLength", "percentFormat");

                        numberingSystem.ScientificFormatPattern = GetPattern(
                            numbersElements, numberingSystem.Id, "scientificFormats", "scientificFormatLength", "scientificFormat");
                    }

                    // only save the numbering systems for which there was actually any data found
                    numbers.NumberingSystems = (from ns in numberingSystems
                                               where ns.Symbols != null || ns.DecimalFormatPatternSets != null
                                               || ns.CurrencySpacings != null
                                               || ns.CurrencyFormatPattern != null || ns.DecimalFormatPattern != null
                                               || ns.PercentFormatPattern != null || ns.ScientificFormatPattern != null
                                               select ns).ToArray();
                }

                numbers.CurrencyDisplayNameSets = GetCurrencyDisplayNameSets(numbersElements);

                if (region != null)
                {
                    numbers.CurrencyPeriods = GetCurrencyPeriods(region.Id);
                }
            }

            return numbers;
        }

        private static CurrencySpacings GetCurrencySpacings(IEnumerable<XElement> numbersElements, string numberingSystemId)
        {
            XElement formatsElement = (from item in numbersElements.Elements("currencyFormats")
                                       where item.Attribute("numberSystem") != null &&
                                       item.Attribute("numberSystem").Value.ToString() == numberingSystemId
                                       select item).FirstOrDefault();
            if (formatsElement != null)
            {
                XElement currencySpacingElement =
                    (from item in formatsElement.Elements("currencySpacing")
                     select item).FirstOrDefault();
                if (currencySpacingElement != null)
                {
                    CurrencySpacings currencySpacings = new CurrencySpacings();

                    XElement beforeCurrencyElement = (from p in currencySpacingElement
                                                          .Elements("beforeCurrency")
                                                      select p).FirstOrDefault();
                    if (beforeCurrencyElement != null)
                    {
                        CurrencySpacing beforeCurrencySpacing = new CurrencySpacing();
                        beforeCurrencySpacing.CurrencyMatch = beforeCurrencyElement.Element("currencyMatch").Value.ToString();
                        beforeCurrencySpacing.SurroundingMatch = beforeCurrencyElement.Element("surroundingMatch").Value.ToString();
                        beforeCurrencySpacing.InsertBetween = beforeCurrencyElement.Element("insertBetween").Value.ToString();
                        currencySpacings.BeforeCurrency = beforeCurrencySpacing;
                    }

                    XElement afterCurrencyElement = (from p in currencySpacingElement
                                                        .Elements("afterCurrency")
                                                     select p).FirstOrDefault();
                    if (afterCurrencyElement != null)
                    {
                        CurrencySpacing afterCurrencySpacing = new CurrencySpacing();
                        afterCurrencySpacing.CurrencyMatch = afterCurrencyElement.Element("currencyMatch").Value.ToString();
                        afterCurrencySpacing.SurroundingMatch = afterCurrencyElement.Element("surroundingMatch").Value.ToString();
                        afterCurrencySpacing.InsertBetween = afterCurrencyElement.Element("insertBetween").Value.ToString();
                        currencySpacings.AfterCurrency = afterCurrencySpacing;
                    }

                    return currencySpacings;
                }
            }

            return null;
        }

        private static CurrencyPeriod[] GetCurrencyPeriods(string regionId)
        {
            XElement regionElement = (from cp in supplementalDataDocument.Elements("supplementalData").Elements("currencyData")
                                                     .Elements("region")
                                      where cp.Attribute("iso3166").Value.ToString() == regionId
                                      select cp).FirstOrDefault();
            if (regionElement != null)
            {
                List<CurrencyPeriod> currencyPeriods = new List<CurrencyPeriod>();
                foreach (XElement currencyPeriodElement in regionElement.Elements("currency"))
                {
                    CurrencyPeriod currencyPeriod = new CurrencyPeriod();
                    currencyPeriod.Id = currencyPeriodElement.Attribute("iso4217").Value.ToString();
                    if (currencyPeriodElement.Attribute("from") != null)
                    {
                        currencyPeriod.From = ParseCldrDate(currencyPeriodElement.Attribute("from").Value.ToString());
                    }

                    if (currencyPeriodElement.Attribute("to") != null)
                    {
                        currencyPeriod.To = ParseCldrDate(currencyPeriodElement.Attribute("to").Value.ToString());
                    }

                    if (currencyPeriodElement.Attribute("tender") != null)
                    {
                        string tender = currencyPeriodElement.Attribute("tender").Value.ToString();
                        currencyPeriod.IsTender = (tender == "true");
                    }
                    else
                    {
                        currencyPeriod.IsTender = true;
                    }

                    currencyPeriods.Add(currencyPeriod);
                }

                return currencyPeriods.ToArray();
            }

            return null;
        }

        private static CurrencyDisplayNameSet[] GetCurrencyDisplayNameSets(IEnumerable<XElement> numbersElements)
        {
            List<XElement> currencySetElements = (from item in numbersElements.Elements("currencies").Elements("currency")
                                                  select item).ToList();

            if (currencySetElements != null && currencySetElements.Count > 0)
            {
                List<CurrencyDisplayNameSet> currencyDisplayNameSets = new List<CurrencyDisplayNameSet>();
                foreach (XElement currencySetElement in currencySetElements)
                {
                    CurrencyDisplayNameSet currencyDisplayNameSet = new CurrencyDisplayNameSet();
                    currencyDisplayNameSet.Id = currencySetElement.Attribute("type").Value.ToString();
                    List<CurrencyDisplayName> currencyDisplayNames = new List<CurrencyDisplayName>();
                    foreach (XElement currencyDisplayNameElement in currencySetElement.Elements("displayName"))
                    {
                        CurrencyDisplayName currencyDisplayName = new CurrencyDisplayName();
                        if (currencyDisplayNameElement.Attribute("count") != null)
                        {
                            string id = currencyDisplayNameElement.Attribute("count").Value.ToString();
                            id = id[0].ToString().ToUpper() + id.Substring(1);
                            currencyDisplayName.Id = id;
                        }

                        currencyDisplayName.Name = currencyDisplayNameElement.Value.ToString();
                        currencyDisplayNames.Add(currencyDisplayName);
                    }

                    currencyDisplayNameSet.CurrencyDisplayNames = currencyDisplayNames.ToArray();

                    XElement currencySymbolElement = currencySetElement.Elements("symbol").FirstOrDefault();
                    if (currencySymbolElement != null)
                    {
                        currencyDisplayNameSet.Symbol = currencySymbolElement.Value.ToString();
                    }

                    currencyDisplayNameSets.Add(currencyDisplayNameSet);
                }

                return currencyDisplayNameSets.ToArray();
            }

            return null;
        }

        private static string GetPattern(
            IEnumerable<XElement> numbersElements, 
            string numberingSystemId,
            string formatsName,
            string formatLengthName,
            string formatName)
        {
            XElement formatsElement = (from item in numbersElements.Elements(formatsName)
                                              where item.Attribute("numberSystem") != null &&
                                              item.Attribute("numberSystem").Value.ToString() == numberingSystemId
                                              select item).FirstOrDefault();
            if (formatsElement != null)
            {
                XElement formatLengthElement =
                    (from item in formatsElement.Elements(formatLengthName)
                     where item.Attribute("type") == null
                     select item).FirstOrDefault();
                if (formatLengthElement != null)
                {
                    XElement patternElement = (from p in formatLengthElement
                                                          .Elements(formatName).Elements("pattern")
                                               select p).FirstOrDefault();
                    if (patternElement != null)
                    {
                        return patternElement.Value.ToString();
                    }
                }
            }

            return null;
        }

        private static DecimalFormatPatternSet[] GetDecimalFormatPatternSets(IEnumerable<XElement> numbersElements, string numberingSystemId)
        {
            XElement decimalFormatsElement = (from item in numbersElements.Elements("decimalFormats")
                                              where item.Attribute("numberSystem") != null &&
                                              item.Attribute("numberSystem").Value.ToString() == numberingSystemId
                                              select item).FirstOrDefault();
            if (decimalFormatsElement != null)
            {
                List<XElement> decimalFormatLengthElements =
                    (from item in decimalFormatsElement.Elements("decimalFormatLength")
                     where item.Attribute("type") != null
                     select item).ToList();

                if (decimalFormatLengthElements.Count > 0)
                {
                    List<DecimalFormatPatternSet> decimalFormatPatternSets = new List<DecimalFormatPatternSet>();
                    foreach (XElement decimalFormatLengthElement in decimalFormatLengthElements)
                    {
                        DecimalFormatPatternSet decimalFormatPatternSet = new DecimalFormatPatternSet();
                        decimalFormatPatternSet.Id = decimalFormatLengthElement.Attribute("type").Value.ToString();

                        List<XElement> patternElements = (from p in decimalFormatLengthElement
                                                              .Elements("decimalFormat").Elements("pattern")
                                                          select p).ToList();
                        List<DecimalFormatPattern> patterns = new List<DecimalFormatPattern>();
                        foreach (XElement patternElement in patternElements)
                        {
                            DecimalFormatPattern pattern = new DecimalFormatPattern();
                            pattern.Id = patternElement.Attribute("type").Value.ToString();
                            pattern.Pattern = patternElement.Value.ToString();
                            pattern.Count = GetPatternCount(patternElement.Attribute("count").Value.ToString());
                            patterns.Add(pattern);
                        }

                        decimalFormatPatternSet.Patterns = patterns.ToArray();

                        decimalFormatPatternSets.Add(decimalFormatPatternSet);
                    }

                    return decimalFormatPatternSets.ToArray();
                }
            }

            return null;
        }

        private static PatternCount GetPatternCount(string patternCount)
        {
            return (PatternCount)Enum.Parse(typeof(PatternCount), patternCount, true);
        }

        private static NumberingSystemSymbols GetNumberingSystemSymbols(IEnumerable<XElement> numbersElements, string numberingSystemId)
        {
            NumberingSystemSymbols symbols = null;

            XElement symbolElement = (from item in numbersElements.Elements("symbols")
                                      where item.Attribute("numberSystem") != null &&
                                      item.Attribute("numberSystem").Value.ToString() == numberingSystemId
                                      select item).FirstOrDefault();
            if (symbolElement != null)
            {
                symbols = new NumberingSystemSymbols();
                if (symbolElement.Element("decimal") != null)
                {
                    symbols.Decimal = symbolElement.Element("decimal").Value.ToString();
                }

                if (symbolElement.Element("group") != null)
                {
                    symbols.Group = symbolElement.Element("group").Value.ToString();
                }

                if (symbolElement.Element("list") != null)
                {
                    symbols.List = symbolElement.Element("list").Value.ToString();
                }

                if (symbolElement.Element("percentSign") != null)
                {
                    symbols.PercentSign = symbolElement.Element("percentSign").Value.ToString();
                }

                if (symbolElement.Element("plusSign") != null)
                {
                    symbols.PlusSign = symbolElement.Element("plusSign").Value.ToString();
                }

                if (symbolElement.Element("minusSign") != null)
                {
                    symbols.MinusSign = symbolElement.Element("minusSign").Value.ToString();
                }

                if (symbolElement.Element("exponential") != null)
                {
                    symbols.Exponential = symbolElement.Element("exponential").Value.ToString();
                }

                if (symbolElement.Element("perMille") != null)
                {
                    symbols.PerMille = symbolElement.Element("perMille").Value.ToString();
                }

                if (symbolElement.Element("infinity") != null)
                {
                    symbols.Infinity = symbolElement.Element("infinity").Value.ToString();
                }

                if (symbolElement.Element("nan") != null)
                {
                    symbols.Nan = symbolElement.Element("nan").Value.ToString();
                }
            }

            return symbols;
        }

        private static MessageSet GetMessages(XDocument document)
        {
            if (options != null && options.CultureOptions != null && !options.CultureOptions.IncludeMessages)
            {
                return null;
            }

            MessageSet messages = null;
            IEnumerable<XElement> ldmlElements = document.Elements("ldml");
            List<XElement> messageDatas = (from item in ldmlElements.Elements("posix")
                                                .Elements("messages").Elements()
                                            select item).ToList();
            if (messageDatas != null && messageDatas.Count > 0)
            {
                List<Message> messageList = new List<Message>();
                foreach(XElement messageData in messageDatas)
                {
                    messageList.Add(new Message()
                    {
                        Id = messageData.Name.ToString(),
                        Text = messageData.Value.ToString()
                    });
                }

                messages = new MessageSet();
                messages.Messages = messageList.ToArray();
            }

            return messages;
        }

        private static Characters GetCharacters(XDocument document)
        {
            if (options != null && options.CultureOptions != null && !options.CultureOptions.IncludeCharacters)
            {
                return null;
            }

            Characters characters = null;
            IEnumerable<XElement> ldmlElements = document.Elements("ldml");
            List<XElement> characterDatas = (from item in ldmlElements.Elements("characters")
                                            select item).ToList();
            if (characterDatas != null && characterDatas.Count > 0)
            {
                characters = new Characters();
                characters.ExemplarCharacters = GetCharacterArray(characterDatas, "exemplarCharacters", null);
                characters.AuxiliaryExemplarCharacters = GetCharacterArray(characterDatas, "exemplarCharacters", "auxiliary");
                characters.PunctuationExemplarCharacters = GetCharacterArray(characterDatas, "exemplarCharacters", "punctuation");
                characters.FinalEllipsis = GetString(characterDatas, "ellipsis", "final");
                characters.InitialEllipsis = GetString(characterDatas, "ellipsis", "initial");
                characters.MedialEllipsis = GetString(characterDatas, "ellipsis", "medial");
                characters.MoreInformation = GetString(characterDatas, "moreInformation", null);
            }

            return characters;
        }

        private static string[] GetCharacterArray(List<XElement> characterDatas, string elementName, string typeName)
        {
            string stringValue = GetString(characterDatas, elementName, typeName);
            if (String.IsNullOrEmpty(stringValue))
            {
                return null;
            }

            // strip off the leading and trailing square brackets
            stringValue = stringValue.Substring(1, stringValue.Length - 2);
            return stringValue.Split(' ');
        }

        private static string GetString(List<XElement> characterDatas, string elementName, string typeName)
        {
            XElement element;
            if (typeName == null)
            {
                element = (from cd in characterDatas.Elements(elementName)
                           where cd.Attribute("type") == null
                           select cd).FirstOrDefault();
            }
            else
            {
                element = (from cd in characterDatas.Elements(elementName)
                           where cd.Attribute("type") != null && cd.Attribute("type").Value.ToString() == typeName
                           select cd).FirstOrDefault();
            }

            if (element == null)
            {
                return null;
            }

            return element.Value.ToString();
        }

        private static Delimiters GetDelimiters(XDocument document)
        {
            if (options != null && options.CultureOptions != null && !options.CultureOptions.IncludeDelimiters)
            {
                return null;
            }

            Delimiters delimiters = null;
            IEnumerable<XElement> ldmlElements = document.Elements("ldml");
            List<XElement> delimiterDatas = (from item in ldmlElements.Elements("delimiters")
                                             select item).ToList();
            if (delimiterDatas != null && delimiterDatas.Count > 0)
            {
                delimiters = new Delimiters();
                delimiters.QuotationStart = GetString(delimiterDatas, "quotationStart", null);
                delimiters.QuotationEnd = GetString(delimiterDatas, "quotationEnd", null);
                delimiters.AlternateQuotationStart = GetString(delimiterDatas, "alternateQuotationStart", null);
                delimiters.AlternateQuotationEnd = GetString(delimiterDatas, "alternateQuotationEnd", null);
            }

            return delimiters;
        }

        private static UnitPatternSet[] GetUnitPatternSets(XDocument document)
        {
            if (options != null && options.CultureOptions != null && !options.CultureOptions.IncludeUnitPatternSets)
            {
                return null;
            }

            IEnumerable<XElement> ldmlElements = document.Elements("ldml");
            List<XElement> unitDatas = (from item in ldmlElements.Elements("units").Elements("unit")
                                             select item).ToList();
            if (unitDatas != null && unitDatas.Count > 0)
            {
                List<UnitPatternSet> unitPatternSets = new List<UnitPatternSet>();
                foreach (XElement unitData in unitDatas)
                {
                    UnitPatternSet unitPatternSet = new UnitPatternSet();
                    unitPatternSet.Id = unitData.Attribute("type").Value.ToString();

                    List<UnitPattern> unitPatterns = new List<UnitPattern>();
                    foreach (XElement unitPatternData in unitData.Elements("unitPattern"))
                    {
                        UnitPattern unitPattern = new UnitPattern();
                        unitPattern.Count = GetPatternCount(unitPatternData.Attribute("count").Value.ToString());
                        unitPattern.Pattern = unitPatternData.Value.ToString();

                        if (unitPatternData.Attribute("alt") != null)
                        {
                            unitPattern.Alt = unitPatternData.Attribute("alt").Value.ToString();
                        }

                        unitPatterns.Add(unitPattern);
                    }

                    unitPatternSet.UnitPatterns = unitPatterns.ToArray();

                    unitPatternSets.Add(unitPatternSet);
                }

                return unitPatternSets.ToArray();
            }

            return null;
        }

        private static Dates GetDates(XDocument document)
        {
            if (options != null && options.CultureOptions != null && !options.CultureOptions.IncludeDates)
            {
                return null;
            }

            Dates dates = null;
            IEnumerable<XElement> ldmlElements = document.Elements("ldml");
            List<XElement> calendarDatas = (from item in ldmlElements.Elements("dates")
                                                .Elements("calendars").Elements("calendar")
                                            select item).ToList();

            XElement defaultData = (from item in ldmlElements.Elements("dates")
                                        .Elements("calendars")
                                    select item.Element("default")).FirstOrDefault();

            if ((calendarDatas != null && calendarDatas.Count > 0) || defaultData != null)
            {
                dates = new Dates();

                if (defaultData != null)
                {
                    dates.DefaultCalendarId = defaultData.Attribute("choice").Value.ToString();
                }

                if (calendarDatas != null && calendarDatas.Count > 0)
                {
                    List<Calendar> calendars = new List<Calendar>();
                    foreach (XElement calendarData in calendarDatas)
                    {
                        Calendar calendar = new Calendar();
                        calendar.Id = calendarData.Attribute("type").Value.ToString();

                        calendar.CalendarDisplayNames = GetCalendarDisplayNames(calendarData);

                        calendar.MonthNameSets =
                            GetNameSets<MonthName, MonthNameSet>(calendarData, "months", "monthContext", "monthWidth", "month");

                        calendar.DayNameSets =
                            GetNameSets<DayName, DayNameSet>(calendarData, "days", "dayContext", "dayWidth", "day");

                        calendar.DayPeriodNameSets =
                            GetNameSets<DayPeriodName, DayPeriodNameSet>(calendarData, "dayPeriods", "dayPeriodContext", "dayPeriodWidth", "dayPeriod");

                        calendar.EraNameSets =
                            GetNameSets<EraName, EraNameSet>(calendarData, "eras", "eraAbbr", null, "era");

                        calendar.DateFormats = GetDateFormats(calendarData);

                        calendar.TimeFormats = GetTimeFormats(calendarData);

                        calendars.Add(calendar);
                    }

                    dates.Calendars = calendars.ToArray();
                }
            }

            return dates;
        }

        private static Layout GetLayout(XDocument document)
        {
            if (options != null && options.CultureOptions != null && !options.CultureOptions.IncludeLayout)
            {
                return null;
            }

            Layout layout = null;
            IEnumerable<XElement> ldmlElements = document.Elements("ldml");
            List<XElement> layoutDatas = (from item in ldmlElements.Elements("layout")
                                          select item).ToList();
            if (layoutDatas != null && layoutDatas.Count > 0)
            {
                XElement orientationData = layoutDatas.Elements("orientation").FirstOrDefault();
                if (orientationData != null)
                {
                    layout = new Layout();
                    layout.Orientation = new Orientation();

                    if (orientationData.Attribute("characters") != null)
                    {
                        layout.Orientation.Characters = orientationData.Attribute("characters").Value.ToString();
                    }

                    if (orientationData.Attribute("lines") != null)
                    {
                        layout.Orientation.Lines = orientationData.Attribute("lines").Value.ToString();
                    }
                }
            }

            return layout;
        }

        private static ListPattern[] GetListPatterns(XDocument document)
        {
            if (options != null && options.CultureOptions != null && !options.CultureOptions.IncludeListPatterns)
            {
                return null;
            }

            IEnumerable<XElement> ldmlElements = document.Elements("ldml");
            List<XElement> listPatternDatas = (from item in ldmlElements.Elements("listPatterns")
                                                .Elements("listPattern").Elements("listPatternPart")
                                            select item).ToList();
            if (listPatternDatas != null && listPatternDatas.Count > 0)
            {
                List<ListPattern> listPatterns = new List<ListPattern>();
                foreach (XElement listPatternData in listPatternDatas)
                {
                    ListPattern listPattern = new ListPattern();
                    listPattern.Id = listPatternData.Attribute("type").Value.ToString();
                    listPattern.Pattern = listPatternData.Value.ToString();
                    listPatterns.Add(listPattern);
                }

                return listPatterns.ToArray();
            }

            return null;
        }

        private static DateFormat[] GetDateFormats(XElement calendarData)
        {
            List<DateFormat> dateFormats = new List<DateFormat>();
            List<XElement> dateFormatDatas = (from item in calendarData.Elements("dateFormats")
                                        .Elements("dateFormatLength")
                            select item).ToList();

            if (dateFormatDatas.Count == 0)
            {
                return null;
            }

            foreach (XElement dateFormatData in dateFormatDatas)
            {
                XElement patternData = (from p in dateFormatData.Elements("dateFormat").Elements("pattern")
                                        select p).FirstOrDefault();
                if (patternData != null)
                {
                    DateFormat dateFormat = new DateFormat();
                    dateFormat.Id = dateFormatData.Attribute("type").Value.ToString();
                    dateFormat.Pattern = Sanitize(patternData.Value.ToString());

                    dateFormats.Add(dateFormat);
                }
            }

            return dateFormats.ToArray();
        }

        private static string Sanitize(string s)
        {
            // remove erroneous 8207 characters in CLDR data
            return s.Replace(((char)8207).ToString(), String.Empty);
        }

        private static TimeFormat[] GetTimeFormats(XElement calendarData)
        {
            List<TimeFormat> timeFormats = new List<TimeFormat>();
            List<XElement> timeFormatDatas = (from item in calendarData.Elements("timeFormats")
                                                .Elements("timeFormatLength")
                                              select item).ToList();

            if (timeFormatDatas.Count == 0)
            {
                return null;
            }

            foreach (XElement timeFormatData in timeFormatDatas)
            {
                XElement patternData = (from p in timeFormatData.Elements("timeFormat").Elements("pattern")
                                        select p).FirstOrDefault();
                if (patternData != null)
                {
                    TimeFormat timeFormat = new TimeFormat();
                    timeFormat.Id = timeFormatData.Attribute("type").Value.ToString();
                    timeFormat.Pattern = Sanitize(patternData.Value.ToString());

                    timeFormats.Add(timeFormat);
                }
            }

            return timeFormats.ToArray();
        }

        private static CalendarDisplayNames GetCalendarDisplayNames(XElement calendarData)
        {
            List<XElement> fieldDatas = (from item in calendarData.Elements("fields")
                                             .Elements("field")
                                         select item).ToList();

            if (fieldDatas == null || fieldDatas.Count == 0)
            {
                return null;
            }

            CalendarDisplayNames calendarDisplayNames = new CalendarDisplayNames();

            foreach (XElement fieldData in fieldDatas)
            {
                string type = fieldData.Attribute("type").Value.ToString();
                string displayName = 
                    fieldData.Element("displayName") == null ? null : fieldData.Element("displayName").Value.ToString();

                if (type == "day")
                {
                    calendarDisplayNames.Day = displayName;

                    calendarDisplayNames.Yesterday = (from r in fieldData.Elements("relative")
                                                      where r.Attribute("type").Value.ToString() == "-1"
                                                      select r.Value.ToString()).FirstOrDefault();

                    calendarDisplayNames.Today = (from r in fieldData.Elements("relative")
                                                      where r.Attribute("type").Value.ToString() == "0"
                                                      select r.Value.ToString()).FirstOrDefault();

                    calendarDisplayNames.Tomorrow = (from r in fieldData.Elements("relative")
                                                      where r.Attribute("type").Value.ToString() == "1"
                                                      select r.Value.ToString()).FirstOrDefault();
                }
                else if (type == "dayperiod")
                {
                    calendarDisplayNames.DayPeriod = displayName;
                }
                else if (type == "era")
                {
                    calendarDisplayNames.Era = displayName;
                }
                else if (type == "hour")
                {
                    calendarDisplayNames.Hour = displayName;
                }
                else if (type == "minute")
                {
                    calendarDisplayNames.Minute = displayName;
                }
                else if (type == "month")
                {
                    calendarDisplayNames.Month = displayName;
                }
                else if (type == "second")
                {
                    calendarDisplayNames.Second = displayName;
                }
                else if (type == "week")
                {
                    calendarDisplayNames.Week = displayName;
                }
                else if (type == "weekday")
                {
                    calendarDisplayNames.WeekDay = displayName;
                }
                else if (type == "year")
                {
                    calendarDisplayNames.Year = displayName;
                }
                else if (type == "zone")
                {
                    calendarDisplayNames.Zone = displayName;
                }
            }

            return calendarDisplayNames;
        }

        private static TSet[] GetNameSets<T, TSet>(
            XElement calendarData, string groupName, string groupContextName, string groupWidthName, string itemName)
            where T: CalendarName, new() 
            where TSet: CalendarNameSet<T>, new()
        {
            List<XElement> nameSetDatas;

            if (groupWidthName != null)
            {
                nameSetDatas = (from item in calendarData.Elements(groupName)
                                            .Elements(groupContextName).Elements(groupWidthName)
                                select item).ToList();
            }
            else
            {
                nameSetDatas = (from item in calendarData.Elements(groupName)
                                            .Elements(groupContextName)
                                select item).ToList();
            }

            if (nameSetDatas.Count == 0)
            {
                return null;
            }

            List<TSet> nameSets = new List<TSet>();
            foreach (XElement nameSetData in nameSetDatas)
            {
                TSet nameSet = new TSet();

                if (nameSetData.Attribute("type") != null)
                {
                    nameSet.Id = nameSetData.Attribute("type").Value.ToString();
                }

                List<T> names = new List<T>();
                List<XElement> nameDatas = (from item in nameSetData.Elements(itemName)
                                            select item).ToList();
                foreach (XElement nameData in nameDatas)
                {
                    T name = new T();
                    name.Id = nameData.Attribute("type").Value.ToString();
                    name.Name = nameData.Value.ToString();
                    names.Add(name);
                }

                nameSet.Names = names.ToArray();

                nameSets.Add(nameSet);
            }

            return nameSets.ToArray();
        }

        private static List<T> GetDisplayNames<T>(XDocument document, string listName, string itemName) where T : DisplayName, new()
        {
            if (options != null && options.CultureOptions != null)
            {
                if ((listName == "languages" && !options.CultureOptions.IncludeLanguageDisplayNames) ||
                    (listName == "territories" && !options.CultureOptions.IncludeRegionDisplayNames) ||
                    (listName == "scripts" && !options.CultureOptions.IncludeScriptDisplayNames))
                {
                    return null;
                }
            }

            IEnumerable<XElement> ldmlElements = document.Elements("ldml");
            List<XElement> datas = (from item in ldmlElements.Elements("localeDisplayNames")
                                                .Elements(listName).Elements(itemName)
                                    select item).ToList();
            if (datas != null && datas.Count > 0)
            {
                List<T> displayNames = new List<T>();
                foreach (XElement data in datas)
                {
                    T displayName = new T();
                    displayName.Id = data.Attribute("type").Value.ToString();
                    displayName.Name = data.Value;
                    displayNames.Add(displayName);
                }

                return displayNames;
            }

            return null;
        }
    }
}
