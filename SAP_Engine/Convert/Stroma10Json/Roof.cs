using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static List<BH.oM.Environment.SAP.Stroma10.Roof> ToRoofs(CustomObject roofsObject)
        {
            List<BH.oM.Environment.SAP.Stroma10.Roof> rtn = new List<BH.oM.Environment.SAP.Stroma10.Roof>();
            foreach (var value in roofsObject.CustomData["Roofs"] as List<CustomObject>)
            {
                rtn.Add(ToRoof(value));
            }
            return rtn;
        }
        public static BH.oM.Environment.SAP.Stroma10.Roof ToRoof(CustomObject roofObject)
        {
            BH.oM.Environment.SAP.Stroma10.Roof sapRoof = new BH.oM.Environment.SAP.Stroma10.Roof();

            sapRoof.ID = System.Convert.ToInt32(roofObject.CustomData["ID"]);

            sapRoof.BHoM_Guid = (Guid)roofObject.CustomData["GUID"];

            sapRoof.Type = System.Convert.ToInt32(roofObject.CustomData["Type"]);

            sapRoof.Construction = System.Convert.ToInt32(roofObject.CustomData["Construction"]);

            sapRoof.Area = System.Convert.ToDouble(roofObject.CustomData["Area"]);

            sapRoof.UValueStart = System.Convert.ToDouble(roofObject.CustomData["UValueStart"]);

            sapRoof.UValue = System.Convert.ToDouble(roofObject.CustomData["UValue"]);

            sapRoof.ResultantUValue = System.Convert.ToDouble(roofObject.CustomData["ResultantUValue"]);

            sapRoof.Curtain = System.Convert.ToBoolean(roofObject.CustomData["Curtain"]);

            sapRoof.ManualInputKappa = System.Convert.ToBoolean(roofObject.CustomData["ManualInputKappa"]);

            sapRoof.Kappa = System.Convert.ToDouble(roofObject.CustomData["Kappa"]);

            // null value - change this
            sapRoof.Dims = (List<object>)roofObject.CustomData["Dims"];


            sapRoof.UValueSelectionID = System.Convert.ToInt32(roofObject.CustomData["UValueSelectionID"]);

            sapRoof.UValueSelected = System.Convert.ToBoolean(roofObject.CustomData["UValueSelected"]);

            sapRoof.EnergyPerformanceCertificateDescription = roofObject.CustomData["EnergyPerformanceCertificateDescription"] as CustomObject;

            sapRoof.LoftInsulation = roofObject.CustomData["LoftInsulation"] as CustomObject;

            return sapRoof;
        }
    }
}
