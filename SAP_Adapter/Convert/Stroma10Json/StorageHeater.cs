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
        public static List<BH.oM.Environment.SAP.Stroma10.StorageHeater> ToStorageHeaters(List<CustomObject> storageHeatersObject)
        {
            if (storageHeatersObject == null)
                return null;

            List<BH.oM.Environment.SAP.Stroma10.StorageHeater> rtn = new List<BH.oM.Environment.SAP.Stroma10.StorageHeater>();
            foreach (var value in storageHeatersObject)
            {
                rtn.Add(ToStorageHeater(value));
            }

            return rtn;
        }

        public static BH.oM.Environment.SAP.Stroma10.StorageHeater ToStorageHeater(CustomObject storageHeaterObject)
        {
            if (storageHeaterObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.StorageHeater sapStorageHeater = new BH.oM.Environment.SAP.Stroma10.StorageHeater();
            sapStorageHeater.ID = System.Convert.ToInt32(storageHeaterObject.CustomData["Id"]);
            sapStorageHeater.NumberOfHeaters = System.Convert.ToInt32(storageHeaterObject.CustomData["NumberOfHeaters"]);
            sapStorageHeater.IndexNumber = storageHeaterObject.CustomData["IndexNumber"] as string;
            sapStorageHeater.HighRetention = System.Convert.ToBoolean(storageHeaterObject.CustomData["HighRetention"]);
            sapStorageHeater.ManufacturerName = storageHeaterObject.CustomData["ManuName"] as string;
            sapStorageHeater.BrandName = storageHeaterObject.CustomData["BrandName"] as string;
            sapStorageHeater.ModelName = storageHeaterObject.CustomData["ModelName"] as string;
            sapStorageHeater.ModelQualifier = storageHeaterObject.CustomData["ModelQualifier"] as string;

            return sapStorageHeater;
        }

        public static Dictionary<string, object> FromStorageHeater(StorageHeater obj)
        {
            if (obj == null)
                return null;
            
            Dictionary<string, object> rtn = new Dictionary<string, object>();
            rtn.Add("Id", obj.ID);
            rtn.Add("NumberOfHeaters", obj.NumberOfHeaters);
            rtn.Add("IndexNumber", obj.IndexNumber);
            rtn.Add("HighRetention", obj.HighRetention);
            rtn.Add("ManuName", obj.ManufacturerName);
            rtn.Add("BrandName", obj.BrandName);
            rtn.Add("ModelName", obj.ModelName);
            rtn.Add("ModelQualifier", obj.ModelQualifier);

            return rtn;
        }
    }
}
