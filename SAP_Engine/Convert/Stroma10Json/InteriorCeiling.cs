using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static List<BH.oM.Environment.SAP.Stroma10.InteriorCeiling> ToInteriorCeilings(CustomObject interiorCeilingsObject)
        {
            List<BH.oM.Environment.SAP.Stroma10.InteriorCeiling> rtn = new List<BH.oM.Environment.SAP.Stroma10.InteriorCeiling>();
            foreach (var value in interiorCeilingsObject.CustomData["InteriorCeilings"] as List<CustomObject>)
            {
                rtn.Add(ToInteriorCeiling(value));
            }
            return rtn;
        }
        public static BH.oM.Environment.SAP.Stroma10.InteriorCeiling ToInteriorCeiling(CustomObject interiorCeilingObject)
        {
            BH.oM.Environment.SAP.Stroma10.InteriorCeiling sapInteriorCeiling = new BH.oM.Environment.SAP.Stroma10.InteriorCeiling();

            sapInteriorCeiling.ID = System.Convert.ToInt32(interiorCeilingObject.CustomData["ID"]);

            sapInteriorCeiling.BHoM_Guid = (Guid)interiorCeilingObject.CustomData["GUID"];

            sapInteriorCeiling.Type = System.Convert.ToInt32(interiorCeilingObject.CustomData["Type"]);

            sapInteriorCeiling.Construction = System.Convert.ToInt32(interiorCeilingObject.CustomData["Construction"]);

            sapInteriorCeiling.Area = System.Convert.ToDouble(interiorCeilingObject.CustomData["Area"]);

            sapInteriorCeiling.UValueStart = System.Convert.ToDouble(interiorCeilingObject.CustomData["UValueStart"]);

            sapInteriorCeiling.UValue = System.Convert.ToDouble(interiorCeilingObject.CustomData["UValue"]);

            sapInteriorCeiling.ResultantUValue = System.Convert.ToDouble(interiorCeilingObject.CustomData["ResultantUValue"]);

            sapInteriorCeiling.Curtain = System.Convert.ToBoolean(interiorCeilingObject.CustomData["Curtain"]);

            sapInteriorCeiling.ManualInputKappa = System.Convert.ToBoolean(interiorCeilingObject.CustomData["ManualInputKappa"]);

            sapInteriorCeiling.Kappa = System.Convert.ToDouble(interiorCeilingObject.CustomData["Kappa"]);

            sapInteriorCeiling.Dims = (List<object>)interiorCeilingObject.CustomData["Dims"];


            sapInteriorCeiling.UValueSelectionID = System.Convert.ToInt32(interiorCeilingObject.CustomData["UValueSelectionID"]);

            sapInteriorCeiling.UValueSelected = System.Convert.ToBoolean(interiorCeilingObject.CustomData["UValueSelected"]);

            sapInteriorCeiling.EnergyPerformanceCertificateDescription = interiorCeilingObject.CustomData["EnergyPerformanceCertificateDescription"] as CustomObject;

            sapInteriorCeiling.LoftInsulation = interiorCeilingObject.CustomData["LoftInsulation"] as CustomObject;

            return sapInteriorCeiling;
        }
    }
}
