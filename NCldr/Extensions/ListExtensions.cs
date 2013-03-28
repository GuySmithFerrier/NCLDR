namespace NCldr.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// ListExtensions is a collection of Extension Methods for Lists
    /// </summary>
    internal static class ListExtensions
    {
        /// <summary>
        /// Clone performs a shallow copy of a generic List
        /// </summary>
        /// <typeparam name="T">The Type of items in the list</typeparam>
        /// <param name="list">The list</param>
        /// <returns>A shallow clone of the list</returns>
        public static List<T> Clone<T>(this List<T> list) where T : ICloneable
        {
            return list.Select(item => (T)item.Clone()).ToList();
        }
    }
}
