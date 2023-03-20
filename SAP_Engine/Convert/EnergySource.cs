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
using BH.oM.Environment.SAP.XML;
using BH.oM.Environment.SAP;

namespace BH.Engine.Environment.SAP
{
    public static partial class Convert
    {
        [Description("Convert SAP Floor to XML floor.")]
        [Input("sapFloor", "SAP floor to convert.")]
        [Output("xmlFloor", "XML floor.")]
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
                    xmlArray.PeakPower = sapArray.PeakPower;
                    xmlArray.Orientation = sapArray.Orientation.FromSAPToXML();
                    xmlArray.Pitch = sapArray.Pitch.FromSAPToXML();
                    xmlArray.Overshading = sapArray.Overshading.FromSAPToXML();
                    xmlArray.MCSCertificate = sapArray.ArrayDetails.MCSCertificate;
                    xmlArray.MCSCertificateReference = sapArray.ArrayDetails.MCSCertificateReference;
                    xmlArray.ManufacturerName = sapArray.ArrayDetails.ManufacturerName;
                    xmlArray.OvershadingMCS = sapArray.ArrayDetails.OvershadingMCS;
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
                    xmlTurbine.RotorDiameter = sapTurbine.RotorDiameter;
                    xmlTurbine.HubHeight = sapTurbine.HubHeight;
                    xmlTurbines.Add(xmlTurbine);
                }
                xmlEnergySource.WindTurbines.WindTurbine = xmlTurbines;
            }

            if (sapEnergySource.HydroElectricGeneration == null)
            {
                xmlEnergySource.HydroElectricGeneration = 0 ;
                xmlEnergySource.HydroElectricCertificate = null;
                xmlEnergySource.IsHydroOutputConnectedToDwellingMeter = false ; 
                xmlEnergySource.HydroElectricGenerationMonths = null;
            }
            else if (sapEnergySource.HydroElectricGeneration != null)
            {
                xmlEnergySource.HydroElectricGeneration = sapEnergySource.HydroElectricGeneration.Generation;
                xmlEnergySource.HydroElectricCertificate = sapEnergySource.HydroElectricGeneration.HydroElectricCertificate;
                xmlEnergySource.IsHydroOutputConnectedToDwellingMeter = sapEnergySource.HydroElectricGeneration.IsHydroOutputConnectedToDwellingMeter;


                //This is messed up - But its friday 
                List<HydroElectricGenerationMonth> hydroElectricGeneration = new List<HydroElectricGenerationMonth>();

                HydroElectricGenerationMonth jan = new HydroElectricGenerationMonth();

                jan.HydroMonth = Months.January.FromSAPToXML();
                jan.HydroValue = sapEnergySource.HydroElectricGeneration.HydroElectricGenerationMonths.Jan;
                hydroElectricGeneration.Add(jan);

                HydroElectricGenerationMonth feb = new HydroElectricGenerationMonth();

                feb.HydroMonth = Months.February.FromSAPToXML();
                feb.HydroValue = sapEnergySource.HydroElectricGeneration.HydroElectricGenerationMonths.Feb;
                hydroElectricGeneration.Add(feb);

                HydroElectricGenerationMonth mar = new HydroElectricGenerationMonth();

                mar.HydroMonth = Months.March.FromSAPToXML();
                mar.HydroValue = sapEnergySource.HydroElectricGeneration.HydroElectricGenerationMonths.Mar;
                hydroElectricGeneration.Add(mar);

                HydroElectricGenerationMonth apr = new HydroElectricGenerationMonth();

                apr.HydroMonth = Months.April.FromSAPToXML();
                apr.HydroValue = sapEnergySource.HydroElectricGeneration.HydroElectricGenerationMonths.Apr;
                hydroElectricGeneration.Add(apr);

                HydroElectricGenerationMonth may = new HydroElectricGenerationMonth();

                may.HydroMonth = Months.May.FromSAPToXML();
                may.HydroValue = sapEnergySource.HydroElectricGeneration.HydroElectricGenerationMonths.May;
                hydroElectricGeneration.Add(may);

                HydroElectricGenerationMonth jun = new HydroElectricGenerationMonth();

                jun.HydroMonth = Months.June.FromSAPToXML();
                jun.HydroValue = sapEnergySource.HydroElectricGeneration.HydroElectricGenerationMonths.Jun;
                hydroElectricGeneration.Add(jun);

                HydroElectricGenerationMonth jul = new HydroElectricGenerationMonth();

                jul.HydroMonth = Months.July.FromSAPToXML();
                jul.HydroValue = sapEnergySource.HydroElectricGeneration.HydroElectricGenerationMonths.Jul;
                hydroElectricGeneration.Add(jul);

                HydroElectricGenerationMonth aug = new HydroElectricGenerationMonth();

                aug.HydroMonth = Months.August.FromSAPToXML();
                aug.HydroValue = sapEnergySource.HydroElectricGeneration.HydroElectricGenerationMonths.Aug;
                hydroElectricGeneration.Add(aug);

                HydroElectricGenerationMonth sep = new HydroElectricGenerationMonth();

                sep.HydroMonth = Months.September.FromSAPToXML();
                sep.HydroValue = sapEnergySource.HydroElectricGeneration.HydroElectricGenerationMonths.Sep;
                hydroElectricGeneration.Add(sep);

                HydroElectricGenerationMonth oct = new HydroElectricGenerationMonth();

                oct.HydroMonth = Months.October.FromSAPToXML();
                oct.HydroValue = sapEnergySource.HydroElectricGeneration.HydroElectricGenerationMonths.Oct;
                hydroElectricGeneration.Add(oct);

                HydroElectricGenerationMonth nov = new HydroElectricGenerationMonth();

                nov.HydroMonth = Months.November.FromSAPToXML();
                nov.HydroValue = sapEnergySource.HydroElectricGeneration.HydroElectricGenerationMonths.Nov;
                hydroElectricGeneration.Add(nov);

                HydroElectricGenerationMonth dec = new HydroElectricGenerationMonth();

                dec.HydroMonth = Months.December.FromSAPToXML();
                dec.HydroValue = sapEnergySource.HydroElectricGeneration.HydroElectricGenerationMonths.Dec;
                hydroElectricGeneration.Add(dec);

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


