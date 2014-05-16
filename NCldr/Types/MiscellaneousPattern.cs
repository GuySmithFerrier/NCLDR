namespace NCldr.Types
{
    using System;

    /// <summary>
    /// MiscellaneousPattern is a number system pattern
    /// </summary>
    [Serializable]
    public class MiscellaneousPattern
    {
        /// <summary>
        /// Gets or sets the identifier for the pattern
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the pattern
        /// </summary>
        public string Pattern { get; set; }
    }
}
