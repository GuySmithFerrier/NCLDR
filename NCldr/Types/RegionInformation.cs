namespace NCldr.Types
{
    using System;

    /// <summary>
    /// RegionInformation provides testing information for language and region populations
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Supplemental_Territory_Information </remarks>
    [Serializable]
    public class RegionInformation
    {
        /// <summary>
        /// Gets or sets the region's identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the region's Gross Domestic Product
        /// </summary>
        public long Gdp { get; set; }

        /// <summary>
        /// Gets or sets the percentage of the population that is able to read and write the
        /// language and is comfortable enough to use it with computers
        /// </summary>
        public float LiteracyPercent { get; set; }

        /// <summary>
        /// Gets or sets the population of the region
        /// </summary>
        public int Population { get; set; }

        /// <summary>
        /// Gets or sets the populations of each language in the region
        /// </summary>
        public LanguagePopulation[] LanguagePopulations { get; set; }
    }
}
