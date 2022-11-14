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
        public static List<BH.oM.Environment.SAP.Stroma10.InteriorFloor> ToInteriorFloors(List<CustomObject> interiorFloorsObject)
        {
            if (interiorFloorsObject == null)
                return null;

            List<InteriorFloor> rtn = new List<InteriorFloor>();
            foreach (var value in interiorFloorsObject)
            {
                rtn.Add(ToInteriorFloor(value));
            }
            return rtn;
        }
        public static BH.oM.Environment.SAP.Stroma10.InteriorFloor ToInteriorFloor(CustomObject interiorFloorObject)
        {
            
            if (interiorFloorObject == null)
                return null;
           

            BH.oM.Environment.SAP.Stroma10.InteriorFloor sapInteriorFloor = new BH.oM.Environment.SAP.Stroma10.InteriorFloor();

            sapInteriorFloor.ID = System.Convert.ToInt32(interiorFloorObject.CustomData["Id"]);

            sapInteriorFloor.BHoM_Guid = (Guid.Parse(interiorFloorObject.CustomData["Guid"] as string));

            sapInteriorFloor.Name = interiorFloorObject.Name;

            sapInteriorFloor.Type = System.Convert.ToInt32(interiorFloorObject.CustomData["Type"]);

            sapInteriorFloor.Construction = System.Convert.ToInt32(interiorFloorObject.CustomData["Construction"]);

            sapInteriorFloor.Area = System.Convert.ToDouble(interiorFloorObject.CustomData["Area"]);

            sapInteriorFloor.UValueStart = System.Convert.ToDouble(interiorFloorObject.CustomData["UValueStart"]);

            sapInteriorFloor.UValue = System.Convert.ToDouble(interiorFloorObject.CustomData["UValue"]);

            sapInteriorFloor.ResultantUValue = System.Convert.ToDouble(interiorFloorObject.CustomData["Ru"]);

            sapInteriorFloor.Curtain = System.Convert.ToBoolean(interiorFloorObject.CustomData["Curtain"]);

            sapInteriorFloor.ManualInputKappa = System.Convert.ToBoolean(interiorFloorObject.CustomData["OverRideK"]);

            sapInteriorFloor.Kappa = System.Convert.ToDouble(interiorFloorObject.CustomData["K"]);

            sapInteriorFloor.Dims = ToDims((interiorFloorObject.CustomData["Dims"] as List<object>).Cast<CustomObject>().ToList());

            sapInteriorFloor.UValueSelectionID = System.Convert.ToInt32(interiorFloorObject.CustomData["UValueSelectionId"]);

            sapInteriorFloor.UValueSelected = System.Convert.ToBoolean(interiorFloorObject.CustomData["UValueSelected"]);

            sapInteriorFloor.EnergyPerformanceCertificateDescription = interiorFloorObject.CustomData["EpcDescription"] as CustomObject;

            sapInteriorFloor.LoftInsulation = interiorFloorObject.CustomData["LoftInsulation"] as CustomObject;

            return sapInteriorFloor;
        }
        public static Dictionary<string, object> FromInteriorFloor(InteriorFloor obj)
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
