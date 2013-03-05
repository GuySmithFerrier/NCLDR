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
        private static RegionTelephoneCode[] GetRegionTelephoneCodes()
        {
            if (options != null && !options.IncludeRegionTelephoneCodes)
            {
                return null;
            }

            XDocument document = GetXmlDocument(@"Core\common\supplemental\telephoneCodeData.xml");

            List<XElement> regionTelephoneCodeElements = (from i in document.Elements("supplementalData")
                                                            .Elements("telephoneCodeData").Elements("codesByTerritory")
                                                          select i).ToList();
            if (regionTelephoneCodeElements == null || regionTelephoneCodeElements.Count == 0)
            {
                return null;
            }

            List<RegionTelephoneCode> regionTelephoneCodes = new List<RegionTelephoneCode>();
            foreach (XElement regionTelephoneCodeElement in regionTelephoneCodeElements)
            {
                string regionId = regionTelephoneCodeElement.Attribute("territory").Value.ToString();

                Progress("Adding region telephone code", regionId);

                RegionTelephoneCode regionTelephoneCode = new RegionTelephoneCode();
                regionTelephoneCode.RegionId = regionId;

                List<string> telephoneCountryCodes = new List<string>();
                foreach (XElement telephoneCountryCodeData in regionTelephoneCodeElement.Elements("telephoneCountryCode"))
                {
                    if (telephoneCountryCodeData.Attribute("to") == null)
                    {
                        telephoneCountryCodes.Add(telephoneCountryCodeData.Attribute("code").Value.ToString());
                    }
                }

                regionTelephoneCode.TelephoneCodes = telephoneCountryCodes.ToArray();

                regionTelephoneCodes.Add(regionTelephoneCode);
                Progress("Added region telephone code", regionId, ProgressEventType.Added, regionTelephoneCode);
            }

            return regionTelephoneCodes.ToArray();
        }
    }
}
