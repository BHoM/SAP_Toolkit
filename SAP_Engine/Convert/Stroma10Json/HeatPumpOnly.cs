using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.HeatPumpOnly ToHeatPumpOnly(CustomObject heatPumpOnlyObject)
        {
            BH.oM.Environment.SAP.Stroma10.HeatPumpOnly sapHeatPumpOnly = new BH.oM.Environment.SAP.Stroma10.HeatPumpOnly();

            sapHeatPumpOnly.ID = System.Convert.ToInt32(heatPumpOnlyObject.CustomData["ID"]);

            sapHeatPumpOnly.HotWaterOnlyHeatPump = System.Convert.ToBoolean(heatPumpOnlyObject.CustomData["HotWaterOnlyHeatPump"]);

            sapHeatPumpOnly.HotWaterHeatPumpIntegral = System.Convert.ToBoolean(heatPumpOnlyObject.CustomData["HotWaterHeatPumpIntegral"]);

            sapHeatPumpOnly.Volume = System.Convert.ToInt32(heatPumpOnlyObject.CustomData["Volume"]);

            sapHeatPumpOnly.DeclaredValue = System.Convert.ToDouble(heatPumpOnlyObject.CustomData["DeclaredValue"]);

            sapHeatPumpOnly.ManufacturerSpecified = System.Convert.ToBoolean(heatPumpOnlyObject.CustomData["ManufacturerSpecified"]);

            sapHeatPumpOnly.SummerEfficiency = System.Convert.ToDouble(heatPumpOnlyObject.CustomData["SummerEfficiency"]);

            sapHeatPumpOnly.WinterEfficiency = System.Convert.ToDouble(heatPumpOnlyObject.CustomData["WinterEfficiency"]);

            return sapHeatPumpOnly;
        }
    }
}
