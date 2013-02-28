namespace NCldr.Types
{
    using System;

    /// <summary>
    /// CharacterFallback provides a list of substitute characters for any one character
    /// </summary>
    [Serializable]
    public class CharacterFallback
    {
        /// <summary>
        /// Gets or sets the character for which one or more substitutes are available
        /// </summary>
        public string Character { get; set; }

        /// <summary>
        /// Gets or sets an array of substitute characters
        /// </summary>
        public string[] Substitutes { get; set; }
    }
}
