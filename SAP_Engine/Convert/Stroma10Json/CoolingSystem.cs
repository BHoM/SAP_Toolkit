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
        public static BH.oM.Environment.SAP.Stroma10.CoolingSystem ToCoolingSystem(CustomObject coolingSystemObject)
        {
            if (coolingSystemObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.CoolingSystem sapCoolingSystem = new BH.oM.Environment.SAP.Stroma10.CoolingSystem();

            sapCoolingSystem.ID = System.Convert.ToInt32(coolingSystemObject.CustomData["Id"]);

            sapCoolingSystem.Include = System.Convert.ToBoolean(coolingSystemObject.CustomData["Include"]);

            sapCoolingSystem.SystemType = System.Convert.ToInt32(coolingSystemObject.CustomData["SystemType"]);

            sapCoolingSystem.EnergyLabel = System.Convert.ToInt32(coolingSystemObject.CustomData["EnergyLabel"]);

            sapCoolingSystem.Overide = System.Convert.ToBoolean(coolingSystemObject.CustomData["Overide"]);

            sapCoolingSystem.CompressorControl = System.Convert.ToInt32(coolingSystemObject.CustomData["CompressorControl"]);

            sapCoolingSystem.CooledArea = System.Convert.ToDouble(coolingSystemObject.CustomData["CooledArea"]);

            sapCoolingSystem.EERMeasuredInclude = System.Convert.ToBoolean(coolingSystemObject.CustomData["EerMeasuredInclude"]);

            sapCoolingSystem.EER = System.Convert.ToDouble(coolingSystemObject.CustomData["Eer"]);

            sapCoolingSystem.Description = coolingSystemObject.CustomData["Description"] as string;

            return sapCoolingSystem;
        }
        public static Dictionary<string, object> FromCoolingSystem(CoolingSystem obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();

            if (obj == null)
                return null;

            rtn.Add("Id", obj.ID);

            rtn.Add("Include", obj.Include);

            rtn.Add("SystemType", obj.SystemType);

            rtn.Add("EnergyLabel", obj.EnergyLabel);

            rtn.Add("Overide", obj.Overide);

            rtn.Add("CompressorControl", obj.CompressorControl);

            rtn.Add("CooledArea", obj.CooledArea);

            rtn.Add("EerMeasuredInclude", obj.EERMeasuredInclude);

            rtn.Add("Eer", obj.EER);

            rtn.Add("Description", obj.Description);

            return rtn;
        }
    }
}
