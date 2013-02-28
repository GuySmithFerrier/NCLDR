namespace NCldr.Types
{
    using System;

    /// <summary>
    /// RuleBasedNumberFormattingRule specifies a rule used for rule based number formatting
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Rule-Based_Number_Formatting </remarks>
    [Serializable]
    public class RuleBasedNumberFormattingRule
    {
        /// <summary>
        /// Gets or sets a value used to indicate the starting number to which the rule applies
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets a value used to indicate an alternate radix to be used in calculating 
        /// the prefix and postfix values for number formatting
        /// </summary>
        public string Radix { get; set; }

        /// <summary>
        /// Gets or sets the rule
        /// </summary>
        public string Rule { get; set; }
    }
}
