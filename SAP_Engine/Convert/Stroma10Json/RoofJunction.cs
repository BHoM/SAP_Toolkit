using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static List<BH.oM.Environment.SAP.Stroma10.RoofJunction> ToRoofJunctions(List<CustomObject> roofJunctionsObject)
        {
            if (roofJunctionsObject == null)
                return null;
            
            List<RoofJunction> rtn = new List<RoofJunction>();
            foreach (var value in roofJunctionsObject)
            {
                rtn.Add(ToRoofJunction(value));
            }
            return rtn;
        }
        public static BH.oM.Environment.SAP.Stroma10.RoofJunction ToRoofJunction(CustomObject roofJunctionObject)
        {
            if (roofJunctionObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.RoofJunction sapRoofJunction = new BH.oM.Environment.SAP.Stroma10.RoofJunction();

            sapRoofJunction.ID = System.Convert.ToInt32(roofJunctionObject.CustomData["Id"]);


            sapRoofJunction.BHoM_Guid = (Guid.Parse(roofJunctionObject.CustomData["Guid"] as string));


            sapRoofJunction.Reference = roofJunctionObject.CustomData["Ref"] as string;


            sapRoofJunction.JunctionDetail = roofJunctionObject.CustomData["JunctionDetail"] as string;


            sapRoofJunction.ThermalTransmittance = System.Convert.ToDouble(roofJunctionObject.CustomData["ThermalTransmittance"]);


            sapRoofJunction.Length = System.Convert.ToDouble(roofJunctionObject.CustomData["Length"]);


            sapRoofJunction.IsAccredited = System.Convert.ToBoolean(roofJunctionObject.CustomData["IsAccredited"]);


            sapRoofJunction.IsDefault = System.Convert.ToBoolean(roofJunctionObject.CustomData["IsDefault"]);


            sapRoofJunction.Accredited = System.Convert.ToDouble(roofJunctionObject.CustomData["Accredited"]);


            sapRoofJunction.Default = System.Convert.ToDouble(roofJunctionObject.CustomData["Default"]);


            sapRoofJunction.Notes = (roofJunctionObject.CustomData["Notes"] as CustomObject);


            sapRoofJunction.RowIDCreated = System.Convert.ToBoolean(roofJunctionObject.CustomData["RowIdCreated"]);


            sapRoofJunction.ImportLength = System.Convert.ToBoolean(roofJunctionObject.CustomData["ImportLenght"]);//


            sapRoofJunction.Count = System.Convert.ToInt32(roofJunctionObject.CustomData["Count"]);


            sapRoofJunction.Result = System.Convert.ToDouble(roofJunctionObject.CustomData["Result"]);

            return sapRoofJunction;
        }
    }
}
