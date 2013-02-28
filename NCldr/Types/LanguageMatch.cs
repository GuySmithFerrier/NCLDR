namespace NCldr.Types
{
    using System;

    /// <summary>
    /// LanguageMatch provides data on how to match requested languages with supported languages
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#LanguageMatching </remarks>
    [Serializable]
    public class LanguageMatch
    {
        /// <summary>
        /// Gets or sets the desired languages
        /// </summary>
        public string Desired { get; set; }

        /// <summary>
        /// Gets or sets the supported languages
        /// </summary>
        public string Supported { get; set; }

        /// <summary>
        /// Gets or sets the percentage indicating the success of the match
        /// </summary>
        public int Percent { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the list traversal is asymmetric (true) or symmetric (false)
        /// </summary>
        public bool IsOneWay { get; set; }
    }
}
