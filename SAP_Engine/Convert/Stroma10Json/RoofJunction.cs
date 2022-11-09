using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static List<BH.oM.Environment.SAP.Stroma10.RoofJunction> ToRoofJunctions(CustomObject roofJunctionsObject)
        {
            List<RoofJunction> rtn = new List<RoofJunction>();
            foreach (var value in roofJunctionsObject.CustomData["RoofJunctions"] as List<CustomObject>)
            {
                rtn.Add(ToRoofJunction(value));
            }
            return rtn;
        }
        public static BH.oM.Environment.SAP.Stroma10.RoofJunction ToRoofJunction(CustomObject roofJunctionObject)
        {
            BH.oM.Environment.SAP.Stroma10.RoofJunction sapRoofJunction = new BH.oM.Environment.SAP.Stroma10.RoofJunction();

            sapRoofJunction.ID = System.Convert.ToInt32(roofJunctionObject.CustomData["ID"]);


            sapRoofJunction.BHoM_Guid = (Guid)roofJunctionObject.CustomData["GUID"];


            sapRoofJunction.Reference = roofJunctionObject.CustomData["Reference"] as string;


            sapRoofJunction.JunctionDetail = roofJunctionObject.CustomData["JunctionDetail"] as string;


            sapRoofJunction.ThermalTransmittance = System.Convert.ToDouble(roofJunctionObject.CustomData["ThermalTransmittance"]);


            sapRoofJunction.Length = System.Convert.ToDouble(roofJunctionObject.CustomData["Length"]);


            sapRoofJunction.IsAccredited = System.Convert.ToBoolean(roofJunctionObject.CustomData["IsAccredited"]);


            sapRoofJunction.IsDefault = System.Convert.ToBoolean(roofJunctionObject.CustomData["IsDefault"]);


            sapRoofJunction.Accredited = System.Convert.ToDouble(roofJunctionObject.CustomData["Accredited"]);


            sapRoofJunction.Default = System.Convert.ToDouble(roofJunctionObject.CustomData["Default"]);


            sapRoofJunction.Notes = (roofJunctionObject.CustomData["Notes"] as CustomObject);


            sapRoofJunction.RowIDCreated = System.Convert.ToBoolean(roofJunctionObject.CustomData["RowIDCreated"]);


            sapRoofJunction.ImportLength = System.Convert.ToBoolean(roofJunctionObject.CustomData["ImportLength"]);


            sapRoofJunction.Count = System.Convert.ToInt32(roofJunctionObject.CustomData["Count"]);


            sapRoofJunction.Result = System.Convert.ToDouble(roofJunctionObject.CustomData["Result"]);

            return sapRoofJunction;
        }
    }
}
