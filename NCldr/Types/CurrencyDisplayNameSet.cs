namespace NCldr.Types
{
    using System;

    /// <summary>
    /// CurrencyDisplayNameSet is a set of localized currency display names
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Currencies </remarks>
    [Serializable]
    public class CurrencyDisplayNameSet
    {
        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the currency symbol
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Gets or sets the localized currency display names
        /// </summary>
        public CurrencyDisplayName[] CurrencyDisplayNames { get; set; }
    }
}
