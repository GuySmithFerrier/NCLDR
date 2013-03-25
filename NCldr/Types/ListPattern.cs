namespace NCldr.Types
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// ListPattern is a specification for one part of a list
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#ListPatterns </remarks>
    [Serializable]
    public class ListPattern
    {
        /// <summary>
        /// Gets or sets the pattern's identifier (that identifier which part of the list that the pattern belongs to)
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the pattern used by the part of the list
        /// </summary>
        public string Pattern { get; set; }

        /// <summary>
        /// Combine combines a child with a parent as necessary and returns the combined object
        /// </summary>
        /// <param name="combinedListPatterns">The child object</param>
        /// <param name="parentListPatterns">The parent object</param>
        /// <returns>The combined object</returns>
        public static ListPattern[] Combine(ListPattern[] combinedListPatterns, ListPattern[] parentListPatterns)
        {
            if (combinedListPatterns == null && parentListPatterns == null)
            {
                return null;
            }
            else if (combinedListPatterns == null)
            {
                return (ListPattern[])parentListPatterns.Clone();
            }
            else if (parentListPatterns == null)
            {
                return combinedListPatterns;
            }

            List<ListPattern> combinedListPattern = new List<ListPattern>(combinedListPatterns);
            foreach (ListPattern parentListPattern in parentListPatterns)
            {
                if (!(from ups in combinedListPatterns
                      where string.Compare(ups.Id, parentListPattern.Id, StringComparison.InvariantCulture) == 0
                      select ups).Any())
                {
                    // this unit pattern set does not exist in the combined list
                    combinedListPattern.Add(parentListPattern);
                }
            }

            return combinedListPattern.ToArray();
        }
    }
}
