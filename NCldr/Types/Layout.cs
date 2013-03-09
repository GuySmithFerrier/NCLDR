namespace NCldr.Types
{
    using System;

    /// <summary>
    /// Layout specifies general layout features
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Layout_Elements </remarks>
    [Serializable]
    public class Layout : ICloneable
    {
        /// <summary>
        /// Gets or sets the default general ordering of lines within a page and characters within a line
        /// </summary>
        public Orientation Orientation { get; set; }

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
