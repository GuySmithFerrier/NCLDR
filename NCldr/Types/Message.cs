namespace NCldr.Types
{
    using System;

    /// <summary>
    /// Message is a localized message
    /// </summary>
    [Serializable]
    public class Message
    {
        /// <summary>
        /// Gets or sets the identifier for the message
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the message's localized text
        /// </summary>
        public string Text { get; set; }
    }
}
