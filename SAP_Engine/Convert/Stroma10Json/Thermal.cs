using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

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

            sapThermal.ConstrunctionDetails = (thermalObject.CustomData["ConstDetails"] as string);

            sapThermal.ManualThermalBridgingYValue = System.Convert.ToBoolean(thermalObject.CustomData["ManualY"]);

            sapThermal.YValue = System.Convert.ToDouble(thermalObject.CustomData["YValue"]);

            sapThermal.CustomApproved = System.Convert.ToBoolean(thermalObject.CustomData["CustomApproved"]);

            sapThermal.ExternalJunctions = ToExternalJunctions((thermalObject.CustomData["ExternalJunctions"] as List<object>).Cast<CustomObject>().ToList());

            sapThermal.PartyJunctions = ToPartyJunctions((thermalObject.CustomData["PartyJunctions"] as List<object>).Cast<CustomObject>().ToList());

            sapThermal.RoofJunctions = ToRoofJunctions((thermalObject.CustomData["RoofJunctions"] as List<object>).Cast<CustomObject>().ToList());

            sapThermal.Reference = System.Convert.ToBoolean(thermalObject.CustomData["Reference"]);

            return sapThermal;
        }
        public static Dictionary<string, object> FromThermal(Thermal obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();

            if (obj == null)
                return null;

            rtn.Add("Id", obj.ID);

            rtn.Add("Guid", obj.BHoM_Guid.ToString());

            rtn.Add("ManualHtb", obj.ManualThermalBridgingCalcuation);
            
            rtn.Add("HtbValue", obj.ThermalBridgingValue);

            rtn.Add("ConstDetails", obj.ConstrunctionDetails);

            rtn.Add("ManualY", obj.ManualThermalBridgingYValue);

            rtn.Add("YValue" ,obj.YValue);  

            rtn.Add("CustomApproved", obj.CustomApproved);

            if (obj.ExternalJunctions != null && obj.ExternalJunctions.Any(x => x != null))
                rtn.Add("ExternalJunctions", obj.ExternalJunctions.Select(x => FromExternalJunction(x)).ToList());

            if (obj.PartyJunctions != null && obj.PartyJunctions.Any(x => x != null))
                rtn.Add("PartyJunctions", obj.PartyJunctions.Select(x => FromPartyJunction(x)).ToList());

            if (obj.RoofJunctions != null && obj.RoofJunctions.Any(x => x != null))
                rtn.Add("RoofJunctions", obj.RoofJunctions.Select(x => FromRoofJunction(x)).ToList());

            rtn.Add("Reference", obj.Reference);

            return rtn;
        }
    }
}
