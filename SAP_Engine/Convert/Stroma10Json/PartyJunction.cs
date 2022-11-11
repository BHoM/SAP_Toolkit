using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static List<BH.oM.Environment.SAP.Stroma10.PartyJunction> ToPartyJunctions(List<CustomObject> partyJunctionsObject)
        {
            if (partyJunctionsObject == null)
                return null;
            List<PartyJunction> rtn = new List<PartyJunction>();
            foreach (var value in partyJunctionsObject)
            {
                rtn.Add(ToPartyJunction(value));
            }
            return rtn;
        }
        public static BH.oM.Environment.SAP.Stroma10.PartyJunction ToPartyJunction(CustomObject partyJunctionObject)
        {
            if (partyJunctionObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.PartyJunction sapPartyJunction = new BH.oM.Environment.SAP.Stroma10.PartyJunction();

            sapPartyJunction.ID = System.Convert.ToInt32(partyJunctionObject.CustomData["Id"]);


            sapPartyJunction.BHoM_Guid = (Guid.Parse(partyJunctionObject.CustomData["Guid"] as string));

            
            sapPartyJunction.Reference = partyJunctionObject.CustomData["Ref"] as string; 

            
            sapPartyJunction.JunctionDetail = partyJunctionObject.CustomData["JunctionDetail"] as string; 

            
            sapPartyJunction.ThermalTransmittance = System.Convert.ToDouble(partyJunctionObject.CustomData["ThermalTransmittance"]); 

            
            sapPartyJunction.Length = System.Convert.ToDouble(partyJunctionObject.CustomData["Length"]); 

            
            sapPartyJunction.IsAccredited = System.Convert.ToBoolean(partyJunctionObject.CustomData["IsAccredited"]);


            sapPartyJunction.IsDefault = System.Convert.ToBoolean(partyJunctionObject.CustomData["IsDefault"]);


            sapPartyJunction.Accredited = System.Convert.ToDouble(partyJunctionObject.CustomData["Accredited"]);


            sapPartyJunction.Default = System.Convert.ToDouble(partyJunctionObject.CustomData["Default"]); 


            sapPartyJunction.Notes = (partyJunctionObject.CustomData["Notes"] as CustomObject); 

            
            sapPartyJunction.RowIDCreated = System.Convert.ToBoolean(partyJunctionObject.CustomData["RowIdCreated"]); 

            
            sapPartyJunction.ImportLength = System.Convert.ToBoolean(partyJunctionObject.CustomData["ImportLenght"]); //

            
            sapPartyJunction.Count = System.Convert.ToInt32(partyJunctionObject.CustomData["Count"]); 

            
            sapPartyJunction.Result = System.Convert.ToDouble(partyJunctionObject.CustomData["Result"]); 

            return sapPartyJunction;
        }
    }
}
