namespace NCldr.Types
{
    using System;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// Currency represents a currency
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Currencies </remarks>
    [Serializable]
    public class Currency : IDescription
    {
        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets the currency's CurrencyFraction
        /// </summary>
        public CurrencyFraction CurrencyFraction
        {
            get
            {
                if (NCldr.CurrencyFractions == null)
                {
                    return null;
                }

                return (from cf in NCldr.CurrencyFractions
                        where string.Compare(cf.Id, this.Id, StringComparison.InvariantCulture) == 0
                        select cf).FirstOrDefault();
            }
        }
    }
}
