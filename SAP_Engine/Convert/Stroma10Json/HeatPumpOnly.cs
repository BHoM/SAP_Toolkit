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
            if (heatPumpOnlyObject == null)
                return null;
            
            BH.oM.Environment.SAP.Stroma10.HeatPumpOnly sapHeatPumpOnly = new BH.oM.Environment.SAP.Stroma10.HeatPumpOnly();

            sapHeatPumpOnly.ID = System.Convert.ToInt32(heatPumpOnlyObject.CustomData["Id"]);

            sapHeatPumpOnly.HotWaterOnlyHeatPump = System.Convert.ToBoolean(heatPumpOnlyObject.CustomData["HotWaterOnlyHp"]);

            sapHeatPumpOnly.HotWaterHeatPumpIntegral = System.Convert.ToBoolean(heatPumpOnlyObject.CustomData["HotWaterHpIntegral"]);

            sapHeatPumpOnly.Volume = System.Convert.ToInt32(heatPumpOnlyObject.CustomData["Volume"]);

            sapHeatPumpOnly.DeclaredValue = System.Convert.ToDouble(heatPumpOnlyObject.CustomData["DeclaredValue"]);

            sapHeatPumpOnly.ManufacturerSpecified = System.Convert.ToBoolean(heatPumpOnlyObject.CustomData["ManuSpecified"]);

            sapHeatPumpOnly.SummerEfficiency = System.Convert.ToDouble(heatPumpOnlyObject.CustomData["SummerEff"]);

            sapHeatPumpOnly.WinterEfficiency = System.Convert.ToDouble(heatPumpOnlyObject.CustomData["WinterEff"]);

            return sapHeatPumpOnly;
        }
    }
}
