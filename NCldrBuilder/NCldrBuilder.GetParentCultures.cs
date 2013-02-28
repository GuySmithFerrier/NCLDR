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
        private static ParentCulture[] GetParentCultures()
        {
            if (options != null && !options.IncludeParentCultures)
            {
                return null;
            }

            List<XElement> parentCultureElements = (from i in supplementalDataDocument.Elements("supplementalData")
                                                        .Elements("parentLocales").Elements("parentLocale")
                                                    select i).ToList();
            if (parentCultureElements == null)
            {
                return null;
            }

            List<ParentCulture> parentCultures = new List<ParentCulture>();
            foreach (XElement parentCultureElement in parentCultureElements)
            {
                string parentId = parentCultureElement.Attribute("parent").Value.ToString();

                Progress("Adding parent culture", parentId);

                ParentCulture parentCulture = new ParentCulture();
                parentCulture.ParentId = parentId;
                parentCulture.CultureIds = parentCultureElement.Attribute("locales").Value.ToString().Split(' ');

                parentCultures.Add(parentCulture);
            }

            return parentCultures.ToArray();
        }
    }
}
