using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using BH.oM.Base;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static List<BH.oM.Environment.SAP.Stroma10.InteriorCeiling> ToInteriorCeilings(List<CustomObject> interiorCeilingsObject)
        {
            if (interiorCeilingsObject == null)
                return null;

            List<BH.oM.Environment.SAP.Stroma10.InteriorCeiling> rtn = new List<BH.oM.Environment.SAP.Stroma10.InteriorCeiling>();
            foreach (var value in interiorCeilingsObject)
            {
                rtn.Add(ToInteriorCeiling(value));
            }
            return rtn;
        }
        public static BH.oM.Environment.SAP.Stroma10.InteriorCeiling ToInteriorCeiling(CustomObject interiorCeilingObject)
        {
            if (interiorCeilingObject == null)
                return null;
            
            BH.oM.Environment.SAP.Stroma10.InteriorCeiling sapInteriorCeiling = new BH.oM.Environment.SAP.Stroma10.InteriorCeiling();

            sapInteriorCeiling.ID = System.Convert.ToInt32(interiorCeilingObject.CustomData["Id"]);

            sapInteriorCeiling.BHoM_Guid = (Guid.Parse(interiorCeilingObject.CustomData["Guid"] as string));

            sapInteriorCeiling.Type = System.Convert.ToInt32(interiorCeilingObject.CustomData["Type"]);

            sapInteriorCeiling.Construction = System.Convert.ToInt32(interiorCeilingObject.CustomData["Construction"]);

            sapInteriorCeiling.Area = System.Convert.ToDouble(interiorCeilingObject.CustomData["Area"]);

            sapInteriorCeiling.UValueStart = System.Convert.ToDouble(interiorCeilingObject.CustomData["UValueStart"]);

            sapInteriorCeiling.UValue = System.Convert.ToDouble(interiorCeilingObject.CustomData["UValue"]);

            sapInteriorCeiling.ResultantUValue = System.Convert.ToDouble(interiorCeilingObject.CustomData["Ru"]);

            sapInteriorCeiling.Curtain = System.Convert.ToBoolean(interiorCeilingObject.CustomData["Curtain"]);

            sapInteriorCeiling.ManualInputKappa = System.Convert.ToBoolean(interiorCeilingObject.CustomData["OverRideK"]);

            sapInteriorCeiling.Kappa = System.Convert.ToDouble(interiorCeilingObject.CustomData["K"]);

            sapInteriorCeiling.Dims = ToDims((interiorCeilingObject.CustomData["Dims"] as List<object>).Cast<CustomObject>().ToList()); ;


            sapInteriorCeiling.UValueSelectionID = System.Convert.ToInt32(interiorCeilingObject.CustomData["UValueSelectionId"]);

            sapInteriorCeiling.UValueSelected = System.Convert.ToBoolean(interiorCeilingObject.CustomData["UValueSelected"]);

            sapInteriorCeiling.EnergyPerformanceCertificateDescription = interiorCeilingObject.CustomData["EpcDescription"] as CustomObject;

            sapInteriorCeiling.LoftInsulation = interiorCeilingObject.CustomData["LoftInsulation"] as CustomObject;

            return sapInteriorCeiling;
        }
    }
}
