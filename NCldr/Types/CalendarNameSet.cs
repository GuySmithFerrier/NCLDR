namespace NCldr.Types
{
    using System;

    /// <summary>
    /// CalendarNameSet is the base class for a set of names used by a calendar
    /// </summary>
    /// <typeparam name="T">The type of the name class derived from CalendarName</typeparam>
    [Serializable]
    public class CalendarNameSet<T> where T : CalendarName
    {
        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets an array of names of type T
        /// </summary>
        public T[] Names { get; set; }
    }
}
