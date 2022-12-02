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
        public static BH.oM.Environment.SAP.Stroma10.Boiler ToBoiler(CustomObject boilerObject)
        {

            if (boilerObject == null)
                return null;


            BH.oM.Environment.SAP.Stroma10.Boiler sapBoiler = new BH.oM.Environment.SAP.Stroma10.Boiler();


            sapBoiler.ID = System.Convert.ToInt32(boilerObject.CustomData["Id"]);


            sapBoiler.InHeatedSpace = System.Convert.ToBoolean(boilerObject.CustomData["InHeatedSpace"]);


            sapBoiler.FlowTemperatureKnown = System.Convert.ToBoolean(boilerObject.CustomData["FlowTempKnown"]);


            sapBoiler.FlowTemperature = System.Convert.ToDouble(boilerObject.CustomData["FlowTemp"]);


            sapBoiler.EmitterTemperature = System.Convert.ToInt32(boilerObject.CustomData["EmitterTemp"]);


            sapBoiler.PumpAge = System.Convert.ToInt32(boilerObject.CustomData["PumpAge"]);


            sapBoiler.Description = (boilerObject.CustomData["Description"] as string);


            sapBoiler.GasBurningType = System.Convert.ToInt32(boilerObject.CustomData["GasBurningType"]);


            sapBoiler.FlueType = System.Convert.ToInt32(boilerObject.CustomData["FlueType"]);


            sapBoiler.FanFlued = System.Convert.ToBoolean(boilerObject.CustomData["FanFlued"]);


            sapBoiler.PumpHeatPump = System.Convert.ToBoolean(boilerObject.CustomData["PumpHp"]);


            sapBoiler.BoilerInterlock = System.Convert.ToBoolean(boilerObject.CustomData["BiLock"]);


            sapBoiler.LoadWeather = System.Convert.ToBoolean(boilerObject.CustomData["LoadWeather"]);


            sapBoiler.LoadWeatherIndexNumber = boilerObject.CustomData["LoadWeatherIndexNumber"] as string;


            sapBoiler.IncludeKeepHot = System.Convert.ToBoolean(boilerObject.CustomData["IncludeKeepHot"]);


            sapBoiler.KeepHotTimed = System.Convert.ToBoolean(boilerObject.CustomData["KeepHotTimed"]);


            sapBoiler.KeepHotFuel = System.Convert.ToInt32(boilerObject.CustomData["KeepHotFuel"]);


            sapBoiler.CondensingBoilerDistributionTemperature = System.Convert.ToInt32(boilerObject.CustomData["CondensingBoilerDistributionTemp"]);


            sapBoiler.HeatPumpDistributionTemperature = System.Convert.ToInt32(boilerObject.CustomData["HeatPumpDistributionTemp"]);


            return sapBoiler;
        }
        public static Dictionary<string, object> FromBoiler(Boiler obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();

            if (obj == null)
                return null;

            rtn.Add("Id", obj.ID);

            rtn.Add("InHeatedSpace", obj.InHeatedSpace);

            rtn.Add("FlowTempKnown", obj.FlowTemperatureKnown);

            rtn.Add("FlowTemp", obj.FlowTemperature);

            rtn.Add("EmitterTemp", obj.EmitterTemperature);

            rtn.Add("PumpAge", obj.PumpAge);

            rtn.Add("Description", obj.Description);

            rtn.Add("GasBurningType", obj.GasBurningType);

            rtn.Add("FlueType", obj.FlueType);

            rtn.Add("FanFlued", obj.FanFlued);

            rtn.Add("PumpHp", obj.PumpHeatPump);

            rtn.Add("BiLock", obj.BoilerInterlock);

            rtn.Add("LoadWeather", obj.LoadWeather);    

            rtn.Add("LoadWeatherIndexNumber", obj.LoadWeatherIndexNumber);

            rtn.Add("IncludeKeepHot", obj.IncludeKeepHot);

            rtn.Add("KeepHotTimed", obj.KeepHotTimed);

            rtn.Add("KeepHotFuel", obj.KeepHotFuel);

            rtn.Add("CondensingBoilerDistributionTemp", obj.CondensingBoilerDistributionTemperature);

            rtn.Add("HeatPumpDistributionTemp", obj.HeatPumpDistributionTemperature);

            return rtn;
        }
    }
}

