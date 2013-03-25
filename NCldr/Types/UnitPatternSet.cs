namespace NCldr.Types
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// UnitPatternSets is a set of UnitPattern objects
    /// </summary>
    [Serializable]
    public class UnitPatternSet
    {
        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the array of UnitPattern objects
        /// </summary>
        public UnitPattern[] UnitPatterns { get; set; }

        /// <summary>
        /// Combine combines a child with a parent as necessary and returns the combined object
        /// </summary>
        /// <param name="combinedUnitPatternSets">The child object</param>
        /// <param name="parentUnitPatternSets">The parent object</param>
        /// <returns>The combined object</returns>
        public static UnitPatternSet[] Combine(UnitPatternSet[] combinedUnitPatternSets, UnitPatternSet[] parentUnitPatternSets)
        {
            if (combinedUnitPatternSets == null && parentUnitPatternSets == null)
            {
                return null;
            }
            else if (combinedUnitPatternSets == null)
            {
                return (UnitPatternSet[])parentUnitPatternSets.Clone();
            }
            else if (parentUnitPatternSets == null)
            {
                return combinedUnitPatternSets;
            }

            List<UnitPatternSet> combinedUnitPatternSetList = new List<UnitPatternSet>(combinedUnitPatternSets);
            foreach (UnitPatternSet parentUnitPatternSet in parentUnitPatternSets)
            {
                if (!(from ups in combinedUnitPatternSets
                      where string.Compare(ups.Id, parentUnitPatternSet.Id, StringComparison.InvariantCulture) == 0
                      select ups).Any())
                {
                    // this unit pattern set does not exist in the combined list
                    combinedUnitPatternSetList.Add(parentUnitPatternSet);
                }
            }

            return combinedUnitPatternSetList.ToArray();
        }
    }
}
