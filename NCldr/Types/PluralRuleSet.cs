namespace NCldr.Types
{
    using System;

    /// <summary>
    /// PluralRuleSet is a set of PluralRules
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Language_Plural_Rules </remarks>
    [Serializable]
    public class PluralRuleSet
    {
        /// <summary>
        /// Gets or sets an array of culture Ids
        /// </summary>
        public string[] CultureNames { get; set; }

        /// <summary>
        /// Gets or sets an array of PluralRules that apply to the associated cultures
        /// </summary>
        public PluralRule[] PluralRules { get; set; }
    }
}
