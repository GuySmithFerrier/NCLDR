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
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#POSIX_Elements </remarks>
    [Serializable]
    public class MessageSet : ICloneable
    {
        /// <summary>
        /// Initializes a new instance of the MessageSet class
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
                                   where string.Compare(m.Id, "yesstr", StringComparison.InvariantCultureIgnoreCase) == 0
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
                                   where string.Compare(m.Id, "yesstr", StringComparison.InvariantCultureIgnoreCase) == 0
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
                                   where string.Compare(m.Id, "nostr", StringComparison.InvariantCultureIgnoreCase) == 0
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
                                   where string.Compare(m.Id, "nostr", StringComparison.InvariantCultureIgnoreCase) == 0
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
        /// Combine combines a child with a parent as necessary and returns the combined object
        /// </summary>
        /// <param name="combinedMessages">The child object</param>
        /// <param name="parentMessages">The parent object</param>
        /// <returns>The combined object</returns>
        public static MessageSet Combine(MessageSet combinedMessages, MessageSet parentMessages)
        {
            if (combinedMessages == null && parentMessages == null)
            {
                return null;
            }
            else if (combinedMessages == null)
            {
                return (MessageSet)parentMessages.Clone();
            }
            else if (parentMessages == null)
            {
                return combinedMessages;
            }

            List<Message> combinedMessagesList = new List<Message>(combinedMessages.Messages);

            foreach (Message parentMessage in parentMessages.Messages)
            {
                if (!(from m in combinedMessages.Messages
                      where m.Id == parentMessage.Id
                      select m).Any())
                {
                    combinedMessagesList.Add(parentMessage);
                }
            }

            combinedMessages.Messages = combinedMessagesList.ToArray();

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
