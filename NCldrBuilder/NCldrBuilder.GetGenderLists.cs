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
        private static GenderList[] GetGenderLists()
        {
            if (options != null && !options.IncludeGenderLists)
            {
                return null;
            }

            XDocument document = GetXmlDocument(@"common\supplemental\genderList.xml");

            List<XElement> genderListElements = (from i in document.Elements("supplementalData")
                                                    .Elements("gender").Elements("personList")
                                                 select i).ToList();
            if (genderListElements == null || genderListElements.Count == 0)
            {
                return null;
            }

            List<GenderList> genderLists = new List<GenderList>();
            foreach (XElement genderListElement in genderListElements)
            {
                string id = genderListElement.Attribute("type").Value.ToString();

                Progress("Adding gender list", id);

                GenderList genderList = new GenderList();
                genderList.Id = id;
                genderList.CultureIds = genderListElement.Attribute("locales").Value.ToString().Split(' ');
                genderLists.Add(genderList);
                Progress("Added gender list", id, ProgressEventType.Added, genderList);
            }

            return genderLists.ToArray();
        }
    }
}
