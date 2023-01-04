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
using System.Linq;
using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;
using BH.oM.Environment.SAP;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.WasteWaterHeatRecovery ToWasteWaterHeatRecovery(CustomObject wasteWaterHeatRecoveryObject)
        {
            if (wasteWaterHeatRecoveryObject == null)
                return null;
            BH.oM.Environment.SAP.Stroma10.WasteWaterHeatRecovery sapWasteWaterHeatRecovery = new BH.oM.Environment.SAP.Stroma10.WasteWaterHeatRecovery();
            sapWasteWaterHeatRecovery.ID = System.Convert.ToInt32(wasteWaterHeatRecoveryObject.CustomData["Id"]);
            sapWasteWaterHeatRecovery.Include = System.Convert.ToBoolean(wasteWaterHeatRecoveryObject.CustomData["Include"]);
            sapWasteWaterHeatRecovery.IsTER = System.Convert.ToBoolean(wasteWaterHeatRecoveryObject.CustomData["IsTer"]);
            sapWasteWaterHeatRecovery.TotalRooms = System.Convert.ToInt32(wasteWaterHeatRecoveryObject.CustomData["TotalRooms"]);
            sapWasteWaterHeatRecovery.Manufacturer = (wasteWaterHeatRecoveryObject.CustomData["Manufacturer"] as string);
            sapWasteWaterHeatRecovery.Model = (wasteWaterHeatRecoveryObject.CustomData["Model"] as string);
            sapWasteWaterHeatRecovery.Efficiency = System.Convert.ToDouble(wasteWaterHeatRecoveryObject.CustomData["Efficiency"]);
            sapWasteWaterHeatRecovery.IsStorage = System.Convert.ToBoolean(wasteWaterHeatRecoveryObject.CustomData["IsStorage"]);
            sapWasteWaterHeatRecovery.WasteWaterHeatRecoverySystems = ToWasteWaterHeatRecoverySystems((wasteWaterHeatRecoveryObject.CustomData["WwhrsSystems"] as List<object>).Cast<CustomObject>().ToList());
            return sapWasteWaterHeatRecovery;
        }

        public static Dictionary<string, object> FromWasteWaterHeatRecovery(WasteWaterHeatRecovery obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();
            if (obj == null)
                return null;
            rtn.Add("Id", obj.ID);
            rtn.Add("Include", obj.Include);
            rtn.Add("IsTer", obj.IsTER);
            rtn.Add("TotalRooms", obj.TotalRooms);
            rtn.Add("Manufacturer", obj.Manufacturer);
            rtn.Add("Model", obj.Model);
            rtn.Add("Efficiency", obj.Efficiency);
            rtn.Add("IsStorage", obj.IsStorage);
            if (obj.WasteWaterHeatRecoverySystems != null && obj.WasteWaterHeatRecoverySystems.Any(x => x != null))
                rtn.Add("WwhrsSystems", obj.WasteWaterHeatRecoverySystems.Select(x => FromWasteWaterHeatRecoverySystem(x)).ToList());
            else
            {
                List<object> temp = new List<object>();
                rtn.Add("WwhrsSystems", temp);
            }

            return rtn;
        }
    }
}
