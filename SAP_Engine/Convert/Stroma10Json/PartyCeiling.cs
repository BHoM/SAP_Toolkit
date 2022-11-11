using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static List<BH.oM.Environment.SAP.Stroma10.PartyCeiling> ToPartyCeilings(List<CustomObject> partyCeilingsObject)
        {
            if (partyCeilingsObject == null)
                return null;

            List<PartyCeiling> rtn = new List<PartyCeiling>();
            foreach (var value in partyCeilingsObject)
            {
                rtn.Add(ToPartyCeiling(value));
            }
            return rtn;
        }
        public static BH.oM.Environment.SAP.Stroma10.PartyCeiling ToPartyCeiling(CustomObject partyCeilingObject)
        {
            if (partyCeilingObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.PartyCeiling sapPartyCeiling = new BH.oM.Environment.SAP.Stroma10.PartyCeiling();

            sapPartyCeiling.ID = System.Convert.ToInt32(partyCeilingObject.CustomData["Id"]);

            sapPartyCeiling.BHoM_Guid = (Guid.Parse(partyCeilingObject.CustomData["Guid"] as string));

            sapPartyCeiling.Type = System.Convert.ToInt32(partyCeilingObject.CustomData["Type"]);

            sapPartyCeiling.Construction = System.Convert.ToInt32(partyCeilingObject.CustomData["Construction"]);

            sapPartyCeiling.Area = System.Convert.ToDouble(partyCeilingObject.CustomData["Area"]);

            sapPartyCeiling.UValueStart = System.Convert.ToDouble(partyCeilingObject.CustomData["UValueStart"]);

            sapPartyCeiling.UValue = System.Convert.ToDouble(partyCeilingObject.CustomData["UValue"]);

            sapPartyCeiling.ResultantUValue = System.Convert.ToDouble(partyCeilingObject.CustomData["Ru"]);

            sapPartyCeiling.Curtain = System.Convert.ToBoolean(partyCeilingObject.CustomData["Curtain"]);

            sapPartyCeiling.ManualInputKappa = System.Convert.ToBoolean(partyCeilingObject.CustomData["OverRideK"]);

            sapPartyCeiling.Kappa = System.Convert.ToDouble(partyCeilingObject.CustomData["K"]);

            sapPartyCeiling.Dims = ToDims((partyCeilingObject.CustomData["Dims"] as List<object>).Cast<CustomObject>().ToList());

            sapPartyCeiling.UValueSelectionID = System.Convert.ToInt32(partyCeilingObject.CustomData["UValueSelectionId"]);

            sapPartyCeiling.UValueSelected = System.Convert.ToBoolean(partyCeilingObject.CustomData["UValueSelected"]);

            sapPartyCeiling.EnergyPerformanceCertificateDescription = partyCeilingObject.CustomData["EpcDescription"] as CustomObject;

            sapPartyCeiling.LoftInsulation = partyCeilingObject.CustomData["LoftInsulation"] as CustomObject;

            return sapPartyCeiling;
        }
    }
}
