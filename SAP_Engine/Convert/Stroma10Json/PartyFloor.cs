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

            sapPartyFloor.EnergyPerformanceCertificateDescription = partyFloorObject.CustomData["EpcDescription"] as CustomObject;

            sapPartyFloor.LoftInsulation = partyFloorObject.CustomData["LoftInsulation"] as CustomObject;

            return sapPartyFloor;
        }
    }
}
