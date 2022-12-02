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
using System.Linq;
using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static List<BH.oM.Environment.SAP.Stroma10.Wall> ToWalls(List<CustomObject> wallsObject)
        {
            if (wallsObject == null)
                return null;
            List<BH.oM.Environment.SAP.Stroma10.Wall> rtn = new List<BH.oM.Environment.SAP.Stroma10.Wall>();
            foreach (var value in wallsObject)
            {
                rtn.Add(ToWall(value));
            }

            return rtn;
        }

        public static BH.oM.Environment.SAP.Stroma10.Wall ToWall(CustomObject wallObject)
        {
            if (wallObject == null)
                return null;
            BH.oM.Environment.SAP.Stroma10.Wall sapWall = new BH.oM.Environment.SAP.Stroma10.Wall();
            sapWall.ID = System.Convert.ToInt32(wallObject.CustomData["Id"]);
            sapWall.BHoM_Guid = (Guid.Parse(wallObject.CustomData["Guid"] as string));
            sapWall.Name = wallObject.Name;
            sapWall.Type = System.Convert.ToInt32(wallObject.CustomData["Type"]);
            sapWall.Construction = System.Convert.ToInt32(wallObject.CustomData["Construction"]);
            sapWall.Area = System.Convert.ToDouble(wallObject.CustomData["Area"]);
            sapWall.UValueStart = System.Convert.ToDouble(wallObject.CustomData["UValueStart"]);
            sapWall.UValue = System.Convert.ToDouble(wallObject.CustomData["UValue"]);
            sapWall.ResultantUValue = System.Convert.ToDouble(wallObject.CustomData["Ru"]);
            sapWall.Curtain = System.Convert.ToBoolean(wallObject.CustomData["Curtain"]);
            sapWall.ManualInputKappa = System.Convert.ToBoolean(wallObject.CustomData["OverRideK"]);
            sapWall.Kappa = System.Convert.ToDouble(wallObject.CustomData["K"]);
            sapWall.Dims = ToDims((wallObject.CustomData["Dims"] as List<object>).Cast<CustomObject>().ToList());
            sapWall.UValueSelectionID = System.Convert.ToInt32(wallObject.CustomData["UValueSelectionId"]);
            sapWall.UValueSelected = System.Convert.ToBoolean(wallObject.CustomData["UValueSelected"]);
            sapWall.EnergyPerformanceCertificateDescription = wallObject.CustomData["EpcDescription"] as string;
            sapWall.LoftInsulation = wallObject.CustomData["LoftInsulation"] as string;
            return sapWall;
        }

        public static Dictionary<string, object> FromWall(Wall obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();
            if (obj == null)
                return null;
            rtn.Add("Id", obj.ID);
            rtn.Add("Guid", obj.BHoM_Guid.ToString());
            rtn.Add("Name", obj.Name);
            rtn.Add("Type", obj.Type);
            rtn.Add("Construction", obj.Construction);
            rtn.Add("Area", obj.Area);
            rtn.Add("UValueStart", obj.UValueStart);
            rtn.Add("UValue", obj.UValue);
            rtn.Add("Ru", obj.ResultantUValue);
            rtn.Add("Curtain", obj.Curtain);
            rtn.Add("OverRideK", obj.ManualInputKappa);
            rtn.Add("K", obj.Kappa);
            if (obj.Dims != null && obj.Dims.Any(x => x != null))
                rtn.Add("Dims", obj.Dims.Select(x => FromDim(x)).ToList());
            else
            {
                List<object> temp = new List<object>();
                rtn.Add("Dims", temp);
            }

            rtn.Add("UValueSelectionId", obj.UValueSelectionID);
            rtn.Add("UValueSelected", obj.UValueSelected);
            rtn.Add("EpcDescription", obj.EnergyPerformanceCertificateDescription);
            rtn.Add("LoftInsulation", obj.LoftInsulation);
            return rtn;
        }
    }
}