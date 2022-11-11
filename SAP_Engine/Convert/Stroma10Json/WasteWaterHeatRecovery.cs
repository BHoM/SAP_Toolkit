using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using BH.oM.Base;

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

            sapWasteWaterHeatRecovery.Manufacturer = (wasteWaterHeatRecoveryObject.CustomData["Manufacturer"] as CustomObject);

            sapWasteWaterHeatRecovery.Model = (wasteWaterHeatRecoveryObject.CustomData["Model"] as CustomObject);

            sapWasteWaterHeatRecovery.Efficiency = System.Convert.ToDouble(wasteWaterHeatRecoveryObject.CustomData["Efficiency"]);

            sapWasteWaterHeatRecovery.IsStorage = System.Convert.ToBoolean(wasteWaterHeatRecoveryObject.CustomData["IsStorage"]);

            sapWasteWaterHeatRecovery.WasteWaterHeatRecoverySystems = ToWasteWaterHeatRecoverySystems((wasteWaterHeatRecoveryObject.CustomData["WwhrsSystems"] as List<object>).Cast<CustomObject>().ToList());

            return sapWasteWaterHeatRecovery;
        }
    }
}
