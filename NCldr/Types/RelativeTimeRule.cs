namespace NCldr.Types
{
    using System;
    using Extensions;

    /// <summary>
    /// RelativeTimeRuleCount indicates a rule type that can be applied in relative times
    /// </summary>
    public enum RelativeTimeRuleCount
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
        Many,

        /// <summary>
        /// Other indicates a count of "other"
        /// </summary>
        Other
    }

    /// <summary>
    /// RelativeTimeRule provides a pattern that corresponds to a given count
    /// </summary>
    [Serializable]
    public class RelativeTimeRule
    {
        /// <summary>
        /// Gets or sets the RelativeTimeRuleCount
        /// </summary>
        public RelativeTimeRuleCount Id { get; set; }

        /// <summary>
        /// Gets or sets a pattern used for this rule
        /// </summary>
        public string Pattern { get; set; }

        /// <summary>
        /// Combine combines a child with a parent as necessary and returns the combined object
        /// </summary>
        /// <param name="combined">The child object</param>
        /// <param name="parent">The parent object</param>
        /// <returns>The combined object</returns>
        public static RelativeTimeRule Combine(RelativeTimeRule combined, RelativeTimeRule parent)
        {
            return combined.Combine<RelativeTimeRule>(parent);
        }
    }
}
