namespace NCldr.Types
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Extensions;

    /// <summary>
    /// DisplayName is a localized name intended for viewing by an end user
    /// </summary>
    [Serializable]
    public class DisplayName : ICloneable
    {
        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the localized name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Clone clones the object
        /// </summary>
        /// <returns>A cloned copy of the object</returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        /// <summary>
        /// Combine combines a child with a parent as necessary and returns the combined object
        /// </summary>
        /// <param name="combinedDisplayNames">The child object</param>
        /// <param name="parentDisplayNames">The parent object</param>
        /// <returns>The combined object</returns>
        public static List<T> Combine<T>(List<T> combinedDisplayNames, List<T> parentDisplayNames) where T : DisplayName
        {
            if (combinedDisplayNames == null && parentDisplayNames == null)
            {
                return null;
            }
            else if (combinedDisplayNames == null)
            {
                return (List<T>)parentDisplayNames.Clone();
            }
            else if (parentDisplayNames == null)
            {
                return combinedDisplayNames;
            }

            List<T> combinedDisplayNamesList = new List<T>(combinedDisplayNames);

            // merge the parent's display names with the current list (giving the current list priority)
            foreach (var parentDisplayName in parentDisplayNames)
            {
                if (!(from dn in combinedDisplayNamesList
                      where string.Compare(dn.Id, parentDisplayName.Id, StringComparison.InvariantCulture) == 0
                      select dn).Any())
                {
                    // the parent's display name does not exist in the current list so add it
                    combinedDisplayNamesList.Add(parentDisplayName);
                }
            }

            return combinedDisplayNamesList;
        }
    }
}
