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
        private static RegionGroup[] GetRegionGroups()
        {
            if (options != null && !options.IncludeRegionGroups)
            {
                return null;
            }

            List<XElement> regionGroupElements = (from i in supplementalDataDocument.Elements("supplementalData")
                                                    .Elements("territoryContainment").Elements("group")
                                                  select i).ToList();
            if (regionGroupElements.Count == 0)
            {
                return null;
            }

            List<RegionGroup> regionGroups = new List<RegionGroup>();
            foreach (XElement regionGroupElement in regionGroupElements)
            {
                string regionGroupId = regionGroupElement.Attribute("type").Value.ToString();
                Progress("Adding region group", regionGroupId);

                RegionGroup regionGroup = new RegionGroup();
                regionGroup.Id = regionGroupId;
                regionGroup.RegionIds = regionGroupElement.Attribute("contains").Value.ToString().Split(' ');

                if (regionGroupElement.Attribute("status") != null)
                {
                    regionGroup.Status = regionGroupElement.Attribute("status").Value.ToString();
                }

                regionGroups.Add(regionGroup);
                Progress("Added region group", regionGroupId, ProgressEventType.Added, regionGroup);
            }

            return regionGroups.ToArray();
        }
    }
}
