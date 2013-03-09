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
        private static DayPeriodRuleSet[] GetDayPeriodRuleSets()
        {
            if (options != null && !options.IncludeDayPeriodRuleSets)
            {
                return null;
            }

            XDocument document = GetXmlDocument(@"common\supplemental\dayPeriods.xml");

            IEnumerable<XElement> ldmlElements = document.Elements("supplementalData");
            List<XElement> dayPeriodRuleSetDatas = (from item in ldmlElements.Elements("dayPeriodRuleSet")
                                                .Elements("dayPeriodRules")
                                                    select item).ToList();
            if (dayPeriodRuleSetDatas != null && dayPeriodRuleSetDatas.Count > 0)
            {
                List<DayPeriodRuleSet> dayPeriodRuleSets = new List<DayPeriodRuleSet>();
                foreach (XElement data in dayPeriodRuleSetDatas)
                {
                    string locales = data.Attribute("locales").Value.ToString();
                    Progress("Adding day period", locales);

                    DayPeriodRuleSet dayPeriodRuleSet = new DayPeriodRuleSet();
                    dayPeriodRuleSet.CultureNames = locales.Split(' ');

                    List<DayPeriodRule> dayPeriodRules = new List<DayPeriodRule>();
                    List<XElement> dayPeriodRuleDatas = data.Elements("dayPeriodRule").ToList();
                    foreach (XElement dayPeriodRuleData in dayPeriodRuleDatas)
                    {
                        DayPeriodRule dayPeriodRule = new DayPeriodRule();
                        dayPeriodRule.Id = dayPeriodRuleData.Attribute("type").Value.ToString();

                        if (dayPeriodRuleData.Attribute("from") != null)
                        {
                            dayPeriodRule.From = dayPeriodRuleData.Attribute("from").Value.ToString();
                        }

                        if (dayPeriodRuleData.Attribute("at") != null)
                        {
                            dayPeriodRule.At = dayPeriodRuleData.Attribute("at").Value.ToString();
                        }

                        if (dayPeriodRuleData.Attribute("after") != null)
                        {
                            dayPeriodRule.After = dayPeriodRuleData.Attribute("after").Value.ToString();
                        }

                        if (dayPeriodRuleData.Attribute("before") != null)
                        {
                            dayPeriodRule.Before = dayPeriodRuleData.Attribute("before").Value.ToString();
                        }

                        if (dayPeriodRuleData.Attribute("to") != null)
                        {
                            dayPeriodRule.To = dayPeriodRuleData.Attribute("to").Value.ToString();
                        }

                        dayPeriodRules.Add(dayPeriodRule);
                    }

                    dayPeriodRuleSet.DayPeriodRules = dayPeriodRules.ToArray();

                    dayPeriodRuleSets.Add(dayPeriodRuleSet);
                    Progress("Added day period", locales, ProgressEventType.Added, dayPeriodRuleSet);
                }

                return dayPeriodRuleSets.ToArray();
            }

            return null;
        }
    }
}
