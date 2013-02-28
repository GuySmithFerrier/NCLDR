namespace NCldr.Types
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Timezone_Names </remarks>
    [Serializable]
    public class MetaTimeZone
    {
        public string Id { get; set; }

        public TimeZoneRegion[] TimeZoneRegions { get; set; }
    }
}
