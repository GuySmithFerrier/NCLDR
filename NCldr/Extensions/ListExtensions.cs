namespace NCldr.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal static class ListExtensions
    {
        public static List<T> Clone<T>(this List<T> list) where T : ICloneable
        {
            return list.Select(item => (T)item.Clone()).ToList();
        }
    }
}
