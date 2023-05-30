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

//using BH.Engine.Data
using System.Collections.Generic;
using System.Linq;

using BH.oM.Environment.SAP;
using BH.oM.Base;
//using BH.Engine.Data.Query;
using Opening = BH.oM.Environment.SAP.Opening;
using BH.oM.Base.Attributes;
using System.ComponentModel;
using BH.oM.Environment.SAP.XML;
using System.Runtime.CompilerServices;

namespace BH.Engine.Environment.SAP
{
    public static partial class Modify
    {
        [Description("Groups objects by dwelling.")]
        [Input("openings", "List of openings.")]
        [Input("walls", "List of walls.")]
        [Input("floors", "List of floors.")]
        [Input("livingAreas", "List of living areas.")]
        [MultiOutput(0, "wallsList", "Lists of walls grouped by dwelling.")]
        [MultiOutput(1, "openingsList", "Lists of openings grouped by dwelling.")]
        [MultiOutput(2, "floorsList", "Lists of floors grouped by dwelling.")]
        [MultiOutput(3, "livingAreaList", "Lists of living areas grouped by dwelling.")]
        public static SAPReport SAPHeatingTemplate(this SAPReport templateSAP, SAPReport reportObj)
        {
            if (templateSAP == null)
            {
                return reportObj;
            }

            if (reportObj == null)
            {
                return null;
            }

            BH.oM.Environment.SAP.XML.PropertyDetails propertyObj = reportObj.SAP10Data.PropertyDetails;
            BH.oM.Environment.SAP.XML.PropertyDetails templateProperty = templateSAP.SAP10Data.PropertyDetails;
            //List<string> heatingObj = new List<string>
            //{
            //    "EnergySource",
            //    "Heating",
            //    "Ventilation",
            //    "ColdWaterSource",
            //    "ThermalMassParameter",
            //    "IsInSmokeControlArea",
            //    "HasSpecialFeature",
            //    "AdditionalAllowableElectricityGeneration",
            //    "IsDwellingExportCapable",
            //    "GasSmartMeterPresent",
            //    "ElectricitySmartMeterPresent",
            //    "PVConnection",
            //    "PVDiverter",
            //    "BatteryCapacity",
            //    "IsWindTurbineConnectedToDwellingMeter",
            //    "SpecialFeatures",
            //    "DesignWaterUse",
            //    "Cooling"
            //};

            propertyObj.EnergySource = templateProperty.EnergySource;
            propertyObj.Heating = templateProperty.Heating;
            propertyObj.Ventilation= templateProperty.Ventilation;
            propertyObj.BuiltForm= templateProperty.BuiltForm;
            propertyObj.ColdWaterSource = templateProperty.ColdWaterSource;
            propertyObj.WindowsOvershading= templateProperty.WindowsOvershading;
            propertyObj.ThermalMassParameter = templateProperty.ThermalMassParameter;
            propertyObj.IsInSmokeControlArea= templateProperty.IsInSmokeControlArea;
            propertyObj.ConservatoryType = templateProperty.ConservatoryType;
            propertyObj.TerrainType = templateProperty.TerrainType;
            propertyObj.HasSpecialFeature= templateProperty.HasSpecialFeature;
            propertyObj.AdditionalAllowableElectricityGeneration = templateProperty.AdditionalAllowableElectricityGeneration;
            propertyObj.IsDwellingExportCapable = templateProperty.IsDwellingExportCapable;
            propertyObj.GasSmartMeterPresent = templateProperty.GasSmartMeterPresent;
            propertyObj.ElectricitySmartMeterPresent = templateProperty.ElectricitySmartMeterPresent;
            propertyObj.PVConnection = templateProperty.PVConnection;
            propertyObj.BatteryCapacity = templateProperty.BatteryCapacity;
            propertyObj.IsWindTurbineConnectedToDwellingMeter = templateProperty.IsWindTurbineConnectedToDwellingMeter;
            propertyObj.SpecialFeatures = templateProperty.SpecialFeatures;
            propertyObj.DesignWaterUse= templateProperty.DesignWaterUse;
            propertyObj.Cooling = templateProperty.Cooling;

            ////var listHeat = templateSAP.GetType().GetProperty(heatingObj[0]).GetValue(templateSAP, null);
            //foreach (var property in heatingObj)
            //{
            //    var templateObj = templateSAP.GetType().GetProperty(property).GetValue(templateSAP);

            //    if (templateObj == null)
            //    {
            //        continue;
            //    }

            //    BH.Engine.Base.Modify.SetPropertyValue(reportObj, property, templateObj);


            //}



            //var templateValueObj = heatingObj.Select(x => templateSAP.GetType().GetProperty(x).GetValue(templateSAP) || null);
            //var properties = heatingObj.Zip(templateValueObj, (v1, v2) => new { PropertyName = v1, NewData = v2 });

            //foreach (var p in properties)
            //{
            //    if (p.NewData != null)
            //    {
            //        BH.Engine.Base.Modify.SetPropertyValue(reportObj,p.PropertyName,p.NewData);
            //    }
            //}


            //foreach (var p in heatingObj)
            //{
            //    if (templateSAP.GetType().GetProperty(p) != null)
            //    {
            //        reportObj.GetType().GetProperty(p).SetValue(reportObj, templateSAP.GetType().GetProperty(p).GetValue(templateSAP, null), null);
            //    }

            //}
            reportObj.SAP10Data.PropertyDetails = propertyObj;
            return reportObj;

        }
    }
}


