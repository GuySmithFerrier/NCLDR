namespace NCldr.Types
{
    using System;
    using System.Text;

    /// <summary>
    /// Identity is the identity of a culture
    /// </summary>
    [Serializable]
    public class Identity
    {
        /// <summary>
        /// Gets or sets the culture's language
        /// </summary>
        public Language Language { get; set; }

        /// <summary>
        /// Gets or sets the culture's script
        /// </summary>
        public Script Script { get; set; }

        /// <summary>
        /// Gets or sets the culture's region
        /// </summary>
        public Region Region { get; set; }

        /// <summary>
        /// Gets or sets the culture's variant (e.g. POSIX)
        /// </summary>
        public Variant Variant { get; set; }

        /// <summary>
        /// Gets the culture's name (in .NET format)
        /// </summary>
        public string CultureName
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(this.Language.Id);

                if (this.Script != null)
                {
                    builder.Append(string.Format("-{0}", this.Script.Id));
                }

                if (this.Region != null)
                {
                    builder.Append(string.Format("-{0}", this.Region.Id));
                }

                if (this.Variant != null)
                {
                    builder.Append(string.Format("-{0}", this.Variant.Id));
                }

                return builder.ToString();
            }
        }

        /// <summary>
        /// Gets the culture's English name
        /// </summary>
        public string EnglishName
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(this.Language.EnglishName);

                if (this.Script != null)
                {
                    if (this.Region != null)
                    {
                        builder.Append(string.Format(" ({0}, {1})", this.Script.EnglishName, this.Region.EnglishName));
                    }
                    else
                    {
                        builder.Append(string.Format(" ({0})", this.Script.EnglishName));
                    }
                }
                else if (this.Region != null)
                {
                    builder.Append(string.Format(" ({0})", this.Region.EnglishName));
                }

                if (this.Variant != null)
                {
                    builder.Append(string.Format(" ({0})", this.Variant.Id));
                }

                return builder.ToString();
            }
        }

        /// <summary>
        /// Gets the culture's display name in the given language
        /// </summary>
        /// <param name="languageId">The language to get the display name in</param>
        /// <returns>The culture's display name in the given language</returns>
        public string DisplayName(string languageId)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.Language.DisplayName(languageId));

            if (this.Script != null)
            {
                if (this.Region != null)
                {
                    builder.Append(string.Format(" ({0}, {1})", this.Script.DisplayName(languageId), this.Region.DisplayName(languageId)));
                }
                else
                {
                    builder.Append(string.Format(" ({0})", this.Script.DisplayName(languageId)));
                }
            }
            else if (this.Region != null)
            {
                builder.Append(string.Format(" ({0})", this.Region.DisplayName(languageId)));
            }

            if (this.Variant != null)
            {
                builder.Append(string.Format(" ({0})", this.Variant.Id));
            }

            return builder.ToString();
        }
    }
}
