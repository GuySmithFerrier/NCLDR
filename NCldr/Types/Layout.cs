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

        /// <summary>
        /// Combine combines a child with a parent as necessary and returns the combined object
        /// </summary>
        /// <param name="combinedLayout">The child object</param>
        /// <param name="parentLayout">The parent object</param>
        /// <returns>The combined object</returns>
        public static Layout Combine(Layout combinedLayout, Layout parentLayout)
        {
            if (combinedLayout == null && parentLayout == null)
            {
                return null;
            }
            else if (combinedLayout == null)
            {
                return (Layout)parentLayout.Clone();
            }
            else if (parentLayout == null)
            {
                return combinedLayout;
            }

            if (combinedLayout.Orientation == null)
            {
                combinedLayout.Orientation = parentLayout.Orientation;
            }
            else if (parentLayout.Orientation != null)
            {
                if (string.IsNullOrEmpty(combinedLayout.Orientation.CharacterOrder))
                {
                    combinedLayout.Orientation.CharacterOrder = parentLayout.Orientation.CharacterOrder;
                }

                if (string.IsNullOrEmpty(combinedLayout.Orientation.LineOrder))
                {
                    combinedLayout.Orientation.LineOrder = parentLayout.Orientation.LineOrder;
                }
            }

            return combinedLayout;
        }
    }
}
