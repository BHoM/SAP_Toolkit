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

            if (boilerObject == null)
                return null;

            
            BH.oM.Environment.SAP.Stroma10.Boiler sapBoiler = new BH.oM.Environment.SAP.Stroma10.Boiler();


            sapBoiler.ID = System.Convert.ToInt32(boilerObject.CustomData["Id"]);

            
            sapBoiler.InHeatedSpace = System.Convert.ToBoolean(boilerObject.CustomData["InHeatedSpace"]); 

            
            sapBoiler.FlowTemperatureKnown = System.Convert.ToBoolean(boilerObject.CustomData["FlowTempKnown"]); 

            
            sapBoiler.FlowTemperature = System.Convert.ToDouble(boilerObject.CustomData["FlowTemp"]); 

            
            sapBoiler.EmitterTemperature = System.Convert.ToInt32(boilerObject.CustomData["EmitterTemp"]); 

            
            sapBoiler.PumpAge = System.Convert.ToInt32(boilerObject.CustomData["PumpAge"]); 


            sapBoiler.Description = (boilerObject.CustomData["Description"] as CustomObject); 

            
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
    }
}
