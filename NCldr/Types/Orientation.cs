namespace NCldr.Types
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Orientation specifies the default general ordering of lines within a page and characters within a line
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Layout_Elements </remarks>
    [Serializable]
    public class Orientation
    {
        /// <summary>
        /// Gets or sets the default general ordering of lines within a page
        /// </summary>
        public string LineOrder { get; set; }

        /// <summary>
        /// Gets or sets the default general ordering of characters within a line
        /// </summary>
        public string CharacterOrder { get; set; }

        /// <summary>
        /// Gets a value indicating whether the ordering of characters within a line is Right To Left
        /// </summary>
        public bool IsRightToLeft
        {
            get
            {
                if (string.IsNullOrEmpty(this.CharacterOrder))
                {
                    return false;
                }

                return string.Compare(this.CharacterOrder, "right-to-left", StringComparison.InvariantCultureIgnoreCase) == 0;
            }
        }
    }
}
