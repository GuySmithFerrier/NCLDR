namespace NCldr.Types
{
    using System;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// Region encapsulates the data and functionality for a geographical region
    /// </summary>
    /// <remarks>A Region is called a Territory in CLDR</remarks>
    [Serializable]
    public class Region : CldrIdentifier
    {
        /// <summary>
        /// Gets the region's English display name
        /// </summary>
        public string EnglishName
        {
            get
            {
                return GetDisplayName("en", this.Id);
            }
        }

        /// <summary>
        /// Gets the region's display name in the given language
        /// </summary>
        /// <param name="languageId">The language to get the display name in</param>
        /// <returns>The region's display name in the given language</returns>
        public string DisplayName(string languageId)
        {
            string displayName = GetDisplayName(languageId, this.Id);
            if (string.IsNullOrEmpty(displayName))
            {
                return this.EnglishName;
            }

            return displayName;
        }

        /// <summary>
        /// GetDisplayName gets the display name of the given culture in the given language
        /// </summary>
        /// <param name="cultureName">The name of the culture</param>
        /// <param name="languageId">The Id of the language</param>
        /// <returns>The display name of the given culture in the given language</returns>
        private static string GetDisplayName(string cultureName, string languageId)
        {
            Culture culture = Culture.GetCulture(cultureName);
            if (culture != null)
            {
                return (from ldn in culture.RegionDisplayNames
                        where string.Compare(ldn.Id, languageId, false, CultureInfo.InvariantCulture) == 0
                        select ldn.Name).FirstOrDefault();
            }

            return null;
        }
    }
}
