namespace NCldr.Types
{
    using System;

    /// <summary>
    /// GenderList is used to determine the gender of a list of 2 or more persons
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#List_Gender </remarks>
    [Serializable]
    public class GenderList
    {
        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the cultures for which the gender of the list applies
        /// </summary>
        public string[] CultureIds { get; set; }
    }
}
