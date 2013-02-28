namespace NCldr.Types
{
    using System;

    /// <summary>
    /// RegionGroup specifies what regions contain what regions
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Supplemental_Territory_Containment.
    /// CLDR regions maintain a hierarchy of: World, Continent, Subcontinent, Country/Region.</remarks>
    [Serializable]
    public class RegionGroup
    {
        /// <summary>
        /// Gets or sets the region identifier that contains the regions
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the regions that are contained by the Id region
        /// </summary>
        public string[] RegionIds { get; set; }

        /// <summary>
        /// Gets or sets whether the status is deprecated or grouping
        /// </summary>
        public string Status { get; set; }
    }
}
