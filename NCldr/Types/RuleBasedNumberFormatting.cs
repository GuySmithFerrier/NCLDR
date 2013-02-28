namespace NCldr.Types
{
    using System;

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
        /// Clone clones the object
        /// </summary>
        /// <returns>A cloned copy of the object</returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
