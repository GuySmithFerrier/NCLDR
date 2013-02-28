namespace NCldr.Types
{
    using System;

    /// <summary>
    /// UnitPatternSets is a set of UnitPattern objects
    /// </summary>
    [Serializable]
    public class UnitPatternSet
    {
        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the array of UnitPattern objects
        /// </summary>
        public UnitPattern[] UnitPatterns { get; set; }
    }
}
