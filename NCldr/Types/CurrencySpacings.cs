namespace NCldr.Types
{
    using System;

    /// <summary>
    /// CurrencySpacings control whether additional characters are inserted on the boundary between
    /// the symbol and the pattern
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Number_Symbols 
    /// and http://www.unicode.org/reports/tr35/#Unicode_Sets </remarks>
    [Serializable]
    public class CurrencySpacings
    {
        /// <summary>
        /// Gets or sets the spacings before the currency
        /// </summary>
        public CurrencySpacing BeforeCurrency { get; set; }

        /// <summary>
        /// Gets or sets the spacings after the currency
        /// </summary>
        public CurrencySpacing AfterCurrency { get; set; }
    }
}
