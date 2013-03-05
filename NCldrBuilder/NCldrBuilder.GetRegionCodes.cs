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
        private static RegionCode[] GetRegionCodes()
        {
            if (options != null && !options.IncludeRegionCodes)
            {
                return null;
            }

            List<XElement> regionCodeElements = (from i in supplementalDataDocument.Elements("supplementalData")
                                                   .Elements("codeMappings").Elements("territoryCodes")
                                                 select i).ToList();
            if (regionCodeElements == null || regionCodeElements.Count == 0)
            {
                return null;
            }

            List<RegionCode> regionCodes = new List<RegionCode>();
            foreach (XElement regionCodeElement in regionCodeElements)
            {
                string regionId = regionCodeElement.Attribute("type").Value.ToString();

                Progress("Adding region code", regionId);

                RegionCode regionCode = new RegionCode();
                regionCode.RegionId = regionId;

                if (regionCodeElement.Attribute("numeric") != null)
                {
                    regionCode.Numeric = regionCodeElement.Attribute("numeric").Value.ToString();
                }

                if (regionCodeElement.Attribute("alpha3") != null)
                {
                    regionCode.Alpha3 = regionCodeElement.Attribute("alpha3").Value.ToString();
                }

                if (regionCodeElement.Attribute("fips10") != null)
                {
                    regionCode.Fips10 = regionCodeElement.Attribute("fips10").Value.ToString();
                }

                regionCodes.Add(regionCode);
                Progress("Added region code", regionId, ProgressEventType.Added, regionCode);
            }

            return regionCodes.ToArray();
        }
    }
}
