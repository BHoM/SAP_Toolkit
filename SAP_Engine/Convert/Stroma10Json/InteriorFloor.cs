using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static List<BH.oM.Environment.SAP.Stroma10.InteriorFloor> ToInteriorFloors(CustomObject interiorFloorsObject)
        {
            List<InteriorFloor> rtn = new List<InteriorFloor>();
            foreach (var value in interiorFloorsObject.CustomData["InteriorFloors"] as List<CustomObject>)
            {
                rtn.Add(ToInteriorFloor(value));
            }
            return rtn;
        }
        public static BH.oM.Environment.SAP.Stroma10.InteriorFloor ToInteriorFloor(CustomObject interiorFloorObject)
        {
            BH.oM.Environment.SAP.Stroma10.InteriorFloor sapInteriorFloor = new BH.oM.Environment.SAP.Stroma10.InteriorFloor();

            sapInteriorFloor.ID = System.Convert.ToInt32(interiorFloorObject.CustomData["ID"]);

            sapInteriorFloor.BHoM_Guid = (Guid)interiorFloorObject.CustomData["GUID"];

            sapInteriorFloor.Type = System.Convert.ToInt32(interiorFloorObject.CustomData["Type"]);

            sapInteriorFloor.Construction = System.Convert.ToInt32(interiorFloorObject.CustomData["Construction"]);

            sapInteriorFloor.Area = System.Convert.ToDouble(interiorFloorObject.CustomData["Area"]);

            sapInteriorFloor.UValueStart = System.Convert.ToDouble(interiorFloorObject.CustomData["UValueStart"]);

            sapInteriorFloor.UValue = System.Convert.ToDouble(interiorFloorObject.CustomData["UValue"]);

            sapInteriorFloor.ResultantUValue = System.Convert.ToDouble(interiorFloorObject.CustomData["ResultantUValue"]);

            sapInteriorFloor.Curtain = System.Convert.ToBoolean(interiorFloorObject.CustomData["Curtain"]);

            sapInteriorFloor.ManualInputKappa = System.Convert.ToBoolean(interiorFloorObject.CustomData["ManualInputKappa"]);

            sapInteriorFloor.Kappa = System.Convert.ToDouble(interiorFloorObject.CustomData["Kappa"]);

            //Null Value
            sapInteriorFloor.Dims = (List<object>)interiorFloorObject.CustomData["Dims"];

            sapInteriorFloor.UValueSelectionID = System.Convert.ToInt32(interiorFloorObject.CustomData["UValueSelectionID"]);

            sapInteriorFloor.UValueSelected = System.Convert.ToBoolean(interiorFloorObject.CustomData["UValueSelected"]);

            sapInteriorFloor.EnergyPerformanceCertificateDescription = interiorFloorObject.CustomData["EnergyPerformanceCertificateDescription"] as CustomObject;

            sapInteriorFloor.LoftInsulation = interiorFloorObject.CustomData["LoftInsulation"] as CustomObject;

            return sapInteriorFloor;
        }
    }
}
