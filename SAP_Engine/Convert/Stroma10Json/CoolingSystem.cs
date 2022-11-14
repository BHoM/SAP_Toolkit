using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.CoolingSystem ToCoolingSystem(CustomObject coolingSystemObject)
        {
            if (coolingSystemObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.CoolingSystem sapCoolingSystem = new BH.oM.Environment.SAP.Stroma10.CoolingSystem();

            sapCoolingSystem.ID = System.Convert.ToInt32(coolingSystemObject.CustomData["Id"]);

            sapCoolingSystem.Include = System.Convert.ToBoolean(coolingSystemObject.CustomData["Include"]);

            sapCoolingSystem.SystemType = System.Convert.ToInt32(coolingSystemObject.CustomData["SystemType"]);

            sapCoolingSystem.EnergyLabel = System.Convert.ToInt32(coolingSystemObject.CustomData["EnergyLabel"]);

            sapCoolingSystem.Overide = System.Convert.ToBoolean(coolingSystemObject.CustomData["Overide"]);

            sapCoolingSystem.CompressorControl = System.Convert.ToInt32(coolingSystemObject.CustomData["CompressorControl"]);

            sapCoolingSystem.CooledArea = System.Convert.ToDouble(coolingSystemObject.CustomData["CooledArea"]);

            sapCoolingSystem.EERMeasuredInclude = System.Convert.ToBoolean(coolingSystemObject.CustomData["EerMeasuredInclude"]);

            sapCoolingSystem.EER = System.Convert.ToDouble(coolingSystemObject.CustomData["Eer"]);

            sapCoolingSystem.Description = coolingSystemObject.CustomData["Description"] as string;

            return sapCoolingSystem;
        }
        public static Dictionary<string, object> FromCoolingSystem(CoolingSystem obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();

            rtn.Add("Id", obj.ID);
            rtn.Add("Include", obj.Include);
            rtn.Add("SystemType", obj.SystemType);
            rtn.Add("EnergyLabel", obj.EnergyLabel);
            rtn.Add("Overide", obj.Overide);
            rtn.Add("CompressorControl", obj.CompressorControl);
            rtn.Add("CooledArea", obj.CooledArea);
            rtn.Add("EerMeasuredInclude", obj.EERMeasuredInclude);
            rtn.Add("Eer", obj.EER);
            rtn.Add("Description", obj.Description);

            return rtn;
        }
    }
}
