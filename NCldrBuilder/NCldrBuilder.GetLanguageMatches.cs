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
        private static LanguageMatch[] GetLanguageMatches()
        {
            if (options != null && !options.IncludeLanguageMatches)
            {
                return null;
            }

            XDocument document = GetXmlDocument(@"Core\common\supplemental\languageInfo.xml");

            List<XElement> languageMatchElements = (from i in document.Elements("supplementalData")
                                                    .Elements("languageMatching").Elements("languageMatches").Elements("languageMatch")
                                                    select i).ToList();
            if (languageMatchElements == null)
            {
                return null;
            }

            List<LanguageMatch> languageMatches = new List<LanguageMatch>();
            foreach (XElement languageMatchElement in languageMatchElements)
            {
                string desired = languageMatchElement.Attribute("desired").Value.ToString();

                Progress("Adding language match", desired);

                XAttribute onewayAttribute = languageMatchElement.Attribute("oneway");

                LanguageMatch languageMatch = new LanguageMatch();
                languageMatch.Desired = desired;
                languageMatch.Supported = languageMatchElement.Attribute("supported").Value.ToString();
                languageMatch.Percent = int.Parse(languageMatchElement.Attribute("percent").Value.ToString());
                languageMatch.IsOneWay = onewayAttribute != null && onewayAttribute.Value.ToString() == "true";
                languageMatches.Add(languageMatch);
            }

            return languageMatches.ToArray();
        }
    }
}
