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
        private static RegionInformation[] GetRegionInformations()
        {
            if (options != null && !options.IncludeRegionInformations)
            {
                return null;
            }

            List<XElement> regionInformationElements = (from i in supplementalDataDocument.Elements("supplementalData")
                                                            .Elements("territoryInfo").Elements("territory")
                                                        select i).ToList();
            if (regionInformationElements.Count == 0)
            {
                return null;
            }

            List<RegionInformation> regionInformations = new List<RegionInformation>();
            foreach (XElement regionInformationElement in regionInformationElements)
            {
                string regionInformationId = regionInformationElement.Attribute("type").Value.ToString();
                Progress("Adding region information", regionInformationId);

                RegionInformation regionInformation = new RegionInformation();
                regionInformation.Id = regionInformationId;
                regionInformation.Gdp = Int64.Parse(regionInformationElement.Attribute("gdp").Value.ToString());
                regionInformation.LiteracyPercent = float.Parse(regionInformationElement.Attribute("literacyPercent").Value.ToString());
                regionInformation.Population = (int)float.Parse(regionInformationElement.Attribute("population").Value.ToString());

                List<LanguagePopulation> languagePopulations = new List<LanguagePopulation>();
                foreach (XElement languagePopulationElement in regionInformationElement.Elements("languagePopulation"))
                {
                    LanguagePopulation languagePopulation = new LanguagePopulation();
                    languagePopulation.Id = languagePopulationElement.Attribute("type").Value.ToString();
                    languagePopulation.PopulationPercent = float.Parse(languagePopulationElement.Attribute("populationPercent").Value.ToString());

                    if (languagePopulationElement.Attribute("references") != null)
                    {
                        languagePopulation.References = languagePopulationElement.Attribute("references").Value.ToString();
                    }

                    if (languagePopulationElement.Attribute("officialStatus") != null)
                    {
                        languagePopulation.OfficialStatus = languagePopulationElement.Attribute("officialStatus").Value.ToString();
                    }

                    languagePopulations.Add(languagePopulation);
                }

                regionInformation.LanguagePopulations = languagePopulations.ToArray();
                regionInformations.Add(regionInformation);
                Progress("Added region information", regionInformationId, ProgressEventType.Added, regionInformation);
            }

            return regionInformations.ToArray();
        }
    }
}
