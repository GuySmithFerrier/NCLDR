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
        private static PostcodeRegex[] GetPostcodeRegexes()
        {
            if (options != null && !options.IncludePostcodeRegexes)
            {
                return null;
            }

            XDocument document = GetXmlDocument(@"Core\common\supplemental\postalcodedata.xml");

            IEnumerable<XElement> supplementalElements = document.Elements("supplementalData");
            List<XElement> postalCodeDatas = (from item in supplementalElements.Elements("postalCodeData")
                                                .Elements("postCodeRegex")
                                              orderby item.Attribute("territoryId").Value
                                              select item).ToList();
            if (postalCodeDatas != null && postalCodeDatas.Count > 0)
            {
                List<PostcodeRegex> postcodeRegexes = new List<PostcodeRegex>();
                foreach (XElement data in postalCodeDatas)
                {
                    string region = data.Attribute("territoryId").Value.ToString();
                    Progress("Adding postal code", region);

                    PostcodeRegex postcodeRegex = new PostcodeRegex();
                    postcodeRegex.RegionId = region;
                    postcodeRegex.Regex = data.Value;

                    postcodeRegexes.Add(postcodeRegex);
                    Progress("Added postal code", region, ProgressEventType.Added, postcodeRegex);
                }

                return postcodeRegexes.ToArray();
            }

            return null;
        }
    }
}
