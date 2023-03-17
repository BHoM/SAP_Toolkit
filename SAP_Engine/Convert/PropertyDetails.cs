///*
// * This file is part of the Buildings and Habitats object Model (BHoM)
// * Copyright (c) 2015 - 2023, the respective contributors. All rights reserved.
// *
// * Each contributor holds copyright over their respective contributions.
// * The project versioning (Git) records all such contribution source information.
// *                                           
// *                                                                              
// * The BHoM is free software: you can redistribute it and/or modify         
// * it under the terms of the GNU Lesser General Public License as published by  
// * the Free Software Foundation, either version 3.0 of the License, or          
// * (at your option) any later version.                                          
// *                                                                              
// * The BHoM is distributed in the hope that it will be useful,              
// * but WITHOUT ANY WARRANTY; without even the implied warranty of               
// * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
// * GNU Lesser General Public License for more details.                          
// *                                                                            
// * You should have received a copy of the GNU Lesser General Public License     
// * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
// */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using BH.oM.Base.Attributes;
using BH.oM.Base;
using BH.oM.Environment.SAP;

namespace BH.Engine.Environment.SAP
{
    public static partial class Convert
    {
        [Description("Convert SAP PropertyDetails to XML PropertyDetails.")]
        [Input("sapPropertyDetails", "SAP PropertyDeatils to convert.")]
        [Output("xmlPropertyDetails", "XML PropertyDetails.")]
        public static BH.oM.Environment.SAP.XML.PropertyDetails ToXML(this oM.Environment.SAP.PropertyDetails sapPropertyDetails)
        {
            BH.oM.Environment.SAP.XML.PropertyDetails xmlPropertyDetails = new BH.oM.Environment.SAP.XML.PropertyDetails();
            List<BH.oM.Environment.SAP.OpeningType> openingTypes = new List<oM.Environment.SAP.OpeningType>();

            if (sapPropertyDetails.Heating == null)
            {
                xmlPropertyDetails.Heating = null;
                xmlPropertyDetails.Cooling = null;
            }

            if (sapPropertyDetails.BuildingParts == null)
            {
                xmlPropertyDetails.BuildingParts = null;
                xmlPropertyDetails.OpeningTypes = null;
            }

            if (sapPropertyDetails.Ventilation == null)
            {
                xmlPropertyDetails.Ventilation = null;
            }

            if (sapPropertyDetails.SpecialFeatures == null)
            {
                xmlPropertyDetails.SpecialFeatures = null;
            }

            /*if(sapPropertyDetails.EnergySource == null)//add
            {
                xmlPropertyDetails.EnergySource = null;
            }

            if (sapPropertyDetails.Lighting == null)//add
            {
                xmlPropertyDetails.Lighting = null;
            }

            if (sapPropertyDetails.DeselectedImprovements == null)//add
            {
                xmlPropertyDetails.DeselectedImprovements = null;
            }

            if (sapPropertyDetails.FlatDetails == null)//add
            {
                xmlPropertyDetails.FlatDetails = null;
            }

            

            */

            if (sapPropertyDetails.Heating != null)
            {
                var outputs = sapPropertyDetails.Heating.ToXML();
                xmlPropertyDetails.Heating = outputs.Item1;
                xmlPropertyDetails.Cooling = outputs.Item2;
            }

            if (sapPropertyDetails.BuildingParts != null)
            {
                var outputs = sapPropertyDetails.BuildingParts.ToXML();
                xmlPropertyDetails.BuildingParts = outputs.Item1;
                xmlPropertyDetails.OpeningTypes = outputs.Item2;
            }

            if (sapPropertyDetails.Ventilation != null)
            {
                xmlPropertyDetails.Ventilation = sapPropertyDetails.Ventilation.ToXML();
            }

            if (sapPropertyDetails.SpecialFeatures != null)
            {
                xmlPropertyDetails.SpecialFeatures = sapPropertyDetails.SpecialFeatures.ToXML();
            }


            xmlPropertyDetails.PropertyType = sapPropertyDetails.PropertyType.FromSAPToXML();
            xmlPropertyDetails.BuiltForm = sapPropertyDetails.BuiltForm.FromSAPToXML();
            xmlPropertyDetails.LivingArea = sapPropertyDetails.LivingArea;
            xmlPropertyDetails.LowestStoreyArea = sapPropertyDetails.LowestStoreyArea;
            xmlPropertyDetails.Orientation = sapPropertyDetails.Orientation.FromSAPToXML();
            xmlPropertyDetails.ConservatoryType = sapPropertyDetails.ConservatoryType.FromSAPToXML();
            xmlPropertyDetails.TerrainType = sapPropertyDetails.TerrainType.FromSAPToXML();

            /*
            FOR BACKWARDS COMPATABILITY ONLY DO NOT USE - xmlPropertyDetails.HasSpecialFeature = false; 
            FOR BACKWARDS COMPATABILITY ONLY DO NOT USE - xmlPropertyDetails.SpecialFeatureDescription = null;
            FOR BACKWARDS COMPATABILITY ONLY DO NOT USE - xmlPropertyDetails.EnergySavedOrGenerated = 0;
            FOR BACKWARDS COMPATABILITY ONLY DO NOT USE - xmlPropertyDetails.SavedOrGeneratedFuel = "0";
            FOR BACKWARDS COMPATABILITY ONLY DO NOT USE - xmlPropertyDetails.EnergyUsed = 0;
            FOR BACKWARDS COMPATABILITY ONLY DO NOT USE - xmlPropertyDetails.EnergyUsedFuel = "0";
            */

            xmlPropertyDetails.IsInSmokeControlArea = "true";
            xmlPropertyDetails.ColdWaterSource = "1";
            xmlPropertyDetails.WindowsOvershading = sapPropertyDetails.Overshading.FromSAPToXML();
            xmlPropertyDetails.ThermalMassParameter = 0;
            xmlPropertyDetails.AdditionalAllowableElectricityGeneration = "0";
            xmlPropertyDetails.GasSmartMeterPresent = false;
            xmlPropertyDetails.ElectricitySmartMeterPresent= false;
            xmlPropertyDetails.IsDwellingExportCapable = false;

            //Come Back to this - needs adding to a class
            xmlPropertyDetails.PVConnection = "0";
            xmlPropertyDetails.PVDiverter = false;
            xmlPropertyDetails.BatteryCapacity = 0;
            xmlPropertyDetails.IsWindTurbineConnectedToDwellingMeter= false;
            xmlPropertyDetails.DesignWaterUse = "1";//Enum? .FromSAPToXML    for DesignWaterUseCode

            return xmlPropertyDetails;
        }
        private static string FromSAPToXML(this BH.oM.Environment.SAP.TypeOfProperty typeOfProperty)
        {
            switch (typeOfProperty)
            {
                case BH.oM.Environment.SAP.TypeOfProperty.House:
                    return "0";

                case BH.oM.Environment.SAP.TypeOfProperty.Bungalow:
                    return "1";

                case BH.oM.Environment.SAP.TypeOfProperty.Flat:
                    return "2";

                case BH.oM.Environment.SAP.TypeOfProperty.Maisonette:
                    return "3";

                case BH.oM.Environment.SAP.TypeOfProperty.ParkHome:
                    return "4";

                default:
                    return "";
            }
        }
        private static string FromSAPToXML(this BH.oM.Environment.SAP.BuiltFormCode builtFormCode)
        {
            switch (builtFormCode)
            {
                case BH.oM.Environment.SAP.BuiltFormCode.Detached:
                    return "1";

                case BH.oM.Environment.SAP.BuiltFormCode.SemiDetached:
                    return "2";

                case BH.oM.Environment.SAP.BuiltFormCode.EndTerrace:
                    return "3";

                case BH.oM.Environment.SAP.BuiltFormCode.MidTerrace:
                    return "4";

                case BH.oM.Environment.SAP.BuiltFormCode.EnclosedEndTerrace:
                    return "5";

                case BH.oM.Environment.SAP.BuiltFormCode.EnclosedMidTerrace:
                    return "6";

                default:
                    return "";
            }
        }
        private static string FromSAPToXML(this BH.oM.Environment.SAP.TypeOfTerrain typeOfTerrain)
        {
            switch (typeOfTerrain)
            {
                case BH.oM.Environment.SAP.TypeOfTerrain.Urban:
                    return "1";

                case BH.oM.Environment.SAP.TypeOfTerrain.Suburban:
                    return "2";

                case BH.oM.Environment.SAP.TypeOfTerrain.Rural:
                    return "3";

                default:
                    return "";
            }
        }
        private static string FromSAPToXML(this BH.oM.Environment.SAP.OrientationCode orientationCode)
        {
            switch (orientationCode)
            {
                case BH.oM.Environment.SAP.OrientationCode.Unknown:
                    return "0";

                case BH.oM.Environment.SAP.OrientationCode.North:
                    return "1";

                case BH.oM.Environment.SAP.OrientationCode.NorthEast:
                    return "2";

                case BH.oM.Environment.SAP.OrientationCode.East:
                    return "3";

                case BH.oM.Environment.SAP.OrientationCode.SouthEast:
                    return "4";

                case BH.oM.Environment.SAP.OrientationCode.South:
                    return "5";

                case BH.oM.Environment.SAP.OrientationCode.SouthWest:
                    return "6";

                case BH.oM.Environment.SAP.OrientationCode.West:
                    return "7";

                case BH.oM.Environment.SAP.OrientationCode.NorthWest:
                    return "8";

                case BH.oM.Environment.SAP.OrientationCode.Horizontal:
                    return "9";

                default:
                    return "";
            }
        }
        private static string FromSAPToXML(this BH.oM.Environment.SAP.TypeOfConservatory typeOfConservatory)
        {
            switch (typeOfConservatory)
            {
                case BH.oM.Environment.SAP.TypeOfConservatory.NoConservatory:
                    return "1";

                case BH.oM.Environment.SAP.TypeOfConservatory.SeparatedUnheatedConservatory:
                    return "2";

                case BH.oM.Environment.SAP.TypeOfConservatory.SeparatedHeatedConservatory:
                    return "3";

                case BH.oM.Environment.SAP.TypeOfConservatory.NotSeparated:
                    return "4";

                default:
                    return "";
            }
        }

        private static string FromSAPToXML(this BH.oM.Environment.SAP.DesignWaterUseCode designWaterUseCode)
        {
            switch (designWaterUseCode)
            {
                case BH.oM.Environment.SAP.DesignWaterUseCode.LessThan125LitresPerPersonPerDay:
                    return "1";

                case BH.oM.Environment.SAP.DesignWaterUseCode.MoreThan125LitresPerPersonPerDay:
                    return "";

                default:
                    return "";
            }
        }

    }
}
