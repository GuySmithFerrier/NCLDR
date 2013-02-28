namespace NCldr.Types
{
    using System;

    /// <summary>
    /// RuleBasedNumberFormattingRuleSet is a set of rules used for rule based number formatting
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Rule-Based_Number_Formatting </remarks>
    [Serializable]
    public class RuleBasedNumberFormattingRuleSet
    {
        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the access
        /// </summary>
        /// <remarks>The ruleset is assumed to be public unless the Access is set to "private"</remarks>
        public string Access { get; set; }

        /// <summary>
        /// Gets or sets the array of rules
        /// </summary>
        public RuleBasedNumberFormattingRule[] RuleBasedNumberFormattingRules { get; set; }
    }
}
