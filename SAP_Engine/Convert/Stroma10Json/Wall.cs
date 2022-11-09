using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static List<BH.oM.Environment.SAP.Stroma10.Wall> ToWalls(CustomObject wallsObject)
        {
            List<BH.oM.Environment.SAP.Stroma10.Wall> rtn = new List<BH.oM.Environment.SAP.Stroma10.Wall>();
            foreach (var value in wallsObject.CustomData["Walls"] as List<CustomObject>)
            {
                rtn.Add(ToWall(value));
            }
            return rtn;
        }
        public static BH.oM.Environment.SAP.Stroma10.Wall ToWall(CustomObject wallObject)
        {
            BH.oM.Environment.SAP.Stroma10.Wall sapWall = new BH.oM.Environment.SAP.Stroma10.Wall();

            sapWall.ID = System.Convert.ToInt32(wallObject.CustomData["ID"]);

            sapWall.BHoM_Guid = (Guid)wallObject.CustomData["GUID"];

            sapWall.Type = System.Convert.ToInt32(wallObject.CustomData["Type"]);

            sapWall.Construction = System.Convert.ToInt32(wallObject.CustomData["Construction"]);

            sapWall.Area = System.Convert.ToDouble(wallObject.CustomData["Area"]);

            sapWall.UValueStart = System.Convert.ToDouble(wallObject.CustomData["UValueStart"]);

            sapWall.UValue = System.Convert.ToDouble(wallObject.CustomData["UValue"]);

            sapWall.ResultantUValue = System.Convert.ToDouble(wallObject.CustomData["ResultantUValue"]);

            sapWall.Curtain = System.Convert.ToBoolean(wallObject.CustomData["Curtain"]);

            sapWall.ManualInputKappa = System.Convert.ToBoolean(wallObject.CustomData["ManualInputKappa"]);

            sapWall.Kappa = System.Convert.ToDouble(wallObject.CustomData["Kappa"]);

            sapWall.Dims = ToDims(wallObject.CustomData["Dims"] as CustomObject);

            sapWall.UValueSelectionID = System.Convert.ToInt32(wallObject.CustomData["UValueSelectionID"]);

            sapWall.UValueSelected = System.Convert.ToBoolean(wallObject.CustomData["UValueSelected"]);

            sapWall.EnergyPerformanceCertificateDescription = wallObject.CustomData["EnergyPerformanceCertificateDescription"] as CustomObject;

            sapWall.LoftInsulation = wallObject.CustomData["LoftInsulation"] as CustomObject;

            return sapWall;
        }
    }
}
