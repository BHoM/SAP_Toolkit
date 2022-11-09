using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;
using BH.oM.Environment.SAP;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static List<BH.oM.Environment.SAP.Stroma10.Floor> ToFloors(CustomObject floorsObject)
        {
            List<BH.oM.Environment.SAP.Stroma10.Floor> rtn = new List<BH.oM.Environment.SAP.Stroma10.Floor>();
            foreach (var value in floorsObject.CustomData["Floors"] as List<CustomObject>)
            {
                rtn.Add(ToFloor(value));
            }
            return rtn;
        }
        public static BH.oM.Environment.SAP.Stroma10.Floor ToFloor(CustomObject floorObject)
        {
            BH.oM.Environment.SAP.Stroma10.Floor sapFloor = new BH.oM.Environment.SAP.Stroma10.Floor();

            sapFloor.ID = System.Convert.ToInt32(floorObject.CustomData["ID"]);

            sapFloor.BHoM_Guid = (Guid)floorObject.CustomData["GUID"];

            sapFloor.Type = System.Convert.ToInt32(floorObject.CustomData["Type"]);

            sapFloor.Construction = System.Convert.ToInt32(floorObject.CustomData["Construction"]);

            sapFloor.Area = System.Convert.ToDouble(floorObject.CustomData["Area"]);

            sapFloor.UValueStart = System.Convert.ToDouble(floorObject.CustomData["UValueStart"]);

            sapFloor.UValue = System.Convert.ToDouble(floorObject.CustomData["UValue"]);

            sapFloor.ResultantUValue = System.Convert.ToDouble(floorObject.CustomData["ResultantUValue"]);

            sapFloor.Curtain = System.Convert.ToBoolean(floorObject.CustomData["Curtain"]);

            sapFloor.ManualInputKappa = System.Convert.ToBoolean(floorObject.CustomData["ManualInputKappa"]);

            sapFloor.Kappa = System.Convert.ToDouble(floorObject.CustomData["Kappa"]);

            sapFloor.Dims = ToDims(floorObject.CustomData["Dims"] as CustomObject);


            sapFloor.UValueSelectionID = System.Convert.ToInt32(floorObject.CustomData["UValueSelectionID"]);

            sapFloor.UValueSelected = System.Convert.ToBoolean(floorObject.CustomData["UValueSelected"]);

            sapFloor.EnergyPerformanceCertificateDescription = floorObject.CustomData["EnergyPerformanceCertificateDescription"] as CustomObject;

            sapFloor.LoftInsulation = floorObject.CustomData["LoftInsulation"] as CustomObject;

            return sapFloor;
        }
    }
}
