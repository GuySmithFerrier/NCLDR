namespace NCldr.Types
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

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
        private Messages messages;

        /// <summary>
        /// Gets or sets the un-resolved Messages
        /// </summary>
        private Messages messagesNoParents;

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
                casing = this.CombineCasing(casing, parentCulture.casingNoParents);
            }

            return casing;
        }

        /// <summary>
        /// CombineCasing combines a child with a parent as necessary and returns the combined object
        /// </summary>
        /// <param name="combinedCasing">The child object</param>
        /// <param name="parentCasing">The parent object</param>
        /// <returns>The combined object</returns>
        private Casing CombineCasing(Casing combinedCasing, Casing parentCasing)
        {
            if (combinedCasing == null && parentCasing == null)
            {
                return null;
            }
            else if (combinedCasing == null)
            {
                return (Casing)parentCasing.Clone();
            }
            else if (parentCasing == null)
            {
                return combinedCasing;
            }

            if (combinedCasing.CalendarField == CasingType.None)
            {
                combinedCasing.CalendarField = parentCasing.CalendarField;
            }

            if (combinedCasing.DayFormatExceptNarrow == CasingType.None)
            {
                combinedCasing.DayFormatExceptNarrow = parentCasing.DayFormatExceptNarrow;
            }

            if (combinedCasing.DayNarrow == CasingType.None)
            {
                combinedCasing.DayNarrow = parentCasing.DayNarrow;
            }

            if (combinedCasing.DayStandAloneExceptNarrow == CasingType.None)
            {
                combinedCasing.DayStandAloneExceptNarrow = parentCasing.DayStandAloneExceptNarrow;
            }

            if (combinedCasing.DisplayName == CasingType.None)
            {
                combinedCasing.DisplayName = parentCasing.DisplayName;
            }

            if (combinedCasing.DisplayNameCount == CasingType.None)
            {
                combinedCasing.DisplayNameCount = parentCasing.DisplayNameCount;
            }

            if (combinedCasing.EraAbbr == CasingType.None)
            {
                combinedCasing.EraAbbr = parentCasing.EraAbbr;
            }

            if (combinedCasing.EraName == CasingType.None)
            {
                combinedCasing.EraName = parentCasing.EraName;
            }

            if (combinedCasing.EraNarrow == CasingType.None)
            {
                combinedCasing.EraNarrow = parentCasing.EraNarrow;
            }

            if (combinedCasing.Key == CasingType.None)
            {
                combinedCasing.Key = parentCasing.Key;
            }

            if (combinedCasing.Language == CasingType.None)
            {
                combinedCasing.Language = parentCasing.Language;
            }

            if (combinedCasing.MetaZoneLong == CasingType.None)
            {
                combinedCasing.MetaZoneLong = parentCasing.MetaZoneLong;
            }

            if (combinedCasing.MetaZoneShort == CasingType.None)
            {
                combinedCasing.MetaZoneShort = parentCasing.MetaZoneShort;
            }

            if (combinedCasing.MonthFormatExceptNarrow == CasingType.None)
            {
                combinedCasing.MonthFormatExceptNarrow = parentCasing.MonthFormatExceptNarrow;
            }

            if (combinedCasing.MonthNarrow == CasingType.None)
            {
                combinedCasing.MonthNarrow = parentCasing.MonthNarrow;
            }

            if (combinedCasing.MonthStandAloneExceptNarrow == CasingType.None)
            {
                combinedCasing.MonthStandAloneExceptNarrow = parentCasing.MonthStandAloneExceptNarrow;
            }

            if (combinedCasing.QuarterAbbreviated == CasingType.None)
            {
                combinedCasing.QuarterAbbreviated = parentCasing.QuarterAbbreviated;
            }

            if (combinedCasing.Region == CasingType.None)
            {
                combinedCasing.Region = parentCasing.Region;
            }

            if (combinedCasing.Script == CasingType.None)
            {
                combinedCasing.Script = parentCasing.Script;
            }

            if (combinedCasing.Symbol == CasingType.None)
            {
                combinedCasing.Symbol = parentCasing.Symbol;
            }

            if (combinedCasing.Tense == CasingType.None)
            {
                combinedCasing.Tense = parentCasing.Tense;
            }

            if (combinedCasing.Type == CasingType.None)
            {
                combinedCasing.Type = parentCasing.Type;
            }

            if (combinedCasing.ZoneExemplarCity == CasingType.None)
            {
                combinedCasing.ZoneExemplarCity = parentCasing.ZoneExemplarCity;
            }

            return combinedCasing;
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
                characters = this.CombineCharacters(characters, parentCulture.charactersNoParents);
            }

            return characters;
        }

        /// <summary>
        /// CombineCharacters combines a child with a parent as necessary and returns the combined object
        /// </summary>
        /// <param name="combinedCharacters">The child object</param>
        /// <param name="parentCharacters">The parent object</param>
        /// <returns>The combined object</returns>
        private Characters CombineCharacters(Characters combinedCharacters, Characters parentCharacters)
        {
            if (combinedCharacters == null && parentCharacters == null)
            {
                return null;
            }
            else if (combinedCharacters == null)
            {
                return (Characters)parentCharacters.Clone();
            }
            else if (parentCharacters == null)
            {
                return combinedCharacters;
            }

            if (combinedCharacters.ExemplarCharacters == null || combinedCharacters.ExemplarCharacters.GetLength(0) == 0)
            {
                combinedCharacters.ExemplarCharacters = parentCharacters.ExemplarCharacters;
            }

            if (combinedCharacters.AuxiliaryExemplarCharacters == null
                || combinedCharacters.AuxiliaryExemplarCharacters.GetLength(0) == 0)
            {
                combinedCharacters.AuxiliaryExemplarCharacters = parentCharacters.AuxiliaryExemplarCharacters;
            }

            if (combinedCharacters.PunctuationExemplarCharacters == null
                || combinedCharacters.PunctuationExemplarCharacters.GetLength(0) == 0)
            {
                combinedCharacters.PunctuationExemplarCharacters = parentCharacters.PunctuationExemplarCharacters;
            }

            if (combinedCharacters.FinalEllipsis == null)
            {
                combinedCharacters.FinalEllipsis = parentCharacters.FinalEllipsis;
            }

            if (combinedCharacters.InitialEllipsis == null)
            {
                combinedCharacters.InitialEllipsis = parentCharacters.InitialEllipsis;
            }

            if (combinedCharacters.MedialEllipsis == null)
            {
                combinedCharacters.MedialEllipsis = parentCharacters.MedialEllipsis;
            }

            if (combinedCharacters.MoreInformation == null)
            {
                combinedCharacters.MoreInformation = parentCharacters.MoreInformation;
            }

            return combinedCharacters;
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
                dates = this.CombineDates(dates, parentCulture.datesNoParents);
            }

            return dates;
        }

        /// <summary>
        /// CombineDates combines a child with a parent as necessary and returns the combined object
        /// </summary>
        /// <param name="combinedDates">The child object</param>
        /// <param name="parentDates">The parent object</param>
        /// <returns>The combined object</returns>
        private Dates CombineDates(Dates combinedDates, Dates parentDates)
        {
            if (combinedDates == null && parentDates == null)
            {
                return null;
            }
            else if (combinedDates == null)
            {
                return (Dates)parentDates.Clone();
            }
            else if (parentDates == null)
            {
                return combinedDates;
            }

            if (combinedDates.DefaultCalendarId == null)
            {
                combinedDates.DefaultCalendarId = parentDates.DefaultCalendarId;
            }

            if (combinedDates.Calendars == null)
            {
                combinedDates.Calendars = parentDates.Calendars;
            }
            else if (combinedDates.Calendars != null && parentDates.Calendars != null)
            {
                // combine the list calendars
                List<Calendar> combinedCalendars = combinedDates.Calendars.ToList();
                foreach (Calendar parentCalendar in parentDates.Calendars)
                {
                    Calendar combinedCalendar = (from c in combinedCalendars
                                                 where string.Compare(c.Id, parentCalendar.Id, false, CultureInfo.InvariantCulture) == 0
                                                 select c).FirstOrDefault();
                    if (combinedCalendar == null)
                    {
                        combinedCalendars.Add(parentCalendar);
                    }
                    else
                    {
                        combinedCalendar = this.CombineCalendar(combinedCalendar, parentCalendar);
                    }
                }

                combinedDates.Calendars = combinedCalendars.ToArray();
            }

            return combinedDates;
        }

        /// <summary>
        /// CombineCalendar combines a child with a parent as necessary and returns the combined object
        /// </summary>
        /// <param name="combinedCalendar">The child object</param>
        /// <param name="parentCalendar">The parent object</param>
        /// <returns>The combined object</returns>
        private Calendar CombineCalendar(Calendar combinedCalendar, Calendar parentCalendar)
        {
            if (combinedCalendar.DateFormats == null || combinedCalendar.DateFormats.GetLength(0) == 0)
            {
                combinedCalendar.DateFormats = parentCalendar.DateFormats;
            }

            if (combinedCalendar.DayNameSets == null || combinedCalendar.DayNameSets.GetLength(0) == 0)
            {
                combinedCalendar.DayNameSets = parentCalendar.DayNameSets;
            }

            if (combinedCalendar.DayPeriodNameSets == null || combinedCalendar.DayPeriodNameSets.GetLength(0) == 0)
            {
                combinedCalendar.DayPeriodNameSets = parentCalendar.DayPeriodNameSets;
            }

            if (combinedCalendar.EraNameSets == null || combinedCalendar.EraNameSets.GetLength(0) == 0)
            {
                combinedCalendar.EraNameSets = parentCalendar.EraNameSets;
            }

            if (combinedCalendar.MonthNameSets == null || combinedCalendar.MonthNameSets.GetLength(0) == 0)
            {
                combinedCalendar.MonthNameSets = parentCalendar.MonthNameSets;
            }
            else
            {
                combinedCalendar.MonthNameSets = 
                    this.CombineMonthNameSets(combinedCalendar.MonthNameSets, parentCalendar.MonthNameSets);
            }

            if (combinedCalendar.TimeFormats == null || combinedCalendar.TimeFormats.GetLength(0) == 0)
            {
                combinedCalendar.TimeFormats = parentCalendar.TimeFormats;
            }

            return combinedCalendar;
        }

        /// <summary>
        /// CombineMonthNameSets combines a child with a parent as necessary and returns the combined object
        /// </summary>
        /// <param name="combinedMonthNameSets">The child object</param>
        /// <param name="parentMonthNameSets">The parent object</param>
        /// <returns>The combined object</returns>
        private MonthNameSet[] CombineMonthNameSets(MonthNameSet[] combinedMonthNameSets, MonthNameSet[] parentMonthNameSets)
        {
            List<MonthNameSet> combinedMonthNameSetList = new List<MonthNameSet>(combinedMonthNameSets);
            foreach (MonthNameSet parentMonthNameSet in parentMonthNameSets)
            {
                MonthNameSet combinedMonthNameSet = (from cmns in combinedMonthNameSetList
                                                     where string.Compare(cmns.Id, parentMonthNameSet.Id, false, CultureInfo.InvariantCulture) == 0
                                                     select cmns).FirstOrDefault();
                if (combinedMonthNameSet == null)
                {
                    // the combined set does not have the parent set so add it
                    combinedMonthNameSetList.Add(parentMonthNameSet);
                }
                else
                {
                    // combine the two lists
                    List<MonthName> combinedMonthNames = new List<MonthName>(combinedMonthNameSet.Names);
                    foreach (MonthName parentMonthName in parentMonthNameSet.Names)
                    {
                        if (!(from cmn in combinedMonthNames
                            where string.Compare(cmn.Id, parentMonthName.Id, false, CultureInfo.InvariantCulture) == 0
                            select cmn).Any())
                        {
                            // the parent month name does not exist in the combined month names
                            combinedMonthNames.Add(parentMonthName);
                        }
                    }

                    combinedMonthNameSet.Names = combinedMonthNames.OrderBy(monthName => int.Parse(monthName.Id)).ToArray();
                }
            }

            return combinedMonthNameSetList.ToArray();
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
                delimiters = this.CombineDelimiters(delimiters, parentCulture.delimitersNoParents);
            }

            return delimiters;
        }

        /// <summary>
        /// CombineDelimiters combines a child with a parent as necessary and returns the combined object
        /// </summary>
        /// <param name="combinedDelimiters">The child object</param>
        /// <param name="parentDelimiters">The parent object</param>
        /// <returns>The combined object</returns>
        private Delimiters CombineDelimiters(Delimiters combinedDelimiters, Delimiters parentDelimiters)
        {
            if (combinedDelimiters == null && parentDelimiters == null)
            {
                return null;
            }
            else if (combinedDelimiters == null)
            {
                return (Delimiters)parentDelimiters.Clone();
            }
            else if (parentDelimiters == null)
            {
                return combinedDelimiters;
            }

            if (combinedDelimiters.QuotationStart == null)
            {
                combinedDelimiters.QuotationStart = parentDelimiters.QuotationStart;
            }

            if (combinedDelimiters.QuotationEnd == null)
            {
                combinedDelimiters.QuotationEnd = parentDelimiters.QuotationEnd;
            }

            if (combinedDelimiters.AlternateQuotationStart == null)
            {
                combinedDelimiters.AlternateQuotationStart = parentDelimiters.AlternateQuotationStart;
            }

            if (combinedDelimiters.AlternateQuotationEnd == null)
            {
                combinedDelimiters.AlternateQuotationEnd = parentDelimiters.AlternateQuotationEnd;
            }

            return combinedDelimiters;
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
                listPatterns = this.CombineListPatterns(listPatterns, parentCulture.listPatternsNoParents);
            }

            return listPatterns;
        }

        /// <summary>
        /// CombineListPatterns combines a child with a parent as necessary and returns the combined object
        /// </summary>
        /// <param name="combinedListPatterns">The child object</param>
        /// <param name="parentListPatterns">The parent object</param>
        /// <returns>The combined object</returns>
        private ListPattern[] CombineListPatterns(ListPattern[] combinedListPatterns, ListPattern[] parentListPatterns)
        {
            if (combinedListPatterns == null && parentListPatterns == null)
            {
                return null;
            }
            else if (combinedListPatterns == null)
            {
                return (ListPattern[])parentListPatterns.Clone();
            }
            else if (parentListPatterns == null)
            {
                return combinedListPatterns;
            }

            List<ListPattern> combinedListPattern = new List<ListPattern>(combinedListPatterns);
            foreach (ListPattern parentListPattern in parentListPatterns)
            {
                if (!(from ups in combinedListPatterns
                      where string.Compare(ups.Id, parentListPattern.Id, false, CultureInfo.InvariantCulture) == 0
                      select ups).Any())
                {
                    // this unit pattern set does not exist in the combined list
                    combinedListPattern.Add(parentListPattern);
                }
            }

            return combinedListPattern.ToArray();
        }

        /// <summary>
        /// Gets or sets the resolved Messages
        /// </summary>
        public Messages Messages
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
        /// GetMessages gets the resolved Messages
        /// </summary>
        /// <returns>The resolved Messages</returns>
        private Messages GetMessages()
        {
            Messages messages = null;
            if (this.messagesNoParents != null)
            {
                messages = (Messages)this.messagesNoParents.Clone();
            }

            Culture[] parentCultures = this.GetParents();
            foreach (Culture parentCulture in parentCultures)
            {
                messages = this.CombineMessages(messages, parentCulture.messagesNoParents);
            }

            return messages;
        }

        /// <summary>
        /// CombineMessages combines a child with a parent as necessary and returns the combined object
        /// </summary>
        /// <param name="combinedMessages">The child object</param>
        /// <param name="parentMessages">The parent object</param>
        /// <returns>The combined object</returns>
        private Messages CombineMessages(Messages combinedMessages, Messages parentMessages)
        {
            if (combinedMessages == null && parentMessages == null)
            {
                return null;
            }
            else if (combinedMessages == null)
            {
                return (Messages)parentMessages.Clone();
            }
            else if (parentMessages == null)
            {
                return combinedMessages;
            }

            IDictionaryEnumerator enumerator = parentMessages.GetEnumerator();
            while (enumerator.MoveNext())
            {
                DictionaryEntry entry = (DictionaryEntry)enumerator.Current;
                if (!combinedMessages.ContainsKey(entry.Key.ToString()))
                {
                    combinedMessages.Add(entry.Key.ToString(), entry.Value.ToString());
                }
            }

            return combinedMessages;
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
                numbers = this.CombineNumbers(numbers, parentCulture.numbersNoParents);
            }

            return numbers;
        }

        /// <summary>
        /// CombineNumbers combines a child with a parent as necessary and returns the combined object
        /// </summary>
        /// <param name="combinedNumbers">The child object</param>
        /// <param name="parentNumbers">The parent object</param>
        /// <returns>The combined object</returns>
        private Numbers CombineNumbers(Numbers combinedNumbers, Numbers parentNumbers)
        {
            if (combinedNumbers == null && parentNumbers == null)
            {
                return null;
            }
            else if (combinedNumbers == null)
            {
                return (Numbers)parentNumbers.Clone();
            }
            else if (parentNumbers == null)
            {
                return combinedNumbers;
            }

            if (string.IsNullOrEmpty(combinedNumbers.DefaultNumberingSystemId))
            {
                combinedNumbers.DefaultNumberingSystemId = parentNumbers.DefaultNumberingSystemId;
            }

            combinedNumbers.NumberingSystemIds = this.CombineHashtables(combinedNumbers.NumberingSystemIds, parentNumbers.NumberingSystemIds);

            combinedNumbers.NumberingSystems = 
                this.CombineArrays<NumberingSystem>(
                combinedNumbers.NumberingSystems, 
                parentNumbers.NumberingSystems,
                (item, parent) => string.Compare(item.Id, parent.Id, false, CultureInfo.InvariantCulture) == 0);

            combinedNumbers.CurrencyDisplayNameSets =
                this.CombineArrays<CurrencyDisplayNameSet>(
                combinedNumbers.CurrencyDisplayNameSets,
                parentNumbers.CurrencyDisplayNameSets,
                (item, parent) => string.Compare(item.Id, parent.Id, false, CultureInfo.InvariantCulture) == 0);

            combinedNumbers.CurrencyPeriods =
                this.CombineArrays<CurrencyPeriod>(
                combinedNumbers.CurrencyPeriods,
                parentNumbers.CurrencyPeriods,
                (item, parent) => string.Compare(item.Id, parent.Id, false, CultureInfo.InvariantCulture) == 0);

            return combinedNumbers;
        }

        /// <summary>
        /// CombineArrays combines a child array with a parent array as necessary and returns the combined array
        /// </summary>
        /// <typeparam name="T">The type of the array elements</typeparam>
        /// <param name="combineds">The child array</param>
        /// <param name="parents">The parent array</param>
        /// <param name="typesAreEqual">A method to determine whether the types are equal</param>
        /// <returns>The combined array</returns>
        private T[] CombineArrays<T>(T[] combineds, T[] parents, Func<T, T, bool> typesAreEqual)
        {
            if (combineds == null && parents == null)
            {
                return null;
            }
            else if (combineds == null)
            {
                T[] copy = new T[parents.GetLength(0)];
                parents.CopyTo(copy, 0);
                return copy;
            }
            else if (parents == null)
            {
                return combineds;
            }

            List<T> combinedList = new List<T>(combineds);
            foreach (T parent in parents)
            {
                if (!(from item in combinedList
                      where typesAreEqual(item, parent)
                      select item).Any())
                {
                    combinedList.Add(parent);
                }
            }

            return combinedList.ToArray();
        }

        /// <summary>
        /// CombineHashtables combines a child Hashtable with a parent Hashtable as necessary and returns the combined Hashtable
        /// </summary>
        /// <param name="combinedHashtable">The child Hashtable</param>
        /// <param name="parentHashtable">The parent Hashtable</param>
        /// <returns>The combined Hashtable</returns>
        private Hashtable CombineHashtables(Hashtable combinedHashtable, Hashtable parentHashtable)
        {
            if (combinedHashtable == null && parentHashtable == null)
            {
                return null;
            }
            else if (combinedHashtable == null)
            {
                return (Hashtable)parentHashtable.Clone();
            }
            else if (parentHashtable == null)
            {
                return combinedHashtable;
            }

            IDictionaryEnumerator enumerator = parentHashtable.GetEnumerator();
            while (enumerator.MoveNext())
            {
                DictionaryEntry entry = (DictionaryEntry)enumerator.Current;
                if (!combinedHashtable.ContainsKey(entry.Key.ToString()))
                {
                    combinedHashtable.Add(entry.Key.ToString(), entry.Value.ToString());
                }
            }

            return combinedHashtable;
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
                ruleBasedNumberFormatting = this.CombineRuleBasedNumberFormatting(ruleBasedNumberFormatting, parentCulture.ruleBasedNumberFormattingNoParents);
            }

            return ruleBasedNumberFormatting;
        }

        /// <summary>
        /// CombineRuleBasedNumberFormatting combines a child with a parent as necessary and returns the combined object
        /// </summary>
        /// <param name="combinedRuleBasedNumberFormatting">The child object</param>
        /// <param name="parentRuleBasedNumberFormatting">The parent object</param>
        /// <returns>The combined object</returns>
        private RuleBasedNumberFormatting CombineRuleBasedNumberFormatting(RuleBasedNumberFormatting combinedRuleBasedNumberFormatting, RuleBasedNumberFormatting parentRuleBasedNumberFormatting)
        {
            if (combinedRuleBasedNumberFormatting == null && parentRuleBasedNumberFormatting == null)
            {
                return null;
            }
            else if (combinedRuleBasedNumberFormatting == null)
            {
                return (RuleBasedNumberFormatting)parentRuleBasedNumberFormatting.Clone();
            }
            else if (parentRuleBasedNumberFormatting == null)
            {
                return combinedRuleBasedNumberFormatting;
            }

            combinedRuleBasedNumberFormatting.OrdinalRuleSets =
                this.CombineArrays<RuleBasedNumberFormattingRuleSet>(
                combinedRuleBasedNumberFormatting.OrdinalRuleSets,
                parentRuleBasedNumberFormatting.OrdinalRuleSets,
                (item, parent) => string.Compare(item.Id, parent.Id, false, CultureInfo.InvariantCulture) == 0);

            combinedRuleBasedNumberFormatting.SpelloutRuleSets =
                this.CombineArrays<RuleBasedNumberFormattingRuleSet>(
                combinedRuleBasedNumberFormatting.SpelloutRuleSets,
                parentRuleBasedNumberFormatting.SpelloutRuleSets,
                (item, parent) => string.Compare(item.Id, parent.Id, false, CultureInfo.InvariantCulture) == 0);

            return combinedRuleBasedNumberFormatting;
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
                    this.languageDisplayNames = this.AddParentDisplayNames<LanguageDisplayName>(
                        this, 
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
                    this.regionDisplayNames = this.AddParentDisplayNames<RegionDisplayName>(
                        this, 
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
                    this.scriptDisplayNames = this.AddParentDisplayNames<ScriptDisplayName>(
                        this, 
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
                unitPatternSets = this.CombineUnitPatternSets(unitPatternSets, parentCulture.unitPatternSetsNoParents);
            }

            return unitPatternSets;
        }

        /// <summary>
        /// CombineUnitPatternSets combines a child with a parent as necessary and returns the combined object
        /// </summary>
        /// <param name="combinedUnitPatternSets">The child object</param>
        /// <param name="parentUnitPatternSets">The parent object</param>
        /// <returns>The combined object</returns>
        private UnitPatternSet[] CombineUnitPatternSets(UnitPatternSet[] combinedUnitPatternSets, UnitPatternSet[] parentUnitPatternSets)
        {
            if (combinedUnitPatternSets == null && parentUnitPatternSets == null)
            {
                return null;
            }
            else if (combinedUnitPatternSets == null)
            {
                return (UnitPatternSet[])parentUnitPatternSets.Clone();
            }
            else if (parentUnitPatternSets == null)
            {
                return combinedUnitPatternSets;
            }

            List<UnitPatternSet> combinedUnitPatternSetList = new List<UnitPatternSet>(combinedUnitPatternSets);
            foreach (UnitPatternSet parentUnitPatternSet in parentUnitPatternSets)
            {
                if (!(from ups in combinedUnitPatternSets
                      where string.Compare(ups.Id, parentUnitPatternSet.Id, false, CultureInfo.InvariantCulture) == 0
                      select ups).Any())
                {
                    // this unit pattern set does not exist in the combined list
                    combinedUnitPatternSetList.Add(parentUnitPatternSet);
                }
            }

            return combinedUnitPatternSetList.ToArray();
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
        /// Gets the culture's display name in a given language
        /// </summary>
        /// <param name="languageId">The Id of the language to get the display name for</param>
        /// <returns>The display name in the given language</returns>
        public string DisplayName(string languageId)
        {
            return this.Identity.DisplayName(languageId);
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
        /// AddParentDisplayNames adds a parent's display names to a child's display names as necessary
        /// </summary>
        /// <typeparam name="T">The type of the display names</typeparam>
        /// <param name="culture">The Culture from which to identify the parent</param>
        /// <param name="displayNames">The child's display names</param>
        /// <param name="getParentsDisplayNames">A method to get the parent's display names</param>
        /// <returns>A list of resolved display names</returns>
        private List<T> AddParentDisplayNames<T>(Culture culture, List<T> displayNames, Func<Culture, List<T>> getParentsDisplayNames) where T : DisplayName
        {
            string parentCultureName = culture.GetParentName();
            if (!string.IsNullOrEmpty(parentCultureName))
            {
                // there is a parent
                Culture parentCulture = Culture.GetCulture(parentCultureName);
                if (parentCulture != null)
                {
                    List<T> parentDisplayNamesNoParents = getParentsDisplayNames(parentCulture);
                    if (parentDisplayNamesNoParents != null && parentDisplayNamesNoParents.Count > 0)
                    {
                        // the parent has display names to merge
                        if (displayNames == null || displayNames.Count == 0)
                        {
                            // there are no existing display names to merge with so take all of the parent's display names
                            displayNames = parentDisplayNamesNoParents;
                        }
                        else
                        {
                            // merge the parent's display names with the current list (giving the current list priority)
                            foreach (var parentDisplayName in parentDisplayNamesNoParents)
                            {
                                if (!(from dn in displayNames
                                      where string.Compare(dn.Id, parentDisplayName.Id, false, CultureInfo.InvariantCulture) == 0
                                      select dn).Any())
                                {
                                    // the parent's display name does not exist in the current list so add it
                                    displayNames.Add(parentDisplayName);
                                }
                            }
                        }
                    }

                    // now merge the collection with this parent's parent
                    displayNames = this.AddParentDisplayNames<T>(parentCulture, displayNames, getParentsDisplayNames);
                }
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
            if (string.Compare(cultureName, "root", false, CultureInfo.InvariantCulture) == 0)
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
                    where string.Compare(c.Identity.CultureName, cultureName, false, CultureInfo.InvariantCulture) == 0
                    select c).FirstOrDefault();
        }
    }
}
