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
        public static BH.oM.Environment.SAP.Stroma10.HeatPumpOnly ToHeatPumpOnly(CustomObject heatPumpOnlyObject)
        {
            if (heatPumpOnlyObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.HeatPumpOnly sapHeatPumpOnly = new BH.oM.Environment.SAP.Stroma10.HeatPumpOnly();
            sapHeatPumpOnly.ID = System.Convert.ToInt32(heatPumpOnlyObject.CustomData["Id"]);
            sapHeatPumpOnly.HotWaterOnlyHeatPump = System.Convert.ToBoolean(heatPumpOnlyObject.CustomData["HotWaterOnlyHp"]);
            sapHeatPumpOnly.HotWaterHeatPumpIntegral = System.Convert.ToBoolean(heatPumpOnlyObject.CustomData["HotWaterHpIntegral"]);
            sapHeatPumpOnly.Volume = System.Convert.ToInt32(heatPumpOnlyObject.CustomData["Volume"]);
            sapHeatPumpOnly.DeclaredValue = System.Convert.ToDouble(heatPumpOnlyObject.CustomData["DeclaredValue"]);
            sapHeatPumpOnly.ManufacturerSpecified = System.Convert.ToBoolean(heatPumpOnlyObject.CustomData["ManuSpecified"]);
            sapHeatPumpOnly.SummerEfficiency = System.Convert.ToDouble(heatPumpOnlyObject.CustomData["SummerEff"]);
            sapHeatPumpOnly.WinterEfficiency = System.Convert.ToDouble(heatPumpOnlyObject.CustomData["WinterEff"]);

            return sapHeatPumpOnly;
        }

        public static Dictionary<string, object> FromHeatPumpOnly(HeatPumpOnly obj)
        {
            if (obj == null)
                return null;

            Dictionary<string, object> rtn = new Dictionary<string, object>();
            rtn.Add("Id", obj.ID);
            rtn.Add("HotWaterOnlyHp", obj.HotWaterOnlyHeatPump);
            rtn.Add("HotWaterHpIntegral", obj.HotWaterHeatPumpIntegral);
            rtn.Add("Volume", obj.Volume);
            rtn.Add("DeclaredValue", obj.DeclaredValue);
            rtn.Add("ManuSpecified", obj.ManufacturerSpecified);
            rtn.Add("SummerEff", obj.SummerEfficiency);
            rtn.Add("WinterEff", obj.WinterEfficiency);

            return rtn;
        }
    }
}
