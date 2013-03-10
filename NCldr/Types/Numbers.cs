namespace NCldr.Types
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// Numbers supplies information for formatting and parsing numbers and currencies
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Number_Elements </remarks>
    [Serializable]
    public class Numbers : ICloneable
    {
        /// <summary>
        /// Gets or sets the Id of the default NumberingSystem
        /// </summary>
        public string DefaultNumberingSystemId { get; set; }

        /// <summary>
        /// Gets the NumberingSystem indicated by the DefaultNumberingSystemId
        /// </summary>
        public NumberingSystem DefaultNumberingSystem
        {
            get
            {
                if (string.IsNullOrEmpty(this.DefaultNumberingSystemId) || this.NumberingSystems == null)
                {
                    return null;
                }

                return (from ns in this.NumberingSystems
                        where string.Compare(ns.Id, this.DefaultNumberingSystemId, false, CultureInfo.InvariantCulture) == 0
                        select ns).FirstOrDefault();
            }
        }

        /// <summary>
        /// Gets or sets a list of numbering systems that are not the default numbering system
        /// </summary>
        public List<OtherNumberingSystem> OtherNumberingSystems { get; set; }

        /// <summary>
        /// Gets or sets a list of numbering systems
        /// </summary>
        public NumberingSystem[] NumberingSystems { get; set; }

        /// <summary>
        /// Gets or sets an array of localized currency display name sets
        /// </summary>
        public CurrencyDisplayNameSet[] CurrencyDisplayNameSets { get; set; }

        /// <summary>
        /// Gets or sets an array of CurrencyPeriods
        /// </summary>
        public CurrencyPeriod[] CurrencyPeriods { get; set; }

        /// <summary>
        /// Gets the CurrencyPeriod that is in use at the current time
        /// </summary>
        public CurrencyPeriod CurrentCurrencyPeriod
        {
            get
            {
                if (this.CurrencyPeriods == null)
                {
                    return null;
                }

                return (from cp in this.CurrencyPeriods
                        where (cp.From == null || cp.From <= DateTime.Now) && (cp.To == null || cp.To >= DateTime.Now)
                        select cp).FirstOrDefault();
            }
        }

        /// <summary>
        /// GetCurrencyPeriods gets an array of CurrencyPeriods for a given datetime
        /// </summary>
        /// <param name="dateTime">The DateTime to get the CurrencyPeriods for</param>
        /// <returns>An array of CurrencyPeriods for a given datetime</returns>
        public CurrencyPeriod[] GetCurrencyPeriods(DateTime dateTime)
        {
            if (this.CurrencyPeriods != null)
            {
                return (from cp in this.CurrencyPeriods
                        where (cp.From == null || cp.From < dateTime)
                        && (cp.To == null || cp.To > dateTime)
                        select cp).ToArray();
            }

            return null;
        }

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
