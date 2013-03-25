namespace NCldr.Types
{
    using System;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// Language identifies a CLDR language
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Unicode_Language_and_Locale_Identifiers </remarks>
    [Serializable]
    public partial class Language : CldrIdentifier
    {
        /// <summary>
        /// Gets the English name of the language
        /// </summary>
        public string EnglishName
        {
            get
            {
                return GetDisplayName("en", this.Id);
            }
        }

        /// <summary>
        /// Gets the native name of the language (i.e. the name of the language in its own language)
        /// </summary>
        public string NativeName
        {
            get
            {
                string nativeName = GetDisplayName(this.Id, this.Id);
                if (string.IsNullOrEmpty(nativeName))
                {
                    return this.EnglishName;
                }

                return nativeName;
            }
        }

        /// <summary>
        /// Gets the display name of the language in a given language
        /// </summary>
        /// <param name="languageId">The language to get the display name in</param>
        /// <returns>The display name of the language in a given language</returns>
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
        /// Gets the display name of a given culture in the given language
        /// </summary>
        /// <param name="cultureName">The name of the culture</param>
        /// <param name="languageId">The language to get the display name in</param>
        /// <returns>The display name of a given culture in the given language</returns>
        private static string GetDisplayName(string cultureName, string languageId)
        {
            Culture culture = Culture.GetCulture(cultureName);
            if (culture != null && culture.LanguageDisplayNames != null)
            {
                return (from ldn in culture.LanguageDisplayNames
                        where string.Compare(ldn.Id, languageId, StringComparison.InvariantCulture) == 0
                        select ldn.Name).FirstOrDefault();
            }

            return null;
        }
    }
}
