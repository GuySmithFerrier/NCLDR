namespace NCldr.Types
{
    using System;

    /// <summary>
    /// Delimiters is a collection of delimiters used by a culture
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Delimiter_Elements </remarks>
    [Serializable]
    public class Delimiters : ICloneable
    {
        /// <summary>
        /// Gets or sets the character(s) used at the start of a quotation
        /// </summary>
        public string QuotationStart { get; set; }

        /// <summary>
        /// Gets or sets the character(s) used at the end of a quotation
        /// </summary>
        public string QuotationEnd { get; set; }

        /// <summary>
        /// Gets or sets the alternative character(s) used at the start of a quotation
        /// </summary>
        public string AlternateQuotationStart { get; set; }

        /// <summary>
        /// Gets or sets the alternative character(s) used at the end of a quotation
        /// </summary>
        public string AlternateQuotationEnd { get; set; }

        /// <summary>
        /// Clone clones the object
        /// </summary>
        /// <returns>A cloned copy of the object</returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
