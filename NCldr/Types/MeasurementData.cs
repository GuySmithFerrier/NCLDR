namespace NCldr.Types
{
    using System;

    /// <summary>
    /// MeasurementData provides data on which regions use which measurement systems and paper sizes
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Measurement_System_Data </remarks>
    [Serializable]
    public class MeasurementData
    {
        /// <summary>
        /// Gets or sets the measurement systems used by regions
        /// </summary>
        public RegionMeasurementSystem[] MeasurementSystems { get; set; }

        /// <summary>
        /// Gets or sets the paper sizes used by regions
        /// </summary>
        public RegionPaperSize[] PaperSizes { get; set; }
    }
}
