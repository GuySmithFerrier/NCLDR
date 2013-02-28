namespace NCldr.Types
{
    using System;

    /// <summary>
    /// RegionPaperSize specifies the regions that use a paper size
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Measurement_System_Data </remarks>
    [Serializable]
    public class RegionPaperSize
    {
        /// <summary>
        /// Gets or sets the paper size identifier
        /// </summary>
        /// <remarks>The values are "A4" and "US-Letter"</remarks>
        public string PaperSizeId { get; set; }

        /// <summary>
        /// Gets or sets an array of region Ids for which the paper size applies
        /// </summary>
        public string[] RegionIds { get; set; }
    }
}
