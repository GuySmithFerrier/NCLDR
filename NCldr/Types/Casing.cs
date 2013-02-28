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
    }
}
