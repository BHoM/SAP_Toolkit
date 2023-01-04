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

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static List<BH.oM.Environment.SAP.Stroma10.Overheating> ToOverheatings(List<CustomObject> overheatingsObject)
        {
            if (overheatingsObject == null)
                return null;
            List<BH.oM.Environment.SAP.Stroma10.Overheating> rtn = new List<BH.oM.Environment.SAP.Stroma10.Overheating>();
            foreach (var value in overheatingsObject)
            {
                rtn.Add(ToOverheating(value));
            }

            return rtn;
        }

        public static BH.oM.Environment.SAP.Stroma10.Overheating ToOverheating(CustomObject overheatingObject)
        {
            if (overheatingObject == null)
                return null;
            BH.oM.Environment.SAP.Stroma10.Overheating sapOverheating = new BH.oM.Environment.SAP.Stroma10.Overheating();
            sapOverheating.ID = System.Convert.ToInt32(overheatingObject.CustomData["Id"]);
            sapOverheating.EaCBuildType = System.Convert.ToInt32(overheatingObject.CustomData["EaCBuildType"]);
            sapOverheating.EaCWindow = System.Convert.ToInt32(overheatingObject.CustomData["EaCWindow"]);
            sapOverheating.EaCOveride = System.Convert.ToBoolean(overheatingObject.CustomData["EaCOveride"]);
            sapOverheating.EaCAirChange = System.Convert.ToDouble(overheatingObject.CustomData["EaCAirChange"]);
            sapOverheating.Night = System.Convert.ToBoolean(overheatingObject.CustomData["Night"]);
            sapOverheating.Conservatory = System.Convert.ToInt32(overheatingObject.CustomData["Conservatory"]);
            sapOverheating.Lights = ToLights((overheatingObject.CustomData["Lights"] as List<object>).Cast<CustomObject>().ToList());
            sapOverheating.LowerEnergyLights = System.Convert.ToInt32(overheatingObject.CustomData["LowerEnergyLights"]);
            return sapOverheating;
        }

        public static Dictionary<string, object> FromOverheating(Overheating obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();
            if (obj == null)
                return null;
            rtn.Add("Id", obj.ID);
            rtn.Add("EaCBuildType", obj.EaCBuildType);
            rtn.Add("EaCWindow", obj.EaCWindow);
            rtn.Add("EaCOveride", obj.EaCOveride);
            rtn.Add("EaCAirChange", obj.EaCAirChange);
            rtn.Add("Night", obj.Night);
            rtn.Add("Conservatory", obj.Conservatory);
            if (obj.Lights != null && obj.Lights.Any(x => x != null))
                rtn.Add("Lights", obj.Lights.Select(x => FromLight(x)).ToList());
            else
            {
                List<object> temp = new List<object>();
                rtn.Add("Lights", temp);
            }

            rtn.Add("LowerEnergyLights", obj.LowerEnergyLights);
            return rtn;
        }
    }
}
