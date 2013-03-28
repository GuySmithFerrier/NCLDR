namespace NCldr.Types
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Extensions;

    /// <summary>
    /// Culture is a representation of the data for a given language and optionally a script, region and variant
    /// </summary>
    /// <remarks>Culture is the NCLDR equivalent to .NET's CultureInfo class.
    /// Note the distinction between the Culture class and the CultureData class: the Culture class
    /// offers data that is fully resolved with the culture's parents whereas the CultureData class
    /// is simply the differences that are relevant for an individual language/script/region/variant.
    /// As such in general you should prefer the Culture class over the CultureData class.</remarks>
    public class Culture
    {
        /// <summary>
        /// Gets or sets the resolved Casing
        /// </summary>
        private Casing casing;

        /// <summary>
        /// Gets or sets the un-resolved Casing
        /// </summary>
        private Casing casingNoParents;

        /// <summary>
        /// Gets or sets the resolved Characters
        /// </summary>
        private Characters characters;

        /// <summary>
        /// Gets or sets the un-resolved Characters
        /// </summary>
        private Characters charactersNoParents;

        /// <summary>
        /// Gets or sets the resolved Dates
        /// </summary>
        private Dates dates;

        /// <summary>
        /// Gets or sets the un-resolved Dates
        /// </summary>
        private Dates datesNoParents;

        /// <summary>
        /// Gets or sets the resolved Delimiters
        /// </summary>
        private Delimiters delimiters;

        /// <summary>
        /// Gets or sets the un-resolved Delimiters
        /// </summary>
        private Delimiters delimitersNoParents;

        /// <summary>
        /// Gets or sets the resolved Layout
        /// </summary>
        private Layout layout;

        /// <summary>
        /// Gets or sets the un-resolved Layout
        /// </summary>
        private Layout layoutNoParents;

        /// <summary>
        /// Gets or sets the resolved ListPatterns
        /// </summary>
        private ListPattern[] listPatterns;

        /// <summary>
        /// Gets or sets the un-resolved ListPatterns
        /// </summary>
        private ListPattern[] listPatternsNoParents;

        /// <summary>
        /// Gets or sets the resolved Messages
        /// </summary>
        private MessageSet messages;

        /// <summary>
        /// Gets or sets the un-resolved Messages
        /// </summary>
        private MessageSet messagesNoParents;

        /// <summary>
        /// Gets or sets the resolved Numbers
        /// </summary>
        private Numbers numbers;

        /// <summary>
        /// Gets or sets the un-resolved Numbers
        /// </summary>
        private Numbers numbersNoParents;

        /// <summary>
        /// Gets or sets the resolved RuleBasedNumberFormatting
        /// </summary>
        private RuleBasedNumberFormatting ruleBasedNumberFormatting;

        /// <summary>
        /// Gets or sets the un-resolved RuleBasedNumberFormatting
        /// </summary>
        private RuleBasedNumberFormatting ruleBasedNumberFormattingNoParents;

        /// <summary>
        /// Gets or sets the resolved LanguageDisplayNames
        /// </summary>
        private List<LanguageDisplayName> languageDisplayNames;

        /// <summary>
        /// Gets or sets the resolved RegionDisplayNames
        /// </summary>
        private List<RegionDisplayName> regionDisplayNames;

        /// <summary>
        /// Gets or sets the resolved ScriptDisplayNames
        /// </summary>
        private List<ScriptDisplayName> scriptDisplayNames;

        /// <summary>
        /// Gets or sets the un-resolved LanguageDisplayName
        /// </summary>
        private List<LanguageDisplayName> languageDisplayNamesNoParents;

        /// <summary>
        /// Gets or sets the un-resolved RegionDisplayNames
        /// </summary>
        private List<RegionDisplayName> regionDisplayNamesNoParents;

        /// <summary>
        /// Gets or sets the un-resolved ScriptDisplayNames
        /// </summary>
        private List<ScriptDisplayName> scriptDisplayNamesNoParents;

        /// <summary>
        /// Gets or sets the resolved UnitPatternSets
        /// </summary>
        private UnitPatternSet[] unitPatternSets;

        /// <summary>
        /// Gets or sets the un-resolved UnitPatternSets
        /// </summary>
        private UnitPatternSet[] unitPatternSetsNoParents;

        /// <summary>
        /// Initializes a new instance of the Culture class
        /// </summary>
        public Culture()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Culture class
        /// </summary>
        /// <param name="cultureData">The CultureData for this language/script/region/variant</param>
        public Culture(CultureData cultureData)
        {
            this.casingNoParents = cultureData.Casing;
            this.charactersNoParents = cultureData.Characters;
            this.datesNoParents = cultureData.Dates;
            this.delimitersNoParents = cultureData.Delimiters;
            this.Identity = cultureData.Identity;
            this.languageDisplayNamesNoParents = cultureData.LanguageDisplayNames;
            this.layoutNoParents = cultureData.Layout;
            this.listPatternsNoParents = cultureData.ListPatterns;
            this.messagesNoParents = cultureData.Messages;
            this.numbersNoParents = cultureData.Numbers;
            this.regionDisplayNamesNoParents = cultureData.RegionDisplayNames;
            this.ruleBasedNumberFormattingNoParents = cultureData.RuleBasedNumberFormatting;
            this.scriptDisplayNamesNoParents = cultureData.ScriptDisplayNames;
            this.unitPatternSetsNoParents = cultureData.UnitPatternSets;
        }

        /// <summary>
        /// Gets or sets the culture's Identity 
        /// </summary>
        public Identity Identity { get; set; }

        /// <summary>
        /// Gets or sets the resolved Casing
        /// </summary>
        public Casing Casing
        {
            get
            {
                if (this.casing == null)
                {
                    this.casing = this.GetCasing();
                }

                return this.casing;
            }

            set
            {
                this.casing = value;
            }
        }

        /// <summary>
        /// Gets or sets the resolved Characters
        /// </summary>
        public Characters Characters
        {
            get
            {
                if (this.characters == null)
                {
                    this.characters = this.GetCharacters();
                }

                return this.characters;
            }

            set
            {
                this.characters = value;
            }
        }

        /// <summary>
        /// Gets or sets the resolved Dates
        /// </summary>
        public Dates Dates
        {
            get
            {
                if (this.dates == null)
                {
                    this.dates = this.GetDates();
                }

                return this.dates;
            }

            set
            {
                this.datesNoParents = value;
            }
        }

        /// <summary>
        /// Gets or sets the resolved Delimiters
        /// </summary>
        public Delimiters Delimiters
        {
            get
            {
                if (this.delimiters == null)
                {
                    this.delimiters = this.GetDelimiters();
                }

                return this.delimiters;
            }

            set
            {
                this.delimiters = value;
            }
        }

        /// <summary>
        /// Gets or sets the resolved Layout
        /// </summary>
        public Layout Layout
        {
            get
            {
                if (this.layout == null)
                {
                    this.layout = this.GetLayout();
                }

                return this.layout;
            }

            set
            {
                this.layout = value;
            }
        }

        /// <summary>
        /// Gets or sets the resolved ListPatterns
        /// </summary>
        public ListPattern[] ListPatterns
        {
            get
            {
                if (this.listPatterns == null)
                {
                    this.listPatterns = this.GetListPatterns();
                }

                return this.listPatterns;
            }

            set
            {
                this.ListPatterns = value;
            }
        }

        /// <summary>
        /// Gets or sets the resolved Messages
        /// </summary>
        public MessageSet Messages
        {
            get
            {
                if (this.messages == null)
                {
                    this.messages = this.GetMessages();
                }

                return this.messages;
            }

            set
            {
                this.messagesNoParents = value;
            }
        }

        /// <summary>
        /// Gets or sets the resolved Numbers
        /// </summary>
        public Numbers Numbers
        {
            get
            {
                if (this.numbers == null)
                {
                    this.numbers = this.GetNumbers();
                }

                return this.numbers;
            }

            set
            {
                this.numbers = value;
            }
        }

        /// <summary>
        /// Gets or sets the resolved RuleBasedNumberFormatting
        /// </summary>
        public RuleBasedNumberFormatting RuleBasedNumberFormatting
        {
            get
            {
                if (this.ruleBasedNumberFormatting == null)
                {
                    this.ruleBasedNumberFormatting = this.GetRuleBasedNumberFormatting();
                }

                return this.ruleBasedNumberFormatting;
            }

            set
            {
                this.ruleBasedNumberFormatting = value;
            }
        }

        /// <summary>
        /// Gets or sets the resolved LanguageDisplayNames
        /// </summary>
        public List<LanguageDisplayName> LanguageDisplayNames
        {
            get
            {
                if (this.languageDisplayNames == null)
                {
                    this.languageDisplayNames = this.GetDisplayNames<LanguageDisplayName>(
                        this.languageDisplayNamesNoParents,
                        (parentCulture) => { return parentCulture.languageDisplayNamesNoParents; });
                }

                return this.languageDisplayNames;
            }

            set
            {
                this.languageDisplayNames = value;
            }
        }

        /// <summary>
        /// Gets or sets the resolved RegionDisplayNames
        /// </summary>
        public List<RegionDisplayName> RegionDisplayNames
        {
            get
            {
                if (this.regionDisplayNames == null)
                {
                    this.regionDisplayNames = this.GetDisplayNames<RegionDisplayName>(
                        this.regionDisplayNamesNoParents,
                        (parentCulture) => { return parentCulture.regionDisplayNamesNoParents; });
                }

                return this.regionDisplayNames;
            }

            set
            {
                this.regionDisplayNames = value;
            }
        }

        /// <summary>
        /// Gets or sets the resolved ScriptDisplayNames
        /// </summary>
        public List<ScriptDisplayName> ScriptDisplayNames
        {
            get
            {
                if (this.scriptDisplayNames == null)
                {
                    this.scriptDisplayNames = this.GetDisplayNames<ScriptDisplayName>(
                        this.scriptDisplayNamesNoParents,
                        (parentCulture) => { return parentCulture.scriptDisplayNamesNoParents; });
                }

                return this.scriptDisplayNames;
            }

            set
            {
                this.scriptDisplayNames = value;
            }
        }

        /// <summary>
        /// Gets or sets the resolved UnitPatternSets
        /// </summary>
        public UnitPatternSet[] UnitPatternSets
        {
            get
            {
                if (this.unitPatternSets == null)
                {
                    this.unitPatternSets = this.GetUnitPatternSets();
                }

                return this.unitPatternSets;
            }

            set
            {
                this.unitPatternSets = value;
            }
        }

        /// <summary>
        /// Gets the culture name
        /// </summary>
        public string Name
        {
            get
            {
                return this.Identity.CultureName;
            }
        }

        /// <summary>
        /// Gets the culture's English name
        /// </summary>
        public string EnglishName
        {
            get
            {
                return this.Identity.EnglishName;
            }
        }

        /// <summary>
        /// Gets the culture's native name
        /// </summary>
        public string NativeName
        {
            get
            {
                return this.DisplayName(this.Identity.Language.Id);
            }
        }

        /// <summary>
        /// Gets a value indicating whether the culture is a neutral culture
        /// </summary>
        public bool IsNeutralCulture
        {
            get
            {
                return this.Identity.Region == null;
            }
        }

        /// <summary>
        /// GetCultures gets an array of cultures that are either neutral or specific according to the parameter passed
        /// </summary>
        /// <param name="isNeutral">Indicates whether the cultures should be neutral. If false then the cultures will be specific.</param>
        /// <returns>An array of cultures</returns>
        private static Culture[] GetCultures(bool isNeutral)
        {
            List<Culture> cultures = new List<Culture>();
            foreach (Culture culture in NCldr.Cultures)
            {
                if (isNeutral)
                {
                    if (culture.IsNeutralCulture)
                    {
                        cultures.Add(culture);
                    }
                }
                else
                {
                    if (!culture.IsNeutralCulture)
                    {
                        cultures.Add(culture);
                    }
                }
            }

            return cultures.ToArray();
        }

        /// <summary>
        /// GetCasing gets the resolved Casing
        /// </summary>
        /// <returns>The resolved Casing</returns>
        private Casing GetCasing()
        {
            Casing casing = null;
            if (this.casingNoParents != null)
            {
                casing = (Casing)this.casingNoParents.Clone();
            }

            Culture[] parentCultures = this.GetParents();
            foreach (Culture parentCulture in parentCultures)
            {
                casing = Casing.Combine(casing, parentCulture.casingNoParents);
            }

            return casing;
        }

        /// <summary>
        /// GetCharacters gets the resolved Characters
        /// </summary>
        /// <returns>The resolved Characters</returns>
        private Characters GetCharacters()
        {
            Characters characters = null;
            if (this.charactersNoParents != null)
            {
                characters = (Characters)this.charactersNoParents.Clone();
            }

            Culture[] parentCultures = this.GetParents();
            foreach (Culture parentCulture in parentCultures)
            {
                characters = Characters.Combine(characters, parentCulture.charactersNoParents);
            }

            return characters;
        }

        /// <summary>
        /// GetDates gets the resolved Dates
        /// </summary>
        /// <returns>The resolved Dates</returns>
        private Dates GetDates()
        {
            Dates dates = null;
            if (this.datesNoParents != null)
            {
                dates = (Dates)this.datesNoParents.Clone();
            }

            Culture[] parentCultures = this.GetParents();
            foreach (Culture parentCulture in parentCultures)
            {
                dates = Dates.Combine(dates, parentCulture.datesNoParents);
            }

            return dates;
        }

        /// <summary>
        /// GetDelimiters gets the resolved Delimiters
        /// </summary>
        /// <returns>The resolved Delimiters</returns>
        private Delimiters GetDelimiters()
        {
            Delimiters delimiters = null;
            if (this.delimitersNoParents != null)
            {
                delimiters = (Delimiters)this.delimitersNoParents.Clone();
            }

            Culture[] parentCultures = this.GetParents();
            foreach (Culture parentCulture in parentCultures)
            {
                delimiters = Delimiters.Combine(delimiters, parentCulture.delimitersNoParents);
            }

            return delimiters;
        }

        /// <summary>
        /// GetLayout gets the resolved Layout
        /// </summary>
        /// <returns>The resolved Layout</returns>
        private Layout GetLayout()
        {
            Layout layout = null;
            if (this.layoutNoParents != null)
            {
                layout = (Layout)this.layoutNoParents.Clone();
            }

            Culture[] parentCultures = this.GetParents();
            foreach (Culture parentCulture in parentCultures)
            {
                layout = Layout.Combine(layout, parentCulture.layoutNoParents);
            }

            return layout;
        }

        /// <summary>
        /// GetListPatterns gets the resolved ListPatterns
        /// </summary>
        /// <returns>The resolved ListPatterns</returns>
        private ListPattern[] GetListPatterns()
        {
            ListPattern[] listPatterns = null;
            if (this.listPatternsNoParents != null)
            {
                listPatterns = (ListPattern[])this.listPatternsNoParents.Clone();
            }

            Culture[] parentCultures = this.GetParents();
            foreach (Culture parentCulture in parentCultures)
            {
                listPatterns = ListPattern.Combine(listPatterns, parentCulture.listPatternsNoParents);
            }

            return listPatterns;
        }

        /// <summary>
        /// GetMessages gets the resolved Messages
        /// </summary>
        /// <returns>The resolved Messages</returns>
        private MessageSet GetMessages()
        {
            MessageSet messages = null;
            if (this.messagesNoParents != null)
            {
                messages = (MessageSet)this.messagesNoParents.Clone();
            }

            Culture[] parentCultures = this.GetParents();
            foreach (Culture parentCulture in parentCultures)
            {
                messages = MessageSet.Combine(messages, parentCulture.messagesNoParents);
            }

            return messages;
        }

        /// <summary>
        /// GetNumbers gets the resolved Numbers
        /// </summary>
        /// <returns>The resolved Numbers</returns>
        private Numbers GetNumbers()
        {
            Numbers numbers = null;
            if (this.numbersNoParents != null)
            {
                numbers = (Numbers)this.numbersNoParents.Clone();
            }

            Culture[] parentCultures = this.GetParents();
            foreach (Culture parentCulture in parentCultures)
            {
                numbers = Numbers.Combine(numbers, parentCulture.numbersNoParents);
            }

            return numbers;
        }

        /// <summary>
        /// GetRuleBasedNumberFormatting gets the resolved RuleBasedNumberFormatting
        /// </summary>
        /// <returns>The resolved RuleBasedNumberFormatting</returns>
        private RuleBasedNumberFormatting GetRuleBasedNumberFormatting()
        {
            RuleBasedNumberFormatting ruleBasedNumberFormatting = null;
            if (this.ruleBasedNumberFormattingNoParents != null)
            {
                ruleBasedNumberFormatting = (RuleBasedNumberFormatting)this.ruleBasedNumberFormattingNoParents.Clone();
            }

            Culture[] parentCultures = this.GetParents();
            foreach (Culture parentCulture in parentCultures)
            {
                ruleBasedNumberFormatting = RuleBasedNumberFormatting.Combine(ruleBasedNumberFormatting, parentCulture.ruleBasedNumberFormattingNoParents);
            }

            return ruleBasedNumberFormatting;
        }

        /// <summary>
        /// GetUnitPatternSets gets the resolved UnitPatternSets
        /// </summary>
        /// <returns>The resolved UnitPatternSets</returns>
        private UnitPatternSet[] GetUnitPatternSets()
        {
            UnitPatternSet[] unitPatternSets = null;
            if (this.unitPatternSetsNoParents != null)
            {
                unitPatternSets = (UnitPatternSet[])this.unitPatternSetsNoParents.Clone();
            }

            Culture[] parentCultures = this.GetParents();
            foreach (Culture parentCulture in parentCultures)
            {
                unitPatternSets = UnitPatternSet.Combine(unitPatternSets, parentCulture.unitPatternSetsNoParents);
            }

            return unitPatternSets;
        }

        /// <summary>
        /// Gets the culture's display name in a given language
        /// </summary>
        /// <param name="languageId">The Id of the language to get the display name for</param>
        /// <returns>The display name in the given language</returns>
        public string DisplayName(string languageId)
        {
            return this.Identity.DisplayName(languageId);
        }

        /// <summary>
        /// GetCultures gets an array of Culture objects for the given culture types
        /// </summary>
        /// <param name="cultureTypes">The CultureTypes to get the cultures for</param>
        /// <returns>An array of Culture objects</returns>
        public static Culture[] GetCultures(CultureTypes cultureTypes)
        {
            if (cultureTypes == CultureTypes.NeutralCultures)
            {
                return GetCultures(true);
            }
            else if (cultureTypes == CultureTypes.SpecificCultures)
            {
                return GetCultures(false);
            }

            return NCldr.Cultures;
        }

        /// <summary>
        /// GetLanguageDisplayNames gets the resolved language display names
        /// </summary>
        /// <returns>The resolved language display names</returns>
        private List<T> GetDisplayNames<T>(List<T> displayNamesNoParents, Func<Culture, List<T>> getParentsDisplayNames) where T : DisplayName
        {
            List<T> displayNames = null;
            if (displayNamesNoParents != null)
            {
                displayNames = (List<T>)displayNamesNoParents.Clone();
            }

            Culture[] parentCultures = this.GetParents();
            foreach (Culture parentCulture in parentCultures)
            {
                displayNames = Types.DisplayName.Combine<T>(displayNames, getParentsDisplayNames(parentCulture));
            }

            return displayNames;
        }

        /// <summary>
        /// GetParents gets an array of parent Cultures (where the order of the elements is determined by the immediate parent first)
        /// </summary>
        /// <returns>An array of parent Cultures</returns>
        public Culture[] GetParents()
        {
            return Culture.GetParents(this.Identity.CultureName);
        }

        /// <summary>
        /// GetParents gets an array of parent Cultures (where the order of the elements is determined by the immediate parent first)
        /// </summary>
        /// <param name="cultureName">The name of the culture to get the parents for</param>
        /// <returns>An array of parent Cultures</returns>
        public static Culture[] GetParents(string cultureName)
        {
            string[] parentCultureNames = GetParentNames(cultureName);
            List<Culture> parentCultures = new List<Culture>();
            foreach (string parentCultureName in parentCultureNames)
            {
                parentCultures.Add(Culture.GetCulture(parentCultureName));
            }

            return parentCultures.ToArray();
        }

        /// <summary>
        /// GetParentName gets the name of the culture's immediate parent culture
        /// </summary>
        /// <returns>The name of the parent culture</returns>
        public string GetParentName()
        {
            return Culture.GetParentName(this.Identity.CultureName);
        }

        /// <summary>
        /// GetParentNames gets an array of parent culture names (where the order of the elements is determined by the immediate parent first)
        /// </summary>
        /// <returns>An array of parent culture names</returns>
        public string[] GetParentNames()
        {
            return Culture.GetParentNames(this.Identity.CultureName);
        }

        /// <summary>
        /// GetParentNames gets an array of parent culture names (where the order of the elements is determined by the immediate parent first)
        /// </summary>
        /// <param name="cultureName">The name of the culture to get the parents for</param>
        /// <returns>An array of parent culture names</returns>
        public static string[] GetParentNames(string cultureName)
        {
            List<string> parentCultureNames = new List<string>();
            string parentCultureName = GetParentName(cultureName);
            while (parentCultureName != null)
            {
                parentCultureNames.Add(parentCultureName);
                parentCultureName = GetParentName(parentCultureName);
            }

            return parentCultureNames.ToArray();
        }

        /// <summary>
        /// GetParentName gets the name of the culture's immediate parent culture
        /// </summary>
        /// <param name="cultureName">The name of the culture to get the parents for</param>
        /// <returns>The name of the parent culture</returns>
        public static string GetParentName(string cultureName)
        {
            if (string.Compare(cultureName, "root", StringComparison.InvariantCulture) == 0)
            {
                return null;
            }

            if (NCldr.ParentCultures != null)
            {
                string parentCultureId = (from p in NCldr.ParentCultures
                                          where p.CultureIds.Contains(cultureName)
                                          select p.ParentId).FirstOrDefault();
                if (parentCultureId != null)
                {
                    // this culture has a 'non-regular' parent
                    return parentCultureId;
                }
            }

            // the culture's parent is based on the regular naming convention
            int dashIndex = cultureName.LastIndexOf('-');
            if (dashIndex == -1)
            {
                return "root";
            }

            return cultureName.Substring(0, dashIndex);
        }

        /// <summary>
        /// GetCulture gets a Culture for the given culture name
        /// </summary>
        /// <param name="cultureName">The name of the culture</param>
        /// <returns>A Culture object or null if the name is unknown</returns>
        public static Culture GetCulture(string cultureName)
        {
            return (from c in NCldr.Cultures
                    where string.Compare(c.Identity.CultureName, cultureName, StringComparison.InvariantCulture) == 0
                    select c).FirstOrDefault();
        }
    }
}
