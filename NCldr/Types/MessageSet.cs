namespace NCldr.Types
{
    using System;
    using System.Collections;
    using System.Globalization;
    using System.Linq;
    using System.Runtime.Serialization;

    /// <summary>
    /// Messages is a list of localized messages
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#POSIX_Elements </remarks>
    [Serializable]
    public class MessageSet : ICloneable
    {
        /// <summary>
        /// Initializes a new instance of the Messages class
        /// </summary>
        public MessageSet()
            : base()
        {
        }

        /// <summary>
        /// Gets or sets an array of Message objects in the set
        /// </summary>
        public Message[] Messages { get; set; }

        /// <summary>
        /// Gets the localized 'wide' form of Yes
        /// </summary>
        public string Yes
        {
            get
            {
                if (this.Messages == null)
                {
                    return null;
                }

                Message message = (from m in this.Messages
                                   where String.Compare(m.Id, "yesstr", true, CultureInfo.InvariantCulture) == 0
                                   select m).FirstOrDefault();

                if (message == null)
                {
                    return null;
                }

                string yesstr = message.Text;
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
                if (this.Messages == null)
                {
                    return null;
                }

                Message message = (from m in this.Messages
                                   where String.Compare(m.Id, "yesstr", true, CultureInfo.InvariantCulture) == 0
                                   select m).FirstOrDefault();

                if (message == null)
                {
                    return null;
                }

                string yesstr = message.Text;
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
                if (this.Messages == null)
                {
                    return null;
                }

                Message message = (from m in this.Messages
                                   where String.Compare(m.Id, "nostr", true, CultureInfo.InvariantCulture) == 0
                                   select m).FirstOrDefault();

                if (message == null)
                {
                    return null;
                }

                string nostr = message.Text;
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
                if (this.Messages == null)
                {
                    return null;
                }

                Message message = (from m in this.Messages
                                   where String.Compare(m.Id, "nostr", true, CultureInfo.InvariantCulture) == 0
                                   select m).FirstOrDefault();

                if (message == null)
                {
                    return null;
                }

                string nostr = message.Text;
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
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
