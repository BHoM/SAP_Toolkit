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
using BH.oM.Base;
using System.Xml;
using BH.oM.Environment.SAP;
using System.Runtime.CompilerServices;
using BH.oM.Environment.SAP.XML;

namespace BH.Engine.Environment.SAP
{
    public static partial class Convert
    {
        [Description("Convert SAP Main Heating to XML Main Heating.")]
        [Input("heating", "SAP Main Heating object to convert.")]
        [Output("XmlMainHeating", "XML MainHeating object that has been converted.")]
        public static oM.Environment.SAP.XML.MainHeating ToXML(this oM.Environment.SAP.MainHeatingDetails heating)
        {

            /********************Main Heating Details**********************/

            oM.Environment.SAP.XML.MainHeating xmlHeatingSystem = new oM.Environment.SAP.XML.MainHeating();

            /*-*-*-*MainHeating*-*-*-*/
            xmlHeatingSystem.MainHeatingNumber = null;
            xmlHeatingSystem.MainHeatingCategory = heating.HeatingCategoryCode.FromSAPToXML();
            xmlHeatingSystem.MainHeatingCommissioningCertificate = null;
            xmlHeatingSystem.MainHeatingInstallationEngineer = null;
            xmlHeatingSystem.PCDFFuelIndex = null;
            xmlHeatingSystem.IsMainHeatingHETASApproved = heating.HETASApproved;
            xmlHeatingSystem.MainHeatingFraction = heating.FractionOfHeat;
            xmlHeatingSystem.ElectricCPSUOperatingTemperature = null;
            xmlHeatingSystem.MCSInstalledHeatPump = heating.MCSCertificate;

            if (heating.HeatingDetails != null)
            {
                xmlHeatingSystem.MainHeatingDataSource = heating.HeatingDetails.Source.FromSAPToXML();
                xmlHeatingSystem.MainHeatingIndexNumber = heating.HeatingDetails.ProductIndex;
                xmlHeatingSystem.MainHeatingManufacturer = heating.HeatingDetails.Details.Manufacturer;
                xmlHeatingSystem.MainHeatingModel = heating.HeatingDetails.Details.Model;
                xmlHeatingSystem.MainHeatingCode = heating.HeatingDetails.MainHeatingCode.FromSAPToXML();
                xmlHeatingSystem.HeatEmitterType = heating.HeatingDetails.EmitterType.FromSAPToXML();
                xmlHeatingSystem.UnderfloorHeatEmitterType = heating.HeatingDetails.UnderfloorEmitterType.FromSAPToXML();
                xmlHeatingSystem.EmitterTemperature = heating.HeatingDetails.EmitterTemperature.FromSAPToXML();
                xmlHeatingSystem.CentralHeatingPumpAge = heating.HeatingDetails.PumpAge.FromSAPToXML();

            }

            /*-*-*-*HeatingDeclared*-*-*-*/

            if (heating.HeatingDeclaredValues != null)
            {
                oM.Environment.SAP.XML.HeatingDeclaredValues xmlHeatingSystemDeclaredValues = new oM.Environment.SAP.XML.HeatingDeclaredValues();

                xmlHeatingSystemDeclaredValues.Efficiency = heating.HeatingDeclaredValues.Efficiency;
                xmlHeatingSystemDeclaredValues.MakeModel = heating.HeatingDeclaredValues.MakeModel;
                xmlHeatingSystemDeclaredValues.TestMethod = heating.HeatingDeclaredValues.TestMethod;

                xmlHeatingSystem.MainHeatingDeclaredValues = xmlHeatingSystemDeclaredValues;
            }

            /*-*-*-*Efficiency*-*-*-*/

            if (heating.Efficiency != null)
            {
                xmlHeatingSystem.EfficiencyType = heating.Efficiency.EfficiencyType.FromSAPToXML();
                xmlHeatingSystem.MainHeatingSystemType = heating.Efficiency.MainHeatingSystemType;
                xmlHeatingSystem.MainHeatingEfficiencyWinter = heating.Efficiency.MainHeatingEfficiencyWinter;
                xmlHeatingSystem.MainHeatingEfficiencySummer = heating.Efficiency.MainHeatingEfficiencySummer;
                xmlHeatingSystem.MainHeatingEfficiency = heating.Efficiency.MainHeatingEfficiency;
            }

            /*-*-*-*Heating Controls*-*-*-*/

            if (heating.HeatingControls != null)
            {
                xmlHeatingSystem.MainHeatingControl = heating.HeatingControls.Controls.FromSAPToXML();
                xmlHeatingSystem.HasSeparateDelayedStart = heating.HeatingControls.DelayedStartThermostat;
                xmlHeatingSystem.BurnerControl = heating.HeatingControls.BurnerControl;
                xmlHeatingSystem.ControlIndexNumber = heating.HeatingControls.ControlIndexNumber;
                xmlHeatingSystem.HeatingControllerFunction = heating.HeatingControls.HeatingControllerFunction;
                xmlHeatingSystem.HeatingControllerEcodesignClass = heating.HeatingControls.HeatingControllerEcodesignClass;

                if (heating.HeatingControls.HeatingControllerDetails != null)
                {
                    xmlHeatingSystem.HeatingControllerManufacturer = heating.HeatingControls.HeatingControllerDetails.Manufacturer;
                    xmlHeatingSystem.HeatingControllerModel = heating.HeatingControls.HeatingControllerDetails.Model;


                }
            }


            /*-*-*-*Heating Fuel*-*-*-*/

            if (heating.HeatingFuel != null)
            {
                xmlHeatingSystem.MainFuelType = heating.HeatingFuel.Fuel.FromSAPToXML();
            }



            /*-*-*-*Boiler Information*-*-*-*/
            if (heating.BoilerInformation != null)
            {
                if (heating.BoilerInformation.TypeOfBoiler != null)
                {
                    xmlHeatingSystem.GasOrOilBoilerType = heating.BoilerInformation.TypeOfBoiler.GasOrOilBoiler.FromSAPToXML();
                    xmlHeatingSystem.CombiBoilerType = heating.BoilerInformation.TypeOfBoiler.CombiBoilerType.FromSAPToXML();
                    xmlHeatingSystem.SolidFuelBoilerType = heating.BoilerInformation.TypeOfBoiler.SolidFuelBoilerType.FromSAPToXML();
                    xmlHeatingSystem.IsInterLockedSystem = heating.BoilerInformation.TypeOfBoiler.BoilerInterlock;
                }

                if (heating.BoilerInformation.BoilerDetails != null)
                {
                    xmlHeatingSystem.IsCondensingBoiler = heating.BoilerInformation.BoilerDetails.IsCondensingBoiler;
                    xmlHeatingSystem.CondensingBoilerHeatDistribution = heating.BoilerInformation.BoilerDetails.CondensingBoilerHeatDistribution;
                    xmlHeatingSystem.CaseHeatEmission = heating.BoilerInformation.BoilerDetails.CaseHeatEmission;
                    xmlHeatingSystem.HeatTransferToWater = heating.BoilerInformation.BoilerDetails.HeatTransferToWater;
                    xmlHeatingSystem.BoilerFuelFeed = heating.BoilerInformation.BoilerDetails.BoilerFuelFeed.FromSAPToXML();
                }

                if (heating.BoilerInformation.PumpDetails != null)
                {
                    xmlHeatingSystem.IsCentralHeatingPumpInHeatedSpace = heating.BoilerInformation.PumpDetails.PumpInHeatedSpace;//only if wet system, Need to check these two
                    xmlHeatingSystem.IsOilPumpInHeatedSpace = heating.BoilerInformation.PumpDetails.OilPumpInHeatedSpace;// only if oil boiler NEED TO DIFFERENTIATE THESE DEPENIDING ON TYPE
                }

                if (heating.BoilerInformation.FlueDetails != null)
                {
                    xmlHeatingSystem.MainHeatingFlueType = heating.BoilerInformation.FlueDetails.FlueType.FromSAPToXML();
                    xmlHeatingSystem.IsFlueFanPresent = heating.BoilerInformation.FlueDetails.FanFlued;
                }
            }

            /*-*-*-*Storage Heaters*-*-*-*/

            if (heating.StorageHeaters != null)
            {
                List<oM.Environment.SAP.XML.StorageHeater> xmlStorageHeaters = new List<oM.Environment.SAP.XML.StorageHeater>();
                foreach (var sapHeater in heating.StorageHeaters)
                {
                    oM.Environment.SAP.XML.StorageHeater xmlHeater = new oM.Environment.SAP.XML.StorageHeater();

                    xmlHeater.NumberOfHeaters = sapHeater.NumberOfHeaters;
                    xmlHeater.IndexNumber = sapHeater.IndexNumber;
                    xmlHeater.HighHeatRetention = sapHeater.HighHeatRetention;

                    xmlStorageHeaters.Add(xmlHeater);
                }

                xmlHeatingSystem.StorageHeaters.StorageHeater = xmlStorageHeaters;

            }

            /*-*-*-*FGHRS*-*-*-*/

            if (heating.FGHRS != null)
            {
                xmlHeatingSystem.HasFGHRS = true;
                xmlHeatingSystem.FGHRSIndexNumber = heating.FGHRS.IndexNumber;
                xmlHeatingSystem.FGHRSEnergySource = heating.FGHRS.FGHRSEnergySource.ToXML();
            }
            else if (heating.FGHRS == null)
            {
                xmlHeatingSystem.HasFGHRS = false;
            }

            return xmlHeatingSystem;

        }
    }  
}

