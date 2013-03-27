using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using NCldr.Types;

namespace NCldr.Builder
{
    public partial class NCldrBuilder
    {
        private static CurrencyFraction[] GetCurrencyFractions()
        {
            if (options != null && !options.IncludeCurrencyFractions)
            {
                return null;
            }

            List<XElement> infoElements = (from i in supplementalDataDocument.Elements("supplementalData")
                                               .Elements("currencyData").Elements("fractions").Elements("info")
                                           select i).ToList();
            if (infoElements.Count == 0)
            {
                return null;
            }

            List<CurrencyFraction> currencyFractions = new List<CurrencyFraction>();
            foreach (XElement infoElement in infoElements)
            {
                string currencyId = infoElement.Attribute("iso4217").Value.ToString();
                Progress("Adding currency fraction", currencyId);

                CurrencyFraction currencyFraction = new CurrencyFraction();
                currencyFraction.Id = currencyId;
                currencyFraction.Digits = int.Parse(infoElement.Attribute("digits").Value.ToString());
                currencyFraction.Rounding = int.Parse(infoElement.Attribute("rounding").Value.ToString());

                XAttribute cashRoundingAttribute = infoElement.Attribute("cashRounding");
                if (cashRoundingAttribute != null)
                {
                    currencyFraction.CashRounding = int.Parse(cashRoundingAttribute.Value.ToString());
                }

                currencyFractions.Add(currencyFraction);
                Progress("Added currency fraction", currencyId, ProgressEventType.Added, currencyFraction);
            }

            return currencyFractions.ToArray();
        }
    }
}
