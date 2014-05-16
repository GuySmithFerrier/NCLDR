namespace NCldr.Types
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Runtime.Serialization;

    /// <summary>
    /// Messages is a list of localized messages
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/tr35-35/tr35-numbers.html#Miscellaneous_Patterns </remarks>
    [Serializable]
    public class MiscellaneousPatternSet : ICloneable
    {
        /// <summary>
        /// Initializes a new instance of the MiscellaneousPatternSet class
        /// </summary>
        public MiscellaneousPatternSet()
            : base()
        {
        }

        /// <summary>
        /// Gets or sets the number system id of the pattern set
        /// </summary>
        /// <example>latn</example>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets an array of MiscellaneousPattern objects in the set
        /// </summary>
        public MiscellaneousPattern[] MiscellaneousPatterns { get; set; }

        /// <summary>
        /// Combine combines a child with a parent as necessary and returns the combined object
        /// </summary>
        /// <param name="combinedMessages">The child object</param>
        /// <param name="parentMessages">The parent object</param>
        /// <returns>The combined object</returns>
        public static MiscellaneousPatternSet Combine(MiscellaneousPatternSet combinedMessages, MiscellaneousPatternSet parentMessages)
        {
            if (combinedMessages == null && parentMessages == null)
            {
                return null;
            }
            else if (combinedMessages == null)
            {
                return (MiscellaneousPatternSet)parentMessages.Clone();
            }
            else if (parentMessages == null)
            {
                return combinedMessages;
            }

            if (parentMessages.MiscellaneousPatterns != null)
            {
                List<MiscellaneousPattern> combinedMessagesList = new List<MiscellaneousPattern>(combinedMessages.MiscellaneousPatterns);

                foreach (MiscellaneousPattern parentMessage in parentMessages.MiscellaneousPatterns)
                {
                    if (!(from m in combinedMessages.MiscellaneousPatterns
                          where m.Id == parentMessage.Id
                          select m).Any())
                    {
                        combinedMessagesList.Add(parentMessage);
                    }
                }

                combinedMessages.MiscellaneousPatterns = combinedMessagesList.ToArray();
            }

            return combinedMessages;
        }

        /// <summary>
        /// Clone clones the object
        /// </summary>
        /// <returns>A cloned copy of the object</returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
