namespace NCldr.Types
{
    using System;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// Script is the script used in a culture
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Locale </remarks>
    [Serializable]
    public partial class Script : CldrIdentifier
    {
        /// <summary>
        /// Gets the English name of the script
        /// </summary>
        public string EnglishName
        {
            get
            {
                return GetDisplayName("en", this.Id);
            }
        }

        /// <summary>
        /// Gets the display name of the script in the given language
        /// </summary>
        /// <param name="languageId">The Id of the language to get the display name in</param>
        /// <returns>The display name of the script in the given language</returns>
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
        /// Gets the display name of the culture's script in the given language
        /// </summary>
        /// <param name="cultureName">The name of the culture</param>
        /// <param name="languageId">The Id of the language to get the display name in</param>
        /// <returns>The display name of the script in the given language</returns>
        private static string GetDisplayName(string cultureName, string languageId)
        {
            Culture culture = Culture.GetCulture(cultureName);
            if (culture != null)
            {
                return (from ldn in culture.ScriptDisplayNames
                        where string.Compare(ldn.Id, languageId, false, CultureInfo.InvariantCulture) == 0
                        select ldn.Name).FirstOrDefault();
            }

            return null;
        }
    }
}
