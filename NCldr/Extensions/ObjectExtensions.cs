namespace NCldr.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// ObjectExtensions is a collection of Extension Methods for Objects
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Combine combines a parent with the object
        /// </summary>
        /// <typeparam name="T">The Type of the objects to combine</typeparam>
        /// <param name="parent">The parent object to combine</param>
        /// <returns>The combined object</returns>
        public static T Combine<T>(this T combined, T parent)
        {
            PropertyInfo[] propertyInfos = combined.GetType().GetProperties();
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                object combinedValue = propertyInfo.GetValue(combined);
                object parentValue = propertyInfo.GetValue(parent);
                if (combinedValue.IsDefault())
                {
                    // the child value is the default
                    if (!parentValue.IsDefault())
                    {
                        // the parent value is not the default so default the child value to the parent value
                        propertyInfo.SetValue(combined, parentValue);
                    }
                }
                else if (!propertyInfo.PropertyType.IsValueType)
                {
                    // the property is a reference type so all of the object's properties must be combined individually
                    MethodInfo methodInfo = typeof(Object).GetMethod("Combine");
                    methodInfo.MakeGenericMethod(propertyInfo.PropertyType).Invoke(null, BindingFlags.InvokeMethod, null, new object[] { combinedValue, parentValue }, null);
                    // combinedValue = combinedValue.Combine<propertyInfo.PropertyType>(parentValue);
                    propertyInfo.SetValue(combined, combinedValue);
                }
            }

            return combined;
        }

        public static bool IsDefault<T>(this T value)
        {
            return value == null || value.Equals(default(T));
        }
    }
}
