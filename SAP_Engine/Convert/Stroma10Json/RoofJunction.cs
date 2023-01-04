/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2023, the respective contributors. All rights reserved.
 *
 * Each contributor holds copyright over their respective contributions.
 * The project versioning (Git) records all such contribution source information.
 *                                           
 *                                                                              
 * The BHoM is free software: you can redistribute it and/or modify         
 * it under the terms of the GNU Lesser General Public License as published by  
 * the Free Software Foundation, either version 3.0 of the License, or          
 * (at your option) any later version.                                          
 *                                                                              
 * The BHoM is distributed in the hope that it will be useful,              
 * but WITHOUT ANY WARRANTY; without even the implied warranty of               
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
 * GNU Lesser General Public License for more details.                          
 *                                                                            
 * You should have received a copy of the GNU Lesser General Public License     
 * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
 */
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
            sapRoofJunction.Notes = (roofJunctionObject.CustomData["Notes"] as string);
            sapRoofJunction.RowIDCreated = System.Convert.ToBoolean(roofJunctionObject.CustomData["RowIdCreated"]);
            sapRoofJunction.ImportLength = System.Convert.ToBoolean(roofJunctionObject.CustomData["ImportLenght"]);
            sapRoofJunction.Count = System.Convert.ToInt32(roofJunctionObject.CustomData["Count"]);
            sapRoofJunction.Result = System.Convert.ToDouble(roofJunctionObject.CustomData["Result"]);
            return sapRoofJunction;
        }

        public static Dictionary<string, object> FromRoofJunction(RoofJunction obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();
            if (obj == null)
                return null;
            rtn.Add("Id", obj.ID);
            rtn.Add("Guid", obj.BHoM_Guid.ToString());
            rtn.Add("Ref", obj.Reference);
            rtn.Add("JunctionDetail", obj.JunctionDetail);
            rtn.Add("ThermalTransmittance", obj.ThermalTransmittance);
            rtn.Add("Length", obj.Length);
            rtn.Add("IsAccredited", obj.IsAccredited);
            rtn.Add("IsDefault", obj.IsDefault);
            rtn.Add("Accredited", obj.Accredited);
            rtn.Add("Default", obj.Default);
            rtn.Add("Notes", obj.Notes);
            rtn.Add("RowIdCreated", obj.RowIDCreated);
            rtn.Add("ImportLenght", obj.ImportLength);
            rtn.Add("Count", obj.Count);
            rtn.Add("Result", obj.Result);
            return rtn;
        }
    }
}
