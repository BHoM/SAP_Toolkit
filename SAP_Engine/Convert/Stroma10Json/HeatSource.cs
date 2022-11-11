using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static List<BH.oM.Environment.SAP.Stroma10.HeatSource> ToHeatSources(List<CustomObject> heatSourcesObject)
        {
            if (heatSourcesObject == null)
                return null;

            List<BH.oM.Environment.SAP.Stroma10.HeatSource> rtn = new List<BH.oM.Environment.SAP.Stroma10.HeatSource>();
            foreach (var value in heatSourcesObject)
            {
                rtn.Add(ToHeatSource(value));
            }
            return rtn;
        }
        public static BH.oM.Environment.SAP.Stroma10.HeatSource ToHeatSource(CustomObject heatSourceObject)
        {
            if (heatSourceObject == null)
                return null;


            BH.oM.Environment.SAP.Stroma10.HeatSource sapHeatSource = new BH.oM.Environment.SAP.Stroma10.HeatSource();

            sapHeatSource.ID = System.Convert.ToInt32(heatSourceObject.CustomData["Id"]);

            sapHeatSource.Type = System.Convert.ToInt32(heatSourceObject.CustomData["Type"]);

            sapHeatSource.Fuel = System.Convert.ToInt32(heatSourceObject.CustomData["Fuel"]);

            sapHeatSource.HeatFraction = System.Convert.ToDouble(heatSourceObject.CustomData["HeatFraction"]);

            sapHeatSource.Efficiency = System.Convert.ToDouble(heatSourceObject.CustomData["Efficiency"]);

            sapHeatSource.HeatSourceType = System.Convert.ToInt32(heatSourceObject.CustomData["HeatSourceType"]);


            return sapHeatSource;
        }
    }
}
