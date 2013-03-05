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
        private static CharacterFallback[] GetCharacterFallbacks()
        {
            if (options != null && !options.IncludeCharacterFallbacks)
            {
                return null;
            }

            XDocument document = GetXmlDocument(@"Core\common\supplemental\characters.xml");

            List<XElement> characterElements = (from i in document.Elements("supplementalData")
                                                    .Elements("characters").Elements("character-fallback").Elements("character")
                                                select i).ToList();
            if (characterElements == null || characterElements.Count == 0)
            {
                return null;
            }

            List<CharacterFallback> characterFallbacks = new List<CharacterFallback>();
            foreach (XElement characterFallbackElement in characterElements)
            {
                string value = characterFallbackElement.Attribute("value").Value.ToString();

                Progress("Adding character fallback", value);

                CharacterFallback characterFallback = new CharacterFallback();
                characterFallback.Character = value;

                List<XElement> substituteElements = characterFallbackElement.Elements("substitute").ToList();
                List<string> substitutes = new List<string>();
                foreach (XElement substituteElement in substituteElements)
                {
                    substitutes.Add(substituteElement.Value);
                }

                characterFallback.Substitutes = substitutes.ToArray();
                characterFallbacks.Add(characterFallback);
                Progress("Added character fallback", value, ProgressEventType.Added, characterFallback);
            }

            return characterFallbacks.ToArray();
        }
    }
}
