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
        public static List<BH.oM.Environment.SAP.Stroma10.PartyFloor> ToPartyFloors(List<CustomObject> partyFloorsObject)
        {
            if (partyFloorsObject == null)
                return null;

            List<PartyFloor> rtn = new List<PartyFloor>();
            foreach (var value in partyFloorsObject)
            {
                rtn.Add(ToPartyFloor(value));
            }
            return rtn;
        }
        public static BH.oM.Environment.SAP.Stroma10.PartyFloor ToPartyFloor(CustomObject partyFloorObject)
        {
            if (partyFloorObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.PartyFloor sapPartyFloor = new BH.oM.Environment.SAP.Stroma10.PartyFloor();

            sapPartyFloor.ID = System.Convert.ToInt32(partyFloorObject.CustomData["Id"]);

            sapPartyFloor.BHoM_Guid = (Guid.Parse(partyFloorObject.CustomData["Guid"] as string));

            sapPartyFloor.Name = partyFloorObject.Name;

            sapPartyFloor.Type = System.Convert.ToInt32(partyFloorObject.CustomData["Type"]);

            sapPartyFloor.Construction = System.Convert.ToInt32(partyFloorObject.CustomData["Construction"]);

            sapPartyFloor.Area = System.Convert.ToDouble(partyFloorObject.CustomData["Area"]);

            sapPartyFloor.UValueStart = System.Convert.ToDouble(partyFloorObject.CustomData["UValueStart"]);

            sapPartyFloor.UValue = System.Convert.ToDouble(partyFloorObject.CustomData["UValue"]);

            sapPartyFloor.ResultantUValue = System.Convert.ToDouble(partyFloorObject.CustomData["Ru"]);

            sapPartyFloor.Curtain = System.Convert.ToBoolean(partyFloorObject.CustomData["Curtain"]);

            sapPartyFloor.ManualInputKappa = System.Convert.ToBoolean(partyFloorObject.CustomData["OverRideK"]);

            sapPartyFloor.Kappa = System.Convert.ToDouble(partyFloorObject.CustomData["K"]);

            sapPartyFloor.Dims = ToDims((partyFloorObject.CustomData["Dims"] as List<object>).Cast<CustomObject>().ToList()); 

            sapPartyFloor.UValueSelectionID = System.Convert.ToInt32(partyFloorObject.CustomData["UValueSelectionId"]);

            sapPartyFloor.UValueSelected = System.Convert.ToBoolean(partyFloorObject.CustomData["UValueSelected"]);

            sapPartyFloor.EnergyPerformanceCertificateDescription = partyFloorObject.CustomData["EpcDescription"] as string;

            sapPartyFloor.LoftInsulation = partyFloorObject.CustomData["LoftInsulation"] as string;

            return sapPartyFloor;
        }
        public static Dictionary<string, object> FromPartyFloor(PartyFloor obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();

            if (obj == null)
                return null;

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

            if (obj.Dims != null && obj.Dims.Any(x => x != null))
                rtn.Add("Dims", obj.Dims.Select(x => FromDim(x)).ToList());
            else
            {
                List<object> temp = new List<object>();
                rtn.Add("Dims", temp);
            }


            rtn.Add("UValueSelectionId", obj.UValueSelectionID);

            rtn.Add("UValueSelected", obj.UValueSelected);

            rtn.Add("EpcDescription", obj.EnergyPerformanceCertificateDescription);

            rtn.Add("LoftInsulation", obj.LoftInsulation);

            return rtn;
        }
    }
}
