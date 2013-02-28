namespace NCldr.Types
{
    using System;

    /// <summary>
    /// ParentCulture is used to indicate the parent culture id for cultures that do not follow
    /// the simple name truncation naming convention
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Parent_Locales </remarks>
    [Serializable]
    public class ParentCulture
    {
        /// <summary>
        /// Gets or sets the Id of the parent culture
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// Gets or sets the array of cultures which are children of the ParentId culture
        /// </summary>
        public string[] CultureIds { get; set; }
    }
}
