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
        public static List<BH.oM.Environment.SAP.Stroma10.PartyWall> ToPartyWalls(List<CustomObject> partyWallsObject)
        {
            if (partyWallsObject == null)
                return null;

            List<PartyWall> rtn = new List<PartyWall>();
            foreach (var value in partyWallsObject)
            {
                rtn.Add(ToPartyWall(value));
            }
            return rtn;
        }
        public static BH.oM.Environment.SAP.Stroma10.PartyWall ToPartyWall(CustomObject partyWallObject)
        {
            if (partyWallObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.PartyWall sapPartyWall = new BH.oM.Environment.SAP.Stroma10.PartyWall();

            sapPartyWall.ID = System.Convert.ToInt32(partyWallObject.CustomData["Id"]);

            sapPartyWall.BHoM_Guid = (Guid.Parse(partyWallObject.CustomData["Guid"] as string));

            sapPartyWall.Type = System.Convert.ToInt32(partyWallObject.CustomData["Type"]);

            sapPartyWall.Construction = System.Convert.ToInt32(partyWallObject.CustomData["Construction"]);

            sapPartyWall.Area = System.Convert.ToDouble(partyWallObject.CustomData["Area"]);

            sapPartyWall.UValueStart = System.Convert.ToDouble(partyWallObject.CustomData["UValueStart"]);

            sapPartyWall.UValue = System.Convert.ToDouble(partyWallObject.CustomData["UValue"]);

            sapPartyWall.ResultantUValue = System.Convert.ToDouble(partyWallObject.CustomData["Ru"]);

            sapPartyWall.Curtain = System.Convert.ToBoolean(partyWallObject.CustomData["Curtain"]);

            sapPartyWall.ManualInputKappa = System.Convert.ToBoolean(partyWallObject.CustomData["OverRideK"]);

            sapPartyWall.Kappa = System.Convert.ToDouble(partyWallObject.CustomData["K"]);

            sapPartyWall.Dims = ToDims((partyWallObject.CustomData["Dims"] as List<object>).Cast<CustomObject>().ToList());

            sapPartyWall.UValueSelectionID = System.Convert.ToInt32(partyWallObject.CustomData["UValueSelectionId"]);

            sapPartyWall.UValueSelected = System.Convert.ToBoolean(partyWallObject.CustomData["UValueSelected"]);

            sapPartyWall.EnergyPerformanceCertificateDescription = partyWallObject.CustomData["EpcDescription"] as CustomObject;

            sapPartyWall.LoftInsulation = partyWallObject.CustomData["LoftInsulation"] as CustomObject;

            return sapPartyWall;
        }
    }
}
