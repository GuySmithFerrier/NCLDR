namespace NCldr.Types
{
    using System;

    /// <summary>
    /// CasingType specifies the correct type of casing
    /// </summary>
    public enum CasingType
    {
        /// <summary>
        /// Either no case conversion should be performed or the case conversion is unknown
        /// </summary>
        None,

        /// <summary>
        /// The case should be in title case
        /// </summary>
        TitleCase,

        /// <summary>
        /// The case should be in lower case
        /// </summary>
        LowerCase
    }

    /// <summary>
    /// Casing is a collection of specifications for what the correct case should be
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Layout_Elements </remarks>
    [Serializable]
    public class Casing : ICloneable
    {
        /// <summary>
        /// Gets or sets the CasingType for the CalendarField
        /// </summary>
        public CasingType CalendarField { get; set; }

        /// <summary>
        /// Gets or sets the CasingType for the DayFormatExceptNarrow
        /// </summary>
        public CasingType DayFormatExceptNarrow { get; set; }

        /// <summary>
        /// Gets or sets the CasingType for the DayNarrow
        /// </summary>
        public CasingType DayNarrow { get; set; }

        /// <summary>
        /// Gets or sets the CasingType for the DayStandAloneExceptNarrow
        /// </summary>
        public CasingType DayStandAloneExceptNarrow { get; set; }

        /// <summary>
        /// Gets or sets the CasingType for the DisplayName
        /// </summary>
        public CasingType DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the CasingType for the DisplayNameCount
        /// </summary>
        public CasingType DisplayNameCount { get; set; }

        /// <summary>
        /// Gets or sets the CasingType for the EraAbbr
        /// </summary>
        public CasingType EraAbbr { get; set; }

        /// <summary>
        /// Gets or sets the CasingType for the EraName
        /// </summary>
        public CasingType EraName { get; set; }

        /// <summary>
        /// Gets or sets the CasingType for the EraNarrow
        /// </summary>
        public CasingType EraNarrow { get; set; }

        /// <summary>
        /// Gets or sets the CasingType for the Key
        /// </summary>
        public CasingType Key { get; set; }

        /// <summary>
        /// Gets or sets the CasingType for the Language
        /// </summary>
        public CasingType Language { get; set; }

        /// <summary>
        /// Gets or sets the CasingType for the MetaZoneLong
        /// </summary>
        public CasingType MetaZoneLong { get; set; }

        /// <summary>
        /// Gets or sets the CasingType for the MetaZoneShort
        /// </summary>
        public CasingType MetaZoneShort { get; set; }

        /// <summary>
        /// Gets or sets the CasingType for the MonthFormatExceptNarrow
        /// </summary>
        public CasingType MonthFormatExceptNarrow { get; set; }

        /// <summary>
        /// Gets or sets the CasingType for the MonthNarrow
        /// </summary>
        public CasingType MonthNarrow { get; set; }

        /// <summary>
        /// Gets or sets the CasingType for the MonthStandAloneExceptNarrow
        /// </summary>
        public CasingType MonthStandAloneExceptNarrow { get; set; }

        /// <summary>
        /// Gets or sets the CasingType for the QuarterAbbreviated
        /// </summary>
        public CasingType QuarterAbbreviated { get; set; }

        /// <summary>
        /// Gets or sets the CasingType for the Script
        /// </summary>
        public CasingType Script { get; set; }

        /// <summary>
        /// Gets or sets the CasingType for the Symbol
        /// </summary>
        public CasingType Symbol { get; set; }

        /// <summary>
        /// Gets or sets the CasingType for the Region
        /// </summary>
        public CasingType Region { get; set; }

        /// <summary>
        /// Gets or sets the CasingType for the Tense
        /// </summary>
        public CasingType Tense { get; set; }

        /// <summary>
        /// Gets or sets the CasingType for the Type
        /// </summary>
        public CasingType Type { get; set; }

        /// <summary>
        /// Gets or sets the CasingType for the ZoneExemplarCity
        /// </summary>
        public CasingType ZoneExemplarCity { get; set; }

        /// <summary>
        /// Clone clones the object
        /// </summary>
        /// <returns>A cloned copy of the object</returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        /// <summary>
        /// Combine combines a child with a parent as necessary and returns the combined object
        /// </summary>
        /// <param name="combinedCasing">The child object</param>
        /// <param name="parentCasing">The parent object</param>
        /// <returns>The combined object</returns>
        public static Casing Combine(Casing combinedCasing, Casing parentCasing)
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
    }
}
