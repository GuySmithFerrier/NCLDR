namespace NCldr.Types
{
    using System;

    /// <summary>
    /// PostcodeRegex is a regular expression that validates a postal code for a region
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Postal_Code_Validation </remarks>
    [Serializable]
    public class PostcodeRegex
    {
        /// <summary>
        /// Gets or sets the Id of the region for which the regular expression applies
        /// </summary>
        public string RegionId { get; set; }

        /// <summary>
        /// Gets or sets a regular expression that validates a postal code for the region
        /// </summary>
        public string Regex { get; set; }
    }
}
