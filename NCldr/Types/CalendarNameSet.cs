namespace NCldr.Types
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// CalendarNameSet is the base class for a set of names used by a calendar
    /// </summary>
    /// <typeparam name="T">The type of the name class derived from CalendarName</typeparam>
    [Serializable]
    public class CalendarNameSet<T> : ICloneable where T : CalendarName
    {
        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets an array of names of type T
        /// </summary>
        public T[] Names { get; set; }

        /// <summary>
        /// Clone clones the object
        /// </summary>
        /// <returns>A cloned copy of the object</returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        /// <summary>
        /// Combine combines a child with a parent as necessary and returns the combined object
        /// </summary>
        /// <param name="combinedCalendarNameSets">The child object</param>
        /// <param name="parentCalendarNameSets">The parent object</param>
        /// <returns>The combined object</returns>
        public static W[] Combine<W>(
            W[] combinedCalendarNameSets, 
            W[] parentCalendarNameSets) where W : CalendarNameSet<T>
        {
            if ((combinedCalendarNameSets == null  || combinedCalendarNameSets.GetLength(0) == 0) && 
                (parentCalendarNameSets == null || parentCalendarNameSets.GetLength(0) == 0))
            {
                return null;
            }
            else if (combinedCalendarNameSets == null || combinedCalendarNameSets.GetLength(0) == 0)
            {
                return (W[])parentCalendarNameSets.Clone();
            }
            else if (parentCalendarNameSets == null || parentCalendarNameSets.GetLength(0) == 0)
            {
                return combinedCalendarNameSets;
            }

            List<W> combinedCalendarNameSetList = new List<W>(combinedCalendarNameSets);
            foreach (W parentCalendarNameSet in parentCalendarNameSets)
            {
                CalendarNameSet<T> combinedCalendarNameSet = (from ups in combinedCalendarNameSets
                                                              where string.Compare(ups.Id, parentCalendarNameSet.Id, StringComparison.InvariantCulture) == 0
                                                              select ups).FirstOrDefault();
                if (combinedCalendarNameSet == null)
                {
                    // this name set does not exist in the combined list
                    combinedCalendarNameSetList.Add(parentCalendarNameSet);
                }
                else
                {
                    // combine the items of the two sets
                    combinedCalendarNameSet = CalendarNameSet<T>.Combine(combinedCalendarNameSet, parentCalendarNameSet);
                }
            }

            return combinedCalendarNameSetList.ToArray();
        }

        /// <summary>
        /// Combine combines a child with a parent as necessary and returns the combined object
        /// </summary>
        /// <param name="combinedCalendarNameSet">The child object</param>
        /// <param name="parentCalendarNameSet">The parent object</param>
        /// <returns>The combined object</returns>
        public static CalendarNameSet<T> Combine(
            CalendarNameSet<T> combinedCalendarNameSet,
            CalendarNameSet<T> parentCalendarNameSet)
        {
            if (combinedCalendarNameSet == null && parentCalendarNameSet == null)
            {
                return null;
            }
            else if (combinedCalendarNameSet == null)
            {
                return (CalendarNameSet<T>)parentCalendarNameSet.Clone();
            }
            else if (parentCalendarNameSet == null)
            {
                return combinedCalendarNameSet;
            }

            List<T> combinedCalendarNames = new List<T>(combinedCalendarNameSet.Names);
            foreach (T parentCalendarName in parentCalendarNameSet.Names)
            {
                if (!(from cn in combinedCalendarNames
                      where String.Compare(cn.Id, parentCalendarName.Id, StringComparison.InvariantCultureIgnoreCase) == 0
                      select cn).Any())
                {
                    // the parent name is not in the combined list
                    combinedCalendarNames.Add(parentCalendarName);
                }
            }

            combinedCalendarNameSet.Names = combinedCalendarNames.ToArray();
            return combinedCalendarNameSet;
        }
    }
}
