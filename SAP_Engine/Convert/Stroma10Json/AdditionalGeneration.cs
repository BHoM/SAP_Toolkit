using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;

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
    }
}
