using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using BH.oM.Base;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static List<BH.oM.Environment.SAP.Stroma10.Roof> ToRoofs(List<CustomObject> roofsObject)
        {
            if (roofsObject == null)
                return null;

            List<BH.oM.Environment.SAP.Stroma10.Roof> rtn = new List<BH.oM.Environment.SAP.Stroma10.Roof>();
            foreach (var value in roofsObject)
            {
                rtn.Add(ToRoof(value));
            }
            return rtn;
        }
        public static BH.oM.Environment.SAP.Stroma10.Roof ToRoof(CustomObject roofObject)
        {
            if (roofObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.Roof sapRoof = new BH.oM.Environment.SAP.Stroma10.Roof();

            sapRoof.ID = System.Convert.ToInt32(roofObject.CustomData["Id"]);

            sapRoof.BHoM_Guid = (Guid.Parse(roofObject.CustomData["Guid"] as string));

            sapRoof.Type = System.Convert.ToInt32(roofObject.CustomData["Type"]);

            sapRoof.Construction = System.Convert.ToInt32(roofObject.CustomData["Construction"]);

            sapRoof.Area = System.Convert.ToDouble(roofObject.CustomData["Area"]);

            sapRoof.UValueStart = System.Convert.ToDouble(roofObject.CustomData["UValueStart"]);

            sapRoof.UValue = System.Convert.ToDouble(roofObject.CustomData["UValue"]);

            sapRoof.ResultantUValue = System.Convert.ToDouble(roofObject.CustomData["Ru"]);

            sapRoof.Curtain = System.Convert.ToBoolean(roofObject.CustomData["Curtain"]);

            sapRoof.ManualInputKappa = System.Convert.ToBoolean(roofObject.CustomData["OverRideK"]);

            sapRoof.Kappa = System.Convert.ToDouble(roofObject.CustomData["K"]);

            sapRoof.Dims = ToDims((roofObject.CustomData["Dims"] as List<object>).Cast<CustomObject>().ToList());

            sapRoof.UValueSelectionID = System.Convert.ToInt32(roofObject.CustomData["UValueSelectionId"]);

            sapRoof.UValueSelected = System.Convert.ToBoolean(roofObject.CustomData["UValueSelected"]);

            sapRoof.EnergyPerformanceCertificateDescription = roofObject.CustomData["EpcDescription"] as CustomObject;

            sapRoof.LoftInsulation = roofObject.CustomData["LoftInsulation"] as CustomObject;

            return sapRoof;
        }
    }
}
