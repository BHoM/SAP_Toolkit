using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static List<BH.oM.Environment.SAP.Stroma10.Wall> ToWalls(List<CustomObject> wallsObject)
        {
            if (wallsObject == null)
                return null;

            List<BH.oM.Environment.SAP.Stroma10.Wall> rtn = new List<BH.oM.Environment.SAP.Stroma10.Wall>();
            foreach (var value in wallsObject)
            {
                rtn.Add(ToWall(value));
            }
            return rtn;
        }
        public static BH.oM.Environment.SAP.Stroma10.Wall ToWall(CustomObject wallObject)
        {
            if (wallObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.Wall sapWall = new BH.oM.Environment.SAP.Stroma10.Wall();

            sapWall.ID = System.Convert.ToInt32(wallObject.CustomData["Id"]);

            sapWall.BHoM_Guid = (Guid.Parse(wallObject.CustomData["Guid"] as string));

            sapWall.Type = System.Convert.ToInt32(wallObject.CustomData["Type"]);

            sapWall.Construction = System.Convert.ToInt32(wallObject.CustomData["Construction"]);

            sapWall.Area = System.Convert.ToDouble(wallObject.CustomData["Area"]);

            sapWall.UValueStart = System.Convert.ToDouble(wallObject.CustomData["UValueStart"]);

            sapWall.UValue = System.Convert.ToDouble(wallObject.CustomData["UValue"]);

            sapWall.ResultantUValue = System.Convert.ToDouble(wallObject.CustomData["Ru"]);

            sapWall.Curtain = System.Convert.ToBoolean(wallObject.CustomData["Curtain"]);

            sapWall.ManualInputKappa = System.Convert.ToBoolean(wallObject.CustomData["OverRideK"]);

            sapWall.Kappa = System.Convert.ToDouble(wallObject.CustomData["K"]);

            sapWall.Dims = ToDims((wallObject.CustomData["Dims"] as List<object>).Cast<CustomObject>().ToList());

            sapWall.UValueSelectionID = System.Convert.ToInt32(wallObject.CustomData["UValueSelectionId"]);

            sapWall.UValueSelected = System.Convert.ToBoolean(wallObject.CustomData["UValueSelected"]);

            sapWall.EnergyPerformanceCertificateDescription = wallObject.CustomData["EpcDescription"] as CustomObject;

            sapWall.LoftInsulation = wallObject.CustomData["LoftInsulation"] as CustomObject;

            return sapWall;
        }
    }
}
