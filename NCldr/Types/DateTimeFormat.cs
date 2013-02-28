namespace NCldr.Types
{
    using System;

    /// <summary>
    /// DateTimeFormat converts CLDR date and time patterns to equivalent .NET date and time patterns
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Date_Format_Patterns </remarks>
    public sealed class DateTimeFormat
    {
        /// <summary>
        /// GetDotNetFormat gets the equivalent .NET date/time format pattern for a given CLDR format pattern
        /// </summary>
        /// <param name="cldrFormat">The CLDR date/time format pattern</param>
        /// <returns>A .NET date/time format pattern</returns>
        public static string GetDotNetFormat(string cldrFormat)
        {
            // CLDR date patterns are defined at http://www.unicode.org/reports/tr35/#Date_Format_Patterns
            // .NET date and time formats are defined at http://msdn.microsoft.com/en-us/library/8kb3ddd4.aspx

            // .NET does not have an equivalent to CLDR's "Modified Julian Day" ('g') and 'g' is interpreted to mean Era in .NET
            cldrFormat = cldrFormat.Replace("g", string.Empty);

            // .NET eras are 'g', CLDR eras are 'G'
            cldrFormat = cldrFormat.Replace('G', 'g');

            // .NET does not have a direct equivalent to CLDR's 'Y' format to indicate "Year (in Week of Year calendars)"
            // so it is simply converted to .NET's year.
            cldrFormat = cldrFormat.Replace('Y', 'y');

            // .NET does not have a direct equivalent to CLDR's 'u' format to indicate "Extended Year"
            // so it is simply converted to .NET's year.
            cldrFormat = cldrFormat.Replace('u', 'y');

            // .NET does not have cyclic year names ('U') so they are removed
            cldrFormat = cldrFormat.Replace("U ", string.Empty);
            cldrFormat = cldrFormat.Replace("U", string.Empty);

            // .NET does not have quarter names ('Q', 'q') so they are removed
            cldrFormat = cldrFormat.Replace("Q ", string.Empty);
            cldrFormat = cldrFormat.Replace("Q", string.Empty);
            cldrFormat = cldrFormat.Replace("q ", string.Empty);
            cldrFormat = cldrFormat.Replace("q", string.Empty);

            // .NET handles genitive month names based on their context within a month string as opposed to
            // CLDR's designation of whether the month name should be stand alone or not so stand alone month
            // designators (i.e. 'L') are converted to month designators
            cldrFormat = cldrFormat.Replace("L", "M");

            // .NET does not have a concept of 'narrow' month names (e.g. J, F, M, A, M, J, J, A, S, O, N, D)
            // so they are converted to a month number
            cldrFormat = cldrFormat.Replace("MMMMM", "M");

            // CLDR's 'I' format has been deprecated and should be ignored
            cldrFormat = cldrFormat.Replace("I", string.Empty);

            // .NET does not have an equivalent to CLDR's week numbers ('w', 'W')
            cldrFormat = cldrFormat.Replace("w ", string.Empty);
            cldrFormat = cldrFormat.Replace("w", string.Empty);
            cldrFormat = cldrFormat.Replace("W ", string.Empty);
            cldrFormat = cldrFormat.Replace("W", string.Empty);

            // .NET does not have an equivalent to CLDR's Day Of Year ('D')
            cldrFormat = cldrFormat.Replace("D ", string.Empty);
            cldrFormat = cldrFormat.Replace("D", string.Empty);

            // .NET does not have an equivalent to CLDR's Day Of Week In Month ('F') e.g. "2nd Wed in July"
            cldrFormat = cldrFormat.Replace("F ", string.Empty);
            cldrFormat = cldrFormat.Replace("F", string.Empty);

            // .NET does not have a concept of genitive week days so convert CLDR's 'c' to CLDR's 'E' so that it can
            // be processed by subsequent rules
            cldrFormat = cldrFormat.Replace("c", "E");

            // Convert CLDR's narrow and short name day of weeks to .NET's short day of week
            cldrFormat = cldrFormat.Replace("EEEEEE", "ddd");
            cldrFormat = cldrFormat.Replace("EEEEE", "ddd");

            // .NET normal day of week is "dddd", CLDR's normal day of week is "EEEE"
            cldrFormat = cldrFormat.Replace("EEEE", "dddd");

            // .NET's day of week is 'd', CLDR's day of week is 'E'
            cldrFormat = cldrFormat.Replace("E", "d");

            // .NET's AM/PM designator is 'tt', CLDR's AM/PM designator is 'a'
            cldrFormat = cldrFormat.Replace("a", "tt");

            // .NET does not have a direct equivalent to CLDR's zero-based hour format so it is converted to one-based hour format
            cldrFormat = cldrFormat.Replace("K", "h");
            cldrFormat = cldrFormat.Replace("k", "H");

            // .NET does not have a direct equivalent to CLDR's 'j' format so it is converted to hour format
            cldrFormat = cldrFormat.Replace("j", "H");

            // The exact translation of CLDR's "S" format is tricky because unlike .NET's 'f' equivalent it includes 
            // the seconds integer so the conversion adds back a fixed seconds integer
            cldrFormat = cldrFormat.Replace("SSSSSS", "sss.ffff");
            cldrFormat = cldrFormat.Replace("SSSSS", "sss.ffff");
            cldrFormat = cldrFormat.Replace("SSSS", "sss.ffff");
            cldrFormat = cldrFormat.Replace("SSS", "sss.ffff");
            cldrFormat = cldrFormat.Replace("SS", "sss.ffff");

            // .NET does not have an equivalent to CLDR's milliseconds in day ('A')
            cldrFormat = cldrFormat.Replace("A ", string.Empty);
            cldrFormat = cldrFormat.Replace("A", string.Empty);

            // .NET's rough equalivent to CLDR's time zone designators ('z', 'Z', 'v', 'V') is 'z'
            cldrFormat = cldrFormat.Replace("Z", "z");
            cldrFormat = cldrFormat.Replace("v", "z");
            cldrFormat = cldrFormat.Replace("V", "z");
            cldrFormat = cldrFormat.Replace("zzzzz", "zzz,zzz");
            cldrFormat = cldrFormat.Replace("zzzz", "zz");

            return cldrFormat;
        }
    }
}
