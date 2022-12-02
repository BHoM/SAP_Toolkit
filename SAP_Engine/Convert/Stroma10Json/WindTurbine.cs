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
        public static BH.oM.Environment.SAP.Stroma10.WindTurbine ToWindTurbine(CustomObject windTurbineObject)
        {
            if (windTurbineObject == null)
                return null;
            BH.oM.Environment.SAP.Stroma10.WindTurbine sapWindTurbine = new BH.oM.Environment.SAP.Stroma10.WindTurbine();
            sapWindTurbine.ID = System.Convert.ToInt32(windTurbineObject.CustomData["Id"]);
            sapWindTurbine.Include = System.Convert.ToBoolean(windTurbineObject.CustomData["Include"]);
            sapWindTurbine.WindTurbineNumber = System.Convert.ToInt32(windTurbineObject.CustomData["WNumber"]);
            sapWindTurbine.WindTurbineRotarDiameter = System.Convert.ToDouble(windTurbineObject.CustomData["WrDiameter"]);
            sapWindTurbine.WindTurbineHeight = System.Convert.ToDouble(windTurbineObject.CustomData["WHeight"]);
            sapWindTurbine.Name = windTurbineObject.Name;
            sapWindTurbine.Certificate = (windTurbineObject.CustomData["Certificate"] as string);
            return sapWindTurbine;
        }

        public static Dictionary<string, object> FromWindTurbine(WindTurbine obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();
            if (obj == null)
                return null;
            rtn.Add("Id", obj.ID);
            rtn.Add("Include", obj.Include);
            rtn.Add("WNumber", obj.WindTurbineNumber);
            rtn.Add("WrDiameter", obj.WindTurbineRotarDiameter);
            rtn.Add("WHeight", obj.WindTurbineHeight);
            rtn.Add("Name", obj.Name);
            rtn.Add("Certificate", obj.Certificate);
            return rtn;
        }
    }
}