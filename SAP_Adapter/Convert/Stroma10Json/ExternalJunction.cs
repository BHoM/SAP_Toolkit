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
using System.ComponentModel;
using System.Text;
using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static List<BH.oM.Environment.SAP.Stroma10.ExternalJunction> ToExternalJunctions(List<CustomObject> externalJunctionsObject)
        {
            if (externalJunctionsObject == null)
                return null;

            List<BH.oM.Environment.SAP.Stroma10.ExternalJunction> rtn = new List<BH.oM.Environment.SAP.Stroma10.ExternalJunction>();
            foreach (var value in externalJunctionsObject)
            {
                rtn.Add(ToExternalJunction(value));
            }

            return rtn;
        }

        public static BH.oM.Environment.SAP.Stroma10.ExternalJunction ToExternalJunction(CustomObject externalJunctionObject)
        {
            if (externalJunctionObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.ExternalJunction sapExternalJunction = new BH.oM.Environment.SAP.Stroma10.ExternalJunction();
            sapExternalJunction.ID = System.Convert.ToInt32(externalJunctionObject.CustomData["Id"]);
            sapExternalJunction.BHoM_Guid = (Guid.Parse(externalJunctionObject.CustomData["Guid"] as string));
            sapExternalJunction.Reference = externalJunctionObject.CustomData["Ref"] as string;
            sapExternalJunction.JunctionDetail = externalJunctionObject.CustomData["JunctionDetail"] as string;
            sapExternalJunction.ThermalTransmittance = System.Convert.ToDouble(externalJunctionObject.CustomData["ThermalTransmittance"]);
            sapExternalJunction.Length = System.Convert.ToDouble(externalJunctionObject.CustomData["Length"]);
            sapExternalJunction.IsAccredited = System.Convert.ToBoolean(externalJunctionObject.CustomData["IsAccredited"]);
            sapExternalJunction.IsDefault = System.Convert.ToBoolean(externalJunctionObject.CustomData["IsDefault"]);
            sapExternalJunction.Accredited = System.Convert.ToDouble(externalJunctionObject.CustomData["Accredited"]);
            sapExternalJunction.Default = System.Convert.ToDouble(externalJunctionObject.CustomData["Default"]);
            sapExternalJunction.Notes = externalJunctionObject.CustomData["Notes"] as string;
            sapExternalJunction.RowIDCreated = System.Convert.ToBoolean(externalJunctionObject.CustomData["RowIdCreated"]);
            sapExternalJunction.ImportLength = System.Convert.ToBoolean(externalJunctionObject.CustomData["ImportLenght"]);
            sapExternalJunction.Count = System.Convert.ToInt32(externalJunctionObject.CustomData["Count"]);
            sapExternalJunction.Result = System.Convert.ToDouble(externalJunctionObject.CustomData["Result"]);

            return sapExternalJunction;
        }

        public static Dictionary<string, object> FromExternalJunction(ExternalJunction obj)
        {
            if (obj == null)
                return null;

            Dictionary<string, object> rtn = new Dictionary<string, object>();
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
