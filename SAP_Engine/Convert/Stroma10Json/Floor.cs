using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using BH.oM.Base;
using BH.oM.Environment.SAP;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static List<BH.oM.Environment.SAP.Stroma10.Floor> ToFloors(List<CustomObject> floorsObject)
        {

            if (floorsObject == null)
                return null;

            List<BH.oM.Environment.SAP.Stroma10.Floor> rtn = new List<BH.oM.Environment.SAP.Stroma10.Floor>();
            foreach (var value in floorsObject)
            {
                rtn.Add(ToFloor(value));
            }
            return rtn;
        }
        public static BH.oM.Environment.SAP.Stroma10.Floor ToFloor(CustomObject floorObject)
        {

            if (floorObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.Floor sapFloor = new BH.oM.Environment.SAP.Stroma10.Floor();

            sapFloor.ID = System.Convert.ToInt32(floorObject.CustomData["Id"]);

            sapFloor.BHoM_Guid = (Guid.Parse(floorObject.CustomData["Guid"]as string));

            sapFloor.Type = System.Convert.ToInt32(floorObject.CustomData["Type"]);

            sapFloor.Construction = System.Convert.ToInt32(floorObject.CustomData["Construction"]);

            sapFloor.Area = System.Convert.ToDouble(floorObject.CustomData["Area"]);

            sapFloor.UValueStart = System.Convert.ToDouble(floorObject.CustomData["UValueStart"]);

            sapFloor.UValue = System.Convert.ToDouble(floorObject.CustomData["UValue"]);

            sapFloor.ResultantUValue = System.Convert.ToDouble(floorObject.CustomData["Ru"]);

            sapFloor.Curtain = System.Convert.ToBoolean(floorObject.CustomData["Curtain"]);

            sapFloor.ManualInputKappa = System.Convert.ToBoolean(floorObject.CustomData["OverRideK"]);

            sapFloor.Kappa = System.Convert.ToDouble(floorObject.CustomData["K"]);

            ////////////////////////////////////
            

            sapFloor.Dims = ToDims((floorObject.CustomData["Dims"] as List<object>).Cast<CustomObject>().ToList());


            ////////////////////////////////////////

            sapFloor.UValueSelectionID = System.Convert.ToInt32(floorObject.CustomData["UValueSelectionId"]);

            sapFloor.UValueSelected = System.Convert.ToBoolean(floorObject.CustomData["UValueSelected"]);

            sapFloor.EnergyPerformanceCertificateDescription = floorObject.CustomData["EpcDescription"] as CustomObject;

            sapFloor.LoftInsulation = floorObject.CustomData["LoftInsulation"] as CustomObject;

            return sapFloor;
        }
    }
}
