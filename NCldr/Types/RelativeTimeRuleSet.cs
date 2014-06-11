namespace NCldr.Types
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// RelativeTimeRuleSet is a set of RelativeTimeRules
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Language_Plural_Rules </remarks>
    [Serializable]
    public class RelativeTimeRuleSet
    {
        /// <summary>
        /// Gets or sets an array of RelativeTimeRules
        /// </summary>
        public RelativeTimeRule[] RelativeTimeRules { get; set; }

        public RelativeTimeRuleSet()
        {
            this.RelativeTimeRules = new RelativeTimeRule[]{};
        }

        /// <summary>
        /// Combine combines a child with a parent as necessary and returns the combined object
        /// </summary>
        /// <param name="combined">The child object</param>
        /// <param name="parent">The parent object</param>
        /// <returns>The combined object</returns>
        public static RelativeTimeRuleSet Combine(RelativeTimeRuleSet combined, RelativeTimeRuleSet parent)
        {
            if (combined == null || combined.RelativeTimeRules == null)
            {
                return parent;
            }
            else if (parent == null || parent.RelativeTimeRules == null)
            {
                return combined;
            }

            List<RelativeTimeRule> combinedRelativeTimeRules = combined.RelativeTimeRules.ToList();
            foreach (RelativeTimeRule parentRelativeTimeRule in parent.RelativeTimeRules)
            {
                RelativeTimeRule combinedRelativeTimeRule = (from crtr in combinedRelativeTimeRules
                                                             where crtr.Id == parentRelativeTimeRule.Id
                                                             select crtr).FirstOrDefault();
                if (combinedRelativeTimeRule == null)
                {
                    combinedRelativeTimeRules.Add(parentRelativeTimeRule);
                }
                else
                {
                    combinedRelativeTimeRule = RelativeTimeRule.Combine(combinedRelativeTimeRule, parentRelativeTimeRule);
                }
            }

            combined.RelativeTimeRules = combinedRelativeTimeRules.ToArray();
            return combined;
        }
    }
}
