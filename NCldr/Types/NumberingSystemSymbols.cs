namespace NCldr.Types
{
    using System;

    /// <summary>
    /// NumberingSystemSymbols is a collection of symbols used by a NumberingSystem
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Number_Symbols </remarks>
    [Serializable]
    public class NumberingSystemSymbols
    {
        /// <summary>
        /// Gets or sets the symbol used to separate decimals
        /// </summary>
        public string Decimal { get; set; }

        /// <summary>
        /// Gets or sets the symbol used to separate groups
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// Gets or sets the symbol used in lists
        /// </summary>
        public string List { get; set; }

        /// <summary>
        /// Gets or sets the symbol used for percentages
        /// </summary>
        public string PercentSign { get; set; }

        /// <summary>
        /// Gets or sets the symbol used to indicate a positive value
        /// </summary>
        public string PlusSign { get; set; }

        /// <summary>
        /// Gets or sets the symbol used to indicate a negative value
        /// </summary>
        public string MinusSign { get; set; }

        /// <summary>
        /// Gets or sets the symbol used for exponential values
        /// </summary>
        public string Exponential { get; set; }

        /// <summary>
        /// Gets or sets the symbol used for superscripting exponent values
        /// </summary>
        public string SuperScriptingExponent { get; set; }

        /// <summary>
        /// Gets or sets the symbol used for PerMille
        /// </summary>
        public string PerMille { get; set; }

        /// <summary>
        /// Gets or sets the symbol used for infinity
        /// </summary>
        public string Infinity { get; set; }

        /// <summary>
        /// Gets or sets the symbol used for Not A Number
        /// </summary>
        public string Nan { get; set; }
    }
}
