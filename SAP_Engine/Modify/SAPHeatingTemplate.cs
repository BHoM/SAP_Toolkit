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
        [Description("Replace heating details in a SAPReport with heating details from a second.")]
        [Input("templateSAP", "SAPReport with the new heating details.")]
        [Input("reportObj", "Original SAPReport object.")]
        [Output("sapReport", "A sap report with the heating details added.")]
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

            reportObj.SAP10Data.PropertyDetails = propertyObj;
            return reportObj;

        }
    }
}


