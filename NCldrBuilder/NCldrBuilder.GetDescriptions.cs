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
        private static T[] GetDescriptions<T>(string filename, string nameCode, string progressName) where T: IDescription, new()
        {
            if (options != null && (filename == "currency" && !options.IncludeCurrencies))
            {
                return null;
            }

            XDocument bcp47Document = GetXmlDocument(String.Format(@"Core\common\bcp47\{0}.xml", filename));

            XElement keyElement = (from i in bcp47Document.Elements("ldmlBCP47").Elements("keyword").Elements("key")
                                           where i.Attribute("name").Value.ToString() == nameCode
                                           select i).FirstOrDefault();

            if (keyElement == null)
            {
                return null;
            }

            List<XElement> elements = (from i in keyElement.Elements("type")
                                               select i).ToList();
            if (elements == null || elements.Count == 0)
            {
                return null;
            }

            List<T> list = new List<T>();
            foreach (XElement element in elements)
            {
                string name = element.Attribute("name").Value.ToString();

                Progress(String.Format("Adding {0}", progressName), name);

                T item = new T();
                item.Id = name;
                item.Description = element.Attribute("description").Value.ToString();
                list.Add(item);
                Progress(String.Format("Added {0}", progressName), name, ProgressEventType.Added, item);
            }

            return list.ToArray();
        }
    }
}
