namespace NCldr.Types
{
    using System;

    /// <summary>
    /// IPeriod is an interface for a period in time
    /// </summary>
    public interface IPeriod
    {
        /// <summary>
        /// Gets or sets the starting point of the period
        /// </summary>
        DateTime? From { get; set; }

        /// <summary>
        /// Gets or sets the ending point of the period
        /// </summary>
        DateTime? To { get; set; }
    }
}
