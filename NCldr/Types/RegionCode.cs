namespace NCldr.Types
{
    using System;

    /// <summary>
    /// RegionCode contains additional codes that identify a region
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Supplemental_Code_Mapping </remarks>
    [Serializable]
    public class RegionCode
    {
        /// <summary>
        /// Gets or sets the region's two letter identifier
        /// </summary>
        public string RegionId { get; set; }

        /// <summary>
        /// Gets or sets the region's ISO numeric code
        /// </summary>
        public string Numeric { get; set; }

        /// <summary>
        /// Gets or sets the region's three letter ISO code
        /// </summary>
        public string Alpha3 { get; set; }

        /// <summary>
        /// Gets or sets the region's FIPS 10 code
        /// </summary>
        public string Fips10 { get; set; }
    }
}
