using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BH.oM.Base;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.Thermal ToThermal(CustomObject thermalObject)
        {
            if (thermalObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.Thermal sapThermal = new BH.oM.Environment.SAP.Stroma10.Thermal();

            sapThermal.ID = System.Convert.ToInt32(thermalObject.CustomData["Id"]);

            sapThermal.BHoM_Guid = (Guid.Parse(thermalObject.CustomData["Guid"] as string));

            sapThermal.ManualThermalBridgingCalcuation = System.Convert.ToBoolean(thermalObject.CustomData["ManualHtb"]);

            sapThermal.ThermalBridgingValue = System.Convert.ToDouble(thermalObject.CustomData["HtbValue"]);

            sapThermal.ConstrunctionDetails = (thermalObject.CustomData["ConstDetails"] as CustomObject);

            sapThermal.ManualThermalBridgingYValue = System.Convert.ToBoolean(thermalObject.CustomData["ManualY"]);

            sapThermal.YValue = System.Convert.ToDouble(thermalObject.CustomData["YValue"]);

            sapThermal.CustomApproved = System.Convert.ToBoolean(thermalObject.CustomData["CustomApproved"]);

            sapThermal.ExternalJunctions = ToExternalJunctions((thermalObject.CustomData["ExternalJunctions"] as List<object>).Cast<CustomObject>().ToList());

            sapThermal.PartyJunctions = ToPartyJunctions((thermalObject.CustomData["PartyJunctions"] as List<object>).Cast<CustomObject>().ToList());

            sapThermal.RoofJunctions = ToRoofJunctions((thermalObject.CustomData["RoofJunctions"] as List<object>).Cast<CustomObject>().ToList());

            sapThermal.Reference = System.Convert.ToBoolean(thermalObject.CustomData["Reference"]);

            return sapThermal;
        }
    }
}
