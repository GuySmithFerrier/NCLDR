namespace NCldr.Types
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// OtherNumberingSystem is a CLDR Numbering System Identifier that is not the default Numbering System
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Number_Elements </remarks>
    [Serializable]
    public class OtherNumberingSystem
    {
        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Combine combines a list of child objects with a list of parent objects as necessary and
        /// returns the combined list of objects
        /// </summary>
        /// <param name="combinedOtherNumberingSystems">The List of child objects</param>
        /// <param name="parentOtherNumberingSystems">The List of parent objects</param>
        /// <returns>The combined list of objects</returns>
        public static List<OtherNumberingSystem> Combine(List<OtherNumberingSystem> combinedOtherNumberingSystems, List<OtherNumberingSystem> parentOtherNumberingSystems)
        {
            if (combinedOtherNumberingSystems == null && parentOtherNumberingSystems == null)
            {
                return null;
            }
            else if (combinedOtherNumberingSystems == null)
            {
                return new List<OtherNumberingSystem>(parentOtherNumberingSystems);
            }
            else if (parentOtherNumberingSystems == null)
            {
                return combinedOtherNumberingSystems;
            }

            foreach (OtherNumberingSystem parentOtherNumberingSystem in parentOtherNumberingSystems)
            {
                if (!combinedOtherNumberingSystems.Where(ons => ons.Id == parentOtherNumberingSystem.Id).Any())
                {
                    combinedOtherNumberingSystems.Add(parentOtherNumberingSystem);
                }
            }

            return combinedOtherNumberingSystems;
        }
    }
}
