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
        private static Reference[] GetReferences()
        {
            if (options != null && !options.IncludeReferences)
            {
                return null;
            }

            List<XElement> referenceElements = (from i in supplementalDataDocument.Elements("supplementalData")
                                                        .Elements("references").Elements("reference")
                                                    select i).ToList();
            if (referenceElements == null || referenceElements.Count == 0)
            {
                return null;
            }

            List<Reference> references = new List<Reference>();
            foreach (XElement referenceElement in referenceElements)
            {
                string id = referenceElement.Attribute("type").Value.ToString();

                Progress("Adding reference", id);

                Reference reference = new Reference();
                reference.Id = id;

                if (referenceElement.Attribute("uri") != null)
                {
                    reference.Uri = referenceElement.Attribute("uri").Value.ToString();
                }

                reference.Value = referenceElement.Value;

                references.Add(reference);
                Progress("Added reference", id, ProgressEventType.Added, reference);
            }

            return references.ToArray();
        }
    }
}
