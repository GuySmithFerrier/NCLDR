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
        private static NumberingSystemType[] GetNumberingSystems()
        {
            if (options != null && !options.IncludeNumberingSystems)
            {
                return null;
            }

            XDocument document = GetXmlDocument(@"common\supplemental\numberingSystems.xml");

            IEnumerable<XElement> ldmlElements = document.Elements("supplementalData");
            List<XElement> numberingSystemDatas = (from item in ldmlElements.Elements("numberingSystems")
                                                .Elements("numberingSystem")
                                                   select item).ToList();
            if (numberingSystemDatas != null && numberingSystemDatas.Count > 0)
            {
                List<NumberingSystemType> numberingSystems = new List<NumberingSystemType>();
                foreach (XElement data in numberingSystemDatas)
                {
                    string id = data.Attribute("id").Value.ToString();
                    Progress("Adding numbering system", id);

                    NumberingSystemType numberingSystem = new NumberingSystemType();
                    numberingSystem.Id = id;
                    numberingSystem.DigitsOrRules = GetNumberingSystemType(data.Attribute("type").Value.ToString());
                    if (data.Attribute("rules") != null)
                    {
                        numberingSystem.Rules = data.Attribute("rules").Value.ToString();
                    }

                    if (data.Attribute("digits") != null)
                    {
                        numberingSystem.Digits = data.Attribute("digits").Value.ToString();
                    }

                    numberingSystems.Add(numberingSystem);
                    Progress("Added numbering system", id, ProgressEventType.Added, numberingSystem);
                }

                UpdateDescriptions(numberingSystems);

                return numberingSystems.ToArray();
            }

            return null;
        }

        private static void UpdateDescriptions(List<NumberingSystemType> numberingSystemTypes)
        {
            GenericDescription[] numberTypeDescriptions = GetDescriptions<GenericDescription>("number", "nu", "number");
            foreach (NumberingSystemType numberingSystemType in numberingSystemTypes)
            {
                GenericDescription description = (from gd in numberTypeDescriptions
                                                  where gd.Id == numberingSystemType.Id
                                                  select gd).FirstOrDefault();
                if (description != null)
                {
                    numberingSystemType.Description = description.Description;
                }
            }
        }

        private static NumberingSystemDigitsOrRules GetNumberingSystemType(string numberingSystemType)
        {
            return (NumberingSystemDigitsOrRules)Enum.Parse(typeof(NumberingSystemDigitsOrRules), numberingSystemType, true);
        }
    }
}
