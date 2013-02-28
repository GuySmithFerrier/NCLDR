namespace NCldr.Types
{
    using System;
    using System.Globalization;
    using System.Text.RegularExpressions;

    /// <summary>
    /// PluralRuleCount indicates a rule type that can be applied in plurals and ordinals
    /// </summary>
    public enum PluralRuleCount
    {
        /// <summary>
        /// Zero indicates a count of 0
        /// </summary>
        Zero,

        /// <summary>
        /// One indicates a count of 1
        /// </summary>
        One,

        /// <summary>
        /// Two indicates a count of 2
        /// </summary>
        Two,

        /// <summary>
        /// Few indicates a count of "a few"
        /// </summary>
        Few,

        /// <summary>
        /// Many indicates a count of "many"
        /// </summary>
        Many
    }

    /// <summary>
    /// PluralRule provides a formula to indicate whether a number matches a count
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Language_Plural_Rules </remarks>
    [Serializable]
    public class PluralRule
    {
        /// <summary>
        /// Gets a string constant used to denote 'true'
        /// </summary>
        private const string TrueString = "true";

        /// <summary>
        /// Gets a string constant used to denote 'false'
        /// </summary>
        private const string FalseString = "false";

        /// <summary>
        /// Gets or sets a value passed from IsMatch down to lower methods in the call stack
        /// </summary>
        private int value;

        /// <summary>
        /// Gets or sets the PluralRuleCount that applies if the Rule is true for a given number
        /// </summary>
        public PluralRuleCount Id { get; set; }

        /// <summary>
        /// Gets or sets a formula indicating whether the rule applies
        /// </summary>
        /// <remarks>Use PluralRule.IsMatch to determine whether the rule applies for a given number</remarks>
        public string Rule { get; set; }

        /// <summary>
        /// IsMatch returns true if an integer matches this rule
        /// </summary>
        /// <param name="value">The integer to compare against this rule</param>
        /// <returns>True if the integer is a match with this rule</returns>
        public bool IsMatch(int value)
        {
            this.value = value;
            string booleanRule = this.Rule;

            Regex nmodRegex = new Regex(@"[\w]*n mod \d+[\w]*");
            booleanRule = nmodRegex.Replace(booleanRule, this.NmodEvaluator);

            // Regex nisRegex = new Regex(@"[\w]*[[0..9]+|n is [0..9]+][\w]*");
            Regex nisRegex = new Regex(@"[\w]*(n|\d+) is \d+[\w]*");
            booleanRule = nisRegex.Replace(booleanRule, this.NisEvaluator);

            return string.Compare(booleanRule, TrueString, false, CultureInfo.InvariantCulture) == 0;
        }

        /// <summary>
        /// NmodEvaluator evaluates "n mod" clauses
        /// </summary>
        /// <param name="match">The regular expression Match object</param>
        /// <returns>The evaluated "n mod" clause</returns>
        private string NmodEvaluator(Match match)
        {
            int isIndex = match.Value.IndexOf(" mod ");
            string matchRightHandSide = match.Value.Substring(isIndex + 5);
            int matchRightHandSideInteger = int.Parse(matchRightHandSide);

            return (this.value % matchRightHandSideInteger).ToString();
        }

        /// <summary>
        /// NisEvaluator evaluates "n is" clauses
        /// </summary>
        /// <param name="match">The regular expression Match object</param>
        /// <returns>The evaluated "n is" clause</returns>
        private string NisEvaluator(Match match)
        {
            int isIndex = match.Value.IndexOf(" is ");
            string matchRightHandSide = match.Value.Substring(isIndex + 4);
            int matchRightHandSideInteger = int.Parse(matchRightHandSide);

            string matchLeftHandSide = match.Value.Substring(0, isIndex);
            int matchLeftHandSideInteger;
            if (string.Compare(matchLeftHandSide, "n", false, CultureInfo.InvariantCulture) == 0)
            {
                matchLeftHandSideInteger = this.value;
            }
            else
            {
                matchLeftHandSideInteger = int.Parse(matchLeftHandSide);
            }

            return matchLeftHandSideInteger == matchRightHandSideInteger ? TrueString : FalseString;
        }
    }
}
