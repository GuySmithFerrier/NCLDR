namespace NCldr.Types
{
    using System;

    /// <summary>
    /// OtherNumberingSystem is a CLDR Numbering System Identifier that is not the default Numbering System
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Number_Elements </remarks>
    [Serializable]
    public class OtherNumberingSystem
    {
        public string Id { get; set; }

        public string Value { get; set; }
    }
}
