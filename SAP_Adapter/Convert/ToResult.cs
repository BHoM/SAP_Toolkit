using BH.oM.Environment.SAP;
using BH.oM.Environment.SAP.Excel;
using BH.oM.Environment.SAP.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BH.Adapter.SAP
{
    public static partial class Convert
    {
        public static SAPResult ToResult(SAPReport sapReport, DwellingSchedule schedule)
        {
            SAPResult result = new SAPResult();

            if (sapReport.SAP10Data.PropertyDetails.BuildingParts.BuildingPart.Count > 0)
            {
                var part = sapReport.SAP10Data.PropertyDetails.BuildingParts.BuildingPart[0];
                result.DwellingName = part.Identifier;
                result.DwellingCount = schedule.Count;
                result.Iteration = part.Identifier.Substring(schedule.DwellingTypeName.Length + 1); //Remove the Dwelling Name plus first separator
                result.TotalFloorArea = TotalFloorArea(sapReport);
                result.FloorAreaByBlock = result.TotalFloorArea * result.DwellingCount;
                result.WallArea = TotalWallArea(sapReport);
                result.WindowArea = TotalWindowArea(sapReport);
                result.WallToFloor = result.WallArea / result.TotalFloorArea;
                result.WindowToFloor = result.WindowArea / result.TotalFloorArea;
                result.WindowToWall = result.WindowArea / result.WallArea;
                result.NotionalWindow = NotionalWindowArea(sapReport);
                result.NotionalWindowToWall = result.NotionalWindow / result.WallArea;

                try
                {
                    result.DER = double.Parse(sapReport.EnergyAssessment.EnergyUse.DER);
                }
                catch { }

                try
                {
                    result.TER = double.Parse(sapReport.EnergyAssessment.EnergyUse.TER);
                }
                catch { }

                try
                {
                    result.DPER = double.Parse(sapReport.EnergyAssessment.EnergyUse.DPER);
                }
                catch { }

                try
                {
                    result.TPER = double.Parse(sapReport.EnergyAssessment.EnergyUse.TPER);
                }
                catch { }

                try
                {
                    result.DFEE = double.Parse(sapReport.EnergyAssessment.EnergyUse.DFEE);
                }
                catch { }

                try
                {
                    result.TFEE = double.Parse(sapReport.EnergyAssessment.EnergyUse.TFEE);
                }
                catch { }

                if (result.TER > 0)
                    result.DERTERImprovement = (result.TER - result.DER) / result.TER;

                if(result.TPER > 0)
                    result.DPERTPERImprovement = (result.TPER - result.DPER) / result.TPER;

                if (result.TFEE > 0)
                    result.DFEETFEEImprovement = (result.TFEE - result.DFEE) / result.TFEE;

                result.BlockDER = result.DER * result.FloorAreaByBlock;
                result.BlockTER = result.TER * result.FloorAreaByBlock;
                result.BlockDPER = result.DPER * result.FloorAreaByBlock;
                result.BlockTPER = result.TPER * result.FloorAreaByBlock;
                result.BlockDFEE = result.DFEE * result.FloorAreaByBlock;
                result.BlockTFEE = result.TFEE * result.FloorAreaByBlock;
            }

            return result;
        }

        private static double TotalFloorArea(SAPReport report)
        {
            double floorArea = 0;

            foreach(var part in report.SAP10Data.PropertyDetails.BuildingParts.BuildingPart)
                floorArea += part.FloorDimensions.FloorDimension.Select(x => x.Area).Sum();

            return floorArea;
        }

        private static double TotalWallArea(SAPReport report)
        {
            double wallArea = 0;

            foreach (var part in report.SAP10Data.PropertyDetails.BuildingParts.BuildingPart)
                wallArea += part.Walls.Wall.Select(x => x.Area).Sum();

            return wallArea;
        }

        private static double TotalWindowArea(SAPReport report)
        {
            double windowArea = 0;

            List<string> acceptableWindowTypes = new List<string>()
            {
                "4", "5", "6",
            };

            foreach (var part in report.SAP10Data.PropertyDetails.BuildingParts.BuildingPart)
                windowArea += part.Openings.Opening.Where(x => acceptableWindowTypes.Contains(x.Type)).Select(x => x.Height * x.Width).Sum();

            return windowArea;
        }

        private static double TotalOpeningArea(SAPReport report)
        {
            double openingArea = 0;

            foreach (var part in report.SAP10Data.PropertyDetails.BuildingParts.BuildingPart)
                openingArea += part.Openings.Opening.Select(x => x.Height * x.Width).Sum();

            return openingArea;
        }

        private static double NotionalWindowArea(SAPReport report)
        {
            double totalOpeningArea = TotalOpeningArea(report);
            double windowArea = TotalWindowArea(report);
            double floorArea = TotalFloorArea(report);

            //Notional window cannot exceed more than 25% of the floor area
            if (totalOpeningArea > (floorArea / 4))
            {
                double doorArea = totalOpeningArea - windowArea;
                double factor = ((floorArea / 4) - doorArea) / windowArea;

                windowArea = windowArea * factor;
            }

            return windowArea;
        }
    }
}
