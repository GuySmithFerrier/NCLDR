﻿using System;
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
        private static LikelySubTag[] GetLikelySubTags()
        {
            if (options != null && !options.IncludeLikelySubTags)
            {
                return null;
            }

            XDocument document = GetXmlDocument(@"Core\common\supplemental\likelySubtags.xml");

            List<XElement> likelySubTagElements = (from i in document.Elements("supplementalData")
                                                    .Elements("likelySubtags").Elements("likelySubtag")
                                                    select i).ToList();
            if (likelySubTagElements == null)
            {
                return null;
            }

            List<LikelySubTag> likelySubTags = new List<LikelySubTag>();
            foreach (XElement likelySubTagElement in likelySubTagElements)
            {
                string fromCultureId = likelySubTagElement.Attribute("from").Value.ToString();

                Progress("Adding likely subtag", fromCultureId);

                LikelySubTag likelySubTag = new LikelySubTag();
                likelySubTag.FromCultureId = fromCultureId;
                likelySubTag.ToCultureId = likelySubTagElement.Attribute("to").Value.ToString();
                likelySubTags.Add(likelySubTag);
            }

            return likelySubTags.ToArray();
        }
    }
}
