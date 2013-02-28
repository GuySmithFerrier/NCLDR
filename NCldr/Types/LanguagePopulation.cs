namespace NCldr.Types
{
    using System;

    /// <summary>
    /// LanguagePopulation provides approximate population statistics for languages
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Supplemental_Territory_Information </remarks>
    [Serializable]
    public class LanguagePopulation
    {
        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the percentage of the population that are functional in the language
        /// </summary>
        public float PopulationPercent { get; set; }

        /// <summary>
        /// Gets or sets the official status of the language
        /// </summary>
        public string OfficialStatus { get; set; }

        /// <summary>
        /// Gets or sets the references used to collect the information
        /// </summary>
        public string References { get; set; }
    }
}
