namespace NCldr.Types
{
    using System;

    /// <summary>
    /// DayPeriodRuleSet is a set of DayPeriodRules for one or more cultures
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#DayPeriodRules. </remarks> 
    [Serializable]
    public class DayPeriodRuleSet
    {
        /// <summary>
        /// Gets or sets an array of culture names for which the rules apply
        /// </summary>
        public string[] CultureNames { get; set; }

        /// <summary>
        /// Gets or sets an array of DayPeriodRules for the associated cultures
        /// </summary>
        public DayPeriodRule[] DayPeriodRules { get; set; }
    }
}
