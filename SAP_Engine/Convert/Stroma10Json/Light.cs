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
        public static List<BH.oM.Environment.SAP.Stroma10.Light> ToLights(List<CustomObject> lightsObject)
        {
            if (lightsObject == null)
                return null;
            List<BH.oM.Environment.SAP.Stroma10.Light> rtn = new List<BH.oM.Environment.SAP.Stroma10.Light>();
            foreach (var value in lightsObject)
            {
                rtn.Add(ToLight(value));
            }

            return rtn;
        }

        public static BH.oM.Environment.SAP.Stroma10.Light ToLight(CustomObject lightObject)
        {
            if (lightObject == null)
                return null;
            BH.oM.Environment.SAP.Stroma10.Light sapLight = new BH.oM.Environment.SAP.Stroma10.Light();
            sapLight.ID = System.Convert.ToInt32(lightObject.CustomData["Id"]);
            sapLight.BHoM_Guid = (Guid.Parse(lightObject.CustomData["Guid"] as string));
            sapLight.Name = lightObject.Name;
            sapLight.Power = System.Convert.ToDouble(lightObject.CustomData["Power"]);
            sapLight.Efficacy = System.Convert.ToDouble(lightObject.CustomData["Efficacy"]);
            sapLight.Capacity = System.Convert.ToDouble(lightObject.CustomData["Capacity"]);
            sapLight.Count = System.Convert.ToInt32(lightObject.CustomData["Count"]);
            return sapLight;
        }

        public static Dictionary<string, object> FromLight(Light obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();
            if (obj == null)
                return null;
            rtn.Add("Id", obj.ID);
            rtn.Add("Guid", obj.BHoM_Guid.ToString());
            rtn.Add("Name", obj.Name);
            rtn.Add("Power", obj.Power);
            rtn.Add("Efficacy", obj.Efficacy);
            rtn.Add("Capacity", obj.Capacity);
            rtn.Add("Count", obj.Count);
            return rtn;
        }
    }
}