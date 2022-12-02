/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2022, the respective contributors. All rights reserved.
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
        public static BH.oM.Environment.SAP.Stroma10.Address ToAddress(CustomObject addressObject)
        {
            if (addressObject == null)
                return null;
            BH.oM.Environment.SAP.Stroma10.Address sapAddress = new BH.oM.Environment.SAP.Stroma10.Address();
            sapAddress.ID = System.Convert.ToInt32(addressObject.CustomData["Id"]);
            sapAddress.AddressLine1 = addressObject.CustomData["AddressLine1"] as string;
            sapAddress.AddressLine2 = addressObject.CustomData["AddressLine2"] as string;
            sapAddress.AddressLine3 = addressObject.CustomData["AddressLine3"] as string;
            sapAddress.City = addressObject.CustomData["City"] as string;
            sapAddress.Postcode = addressObject.CustomData["Postcode"] as string;
            sapAddress.UniquePropertyReferenceNumber = addressObject.CustomData["Uprn"] as string;
            sapAddress.Country = addressObject.CustomData["Country"] as string;
            sapAddress.DisplayAddress = addressObject.CustomData["DisplayAddress"] as string;
            return sapAddress;
        }

        public static Dictionary<string, object> FromAddress(BH.oM.Environment.SAP.Stroma10.Address obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();
            if (obj == null)
                return null;
            rtn.Add("Id", obj.ID);
            rtn.Add("AddressLine1", obj.AddressLine1);
            rtn.Add("AddressLine2", obj.AddressLine2);
            rtn.Add("AddressLine3", obj.AddressLine3);
            rtn.Add("City", obj.City);
            rtn.Add("Postcode", obj.Postcode);
            rtn.Add("Uprn", obj.UniquePropertyReferenceNumber);
            rtn.Add("Country", obj.Country);
            rtn.Add("DisplayAddress", obj.DisplayAddress);
            return rtn;
        }
    }
}