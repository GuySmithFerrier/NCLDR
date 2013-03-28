namespace NCldr.Types
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// RuleBasedNumberFormatting encapsulates a set of rules for mapping binary numbers to and from
    /// a readable representation
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Rule-Based_Number_Formatting </remarks>
    [Serializable]
    public class RuleBasedNumberFormatting : ICloneable
    {
        /// <summary>
        /// Gets or sets the rules used for spelling out numbers
        /// </summary>
        public RuleBasedNumberFormattingRuleSet[] SpelloutRuleSets { get; set; }

        /// <summary>
        /// Gets or sets the rules used for ordinal numbers (1st, 2nd, 3rd,...)
        /// </summary>
        public RuleBasedNumberFormattingRuleSet[] OrdinalRuleSets { get; set; }

        /// <summary>
        /// Combine combines a child with a parent as necessary and returns the combined object
        /// </summary>
        /// <param name="combinedRuleBasedNumberFormatting">The child object</param>
        /// <param name="parentRuleBasedNumberFormatting">The parent object</param>
        /// <returns>The combined object</returns>
        public static RuleBasedNumberFormatting Combine(RuleBasedNumberFormatting combinedRuleBasedNumberFormatting, RuleBasedNumberFormatting parentRuleBasedNumberFormatting)
        {
            if (combinedRuleBasedNumberFormatting == null && parentRuleBasedNumberFormatting == null)
            {
                return null;
            }
            else if (combinedRuleBasedNumberFormatting == null)
            {
                return (RuleBasedNumberFormatting)parentRuleBasedNumberFormatting.Clone();
            }
            else if (parentRuleBasedNumberFormatting == null)
            {
                return combinedRuleBasedNumberFormatting;
            }

            combinedRuleBasedNumberFormatting.OrdinalRuleSets =
                CombineArrays<RuleBasedNumberFormattingRuleSet>(
                combinedRuleBasedNumberFormatting.OrdinalRuleSets,
                parentRuleBasedNumberFormatting.OrdinalRuleSets,
                (item, parent) => string.Compare(item.Id, parent.Id, StringComparison.InvariantCulture) == 0);

            combinedRuleBasedNumberFormatting.SpelloutRuleSets =
                CombineArrays<RuleBasedNumberFormattingRuleSet>(
                combinedRuleBasedNumberFormatting.SpelloutRuleSets,
                parentRuleBasedNumberFormatting.SpelloutRuleSets,
                (item, parent) => string.Compare(item.Id, parent.Id, StringComparison.InvariantCulture) == 0);

            return combinedRuleBasedNumberFormatting;
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
