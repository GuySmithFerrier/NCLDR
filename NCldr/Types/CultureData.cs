namespace NCldr.Types
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// CultureData represents the un-resolved CLDR data for a single culture
    /// </summary>
    /// <remarks>In general you should use the Culture class instead of the CultureData class
    /// because the Culture class returns data that has been resolved with the Culture's parent Cultures.</remarks>
    [Serializable]
    public class CultureData
    {
        /// <summary>
        /// Gets or sets the culture's Identity 
        /// </summary>
        public Identity Identity { get; set; }

        /// <summary>
        /// Gets or sets the culture's language display names
        /// </summary>
        public List<LanguageDisplayName> LanguageDisplayNames { get; set; }

        /// <summary>
        /// Gets or sets the culture's region display names
        /// </summary>
        public List<RegionDisplayName> RegionDisplayNames { get; set; }

        /// <summary>
        /// Gets or sets the culture's script display names
        /// </summary>
        public List<ScriptDisplayName> ScriptDisplayNames { get; set; }

        /// <summary>
        /// Gets or sets the culture's casing rules
        /// </summary>
        public Casing Casing { get; set; }

        /// <summary>
        /// Gets or sets the culture's characters
        /// </summary>
        public Characters Characters { get; set; }

        /// <summary>
        /// Gets or sets the culture's delimiters
        /// </summary>
        public Delimiters Delimiters { get; set; }

        /// <summary>
        /// Gets or sets the culture's dates and calendars
        /// </summary>
        public Dates Dates { get; set; }

        /// <summary>
        /// Gets or sets the culture's list patterns
        /// </summary>
        public ListPattern[] ListPatterns { get; set; }

        /// <summary>
        /// Gets or sets the culture's messages
        /// </summary>
        public Messages Messages { get; set; }

        /// <summary>
        /// Gets or sets the culture's numbers and formats
        /// </summary>
        public Numbers Numbers { get; set; }

        /// <summary>
        /// Gets or sets the culture's rule based number formatting
        /// </summary>
        public RuleBasedNumberFormatting RuleBasedNumberFormatting { get; set; }

        /// <summary>
        /// Gets or sets the culture's unit pattern sets
        /// </summary>
        public UnitPatternSet[] UnitPatternSets { get; set; }

        /// <summary>
        /// Gets a CultureData for the given culture name
        /// </summary>
        /// <param name="cultureName">The name of the culture to get the CultureData for</param>
        /// <returns>A CultureData for the given culture name</returns>
        public static CultureData GetCulture(string cultureName)
        {
            return (from c in NCldr.CultureDatas
                    where string.Compare(c.Identity.CultureName, cultureName, false, CultureInfo.InvariantCulture) == 0
                    select c).FirstOrDefault();
        }
    }
}
