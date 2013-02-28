namespace NCldr.Types
{
    using System;

    /// <summary>
    /// Characters provides lists of characters used in a culture
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Character_Elements </remarks>
    [Serializable]
    public class Characters : ICloneable
    {
        /// <summary>
        /// Gets or sets the commonly used letters for a given modern form of a language
        /// </summary>
        public string[] ExemplarCharacters { get; set; }

        /// <summary>
        /// Gets or sets the non-native or historical characters that would customarily occur in 
        /// common publications or dictionaries
        /// </summary>
        public string[] AuxiliaryExemplarCharacters { get; set; }

        /// <summary>
        /// Gets or sets the common punctuation characters that are used with the language 
        /// </summary>
        public string[] PunctuationExemplarCharacters { get; set; }

        /// <summary>
        /// Gets or sets the final ellipsis
        /// </summary>
        public string FinalEllipsis { get; set; }

        /// <summary>
        /// Gets or sets the initial ellipsis
        /// </summary>
        public string InitialEllipsis { get; set; }

        /// <summary>
        /// Gets or sets the medial ellipsis
        /// </summary>
        public string MedialEllipsis { get; set; }

        /// <summary>
        /// Gets or sets the string used to indicate more information is available
        /// </summary>
        public string MoreInformation { get; set; }

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
