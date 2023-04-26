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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using BH.oM.Base.Attributes;
using BH.oM.Environment.SAP.XML;
using BH.oM.Environment.SAP;

namespace BH.Engine.Environment.SAP
{
    public static partial class Convert
    {
        [Description("Convert SAP Energy Source to XML Energy Source.")]
        [Input("sapEnergySource", "SAP floor to convert.")]
        [Output("xmlEnergySource", "XML floor.")]
        public static BH.oM.Environment.SAP.XML.EnergySource ToXML(this BH.oM.Environment.SAP.EnergySource sapEnergySource)
        {
            BH.oM.Environment.SAP.XML.EnergySource xmlEnergySource = new oM.Environment.SAP.XML.EnergySource();

            xmlEnergySource.ElectricityTariff = sapEnergySource.ElectricityTariff.FromSAPToXML();

            if (sapEnergySource.PhotovoltaicArrays == null)
            {
                xmlEnergySource.PhotovoltaicArrays = null;
            }
            else if (sapEnergySource.PhotovoltaicArrays != null)
            {
                List < BH.oM.Environment.SAP.XML.PhotovoltaicArray > xmlArrays = new List<BH.oM.Environment.SAP.XML.PhotovoltaicArray>();
                
                foreach (var sapArray in sapEnergySource.PhotovoltaicArrays)
                {
                    BH.oM.Environment.SAP.XML.PhotovoltaicArray xmlArray = new oM.Environment.SAP.XML.PhotovoltaicArray();
                    xmlArray.PeakPower = sapArray.PeakPower.ToString();
                    xmlArray.Orientation = sapArray.Orientation.FromSAPToXML();
                    xmlArray.Pitch = sapArray.Pitch.FromSAPToXML();
                    xmlArray.Overshading = sapArray.Overshading.FromSAPToXML();
                    xmlArray.MCSCertificate = sapArray.ArrayDetails.MCSCertificate;
                    xmlArray.MCSCertificateReference = sapArray.ArrayDetails.MCSCertificateReference;
                    xmlArray.ManufacturerName = sapArray.ArrayDetails.ManufacturerName;
                    xmlArray.OvershadingMCS = sapArray.ArrayDetails.OvershadingMCS.ToString();
                    xmlArrays.Add(xmlArray);
                }
                xmlEnergySource.PhotovoltaicArrays.PhotovoltaicArray = xmlArrays;
                
            }

            if (sapEnergySource.WindTurbines == null)
            {
                xmlEnergySource.PhotovoltaicArrays = null;
                
            }
            else if (sapEnergySource.WindTurbines != null)
            {
                List<BH.oM.Environment.SAP.XML.WindTurbine> xmlTurbines = new List<oM.Environment.SAP.XML.WindTurbine>();
                
                foreach (var sapTurbine in sapEnergySource.WindTurbines)
                {
                    BH.oM.Environment.SAP.XML.WindTurbine xmlTurbine = new oM.Environment.SAP.XML.WindTurbine();
                    xmlTurbine.ManufacturerName = sapTurbine.ManufacturerName;
                    xmlTurbine.Certificate = sapTurbine.Certificate;
                    xmlTurbine.RotorDiameter = sapTurbine.RotorDiameter.ToString();
                    xmlTurbine.HubHeight = sapTurbine.HubHeight.ToString();
                    xmlTurbines.Add(xmlTurbine);
                }
                xmlEnergySource.WindTurbines.WindTurbine = xmlTurbines;
            }

            if (sapEnergySource.HydroElectricGeneration == null)
            {
                xmlEnergySource.HydroElectricGeneration = null ;
                xmlEnergySource.HydroElectricCertificate = null;
                xmlEnergySource.IsHydroOutputConnectedToDwellingMeter = false ; 
                xmlEnergySource.HydroElectricGenerationMonths = null;
            }
            else if (sapEnergySource.HydroElectricGeneration != null)
            {
                xmlEnergySource.HydroElectricGeneration = sapEnergySource.HydroElectricGeneration.Generation.ToString();
                xmlEnergySource.HydroElectricCertificate = sapEnergySource.HydroElectricGeneration.HydroElectricCertificate;
                xmlEnergySource.IsHydroOutputConnectedToDwellingMeter = sapEnergySource.HydroElectricGeneration.IsHydroOutputConnectedToDwellingMeter;

                List<HydroElectricGenerationMonth> hydroElectricGeneration = new List<HydroElectricGenerationMonth>();

                foreach (var monthData in sapEnergySource.HydroElectricGeneration.HydroElectricGenerationMonths)
                {
                    HydroElectricGenerationMonth month = new HydroElectricGenerationMonth();
                    month.HydroMonth = monthData.Month.FromSAPToXML();
                    month.HydroValue= monthData.Value;

                    hydroElectricGeneration.Add(month);

                }

                xmlEnergySource.HydroElectricGenerationMonths.HydroElectricGenerationMonth= hydroElectricGeneration;

            }


            return xmlEnergySource;
        }
        private static string FromSAPToXML(this BH.oM.Environment.SAP.ElectricityTariffCode electricityTariffCode)
        {
            switch (electricityTariffCode)
            {
                case BH.oM.Environment.SAP.ElectricityTariffCode.StandardTariff:
                    return "1";

                case BH.oM.Environment.SAP.ElectricityTariffCode.OffPeak7Hour:
                    return "2";

                case BH.oM.Environment.SAP.ElectricityTariffCode.OffPeak10Hour:
                    return "3";

                case BH.oM.Environment.SAP.ElectricityTariffCode._24Hour:
                    return "4";

                case BH.oM.Environment.SAP.ElectricityTariffCode.OffPeak18Hour:
                    return "5";

                case BH.oM.Environment.SAP.ElectricityTariffCode.NotApplicable:
                    return "ND";

                default:
                    return "";
            }
        }
        private static string FromSAPToXML(this BH.oM.Environment.SAP.CompassDirectionCode compassDirectionCode)
        {
            switch (compassDirectionCode)
            {
                case BH.oM.Environment.SAP.CompassDirectionCode.North:
                    return "1";

                case BH.oM.Environment.SAP.CompassDirectionCode.NorthEast:
                    return "2";

                case BH.oM.Environment.SAP.CompassDirectionCode.East:
                    return "3";

                case BH.oM.Environment.SAP.CompassDirectionCode.SouthEast:
                    return "4";

                case BH.oM.Environment.SAP.CompassDirectionCode.South:
                    return "5";

                case BH.oM.Environment.SAP.CompassDirectionCode.SouthWest:
                    return "6";

                case BH.oM.Environment.SAP.CompassDirectionCode.West:
                    return "7";

                case BH.oM.Environment.SAP.CompassDirectionCode.NorthWest:
                    return "8";

                case BH.oM.Environment.SAP.CompassDirectionCode.ToBeUsedWhenThePitchIsHorizontal:
                    return "ND";

                case BH.oM.Environment.SAP.CompassDirectionCode.NotRecordedForBackwardsCompatibilityOnlyDoNotUse:
                    return "NR";

                default:
                    return "";
            }
        }

        private static string FromSAPToXML(this BH.oM.Environment.SAP.SolarCollectorOvershadingCode solarCollectorOvershadingCode)
        {
            switch (solarCollectorOvershadingCode)
            {
                case BH.oM.Environment.SAP.SolarCollectorOvershadingCode.NoneOrVeryLittle:
                    return "1";

                case BH.oM.Environment.SAP.SolarCollectorOvershadingCode.Modest:
                    return "2";

                case BH.oM.Environment.SAP.SolarCollectorOvershadingCode.Significant:
                    return "3";

                case BH.oM.Environment.SAP.SolarCollectorOvershadingCode.Heavy:
                    return "4";

                case BH.oM.Environment.SAP.SolarCollectorOvershadingCode.Severe:
                    return "5";

                case BH.oM.Environment.SAP.SolarCollectorOvershadingCode.ForBackwardsCompatabilityOnlyDoNotUse:
                    return "ND";

                default:
                    return "";
            }
        }

    }
}


