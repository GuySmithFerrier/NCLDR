namespace NCldr.Types
{
    using System;

    /// <summary>
    /// Era is a period in time. For a localization of the name of an era see EraName.
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Calendar_Elements </remarks>
    [Serializable]
    public class Era
    {
        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the start of the era
        /// </summary>
        public string Start { get; set; }

        /// <summary>
        /// Gets or sets the end of the era
        /// </summary>
        public string End { get; set; }
    }
}
