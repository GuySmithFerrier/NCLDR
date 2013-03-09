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
        public string Lines { get; set; }

        /// <summary>
        /// Gets or sets the default general ordering of characters within a line
        /// </summary>
        public string Characters { get; set; }

        /// <summary>
        /// IsRightToLeft returns true if the ordering of characters within a line is Right To Left
        /// </summary>
        /// <returns>True if the ordering of characters within a line is Right To Left</returns>
        public bool IsRightToLeft()
        {
            if (String.IsNullOrEmpty(this.Characters))
            {
                return false;
            }

            return string.Compare(this.Characters, "right-to-left", true, CultureInfo.InvariantCulture) == 0;
        }
    }
}
