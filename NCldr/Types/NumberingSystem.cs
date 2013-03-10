namespace NCldr.Types
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// NumberingSystem is a numbering system used by a culture
    /// </summary>
    /// <remarks>CLDR reference: http://www.unicode.org/reports/tr35/#Number_Elements </remarks>
    [Serializable]
    public class NumberingSystem
    {
        /// <summary>
        /// Gets the string used in CLDR format patterns to identify the currency symbol
        /// </summary>
        public const string CldrCurrencyIdentifier = "¤";

        /// <summary>
        /// Gets the string used in CLDR format patterns to identify the minus sign
        /// </summary>
        public const string CldrMinusIdentifier = "-";

        /// <summary>
        /// Gets the string used in CLDR format patterns to identify the percent sign
        /// </summary>
        public const string CldrPercentIdentifier = "%";

        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the symbols used in the numbering system
        /// </summary>
        public NumberingSystemSymbols Symbols { get; set; }

        /// <summary>
        /// Gets or sets the CLDR currency format pattern
        /// </summary>
        public string CurrencyFormatPattern { get; set; }

        /// <summary>
        /// Gets or sets the currency spacings
        /// </summary>
        public CurrencySpacings CurrencySpacings { get; set; }

        /// <summary>
        /// Gets or sets the CLDR decimal format pattern
        /// </summary>
        public string DecimalFormatPattern { get; set; }

        /// <summary>
        /// Gets or sets the set of decimal format patterns
        /// </summary>
        public DecimalFormatPatternSet[] DecimalFormatPatternSets { get; set; }

        /// <summary>
        /// Gets or sets the CLDR percent format pattern
        /// </summary>
        public string PercentFormatPattern { get; set; }

        /// <summary>
        /// Gets or sets the CLDR scientific format pattern
        /// </summary>
        public string ScientificFormatPattern { get; set; }

        /// <summary>
        /// Gets the .NET group sizes used by numbers (known as decimals in CLDR)
        /// </summary>
        public int[] NumberGroupSizes
        {
            get
            {
                return GetGroupSizes(this.NumberFormatPositivePattern);
            }
        }

        /// <summary>
        /// Gets the CLDR format pattern used for positive numbers
        /// </summary>
        public string NumberFormatPositivePattern
        {
            get
            {
                if (string.IsNullOrEmpty(this.DecimalFormatPattern))
                {
                    return null;
                }

                return this.DecimalFormatPattern.Split(';')[0];
            }
        }

        /// <summary>
        /// Gets the CLDR format pattern used for negative numbers
        /// </summary>
        public string NumberFormatNegativePattern
        {
            get
            {
                if (string.IsNullOrEmpty(this.DecimalFormatPattern))
                {
                    return null;
                }

                string[] formatPatterns = this.DecimalFormatPattern.Split(';');
                if (formatPatterns.GetLength(0) > 1)
                {
                    return formatPatterns[1];
                }

                // when there is no explicit negative pattern the negative pattern is the same as the positive pattern
                return formatPatterns[0];
            }
        }

        /// <summary>
        /// GetDecimalDigits gets the number of digits that should be used to display decimals given the format pattern
        /// </summary>
        /// <param name="pattern">The pattern to get the number of digits from</param>
        /// <returns>The number of digits that should be used to display decimals given the format pattern</returns>
        private int GetDecimalDigits(string pattern)
        {
            if (string.IsNullOrEmpty(pattern))
            {
                return 0;
            }

            int decimalPointIndex = pattern.IndexOf(".");
            if (decimalPointIndex == -1)
            {
                return 0;
            }

            string decimalPlaces = pattern.Substring(decimalPointIndex + 1);
            if (decimalPlaces.Length > 0 && decimalPlaces.Replace("#", string.Empty).Length == 0)
            {
                // The decimal places string is wholly made up of # characters. So it is something like "###".
                // CLDR interprets "#" to mean display a number if a value is present but display nothing if no value is present.
                // So 123.456 using a pattern of "###.###" is "123.456" but with a pattern of "###.####" is still "123.456"
                // (notice that the four decimal "#"s only return 3 decimal places).
                // The problem here is that .NET does not have an 'optional' number of decimal places - only has a fixed
                // number of decimal places. The CLDR patterns typically allow additional room for growth using the "#" symbol
                // but this doesn't translate to a fixed number of decimal places. So "###.###" does not mean 
                // "display 3 decimal places" - it means "display anything up to 3 decimal places".
                // So this next line removes a single decimal place as a very rough way of adjusting for this difference.
                return decimalPlaces.Length - 1;
            }

            return decimalPlaces.Length;
        }

        /// <summary>
        /// Gets the number of decimal digits for the positive number pattern
        /// </summary>
        public int NumberDecimalDigits
        {
            get
            {
                return this.GetDecimalDigits(this.NumberFormatPositivePattern);
            }
        }

        /// <summary>
        /// Gets a value indicating whether the number pattern has an explicit negative pattern (or if it is simply inferred from the positive pattern)
        /// </summary>
        private bool NumberHasNegativePattern
        {
            get
            {
                string numberFormatPattern = this.DecimalFormatPattern;
                if (string.IsNullOrEmpty(numberFormatPattern))
                {
                    return false;
                }

                return numberFormatPattern.Split(';').GetLength(0) >= 1;
            }
        }

        /// <summary>
        /// Gets the .NET pattern used for negative numbers
        /// </summary>
        public int NumberNegativePattern
        {
            get
            {
                if (!this.NumberHasNegativePattern)
                {
                    // the default is "(n)"
                    return 0;
                }

                string numberFormatNegativePattern = this.NumberFormatNegativePattern;

                if (string.IsNullOrEmpty(numberFormatNegativePattern))
                {
                    // the default is "(n)"
                    return 0;
                }

                if (numberFormatNegativePattern.StartsWith("(") &&
                    numberFormatNegativePattern.EndsWith(")"))
                {
                    // "(n)"
                    return 0;
                }
                else if (numberFormatNegativePattern.StartsWith(CldrMinusIdentifier + " "))
                {
                    // "- n"
                    return 2;
                }
                else if (numberFormatNegativePattern.StartsWith(CldrMinusIdentifier))
                {
                    // "-n"
                    return 1;
                }
                else if (numberFormatNegativePattern.EndsWith(" " + CldrMinusIdentifier))
                {
                    // "n -"
                    return 3;
                }

                // the default is "(n)"
                return 0;
            }
        }

        /// <summary>
        /// Gets the .NET group sizes used by percentages
        /// </summary>
        public int[] PercentGroupSizes
        {
            get
            {
                return GetGroupSizes(this.PercentFormatPositivePattern);
            }
        }

        /// <summary>
        /// Gets the number of decimal digits for the positive percentage pattern
        /// </summary>
        public int PercentDecimalDigits
        {
            get
            {
                return this.GetDecimalDigits(this.PercentFormatPositivePattern);
            }
        }

        /// <summary>
        /// Gets the CLDR format pattern used for positive percentages
        /// </summary>
        public string PercentFormatPositivePattern
        {
            get
            {
                if (string.IsNullOrEmpty(this.PercentFormatPattern))
                {
                    return null;
                }

                return this.PercentFormatPattern.Split(';')[0];
            }
        }

        /// <summary>
        /// Gets the CLDR format pattern used for negative percentages
        /// </summary>
        public string PercentFormatNegativePattern
        {
            get
            {
                if (string.IsNullOrEmpty(this.PercentFormatPattern))
                {
                    return null;
                }

                string[] formatPatterns = this.PercentFormatPattern.Split(';');
                if (formatPatterns.GetLength(0) > 1)
                {
                    return formatPatterns[1];
                }

                // when there is no explicit negative pattern the negative pattern is the same as the positive pattern
                return formatPatterns[0];
            }
        }

        /// <summary>
        /// Gets the .NET pattern used for positive percentages
        /// </summary>
        public int PercentPositivePattern
        {
            get
            {
                string percentFormatPositivePattern = this.PercentFormatPositivePattern;

                if (string.IsNullOrEmpty(percentFormatPositivePattern))
                {
                    // the default is "n %"
                    return 0;
                }

                if (percentFormatPositivePattern.EndsWith(" " + CldrPercentIdentifier))
                {
                    // "n %"
                    return 0;
                }
                else if (percentFormatPositivePattern.EndsWith(CldrPercentIdentifier))
                {
                    // "n%"
                    return 1;
                }
                else if (percentFormatPositivePattern.StartsWith(CldrPercentIdentifier))
                {
                    // "%n"
                    return 2;
                }

                // the default is "n %"
                return 0;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the percentage pattern has an explicit negative pattern (or if it is simply inferred from the positive pattern)
        /// </summary>
        private bool PercentHasNegativePattern
        {
            get
            {
                string percentFormatPattern = this.PercentFormatPattern;
                if (string.IsNullOrEmpty(percentFormatPattern))
                {
                    return false;
                }

                return percentFormatPattern.Split(';').GetLength(0) >= 1;
            }
        }

        /// <summary>
        /// Gets the .NET pattern used for negative percentages
        /// </summary>
        public int PercentNegativePattern
        {
            get
            {
                if (!this.PercentHasNegativePattern)
                {
                    return this.PercentPositivePattern;
                }

                string percentFormatNegativePattern = this.PercentFormatNegativePattern;

                if (string.IsNullOrEmpty(percentFormatNegativePattern))
                {
                    // the default is "-n %"
                    return 0;
                }

                if (percentFormatNegativePattern.StartsWith(CldrMinusIdentifier) &&
                    percentFormatNegativePattern.EndsWith(" " + CldrPercentIdentifier))
                {
                    // "-n %"
                    return 0;
                }
                else if (percentFormatNegativePattern.StartsWith(CldrMinusIdentifier) &&
                    percentFormatNegativePattern.EndsWith(CldrPercentIdentifier))
                {
                    // "-n%"
                    return 1;
                }
                else if (percentFormatNegativePattern.StartsWith(CldrMinusIdentifier + CldrPercentIdentifier))
                {
                    // "-%n"
                    return 2;
                }

                // the default is "-n %"
                return 0;
            }
        }

        /// <summary>
        /// Gets the .NET group sizes used by currencies
        /// </summary>
        public int[] CurrencyGroupSizes
        {
            get
            {
                return GetGroupSizes(this.CurrencyFormatPositivePattern);
            }
        }

        /// <summary>
        /// Gets the CLDR format pattern used for positive currencies
        /// </summary>
        public string CurrencyFormatPositivePattern
        {
            get
            {
                if (string.IsNullOrEmpty(this.CurrencyFormatPattern))
                {
                    return null;
                }

                // A currency pattern may contain both positive and optional negative patterns separated by a semi colon.
                // So in the "#,##0.00;(#,##0.00)" pattern "#,##0.00" is the positive pattern and "(#,##0.00)" is the negative
                // pattern.
                return this.CurrencyFormatPattern.Split(';')[0];
            }
        }

        /// <summary>
        /// Gets the CLDR format pattern used for negative currencies
        /// </summary>
        public string CurrencyFormatNegativePattern
        {
            get
            {
                if (string.IsNullOrEmpty(this.CurrencyFormatPattern))
                {
                    return null;
                }

                string[] formatPatterns = this.CurrencyFormatPattern.Split(';');
                if (formatPatterns.GetLength(0) > 1)
                {
                    return formatPatterns[1];
                }

                // when there is no explicit negative pattern the negative pattern is the same as the positive pattern
                return formatPatterns[0];
            }
        }

        /// <summary>
        /// Gets the .NET pattern used for positive currencies
        /// </summary>
        public int CurrencyPositivePattern
        {
            get
            {
                string currencyFormatPositivePattern = this.CurrencyFormatPositivePattern;

                if (string.IsNullOrEmpty(currencyFormatPositivePattern))
                {
                    // the default is "$n"
                    return 0;
                }

                if (currencyFormatPositivePattern.StartsWith(CldrCurrencyIdentifier + " "))
                {
                    // "$ n"
                    return 2;
                }
                else if (currencyFormatPositivePattern.EndsWith(" " + CldrCurrencyIdentifier))
                {
                    // "n $"
                    return 3;
                }
                else if (currencyFormatPositivePattern.StartsWith(CldrCurrencyIdentifier))
                {
                    // "$n"
                    return 0;
                }
                else if (currencyFormatPositivePattern.EndsWith(CldrCurrencyIdentifier))
                {
                    // "n$"
                    return 1;
                }

                // the default is "$n"
                return 0;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the currency pattern has an explicit negative pattern (or if it is simply inferred from the positive pattern)
        /// </summary>
        private bool CurrencyHasNegativePattern
        {
            get
            {
                string currencyFormatPattern = this.CurrencyFormatPattern;
                if (string.IsNullOrEmpty(currencyFormatPattern))
                {
                    return false;
                }

                return currencyFormatPattern.Split(';').GetLength(0) >= 1;
            }
        }

        /// <summary>
        /// Gets the .NET pattern used for negative currencies
        /// </summary>
        public int CurrencyNegativePattern
        {
            get
            {
                if (!this.CurrencyHasNegativePattern)
                {
                    return this.CurrencyPositivePattern;
                }

                string currencyFormatNegativePattern = this.CurrencyFormatNegativePattern;

                if (string.IsNullOrEmpty(currencyFormatNegativePattern))
                {
                    // the default is "($n)"
                    return 0;
                }

                if (currencyFormatNegativePattern.StartsWith("(" + CldrCurrencyIdentifier) && 
                    currencyFormatNegativePattern.EndsWith(")"))
                {
                    // "($n)"
                    return 0;
                }
                else if (currencyFormatNegativePattern.StartsWith(CldrMinusIdentifier + CldrCurrencyIdentifier))
                {
                    // "-$n"
                    return 1;
                }
                else if (currencyFormatNegativePattern.StartsWith(CldrCurrencyIdentifier + CldrMinusIdentifier))
                {
                    // "$-n"
                    return 2;
                }
                else if (currencyFormatNegativePattern.StartsWith(CldrCurrencyIdentifier) &&
                    currencyFormatNegativePattern.EndsWith(CldrMinusIdentifier))
                {
                    // "$n-"
                    return 3;
                }
                else if (currencyFormatNegativePattern.StartsWith("(") &&
                    currencyFormatNegativePattern.EndsWith(CldrCurrencyIdentifier + ")"))
                {
                    // "(n$)"
                    return 4;
                }
                else if (currencyFormatNegativePattern.StartsWith(CldrMinusIdentifier) &&
                    currencyFormatNegativePattern.EndsWith(CldrCurrencyIdentifier))
                {
                    // "-n$"
                    return 5;
                }
                else if (currencyFormatNegativePattern.EndsWith(CldrMinusIdentifier + CldrCurrencyIdentifier))
                {
                    // "n-$"
                    return 6;
                }
                else if (currencyFormatNegativePattern.EndsWith(CldrCurrencyIdentifier + CldrMinusIdentifier))
                {
                    // "n$-"
                    return 7;
                }
                else if (currencyFormatNegativePattern.StartsWith(CldrMinusIdentifier) &&
                    currencyFormatNegativePattern.EndsWith(" " + CldrCurrencyIdentifier))
                {
                    // "-n $"
                    return 8;
                }
                else if (currencyFormatNegativePattern.StartsWith(CldrMinusIdentifier + CldrCurrencyIdentifier + " "))
                {
                    // "-$ n"
                    return 9;
                }
                else if (currencyFormatNegativePattern.EndsWith(" " + CldrCurrencyIdentifier + CldrMinusIdentifier))
                {
                    // "n $-"
                    return 10;
                }
                else if (currencyFormatNegativePattern.StartsWith(CldrCurrencyIdentifier + " ") &&
                    currencyFormatNegativePattern.EndsWith(CldrMinusIdentifier))
                {
                    // "$ n-"
                    return 11;
                }
                else if (currencyFormatNegativePattern.StartsWith(CldrCurrencyIdentifier + " " + CldrMinusIdentifier))
                {
                    // "$ -n"
                    return 12;
                }
                else if (currencyFormatNegativePattern.EndsWith(CldrMinusIdentifier + " " + CldrCurrencyIdentifier))
                {
                    // "n- $"
                    return 13;
                }
                else if (currencyFormatNegativePattern.StartsWith("(" + CldrCurrencyIdentifier + " ") &&
                    currencyFormatNegativePattern.EndsWith(")"))
                {
                    // "($ n)"
                    return 14;
                }
                else if (currencyFormatNegativePattern.StartsWith("(") &&
                    currencyFormatNegativePattern.EndsWith(" " + CldrCurrencyIdentifier + ")"))
                {
                    // "(n $)"
                    return 15;
                }

                // the default is "($n)"
                return 0;
            }
        }

        /// <summary>
        /// Gets the NumberingSystemType
        /// </summary>
        public NumberingSystemType NumberingSystemType
        {
            get
            {
                if (NCldr.NumberingSystems == null)
                {
                    return null;
                }

                return (from nst in NCldr.NumberingSystems
                        where string.Compare(nst.Id, this.Id, StringComparison.InvariantCulture) == 0
                        select nst).FirstOrDefault();
            }
        }

        /// <summary>
        /// Gets the .NET group sizes used by the given pattern
        /// </summary>
        /// <param name="pattern">The pattern to get the group sizes from</param>
        /// <returns>The .NET group sizes used by the given pattern</returns>
        public static int[] GetGroupSizes(string pattern)
        {
            if (pattern == null)
            {
                return null;
            }

            // strip away the currency symbol, percent symbol, minus sign, parentheses, spaces
            pattern = pattern.Replace(CldrCurrencyIdentifier, string.Empty);
            pattern = pattern.Replace(CldrPercentIdentifier, string.Empty);
            pattern = pattern.Replace(CldrMinusIdentifier, string.Empty);
            pattern = pattern.Replace("(", string.Empty);
            pattern = pattern.Replace(")", string.Empty);
            pattern = pattern.Replace(" ", string.Empty);

            int decimalPointIndex = pattern.IndexOf(".");
            if (decimalPointIndex > -1)
            {
                // remove the decimals
                pattern = pattern.Substring(0, decimalPointIndex);
            }

            // the remaining pattern is something like "##,###,####" (for which the group sizes appear to be { 4, 3, 2 }
            // but are actually { 4, 3 } because the leading group size is ignored by CLDR)
            string[] bits = pattern.Split(',');
            if (bits.GetLength(0) == 1)
            {
                // there are no groups
                return new int[] { 0 };
            }

            List<int> groupSizes = new List<int>();
            
            // remember: the leading group size is ignored
            for (int groupIndex = bits.GetLength(0); groupIndex > 1; groupIndex--)
            {
                string bit = bits[groupIndex - 1];
                groupSizes.Add(bit.Length);
            }

            return groupSizes.ToArray();
        }
    }
}
