namespace NCldr.Types
{
    using System;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// NumberingSystemDigitsOrRules is used by NumberingSystemType to indicate whether to use digits (Numeric) or rules (Algorithmic)
    /// </summary>
    public enum NumberingSystemDigitsOrRules
    {
        /// <summary>
        /// Numeric indicates that digits should be used
        /// </summary>
        Numeric,

        /// <summary>
        /// Algorithmic indicates the rules should be used
        /// </summary>
        Algorithmic
    }

    /// <summary>
    /// NumberingSystemType is used to define different representations for numeric values to an end user
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Numbering_Systems </remarks>
    [Serializable]
    public class NumberingSystemType
    {
        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets whether to use the Digits property or the Rules property
        /// </summary>
        public NumberingSystemDigitsOrRules DigitsOrRules { get; set; }

        /// <summary>
        /// Gets or sets the digits used to represent numbers, in order, starting from zero
        /// </summary>
        public string Digits { get; set; }

        /// <summary>
        /// Gets or sets the RuleBasedNumberFormatting ruleset to be used for formatting numbers from this numbering system
        /// </summary>
        public string Rules { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets the Digits as an array of string
        /// </summary>
        public string[] DigitsArray
        {
            get
            {
                if (this.Digits == null)
                {
                    return null;
                }

                return this.Digits.Select(c => c.ToString()).ToArray();
            }
        }

        /// <summary>
        /// Gets the equivalent .NET DigitShapes
        /// </summary>
        public DigitShapes DigitShapes
        {
            get
            {
                if (this.Digits == null || string.Compare(this.Digits, "0123456789", false, CultureInfo.InvariantCulture) == 0)
                {
                    return DigitShapes.None;
                }

                if (this.DigitsOrRules == NumberingSystemDigitsOrRules.Numeric)
                {
                    // this numbering system uses non-Latin numerals but the rule is a simple substitution of numerals
                    return DigitShapes.NativeNational;
                }
                else if (this.DigitsOrRules == NumberingSystemDigitsOrRules.Algorithmic)
                {
                    // this numbering system uses non-Latin numerals and the substitution is based on an algorithm
                    return DigitShapes.Context;
                }

                return DigitShapes.None;
            }
        }
    }
}
