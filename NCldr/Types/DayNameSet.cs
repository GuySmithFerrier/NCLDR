namespace NCldr.Types
{
    using System;

    /// <summary>
    /// DayNameSet is a set of localized day names used by a calendar
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Calendar_Elements </remarks>
    [Serializable]
    public class DayNameSet : CalendarNameSet<DayName>
    {
    }
}
