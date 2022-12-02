/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2021, the respective contributors. All rights reserved.
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
        public static List<BH.oM.Environment.SAP.Stroma10.WasteWaterHeatRecoverySystem> ToWasteWaterHeatRecoverySystems(List<CustomObject> wasteWaterHeatRecoverySystemsObject)
        {
            if (wasteWaterHeatRecoverySystemsObject == null)
                return null;

            List<WasteWaterHeatRecoverySystem> rtn = new List<WasteWaterHeatRecoverySystem>();
            foreach (var value in wasteWaterHeatRecoverySystemsObject)
            {
                rtn.Add(ToWasteWaterHeatRecoverySystem(value));
            }
            return rtn;
        }
        public static BH.oM.Environment.SAP.Stroma10.WasteWaterHeatRecoverySystem ToWasteWaterHeatRecoverySystem(CustomObject wasteWaterHeatRecoverySystemObject)
        {

            if (wasteWaterHeatRecoverySystemObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.WasteWaterHeatRecoverySystem sapWasteWaterHeatRecoverySystem = new BH.oM.Environment.SAP.Stroma10.WasteWaterHeatRecoverySystem();

            sapWasteWaterHeatRecoverySystem.ID = System.Convert.ToInt32(wasteWaterHeatRecoverySystemObject.CustomData["Id"]);

            sapWasteWaterHeatRecoverySystem.SystemReference = (wasteWaterHeatRecoverySystemObject.CustomData["SystemRef"] as string);

            sapWasteWaterHeatRecoverySystem.DedicatedStorage = System.Convert.ToDouble(wasteWaterHeatRecoverySystemObject.CustomData["DedicatedStorage"]);

            sapWasteWaterHeatRecoverySystem.WithBath = System.Convert.ToInt32(wasteWaterHeatRecoverySystemObject.CustomData["WithBath"]);
            
            sapWasteWaterHeatRecoverySystem.WithNoBath = System.Convert.ToInt32(wasteWaterHeatRecoverySystemObject.CustomData["WithNoBath"]);

            return sapWasteWaterHeatRecoverySystem;
        }
        public static Dictionary<string, object> FromWasteWaterHeatRecoverySystem(WasteWaterHeatRecoverySystem obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();

            if (obj == null)
                return null;

            rtn.Add("Id", obj.ID);

            rtn.Add("SystemRef", obj.SystemReference);

            rtn.Add("DedicatedStorage", obj.DedicatedStorage);

            rtn.Add("WithBath", obj.WithBath);

            rtn.Add("WithNoBath", obj.WithNoBath);

            return rtn;
        }
    }
}
