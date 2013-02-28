namespace NCldr.Types
{
    using System;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// CurrencyPeriod represents the period in which a currency is/was in use
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Supplemental_Currency_Data </remarks>
    [Serializable]
    public class CurrencyPeriod : IPeriod
    {
        /// <summary>
        /// Gets or sets the currency identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the date from which the currency began use (if any)
        /// </summary>
        public DateTime? From { get; set; }

        /// <summary>
        /// Gets or sets the date after which the currency was no longer in use (if any)
        /// </summary>
        public DateTime? To { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the currency is legal tender
        /// </summary>
        public bool IsTender { get; set; }

        /// <summary>
        /// Gets the currency's Currency object
        /// </summary>
        public Currency Currency
        {
            get
            {
                if (NCldr.Currencies == null)
                {
                    return null;
                }

                return (from c in NCldr.Currencies
                        where string.Compare(c.Id, this.Id, false, CultureInfo.InvariantCulture) == 0
                        select c).FirstOrDefault();
            }
        }
    }
}
