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

        /// <summary>
        /// Combine combines a child with a parent as necessary and returns the combined object
        /// </summary>
        /// <param name="combinedCharacters">The child object</param>
        /// <param name="parentCharacters">The parent object</param>
        /// <returns>The combined object</returns>
        public static Characters Combine(Characters combinedCharacters, Characters parentCharacters)
        {
            if (combinedCharacters == null && parentCharacters == null)
            {
                return null;
            }
            else if (combinedCharacters == null)
            {
                return (Characters)parentCharacters.Clone();
            }
            else if (parentCharacters == null)
            {
                return combinedCharacters;
            }

            if (combinedCharacters.ExemplarCharacters == null || combinedCharacters.ExemplarCharacters.GetLength(0) == 0)
            {
                combinedCharacters.ExemplarCharacters = parentCharacters.ExemplarCharacters;
            }

            if (combinedCharacters.AuxiliaryExemplarCharacters == null
                || combinedCharacters.AuxiliaryExemplarCharacters.GetLength(0) == 0)
            {
                combinedCharacters.AuxiliaryExemplarCharacters = parentCharacters.AuxiliaryExemplarCharacters;
            }

            if (combinedCharacters.PunctuationExemplarCharacters == null
                || combinedCharacters.PunctuationExemplarCharacters.GetLength(0) == 0)
            {
                combinedCharacters.PunctuationExemplarCharacters = parentCharacters.PunctuationExemplarCharacters;
            }

            if (combinedCharacters.FinalEllipsis == null)
            {
                combinedCharacters.FinalEllipsis = parentCharacters.FinalEllipsis;
            }

            if (combinedCharacters.InitialEllipsis == null)
            {
                combinedCharacters.InitialEllipsis = parentCharacters.InitialEllipsis;
            }

            if (combinedCharacters.MedialEllipsis == null)
            {
                combinedCharacters.MedialEllipsis = parentCharacters.MedialEllipsis;
            }

            if (combinedCharacters.MoreInformation == null)
            {
                combinedCharacters.MoreInformation = parentCharacters.MoreInformation;
            }

            return combinedCharacters;
        }
    }
}
