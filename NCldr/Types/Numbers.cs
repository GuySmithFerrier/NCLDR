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
                        where string.Compare(ns.Id, this.DefaultNumberingSystemId, StringComparison.InvariantCulture) == 0
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

        /// <summary>
        /// Combine combines a child with a parent as necessary and returns the combined object
        /// </summary>
        /// <param name="combinedNumbers">The child object</param>
        /// <param name="parentNumbers">The parent object</param>
        /// <returns>The combined object</returns>
        public static Numbers Combine(Numbers combinedNumbers, Numbers parentNumbers)
        {
            if (combinedNumbers == null && parentNumbers == null)
            {
                return null;
            }
            else if (combinedNumbers == null)
            {
                return (Numbers)parentNumbers.Clone();
            }
            else if (parentNumbers == null)
            {
                return combinedNumbers;
            }

            if (string.IsNullOrEmpty(combinedNumbers.DefaultNumberingSystemId))
            {
                combinedNumbers.DefaultNumberingSystemId = parentNumbers.DefaultNumberingSystemId;
            }

            combinedNumbers.OtherNumberingSystems = OtherNumberingSystem.Combine(combinedNumbers.OtherNumberingSystems, parentNumbers.OtherNumberingSystems);

            combinedNumbers.NumberingSystems =
                CombineArrays<NumberingSystem>(
                combinedNumbers.NumberingSystems,
                parentNumbers.NumberingSystems,
                (item, parent) => string.Compare(item.Id, parent.Id, StringComparison.InvariantCulture) == 0);

            combinedNumbers.CurrencyDisplayNameSets =
                CombineArrays<CurrencyDisplayNameSet>(
                combinedNumbers.CurrencyDisplayNameSets,
                parentNumbers.CurrencyDisplayNameSets,
                (item, parent) => string.Compare(item.Id, parent.Id, StringComparison.InvariantCulture) == 0);

            combinedNumbers.CurrencyPeriods =
                CombineArrays<CurrencyPeriod>(
                combinedNumbers.CurrencyPeriods,
                parentNumbers.CurrencyPeriods,
                (item, parent) => string.Compare(item.Id, parent.Id, StringComparison.InvariantCulture) == 0);

            return combinedNumbers;
        }

        /// <summary>
        /// CombineArrays combines a child array with a parent array as necessary and returns the combined array
        /// </summary>
        /// <typeparam name="T">The type of the array elements</typeparam>
        /// <param name="combineds">The child array</param>
        /// <param name="parents">The parent array</param>
        /// <param name="typesAreEqual">A method to determine whether the types are equal</param>
        /// <returns>The combined array</returns>
        private static T[] CombineArrays<T>(T[] combineds, T[] parents, Func<T, T, bool> typesAreEqual)
        {
            if (combineds == null && parents == null)
            {
                return null;
            }
            else if (combineds == null)
            {
                T[] copy = new T[parents.GetLength(0)];
                parents.CopyTo(copy, 0);
                return copy;
            }
            else if (parents == null)
            {
                return combineds;
            }

            List<T> combinedList = new List<T>(combineds);
            foreach (T parent in parents)
            {
                if (!(from item in combinedList
                      where typesAreEqual(item, parent)
                      select item).Any())
                {
                    combinedList.Add(parent);
                }
            }

            return combinedList.ToArray();
        }
    }
}
