namespace NCldr.Types
{
    using System;

    /// <summary>
    /// RegionTelephoneCode provides the telephone code(s) used in a region
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Telephone_Code_Data </remarks>
    [Serializable]
    public class RegionTelephoneCode
    {
        /// <summary>
        /// Gets or sets the region identifier for which the telephone code(s) apply
        /// </summary>
        public string RegionId { get; set; }

        /// <summary>
        /// Gets or sets an array of telephone codes that apply to the region
        /// </summary>
        /// <remarks>Typically this is a single telephone code for each region but where a region
        /// is not a country/region (e.g. the World) it can be more than one telephone code</remarks>
        public string[] TelephoneCodes { get; set; }
    }
}
