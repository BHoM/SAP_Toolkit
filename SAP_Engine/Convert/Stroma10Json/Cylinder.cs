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
using System.ComponentModel;
using System.Text;
using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.Cylinder ToCylinder(CustomObject cylinderObject)
        {
            if (cylinderObject == null)
                return null;
            BH.oM.Environment.SAP.Stroma10.Cylinder sapCylinder = new BH.oM.Environment.SAP.Stroma10.Cylinder();
            sapCylinder.ID = System.Convert.ToInt32(cylinderObject.CustomData["Id"]);
            sapCylinder.Volume = System.Convert.ToDouble(cylinderObject.CustomData["Volume"]);
            sapCylinder.ManufacturerSpecified = System.Convert.ToBoolean(cylinderObject.CustomData["ManuSpecified"]);
            sapCylinder.DeclaredLoss = System.Convert.ToDouble(cylinderObject.CustomData["DeclaredLoss"]);
            sapCylinder.Insulation = System.Convert.ToInt32(cylinderObject.CustomData["Insulation"]);
            sapCylinder.InsulationThickness = System.Convert.ToDouble(cylinderObject.CustomData["InsThick"]);
            sapCylinder.InHeatedSpace = System.Convert.ToBoolean(cylinderObject.CustomData["InHeatedSpace"]);
            sapCylinder.Thermostat = System.Convert.ToBoolean(cylinderObject.CustomData["Thermostat"]);
            sapCylinder.PipeWorkInsulated = System.Convert.ToBoolean(cylinderObject.CustomData["PipeWorkInsulated"]);
            sapCylinder.PipeWorkInsulation = System.Convert.ToInt32(cylinderObject.CustomData["PipeWorkInsulation"]);
            sapCylinder.Timed = System.Convert.ToBoolean(cylinderObject.CustomData["Timed"]);
            sapCylinder.SummerImmersion = System.Convert.ToBoolean(cylinderObject.CustomData["SummerImmersion"]);
            sapCylinder.Immersion = System.Convert.ToInt32(cylinderObject.CustomData["Immersion"]);
            sapCylinder.ImmersionHeater = System.Convert.ToBoolean(cylinderObject.CustomData["HpImmersion"]);
            sapCylinder.HeatPumpExchanger = System.Convert.ToDouble(cylinderObject.CustomData["HpExchanger"]);
            sapCylinder.Manufacturer = (cylinderObject.CustomData["Manufacturer"] as string);
            sapCylinder.Model = (cylinderObject.CustomData["Model"] as string);
            sapCylinder.CommissioningCertificate = (cylinderObject.CustomData["CommissioningCertificate"] as string);
            return sapCylinder;
        }

        public static Dictionary<string, object> FromCylinder(Cylinder obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();
            if (obj == null)
                return null;
            rtn.Add("Id", obj.ID);
            rtn.Add("Volume", obj.Volume);
            rtn.Add("ManuSpecified", obj.ManufacturerSpecified);
            rtn.Add("DeclaredLoss", obj.DeclaredLoss);
            rtn.Add("Insulation", obj.Insulation);
            rtn.Add("InsThick", obj.InsulationThickness);
            rtn.Add("InHeatedSpace", obj.InHeatedSpace);
            rtn.Add("Thermostat", obj.Thermostat);
            rtn.Add("PipeWorkInsulated", obj.PipeWorkInsulated);
            rtn.Add("PipeWorkInsulation", obj.PipeWorkInsulation);
            rtn.Add("Timed", obj.Timed);
            rtn.Add("SummerImmersion", obj.SummerImmersion);
            rtn.Add("Immersion", obj.Immersion);
            rtn.Add("HpImmersion", obj.ImmersionHeater);
            rtn.Add("HpExchanger", obj.HeatPumpExchanger);
            rtn.Add("Manufacturer", obj.Manufacturer);
            rtn.Add("Model", obj.Model);
            rtn.Add("CommissioningCertificate", obj.CommissioningCertificate);
            return rtn;
        }
    }
}