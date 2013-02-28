namespace NCldr.Types
{
    using System;

    /// <summary>
    /// DayPeriodNameSet is a set of localized day period names used by a calendar
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Calendar_Elements </remarks>
    [Serializable]
    public class DayPeriodNameSet : CalendarNameSet<DayPeriodName>
    {
    }
}
