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
        private static MeasurementData GetMeasurementData()
        {
            if (options != null && !options.IncludeMeasurementData)
            {
                return null;
            }

            XElement measurementDataElement = (from i in supplementalDataDocument.Elements("supplementalData")
                                                   .Elements("measurementData")
                                               select i).FirstOrDefault();
            if (measurementDataElement == null)
            {
                return null;
            }

            Progress("Adding measurement data", String.Empty);

            MeasurementData measurementData = new MeasurementData();

            List<XElement> measurementSystemElements = measurementDataElement.Elements("measurementSystem").ToList();
            if (measurementSystemElements.Count > 0)
            {
                List<RegionMeasurementSystem> minDaysCounts = new List<RegionMeasurementSystem>();
                foreach (XElement measurementSystemElement in measurementSystemElements)
                {
                    RegionMeasurementSystem regionMeasurementSystem = new RegionMeasurementSystem();
                    regionMeasurementSystem.MeasurementSystemId = measurementSystemElement.Attribute("type").Value.ToString();
                    regionMeasurementSystem.RegionIds = measurementSystemElement.Attribute("territories").Value.ToString().Split(' ');
                    minDaysCounts.Add(regionMeasurementSystem);
                }

                measurementData.MeasurementSystems = minDaysCounts.ToArray();
            }

            List<XElement> paperSizeElements = measurementDataElement.Elements("paperSize").ToList();
            if (paperSizeElements.Count > 0)
            {
                List<RegionPaperSize> paperSizes = new List<RegionPaperSize>();
                foreach (XElement paperSizeElement in paperSizeElements)
                {
                    RegionPaperSize regionPaperSize = new RegionPaperSize();
                    regionPaperSize.PaperSizeId = paperSizeElement.Attribute("type").Value.ToString();
                    regionPaperSize.RegionIds = paperSizeElement.Attribute("territories").Value.ToString().Split(' ');
                    paperSizes.Add(regionPaperSize);
                }

                measurementData.PaperSizes = paperSizes.ToArray();
            }

            return measurementData;
        }
    }
}
