namespace NCldr.Types
{
    using System;

    /// <summary>
    /// MonthNameSet is a set of localized month names used by a calendar
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Calendar_Elements </remarks>
    [Serializable]
    public class MonthNameSet : CalendarNameSet<MonthName>
    {
    }
}
