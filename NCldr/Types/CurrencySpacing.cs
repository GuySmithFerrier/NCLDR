namespace NCldr.Types
{
    using System;

    /// <summary>
    /// CurrencySpacing controls whether additional characters are inserted on the boundary between
    /// the symbol and the pattern
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Number_Symbols 
    /// and http://www.unicode.org/reports/tr35/#Unicode_Sets </remarks>
    [Serializable]
    public class CurrencySpacing
    {
        /// <summary>
        /// Gets or sets the currency match
        /// </summary>
        public string CurrencyMatch { get; set; }

        /// <summary>
        /// Gets or sets the surrounding match
        /// </summary>
        public string SurroundingMatch { get; set; }

        /// <summary>
        /// Gets or sets insert between
        /// </summary>
        public string InsertBetween { get; set; }
    }
}
