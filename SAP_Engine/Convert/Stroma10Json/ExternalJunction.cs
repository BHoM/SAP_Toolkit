using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using BH.oM.Base;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {

        public static List<BH.oM.Environment.SAP.Stroma10.ExternalJunction> ToExternalJunctions(CustomObject externalJunctionsObject)
        {
            List<BH.oM.Environment.SAP.Stroma10.ExternalJunction> rtn = new List<BH.oM.Environment.SAP.Stroma10.ExternalJunction>();

            foreach (var value in externalJunctionsObject.CustomData["ExternalJunctions"] as List<CustomObject>)
            { 
                rtn.Add(ToExternalJunction(value));
            }
            return rtn; 
        }
        public static BH.oM.Environment.SAP.Stroma10.ExternalJunction ToExternalJunction(CustomObject externalJunctionObject)
        {
            BH.oM.Environment.SAP.Stroma10.ExternalJunction sapExternalJunction = new BH.oM.Environment.SAP.Stroma10.ExternalJunction();

            sapExternalJunction.ID = System.Convert.ToInt32(externalJunctionObject.CustomData["ID"]);

        
            sapExternalJunction.BHoM_Guid = (Guid)externalJunctionObject.CustomData["GUID"];

        
            sapExternalJunction.Reference = externalJunctionObject.CustomData["Reference"] as string; 

        
            sapExternalJunction.JunctionDetail = externalJunctionObject.CustomData["JunctionDetail"] as string; 

        
            sapExternalJunction.ThermalTransmittance = System.Convert.ToDouble(externalJunctionObject.CustomData["ThermalTransmittance"]); 

        
            sapExternalJunction.Length = System.Convert.ToDouble(externalJunctionObject.CustomData["Length"]); 

        
            sapExternalJunction.IsAccredited = System.Convert.ToBoolean(externalJunctionObject.CustomData["IsAccredited"]); 

        
            sapExternalJunction.IsDefault = System.Convert.ToBoolean(externalJunctionObject.CustomData["IsDefault"]); 

        
            sapExternalJunction.Accredited = System.Convert.ToDouble(externalJunctionObject.CustomData["Accredited"]); 

        
            sapExternalJunction.Default = System.Convert.ToDouble(externalJunctionObject.CustomData["Default"]); 

        
            sapExternalJunction.Notes = externalJunctionObject.CustomData["Notes"] as string; 

        
            sapExternalJunction.RowIDCreated = System.Convert.ToBoolean(externalJunctionObject.CustomData["RowIDCreated"]); 

        
            sapExternalJunction.ImportLength = System.Convert.ToBoolean(externalJunctionObject.CustomData["ImportLength"]); 

        
            sapExternalJunction.Count = System.Convert.ToInt32(externalJunctionObject.CustomData["Count"]); 

        
            sapExternalJunction.Result = System.Convert.ToDouble(externalJunctionObject.CustomData["Result"]);


            return sapExternalJunction;
        }
    }
}

