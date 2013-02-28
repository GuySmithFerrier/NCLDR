namespace NCldr.Types
{
    using System;

    /// <summary>
    /// CalendarName is a base class for a name used by a calendar
    /// </summary>
    [Serializable]
    public class CalendarName
    {
        /// <summary>
        /// Gets or sets the Id of the name
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the localized name
        /// </summary>
        public string Name { get; set; }
    }
}
