﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

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

            sapInteriorCeiling.Name = interiorCeilingObject.Name;

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
        public static Dictionary<string, object> FromInteriorCeiling(InteriorCeiling obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();

            rtn.Add("Id", obj.ID);
            rtn.Add("Guid", obj.BHoM_Guid.ToString());
            rtn.Add("Name", obj.Name);
            rtn.Add("Type", obj.Type);
            rtn.Add("Construction", obj.Construction);
            rtn.Add("Area", obj.Area);
            rtn.Add("UValueStart", obj.UValueStart);
            rtn.Add("UValue", obj.UValue);
            rtn.Add("Ru", obj.ResultantUValue);
            rtn.Add("Curtain", obj.Curtain);
            rtn.Add("OverRideK", obj.ManualInputKappa);
            rtn.Add("K", obj.Kappa);
            rtn.Add("Dims", obj.Dims.Select(x => FromDim(x)).ToList());
            rtn.Add("UValueSelectionId", obj.UValueSelectionID);
            rtn.Add("UValueSelected", obj.UValueSelected);
            rtn.Add("EpcDescription", obj.EnergyPerformanceCertificateDescription);
            rtn.Add("LoftInsulation", obj.LoftInsulation);


            return rtn;
        }
    }
}
