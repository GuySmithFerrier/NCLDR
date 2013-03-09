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
        private static PluralRuleSet[] GetPluralRuleSets(bool ordinals = false)
        {
            if (options != null && ((ordinals && !options.IncludeOrdinalRuleSets) ||
                (!ordinals && !options.IncludePluralRuleSets)))
            {
                return null;
            }

            string filename = ordinals ? "ordinals" : "plurals";
            string ruleSetType = ordinals ? "ordinal" : "plural";

            XDocument document = GetXmlDocument(String.Format(@"common\supplemental\{0}.xml", filename));

            IEnumerable<XElement> ldmlElements = document.Elements("supplementalData");
            List<XElement> pluralRuleSetDatas = (from item in ldmlElements.Elements("plurals")
                                                .Elements("pluralRules")
                                                 select item).ToList();
            if (pluralRuleSetDatas != null && pluralRuleSetDatas.Count > 0)
            {
                List<PluralRuleSet> pluralRuleSets = new List<PluralRuleSet>();
                foreach (XElement data in pluralRuleSetDatas)
                {
                    string cultureNames = data.Attribute("locales").Value.ToString();
                    Progress(String.Format("Adding {0} rule set", ruleSetType), cultureNames);

                    PluralRuleSet pluralRuleSet = new PluralRuleSet();
                    pluralRuleSet.CultureNames = cultureNames.Split(' ');

                    List<XElement> pluralRuleDatas = (from item in data
                                                        .Elements("pluralRule")
                                                      select item).ToList();
                    if (pluralRuleDatas != null)
                    {
                        List<PluralRule> pluralRules = new List<PluralRule>();
                        foreach (XElement pluralRuleData in pluralRuleDatas)
                        {
                            PluralRule pluralRule = new PluralRule();
                            pluralRule.Id = GetPluralRuleCount(pluralRuleData.Attribute("count").Value.ToString());
                            pluralRule.Rule = pluralRuleData.Value;
                            pluralRules.Add(pluralRule);
                        }

                        pluralRuleSet.PluralRules = pluralRules.ToArray();
                    }

                    pluralRuleSets.Add(pluralRuleSet);
                    Progress(String.Format("Added {0} rule set", ruleSetType), cultureNames, ProgressEventType.Added, pluralRuleSet);
                }

                return pluralRuleSets.ToArray();
            }

            return null;
        }

        private static PluralRuleCount GetPluralRuleCount(string pluralRuleCount)
        {
            return (PluralRuleCount)Enum.Parse(typeof(PluralRuleCount), pluralRuleCount, true);
        }
    }
}
