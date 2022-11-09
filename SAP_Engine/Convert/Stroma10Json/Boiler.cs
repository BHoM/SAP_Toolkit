using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using BH.oM.Base;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.Boiler ToBoiler(CustomObject boilerObject)
        {
            BH.oM.Environment.SAP.Stroma10.Boiler sapBoiler = new BH.oM.Environment.SAP.Stroma10.Boiler();


            sapBoiler.ID = System.Convert.ToInt32(boilerObject.CustomData["ID"]);

            
            sapBoiler.InHeatedSpace = System.Convert.ToBoolean(boilerObject.CustomData["InHeatedSpace"]); 

            
            sapBoiler.FlowTemperatureKnown = System.Convert.ToBoolean(boilerObject.CustomData["FlowTemperatureKnown"]); 

            
            sapBoiler.FlowTemperature = System.Convert.ToDouble(boilerObject.CustomData["FlowTemperature"]); 

            
            sapBoiler.EmitterTemperature = System.Convert.ToInt32(boilerObject.CustomData["EmitterTemperature"]); 

            
            sapBoiler.PumpAge = System.Convert.ToInt32(boilerObject.CustomData["PumpAge"]); 


            sapBoiler.Description = (boilerObject.CustomData["Description"] as CustomObject); 

            
            sapBoiler.GasBurningType = System.Convert.ToInt32(boilerObject.CustomData["GasBurningType"]); 

            
            sapBoiler.FlueType = System.Convert.ToInt32(boilerObject.CustomData["FlueType"]); 

            
            sapBoiler.FanFlued = System.Convert.ToBoolean(boilerObject.CustomData["FanFlued"]); 

            
            sapBoiler.PumpHeatPump = System.Convert.ToBoolean(boilerObject.CustomData["PumpHeatPump"]); 

            
            sapBoiler.BoilerInterlock = System.Convert.ToBoolean(boilerObject.CustomData["BoilerInterlock"]); 

            
            sapBoiler.LoadWeather = System.Convert.ToBoolean(boilerObject.CustomData["LoadWeather"]); 

            
            sapBoiler.LoadWeatherIndexNumber = boilerObject.CustomData["LoadWeatherIndexNumber"] as string; 

            
            sapBoiler.IncludeKeepHot = System.Convert.ToBoolean(boilerObject.CustomData["IncludeKeepHot"]); 

            
            sapBoiler.KeepHotTimed = System.Convert.ToBoolean(boilerObject.CustomData["KeepHotTimed"]); 

            
            sapBoiler.KeepHotFuel = System.Convert.ToInt32(boilerObject.CustomData["KeepHotFuel"]); 

            
            sapBoiler.CondensingBoilerDistributionTemperature = System.Convert.ToInt32(boilerObject.CustomData["CondensingBoilerDistributionTemperature"]); 

            
            sapBoiler.HeatPumpDistributionTemperature = System.Convert.ToInt32(boilerObject.CustomData["HeatPumpDistributionTemperature"]); 


            return sapBoiler;
        }
    }
}
