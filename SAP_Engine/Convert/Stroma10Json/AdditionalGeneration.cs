using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.AdditionalGeneration ToAdditionalGeneration(CustomObject additionalGenerationObject)
        {
            if (additionalGenerationObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.AdditionalGeneration sapAdditionalGeneration = new BH.oM.Environment.SAP.Stroma10.AdditionalGeneration();

            sapAdditionalGeneration.ID = System.Convert.ToInt32(additionalGenerationObject.CustomData["Id"]);

            sapAdditionalGeneration.Include = System.Convert.ToBoolean(additionalGenerationObject.CustomData["Include"]);

            sapAdditionalGeneration.EnergyGenerated = System.Convert.ToDouble(additionalGenerationObject.CustomData["EGenerated"]);

            sapAdditionalGeneration.TotalArea = System.Convert.ToDouble(additionalGenerationObject.CustomData["TotalArea"]);

            return sapAdditionalGeneration;
        }

        public static Dictionary<string, object> FromAdditionalGeneration(AdditionalGeneration obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();

            rtn.Add("Id", obj.ID);

            rtn.Add("Include", obj.Include);

            rtn.Add("EGenerated", obj.EnergyGenerated);

            rtn.Add("TotalArea", obj.TotalArea);

            return rtn;
        }
    }
}
