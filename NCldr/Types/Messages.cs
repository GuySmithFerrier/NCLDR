namespace NCldr.Types
{
    using System;
    using System.Collections;
    using System.Runtime.Serialization;

    /// <summary>
    /// Messages is a list of localized messages
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#POSIX_Elements </remarks>
    [Serializable]
    public class Messages : Hashtable, ICloneable
    {
        /// <summary>
        /// Initializes a new instance of the Messages class
        /// </summary>
        public Messages()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Messages class
        /// </summary>
        /// <param name="info">A SerializationInfo object</param>
        /// <param name="context">A StreamingContext object</param>
        public Messages(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Gets the localized 'wide' form of Yes
        /// </summary>
        public string Yes
        {
            get
            {
                if (!this.ContainsKey("yesstr"))
                {
                    return null;
                }

                string yesstr = this["yesstr"].ToString();
                if (string.IsNullOrEmpty(yesstr))
                {
                    return null;
                }

                // yesstr is in the form "yes:y"
                return yesstr.Split(':')[0];
            }
        }

        /// <summary>
        /// Gets the localized 'short' form of Yes
        /// </summary>
        public string YesShort
        {
            get
            {
                if (!this.ContainsKey("yesstr"))
                {
                    return null;
                }

                string yesstr = this["yesstr"].ToString();
                if (string.IsNullOrEmpty(yesstr))
                {
                    return null;
                }

                // yesstr is in the form "yes:y"
                string[] yesBits = yesstr.Split(':');
                if (yesBits.GetLength(0) < 2)
                {
                    return null;
                }

                return yesBits[1];
            }
        }

        /// <summary>
        /// Gets the localized 'wide' form of No
        /// </summary>
        public string No
        {
            get
            {
                if (!this.ContainsKey("nostr"))
                {
                    return null;
                }

                string nostr = this["nostr"].ToString();
                if (string.IsNullOrEmpty(nostr))
                {
                    return null;
                }

                // nostr is in the form "no:n"
                return nostr.Split(':')[0];
            }
        }

        /// <summary>
        /// Gets the localized 'short' form of No
        /// </summary>
        public string NoShort
        {
            get
            {
                if (!this.ContainsKey("nostr"))
                {
                    return null;
                }

                string nostr = this["nostr"].ToString();
                if (string.IsNullOrEmpty(nostr))
                {
                    return null;
                }

                // nostr is in the form "no:n"
                string[] noBits = nostr.Split(':');
                if (noBits.GetLength(0) < 2)
                {
                    return null;
                }

                return noBits[1];
            }
        }

        /// <summary>
        /// Clone clones the object
        /// </summary>
        /// <returns>A cloned copy of the object</returns>
        public new object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
