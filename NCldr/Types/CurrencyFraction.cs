namespace NCldr.Types
{
    using System;

    /// <summary>
    /// CurrencyFraction is the number of digits and the rounding used by a currency
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Supplemental_Currency_Data </remarks>
    [Serializable]
    public class CurrencyFraction
    {
        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the number of decimal digits
        /// </summary>
        public int Digits { get; set; }

        /// <summary>
        /// Gets or sets the number of decimal places for rounding
        /// </summary>
        public int Rounding { get; set; }
    }
}
