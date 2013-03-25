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

        /// <summary>
        /// Combine combines a child with a parent as necessary and returns the combined object
        /// </summary>
        /// <param name="combinedDelimiters">The child object</param>
        /// <param name="parentDelimiters">The parent object</param>
        /// <returns>The combined object</returns>
        public static Delimiters Combine(Delimiters combinedDelimiters, Delimiters parentDelimiters)
        {
            if (combinedDelimiters == null && parentDelimiters == null)
            {
                return null;
            }
            else if (combinedDelimiters == null)
            {
                return (Delimiters)parentDelimiters.Clone();
            }
            else if (parentDelimiters == null)
            {
                return combinedDelimiters;
            }

            if (combinedDelimiters.QuotationStart == null)
            {
                combinedDelimiters.QuotationStart = parentDelimiters.QuotationStart;
            }

            if (combinedDelimiters.QuotationEnd == null)
            {
                combinedDelimiters.QuotationEnd = parentDelimiters.QuotationEnd;
            }

            if (combinedDelimiters.AlternateQuotationStart == null)
            {
                combinedDelimiters.AlternateQuotationStart = parentDelimiters.AlternateQuotationStart;
            }

            if (combinedDelimiters.AlternateQuotationEnd == null)
            {
                combinedDelimiters.AlternateQuotationEnd = parentDelimiters.AlternateQuotationEnd;
            }

            return combinedDelimiters;
        }
    }
}
