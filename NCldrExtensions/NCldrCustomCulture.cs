namespace NCldr.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Types;

    /// <summary>
    /// NCldrCustomCulture is a custom culture helper class for creating NCLDR custom cultures
    /// </summary>
    public class NCldrCustomCulture
    {
        /// <summary>
        /// Registers the NCLDR culture
        /// </summary>
        /// <param name="cldrCultureName">The name of the CLDR culture from which to create the .NET culture</param>
        /// <param name="dotNetCultureName">The name of the .NET custom culture to create</param>
        public static void Register(string cldrCultureName, string dotNetCultureName)
        {
            CreateNCldrCultureAndRegionInfoBuilder(cldrCultureName, dotNetCultureName).Register();
        }

        /// <summary>
        /// Creates a CultureAndRegionInfoBuilder object for the NCLDR culture
        /// </summary>
        /// <param name="cldrCultureName">The name of the CLDR culture from which to create the .NET culture</param>
        /// <param name="dotNetCultureName">The name of the .NET custom culture to create</param>
        /// <returns>A CultureAndRegionInfoBuilder object for the NCLDR culture</returns>
        public static CultureAndRegionInfoBuilder CreateNCldrCultureAndRegionInfoBuilder(string cldrCultureName, string dotNetCultureName)
        {
            Culture culture = Culture.GetCulture(cldrCultureName);

            CultureAndRegionModifiers cultureAndRegionModifiers =
                culture.IsNeutralCulture ? CultureAndRegionModifiers.Neutral : CultureAndRegionModifiers.None;

            CultureAndRegionInfoBuilder builder = new CultureAndRegionInfoBuilder(dotNetCultureName, cultureAndRegionModifiers);

            CultureInfo parentCultureInfo = GetParentCultureInfo(culture);

            builder.Parent = parentCultureInfo;

            builder.CultureEnglishName = culture.EnglishName;

            if (string.IsNullOrEmpty(culture.NativeName))
            {
                builder.CultureNativeName = culture.EnglishName;
            }
            else
            {
                builder.CultureNativeName = culture.NativeName;
            }

            builder.TwoLetterISOLanguageName = culture.Identity.Language.Id;

            // CLDR does not have data for ThreeLetterISOLanguageName but one must be assigned for the culture to be valid
            builder.ThreeLetterISOLanguageName = culture.Identity.Language.Id;

            // CLDR does not have data for ThreeLetterWindowsLanguageName but one must be assigned for the culture to be valid
            builder.ThreeLetterWindowsLanguageName = culture.Identity.Language.Id;

            // The CultureAndRegionInfoBuilder requires dummy values for these properties
            // even though there is no region or currency values
            builder.RegionEnglishName = "xxx";
            builder.RegionNativeName = "xxx";
            builder.ThreeLetterISORegionName = "xxx";
            builder.ThreeLetterWindowsRegionName = "xxx";
            builder.TwoLetterISORegionName = "xx";
            builder.ISOCurrencySymbol = "xx";
            builder.CurrencyEnglishName = "xxx";
            builder.CurrencyNativeName = "xxx";

            if (culture.Identity.Region != null)
            {
                Region region = culture.Identity.Region;
                builder.RegionEnglishName = region.EnglishName;

                string regionNativeName = region.DisplayName(culture.Identity.Language.Id);
                if (string.IsNullOrEmpty(regionNativeName))
                {
                    builder.RegionNativeName = region.EnglishName;
                }
                else
                {
                    builder.RegionNativeName = regionNativeName;
                }

                RegionCode regionCode = RegionExtensions.GetRegionCode(region.Id);
                if (regionCode != null && regionCode.Alpha3 != null)
                {
                    builder.ThreeLetterISORegionName = regionCode.Alpha3;
                }
                else
                {
                    builder.ThreeLetterISORegionName = region.Id;
                }

                // CLDR does not have data for ThreeLetterWindowsRegionName but one must be assigned for the culture to be valid
                builder.ThreeLetterWindowsRegionName = region.Id;
                builder.TwoLetterISORegionName = region.Id;

                builder.IsMetric = RegionExtensions.GetMeasurementSystem(region.Id).IsMetric;
            }
            else
            {
                builder.IsMetric = RegionExtensions.GetMeasurementSystem(NCldr.RegionIdForTheWorld).IsMetric;
            }

            // CLDR does not have data for KeyboardLayoutId or GeoId
            builder.IetfLanguageTag = cldrCultureName;

            builder.GregorianDateTimeFormat = CreateDateTimeFormatInfo(culture);
            builder.AvailableCalendars = GetAvailableCalendars(culture);

            builder.NumberFormat = CreateNumberFormatInfo(culture);

            if (culture.Numbers != null && culture.Numbers.CurrencyDisplayNameSets != null)
            {
                string currencyName = culture.Numbers.CurrentCurrencyPeriod.Id;
                if (!string.IsNullOrEmpty(currencyName))
                {
                    builder.ISOCurrencySymbol = currencyName;

                    builder.CurrencyEnglishName = CultureExtensions.GetCurrencyDisplayName(currencyName, "en");

                    string currencyNativeName = CultureExtensions.GetCurrencyDisplayName(currencyName, culture.Identity.Language.Id);
                    builder.CurrencyNativeName = currencyNativeName == null ? builder.CurrencyEnglishName : currencyNativeName;
                }
            }

            builder.TextInfo = parentCultureInfo.TextInfo;
            builder.CompareInfo = parentCultureInfo.CompareInfo;

            return builder;
        }

        /// <summary>
        /// GetParentCultureInfo gets the .NET CultureInfo parent of the NCLDR culture
        /// </summary>
        /// <param name="culture">The Culture to get the parent for</param>
        /// <returns>The .NET CultureInfo parent of the NCLDR culture</returns>
        private static CultureInfo GetParentCultureInfo(Culture culture)
        {
            string parentCultureName = culture.GetParentName();
            try
            {
                // try to return a .NET culture if one exists
                return new CultureInfo(parentCultureName);
            }
            catch
            {
                // the parent culture does not exist in .NET so default to the Invariant culture
                return CultureInfo.InvariantCulture;
            }
        }

        /// <summary>
        /// GetAvailableCalendars gets an array of .NET calendars available to the Culture
        /// </summary>
        /// <param name="culture">The Culture to get the Calendars for</param>
        /// <returns>An array of .NET calendars available to the Culture</returns>
        /// <remarks>The list is filtered to include only those .NET Calendars that can be used
        /// with custom cultures</remarks>
        private static System.Globalization.Calendar[] GetAvailableCalendars(Culture culture)
        {
            if (culture.Dates == null || culture.Dates.Calendars == null)
            {
                return null;
            }

            List<System.Globalization.Calendar> availableCalendars = new List<System.Globalization.Calendar>();

            // the order of the calendars is important - the default calendar must be the first calendar in the list
            foreach (Types.Calendar calendar in culture.Dates.Calendars.OrderBy(c => c.Id != culture.Dates.DefaultCalendarId))
            {
                System.Globalization.Calendar dotNetCalendar = GetCalendar(calendar);

                // The CultureAndRegionInfoBuilder.AvailableCalendars property does not allow
                // certain types of calendars to be included in the array assigned to it
                if (dotNetCalendar != null
                    && dotNetCalendar.GetType() != typeof(PersianCalendar)
                    && dotNetCalendar.GetType() != typeof(TaiwanLunisolarCalendar)
                    && dotNetCalendar.GetType() != typeof(KoreanLunisolarCalendar)
                    && dotNetCalendar.GetType() != typeof(JapaneseLunisolarCalendar)
                    && dotNetCalendar.GetType() != typeof(ChineseLunisolarCalendar)
                    && dotNetCalendar.GetType() != typeof(JulianCalendar))
                {
                    availableCalendars.Add(dotNetCalendar);
                }
            }

            return availableCalendars.ToArray();
        }

        /// <summary>
        /// GetCalendar returns a .NET Calendar equivalent to a CLDR Calendar
        /// </summary>
        /// <param name="calendar">A CLDR Calendar</param>
        /// <returns>A .NET Calendar</returns>
        private static System.Globalization.Calendar GetCalendar(Types.Calendar calendar)
        {
            System.Globalization.Calendar dotNetCalendar = null;

            if (string.Compare(calendar.Id, "gregorian", false, CultureInfo.InvariantCulture) == 0 && calendar.CalendarType.CalendarAlgorithmType == CalendarAlgorithmType.SolarCalendar)
            {
                dotNetCalendar = new GregorianCalendar();
            }
            else if (string.Compare(calendar.Id, "japanese", false, CultureInfo.InvariantCulture) == 0)
            {
                if (calendar.CalendarType.CalendarAlgorithmType == CalendarAlgorithmType.SolarCalendar)
                {
                    dotNetCalendar = new JapaneseCalendar();
                }
                else if (calendar.CalendarType.CalendarAlgorithmType == CalendarAlgorithmType.LunisolarCalendar)
                {
                    dotNetCalendar = new JapaneseLunisolarCalendar();
                }
            }
            else if (string.Compare(calendar.Id, "islamic-civil", false, CultureInfo.InvariantCulture) == 0 && 
                calendar.CalendarType.CalendarAlgorithmType == CalendarAlgorithmType.LunisolarCalendar)
            {
                dotNetCalendar = new HijriCalendar();
            }
            else if (string.Compare(calendar.Id, "islamic", false, CultureInfo.InvariantCulture) == 0
                && calendar.CalendarType.CalendarAlgorithmType == CalendarAlgorithmType.LunisolarCalendar)
            {
                dotNetCalendar = new HijriCalendar();
            }
            else if (string.Compare(calendar.Id, "chinese", false, CultureInfo.InvariantCulture) == 0 && 
                calendar.CalendarType.CalendarAlgorithmType == CalendarAlgorithmType.LunisolarCalendar)
            {
                dotNetCalendar = new ChineseLunisolarCalendar();
            }
            else if (string.Compare(calendar.Id, "hebrew", false, CultureInfo.InvariantCulture) == 0 && 
                calendar.CalendarType.CalendarAlgorithmType == CalendarAlgorithmType.LunisolarCalendar)
            {
                dotNetCalendar = new HebrewCalendar();
            }
            else if (string.Compare(calendar.Id, "buddhist", false, CultureInfo.InvariantCulture) == 0 && 
                calendar.CalendarType.CalendarAlgorithmType == CalendarAlgorithmType.SolarCalendar)
            {
                dotNetCalendar = new ThaiBuddhistCalendar();
            }
            else if (string.Compare(calendar.Id, "coptic", false, CultureInfo.InvariantCulture) == 0)
            {
                return null;
            }
            else if (string.Compare(calendar.Id, "persian", false, CultureInfo.InvariantCulture) == 0 && 
                calendar.CalendarType.CalendarAlgorithmType == CalendarAlgorithmType.SolarCalendar)
            {
                return new PersianCalendar();
            }
            else if (string.Compare(calendar.Id, "ethiopic", false, CultureInfo.InvariantCulture) == 0)
            {
                return null;
            }
            else if (string.Compare(calendar.Id, "indian", false, CultureInfo.InvariantCulture) == 0)
            {
                return null;
            }
            else if (string.Compare(calendar.Id, "roc", false, CultureInfo.InvariantCulture) == 0)
            {
                return null;
            }

            return dotNetCalendar;
        }

        /// <summary>
        /// CreateNumberFormatInfo creates a .NET NumberFormatInfo for the CLDR Culture
        /// </summary>
        /// <param name="culture">The Culture to get the NumberFormatInfo for</param>
        /// <returns>A .NET NumberFormatInfo for the CLDR Culture</returns>
        private static NumberFormatInfo CreateNumberFormatInfo(Culture culture)
        {
            if (culture.Numbers == null)
            {
                return null;
            }

            string currencyId = culture.Numbers.CurrentCurrencyPeriod.Id;

            NumberFormatInfo numberFormatInfo = new NumberFormatInfo();

            CurrencyFraction currencyFraction = NCldr.GetCurrencyFraction(currencyId);

            if (currencyFraction != null)
            {
                numberFormatInfo.CurrencyDecimalDigits = currencyFraction.Digits;
            }

            if (culture.Numbers.DefaultNumberingSystem != null && culture.Numbers.DefaultNumberingSystem.Symbols != null)
            {
                NumberingSystem numberingSystem = culture.Numbers.DefaultNumberingSystem;
                NumberingSystemSymbols symbols = numberingSystem.Symbols;
                NumberingSystemType numberingSystemType = numberingSystem.NumberingSystemType;
                CurrencyPeriod currentCurrencyPeriod = culture.Numbers.CurrentCurrencyPeriod;

                if (!string.IsNullOrEmpty(symbols.Nan))
                {
                    numberFormatInfo.NaNSymbol = symbols.Nan;
                }

                if (!string.IsNullOrEmpty(symbols.Infinity))
                {
                    string minusSign = "-";
                    if (!string.IsNullOrEmpty(symbols.MinusSign))
                    {
                        minusSign = symbols.MinusSign;
                    }

                    numberFormatInfo.NegativeInfinitySymbol = minusSign + symbols.Infinity;
                }

                if (!string.IsNullOrEmpty(symbols.MinusSign))
                {
                    numberFormatInfo.NegativeSign = symbols.MinusSign;
                }

                if (!string.IsNullOrEmpty(symbols.Infinity))
                {
                    numberFormatInfo.PositiveInfinitySymbol = symbols.Infinity;
                }

                if (!string.IsNullOrEmpty(symbols.PercentSign))
                {
                    numberFormatInfo.PercentSymbol = symbols.PercentSign;
                }

                if (!string.IsNullOrEmpty(symbols.PerMille))
                {
                    numberFormatInfo.PerMilleSymbol = symbols.PerMille;
                }

                if (!string.IsNullOrEmpty(symbols.PlusSign))
                {
                    numberFormatInfo.PositiveSign = symbols.PlusSign;
                }

                if (!string.IsNullOrEmpty(symbols.Decimal))
                {
                    numberFormatInfo.CurrencyDecimalSeparator = symbols.Decimal;
                    numberFormatInfo.NumberDecimalSeparator = symbols.Decimal;
                    numberFormatInfo.PercentDecimalSeparator = symbols.Decimal;
                }

                if (!string.IsNullOrEmpty(symbols.Group))
                {
                    numberFormatInfo.CurrencyGroupSeparator = symbols.Group;
                    numberFormatInfo.NumberGroupSeparator = symbols.Group;
                    numberFormatInfo.PercentGroupSeparator = symbols.Group;
                }

                if (numberingSystemType != null && numberingSystemType.DigitsOrRules == NumberingSystemDigitsOrRules.Numeric)
                {
                    numberFormatInfo.NativeDigits = numberingSystemType.DigitsArray;
                }

                if (currentCurrencyPeriod != null)
                {
                    CurrencyDisplayNameSet currencyDisplayNameSet = (from cdns in culture.Numbers.CurrencyDisplayNameSets
                                                                     where string.Compare(cdns.Id, currentCurrencyPeriod.Id, false, CultureInfo.InvariantCulture) == 0
                                                                     select cdns).FirstOrDefault();
                    if (currencyDisplayNameSet != null && !string.IsNullOrEmpty(currencyDisplayNameSet.Symbol))
                    {
                        numberFormatInfo.CurrencySymbol = currencyDisplayNameSet.Symbol;
                    }
                }

                if (numberingSystemType == null)
                {
                    numberFormatInfo.DigitSubstitution = DigitShapes.None;
                }
                else
                {
                    numberFormatInfo.DigitSubstitution = numberingSystemType.DigitShapes;
                }

                if (!string.IsNullOrEmpty(numberingSystem.CurrencyFormatPattern))
                {
                    numberFormatInfo.CurrencyPositivePattern = numberingSystem.CurrencyPositivePattern;
                    numberFormatInfo.CurrencyNegativePattern = numberingSystem.CurrencyNegativePattern;
                    numberFormatInfo.CurrencyGroupSizes = numberingSystem.CurrencyGroupSizes;
                }

                if (!string.IsNullOrEmpty(numberingSystem.PercentFormatPattern))
                {
                    numberFormatInfo.PercentDecimalDigits = numberingSystem.PercentDecimalDigits;
                    numberFormatInfo.PercentGroupSizes = numberingSystem.PercentGroupSizes;
                    numberFormatInfo.PercentNegativePattern = numberingSystem.PercentNegativePattern;
                    numberFormatInfo.PercentPositivePattern = numberingSystem.PercentPositivePattern;
                }

                if (!string.IsNullOrEmpty(numberingSystem.DecimalFormatPattern))
                {
                    numberFormatInfo.NumberDecimalDigits = numberingSystem.NumberDecimalDigits;
                    numberFormatInfo.NumberGroupSizes = numberingSystem.NumberGroupSizes;
                    numberFormatInfo.NumberNegativePattern = numberingSystem.NumberNegativePattern;
                }
            }

            return numberFormatInfo;
        }

        /// <summary>
        /// CreateDateTimeFormatInfo creates a .NET DateTimeFormatInfo for the CLDR Culture
        /// </summary>
        /// <param name="culture">The Culture to get the DateTimeFormatInfo for</param>
        /// <returns>A .NET DateTimeFormatInfo for the CLDR Culture</returns>
        private static DateTimeFormatInfo CreateDateTimeFormatInfo(Culture culture)
        {
            System.Globalization.Calendar calendar = new GregorianCalendar(GregorianCalendarTypes.Localized);
            DateTimeFormatInfo dateTimeFormatInfo = new DateTimeFormatInfo();
            dateTimeFormatInfo.Calendar = calendar;

            if (culture.Dates != null && culture.Dates.Calendars != null)
            {
                Types.Calendar gregorianCalendar = (from c in culture.Dates.Calendars
                                                    where string.Compare(c.Id, "gregorian", false, CultureInfo.InvariantCulture) == 0
                                                    select c).FirstOrDefault();
                if (gregorianCalendar != null)
                {
                    if (gregorianCalendar.AbbreviatedDayNames != null)
                    {
                        dateTimeFormatInfo.AbbreviatedDayNames = gregorianCalendar.AbbreviatedDayNames;
                    }

                    if (gregorianCalendar.DayNames != null)
                    {
                        dateTimeFormatInfo.DayNames = gregorianCalendar.DayNames;
                    }

                    if (gregorianCalendar.ShortestDayNames != null)
                    {
                        dateTimeFormatInfo.ShortestDayNames = gregorianCalendar.ShortestDayNames;
                    }

                    if (gregorianCalendar.AbbreviatedMonthNames != null)
                    {
                        dateTimeFormatInfo.AbbreviatedMonthNames = gregorianCalendar.AbbreviatedMonthNames;
                        dateTimeFormatInfo.AbbreviatedMonthGenitiveNames = gregorianCalendar.AbbreviatedMonthNames;
                    }

                    if (gregorianCalendar.MonthNames != null)
                    {
                        dateTimeFormatInfo.MonthNames = gregorianCalendar.MonthNames;
                        dateTimeFormatInfo.MonthGenitiveNames = gregorianCalendar.MonthNames;
                    }

                    if (!string.IsNullOrEmpty(gregorianCalendar.AMDesignator))
                    {
                        // AMDesignator must be 14 characters or less
                        string amDesignator = gregorianCalendar.AMDesignator;
                        dateTimeFormatInfo.AMDesignator = amDesignator.Substring(0, Math.Min(amDesignator.Length, 14));
                    }

                    if (!string.IsNullOrEmpty(gregorianCalendar.PMDesignator))
                    {
                        // PMDesignator must be 14 characters or less
                        string pmDesignator = gregorianCalendar.PMDesignator;
                        dateTimeFormatInfo.PMDesignator = pmDesignator.Substring(0, Math.Min(pmDesignator.Length, 14));
                    }

                    dateTimeFormatInfo.CalendarWeekRule = CalendarWeekRule.FirstDay;

                    if (culture.Identity.Region != null)
                    {
                        dateTimeFormatInfo.FirstDayOfWeek = RegionExtensions.GetFirstDayOfWeek(culture.Identity.Region.Id);
                    }
                    else
                    {
                        dateTimeFormatInfo.FirstDayOfWeek = RegionExtensions.GetFirstDayOfWeek(NCldr.RegionIdForTheWorld);
                    }

                    if (!string.IsNullOrEmpty(gregorianCalendar.FullDotNetDatePattern))
                    {
                        // dateTimeFormatInfo.FullDateTimePattern = "dd MMMM yyyy HH:mm:ss";
                        dateTimeFormatInfo.FullDateTimePattern = gregorianCalendar.FullDotNetDatePattern;
                    }

                    if (!string.IsNullOrEmpty(gregorianCalendar.LongDotNetDatePattern))
                    {
                        // dateTimeFormatInfo.LongDatePattern = "dd MMMM yyyy";
                        // dateTimeFormatInfo.MonthDayPattern = "dd MMMM";
                        // dateTimeFormatInfo.YearMonthPattern = "MMMM, yyyy";
                        dateTimeFormatInfo.LongDatePattern = gregorianCalendar.LongDotNetDatePattern;
                        
                        // CLDR does not have a month day pattern so make one by stripping out the year from the long date format
                        dateTimeFormatInfo.MonthDayPattern =
                            dateTimeFormatInfo.LongDatePattern.Replace("y", string.Empty);

                        // CLDR does not have a year month pattern so make one by stripping out the day from the long date format
                        dateTimeFormatInfo.YearMonthPattern =
                            dateTimeFormatInfo.LongDatePattern.Replace("d", string.Empty);
                   }

                    if (!string.IsNullOrEmpty(gregorianCalendar.ShortDotNetDatePattern))
                    {
                        // dateTimeFormatInfo.ShortDatePattern = "dd-MM-yyyy";
                        dateTimeFormatInfo.ShortDatePattern = gregorianCalendar.ShortDotNetDatePattern;
                    }

                    if (!string.IsNullOrEmpty(gregorianCalendar.LongDotNetTimePattern))
                    {
                        // dateTimeFormatInfo.LongTimePattern = "HH:mm:ss";
                        dateTimeFormatInfo.LongTimePattern = gregorianCalendar.LongDotNetTimePattern;
                    }

                    if (!string.IsNullOrEmpty(gregorianCalendar.ShortDotNetTimePattern))
                    {
                        // dateTimeFormatInfo.ShortTimePattern = "HH:mm";
                        dateTimeFormatInfo.ShortTimePattern = gregorianCalendar.ShortDotNetTimePattern;
                    }

                    dateTimeFormatInfo.DateSeparator = gregorianCalendar.DateSeparator;
                    dateTimeFormatInfo.TimeSeparator = gregorianCalendar.TimeSeparator;
                }
            }

            return dateTimeFormatInfo;
        }
    }
}
