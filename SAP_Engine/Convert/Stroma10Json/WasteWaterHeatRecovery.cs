using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;
using BH.oM.Environment.SAP;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.WasteWaterHeatRecovery ToWasteWaterHeatRecovery(CustomObject wasteWaterHeatRecoveryObject)
        {
            if (wasteWaterHeatRecoveryObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.WasteWaterHeatRecovery sapWasteWaterHeatRecovery = new BH.oM.Environment.SAP.Stroma10.WasteWaterHeatRecovery();

            sapWasteWaterHeatRecovery.ID = System.Convert.ToInt32(wasteWaterHeatRecoveryObject.CustomData["Id"]);

            sapWasteWaterHeatRecovery.Include = System.Convert.ToBoolean(wasteWaterHeatRecoveryObject.CustomData["Include"]);

            sapWasteWaterHeatRecovery.IsTER = System.Convert.ToBoolean(wasteWaterHeatRecoveryObject.CustomData["IsTer"]);

            sapWasteWaterHeatRecovery.TotalRooms = System.Convert.ToInt32(wasteWaterHeatRecoveryObject.CustomData["TotalRooms"]);

            sapWasteWaterHeatRecovery.Manufacturer = (wasteWaterHeatRecoveryObject.CustomData["Manufacturer"] as string);

            sapWasteWaterHeatRecovery.Model = (wasteWaterHeatRecoveryObject.CustomData["Model"] as string);

            sapWasteWaterHeatRecovery.Efficiency = System.Convert.ToDouble(wasteWaterHeatRecoveryObject.CustomData["Efficiency"]);

            sapWasteWaterHeatRecovery.IsStorage = System.Convert.ToBoolean(wasteWaterHeatRecoveryObject.CustomData["IsStorage"]);

            sapWasteWaterHeatRecovery.WasteWaterHeatRecoverySystems = ToWasteWaterHeatRecoverySystems((wasteWaterHeatRecoveryObject.CustomData["WwhrsSystems"] as List<object>).Cast<CustomObject>().ToList());

            return sapWasteWaterHeatRecovery;
        }
        public static Dictionary<string, object> FromWasteWaterHeatRecovery(WasteWaterHeatRecovery obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();

            if (obj == null)
                return null;

            rtn.Add("Id", obj.ID);

            rtn.Add("Include", obj.Include);

            rtn.Add("IsTer", obj.IsTER);

            rtn.Add("TotalRooms", obj.TotalRooms);

            rtn.Add("Manufacturer", obj.Manufacturer);

            rtn.Add("Model", obj.Model);

            rtn.Add("Efficiency", obj.Efficiency);

            rtn.Add("IsStorage", obj.IsStorage);

            if (obj.WasteWaterHeatRecoverySystems != null && obj.WasteWaterHeatRecoverySystems.Any(x => x != null))
                rtn.Add("WwhrsSystems", obj.WasteWaterHeatRecoverySystems.Select(x => FromWasteWaterHeatRecoverySystem(x)).ToList());

            return rtn;
        }
    }
}
