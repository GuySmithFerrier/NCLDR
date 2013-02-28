namespace NCldr.Types
{
    using System;
    using System.Globalization;

    /// <summary>
    /// RegionMeasurementSystem specifies the regions that use a Measurement System
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Measurement_System_Data </remarks>
    [Serializable]
    public class RegionMeasurementSystem
    {
        /// <summary>
        /// Gets or sets the measurement system identifier
        /// </summary>
        /// <remarks>The values are "metric", "US" and "UK"</remarks>
        public string MeasurementSystemId { get; set; }

        /// <summary>
        /// Gets or sets an array of region Ids for which the measurement system applies
        /// </summary>
        public string[] RegionIds { get; set; }

        /// <summary>
        /// Gets a value indicating whether the measurement system is metric
        /// </summary>
        public bool IsMetric
        {
            get
            {
                return string.Compare(this.MeasurementSystemId, "metric", false, CultureInfo.InvariantCulture) == 0;
            }
        }
    }
}
