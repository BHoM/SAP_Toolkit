/////*
//// * This file is part of the Buildings and Habitats object Model (BHoM)
//// * Copyright (c) 2015 - 2023, the respective contributors. All rights reserved.
//// *
//// * Each contributor holds copyright over their respective contributions.
//// * The project versioning (Git) records all such contribution source information.
//// *                                           
//// *                                                                              
//// * The BHoM is free software: you can redistribute it and/or modify         
//// * it under the terms of the GNU Lesser General Public License as published by  
//// * the Free Software Foundation, either version 3.0 of the License, or          
//// * (at your option) any later version.                                          
//// *                                                                              
//// * The BHoM is distributed in the hope that it will be useful,              
//// * but WITHOUT ANY WARRANTY; without even the implied warranty of               
//// * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
//// * GNU Lesser General Public License for more details.                          
//// *                                                                            
//// * You should have received a copy of the GNU Lesser General Public License     
//// * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
//// */

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.ComponentModel;
//using BH.oM.Base.Attributes;
//using BH.oM.Base;

//namespace BH.Engine.Environment.SAP
//{
//    public static partial class Convert
//    {
//        //[Description("Convert SAP PropertyDetails to XML PropertyDetails.")]
//        //[Input("sapPropertyDetails", "SAP PropertyDeatils to convert.")]
//        //[Output("xmlPropertyDetails", "XML PropertyDetails.")]
//        public static BH.oM.Environment.SAP.XML.PropertyDetails ToXML(this List<oM.Environment.SAP.Stroma10.Dwelling> sapDwelling)
//        {
//            BH.oM.Environment.SAP.XML.PropertyDetails xmlPropertyDetails = new BH.oM.Environment.SAP.XML.PropertyDetails();
//            List<BH.oM.Environment.SAP.OpeningType> openingTypes = new List<oM.Environment.SAP.OpeningType>();

//            xmlPropertyDetails.PropertyType = sapDwelling[1].DwellingVersions[1].DwellingDetails.PropertyType.ToString(); //check
//            xmlPropertyDetails.BuiltForm = sapDwelling[1].DwellingVersions[1].DwellingDetails.BuiltForm.ToString();
//            xmlPropertyDetails.LivingArea = "0"; //check - sum total living areas from SAP?
//            xmlPropertyDetails.LowestStoreyArea = 0; //check
//            xmlPropertyDetails.Orientation = sapDwelling[1].DwellingVersions[1].DwellingDetails.Orientation.ToString(); //change as this is "North" and needs to be a num
//            xmlPropertyDetails.ConservatoryType = sapDwelling[1].DwellingVersions[1].Overheating.Conservatory.ToString();//CHeck Type
//            xmlPropertyDetails.TerrainType = sapDwelling[1].DwellingVersions[1].DwellingDetails.Terrain.ToString();//Check
//            xmlPropertyDetails.IsInSmokeControlArea = sapDwelling[1].DwellingVersions[1].DwellingDetails.SmokeControl;//check - change from num to t/f
//            xmlPropertyDetails.ColdWaterSource = null; //can't find on STROMA 10
//            xmlPropertyDetails.WindowsOvershading = "2";//check in SAP make calculation to find avg of all windows
//            xmlPropertyDetails.ThermalMassParameter = sapDwelling[1].DwellingVersions[1].DwellingDetails.ThermalMass; //somethings wrong here
//            xmlPropertyDetails.AdditionalAllowableElectricityGeneration = null; //IDK
//            xmlPropertyDetails.GasSmartMeterPresent = sapDwelling[1].DwellingVersions[1].DwellingDetails.IsGasMeter;
//            xmlPropertyDetails.ElectricitySmartMeterPresent = sapDwelling[1].DwellingVersions[1].DwellingDetails.IsElectricMeter;
//            xmlPropertyDetails.IsDwellingExportCapable = sapDwelling[1].DwellingVersions[1].DwellingDetails.IsCableExport;
//            xmlPropertyDetails.PVConnection = "0"; //IDK
//            xmlPropertyDetails.PVDiverter = null; //IDK
//            xmlPropertyDetails.BatteryCapacity = 0;//IDK
//            xmlPropertyDetails.IsWindTurbineConnectedToDwellingMeter = null; //IDK





//            //if (sapPropertyDetails.Heating == null)
//            //{
//            //    xmlPropertyDetails.Heating = null;
//            //    xmlPropertyDetails.Cooling = null;
//            //}

//            //if (sapPropertyDetails.BuildingParts == null)
//            //{
//            //    xmlPropertyDetails.BuildingParts = null;
//            //    xmlPropertyDetails.OpeningTypes = null;
//            //}

//            //if (sapPropertyDetails.Ventilation == null)
//            //{
//            //    xmlPropertyDetails.Ventilation = null;
//            //}

//            //if (sapPropertyDetails.Heating != null)
//            //{
//            //    var outputs = sapPropertyDetails.Heating.ToXML();
//            //    xmlPropertyDetails.Heating = outputs.Item1;
//            //    xmlPropertyDetails.Cooling = outputs.Item2;
//            //}

//            //if (sapPropertyDetails.BuildingParts != null)
//            //{
//            //    var outputs = sapPropertyDetails.BuildingParts.ToXML();
//            //    xmlPropertyDetails.BuildingParts = outputs.Item1;
//            //    xmlPropertyDetails.OpeningTypes = outputs.Item2;
//            //}

//            //if (sapPropertyDetails.Ventilation != null)
//            //{
//            //    xmlPropertyDetails.Ventilation = sapPropertyDetails.Ventilation.ToXML();
//            //}

//            ////Ellie - changes: moved this line from BuildingPart file
//            //xmlPropertyDetails.WindowsOvershading = sapPropertyDetails.Overshading.FromSAPToXML();
//            //xmlPropertyDetails.PropertyType = sapPropertyDetails.PropertyType;
//            //xmlPropertyDetails.BuiltForm = sapPropertyDetails.BuiltForm;
//            //xmlPropertyDetails.LivingArea = sapPropertyDetails.LivingArea;
//            //xmlPropertyDetails.Orientation = sapPropertyDetails.Orientation;

//            return xmlPropertyDetails;
//        }
//    }
//}
