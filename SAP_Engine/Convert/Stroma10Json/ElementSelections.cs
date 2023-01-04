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
        public static BH.oM.Environment.SAP.Stroma10.ElementSelections ToElementSelections(CustomObject elementSelectionsObject)
        {
            if (elementSelectionsObject == null)
                return null;
            BH.oM.Environment.SAP.Stroma10.ElementSelections sapElementSelections = new BH.oM.Environment.SAP.Stroma10.ElementSelections();
            sapElementSelections.ID = System.Convert.ToInt32(elementSelectionsObject.CustomData["Id"]);
            sapElementSelections.FabricElement = elementSelectionsObject.CustomData["FabricElement"] as string;
            sapElementSelections.VentilationElement = elementSelectionsObject.CustomData["VentilationElement"] as string;
            sapElementSelections.HeatingElement = elementSelectionsObject.CustomData["HeatingElement"] as string;
            sapElementSelections.WaterElement = elementSelectionsObject.CustomData["WaterElement"] as string;
            sapElementSelections.RenewableElement = elementSelectionsObject.CustomData["RenewableElement"] as string;
            sapElementSelections.OverheatingElement = elementSelectionsObject.CustomData["OverheatingElement"] as string;
            return sapElementSelections;
        }

        public static Dictionary<string, object> FromElementSelections(ElementSelections obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();
            if (obj == null)
                return null;
            rtn.Add("Id", obj.ID);
            rtn.Add("FabricElement", obj.FabricElement);
            rtn.Add("VentilationElement", obj.VentilationElement);
            rtn.Add("HeatingElement", obj.HeatingElement);
            rtn.Add("WaterElement", obj.WaterElement);
            rtn.Add("RenewableElement", obj.RenewableElement);
            rtn.Add("OverheatingElement", obj.OverheatingElement);
            return rtn;
        }
    }
}
