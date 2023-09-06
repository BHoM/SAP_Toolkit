using BH.oM.Base.Attributes;
using BH.Adapter.SAP.XML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.Adapter.SAP
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

            PropertyDetails propertyObj = reportObj.SAP10Data.PropertyDetails;
            PropertyDetails templateProperty = templateSAP.SAP10Data.PropertyDetails;
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
            propertyObj.Ventilation = templateProperty.Ventilation;
            propertyObj.BuiltForm = templateProperty.BuiltForm;
            propertyObj.ColdWaterSource = templateProperty.ColdWaterSource;
            propertyObj.WindowsOvershading = templateProperty.WindowsOvershading;
            propertyObj.ThermalMassParameter = templateProperty.ThermalMassParameter;
            propertyObj.IsInSmokeControlArea = templateProperty.IsInSmokeControlArea;
            propertyObj.ConservatoryType = templateProperty.ConservatoryType;
            propertyObj.TerrainType = templateProperty.TerrainType;
            propertyObj.HasSpecialFeature = templateProperty.HasSpecialFeature;
            propertyObj.AdditionalAllowableElectricityGeneration = templateProperty.AdditionalAllowableElectricityGeneration;
            propertyObj.IsDwellingExportCapable = templateProperty.IsDwellingExportCapable;
            propertyObj.GasSmartMeterPresent = templateProperty.GasSmartMeterPresent;
            propertyObj.ElectricitySmartMeterPresent = templateProperty.ElectricitySmartMeterPresent;
            propertyObj.PVConnection = templateProperty.PVConnection;
            propertyObj.BatteryCapacity = templateProperty.BatteryCapacity;
            propertyObj.IsWindTurbineConnectedToDwellingMeter = templateProperty.IsWindTurbineConnectedToDwellingMeter;
            propertyObj.SpecialFeatures = templateProperty.SpecialFeatures;
            propertyObj.DesignWaterUse = templateProperty.DesignWaterUse;
            propertyObj.Cooling = templateProperty.Cooling;

            reportObj.SAP10Data.PropertyDetails = propertyObj;
            return reportObj;
        }
    }
}
