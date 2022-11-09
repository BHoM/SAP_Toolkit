using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.Thermal ToThermal(CustomObject thermalObject)
        {
            BH.oM.Environment.SAP.Stroma10.Thermal sapThermal = new BH.oM.Environment.SAP.Stroma10.Thermal();

            sapThermal.ID = System.Convert.ToInt32(thermalObject.CustomData["ID"]);

            sapThermal.BHoM_Guid = (Guid)thermalObject.CustomData["GUID"];

            sapThermal.ManualThermalBridgingCalcuation = System.Convert.ToBoolean(thermalObject.CustomData["ManualThermalBridgingCalcuation"]);

            sapThermal.ThermalBridgingValue = System.Convert.ToDouble(thermalObject.CustomData["ThermalBridgingValue"]);

            sapThermal.ConstrunctionDetails = (thermalObject.CustomData["ConstrunctionDetails"] as CustomObject);

            sapThermal.ManualThermalBridgingYValue = System.Convert.ToBoolean(thermalObject.CustomData["ManualThermalBridgingYValue"]);

            sapThermal.YValue = System.Convert.ToDouble(thermalObject.CustomData["YValue"]);

            sapThermal.CustomApproved = System.Convert.ToBoolean(thermalObject.CustomData["CustomApproved"]);

            sapThermal.ExternalJunctions = ToExternalJunctions(thermalObject.CustomData["ExternalJunctions"] as CustomObject);

            sapThermal.PartyJunctions = ToPartyJunctions(thermalObject.CustomData["PartyJunctions"] as CustomObject);

            sapThermal.RoofJunctions = ToRoofJunctions(thermalObject.CustomData["RoofJunctions"] as CustomObject);

            sapThermal.Reference = System.Convert.ToBoolean(thermalObject.CustomData["Reference"]);

            sapThermal.Include = System.Convert.ToBoolean(thermalObject.CustomData["Include"]);

            sapThermal.Type = System.Convert.ToInt32(thermalObject.CustomData["Type"]);

            sapThermal.Location = System.Convert.ToInt32(thermalObject.CustomData["Location"]);

            sapThermal.Connection = System.Convert.ToInt32(thermalObject.CustomData["Connection"]);


            return sapThermal;
        }
    }
}
