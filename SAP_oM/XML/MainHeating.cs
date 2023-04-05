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
using System.ComponentModel;
using System.Linq;
using BH.oM.Base;
using System.Xml.Serialization;

namespace BH.oM.Environment.SAP.XML
{
    [Serializable]
    [XmlRoot(ElementName = "SAP-MainHeating", IsNullable = false)]
    public class MainHeating : IObject
    {
        [Description("Identifies the main heating as system 1 or system 2.  System 1 must always be present, system 2 is included only when there are two systems.")]
        [XmlElement("Main-Heating-Number")]
        public virtual string MainHeatingNumber { get; set; } = "1";

        [Description("Category of heating system for the main heating system.")]
        [XmlElement("Main-Heating-Category")]
        public virtual string MainHeatingCategory { get; set; } = "6";

        [Description("Fraction of main heating provided by this system, is 1 if only one main system.")]
        [XmlElement("Main-Heating-Fraction")]
        public virtual double MainHeatingFraction { get; set; } = 1;

        [Description("Source of main heating system data.")]
        [XmlElement("Main-Heating-Data-Source")]
        public virtual string MainHeatingDataSource { get; set; } = "2";

        [Description("Main heating code; when heating data source is SAP table.")]
        [XmlElement("Main-Heating-Code")]
        public virtual string MainHeatingCode { get; set; } = null;

        [Description(".")]
        [XmlElement("Main-Heating-Manufacturer")]
        public virtual string MainHeatingManufacturer { get; set; } = null;

        [Description(".")]
        [XmlElement("Main-Heating-Model")]
        public virtual string MainHeatingModel { get; set; } = null;

        [Description(".")]
        [XmlElement("Main-Heating-Commissioning-Certificate")]
        public virtual string MainHeatingCommissioningCertificate { get; set; } = null;

        [Description(".")]
        [XmlElement("Main-Heating-Installation-Engineer")]
        public virtual string MainHeatingInstallationEngineer { get; set; } = null;

        [Description("The type of fuel used to power the central heating e.g. Gas, Electricity; not used if main heating system is community heating scheme.")]
        [XmlElement("Main-Fuel-Type")]
        public virtual string MainFuelType { get; set; } = "51";

        [Description("Type of Main Control for the Heating System.")]
        [XmlElement("Main-Heating-Control")]
        public virtual string MainHeatingControl { get; set; } = "2305";

        [Description("Identifies the means by which the central heating system (if present) emits heat; only when wet system (radiators or underfloor).")]
        [XmlElement("Heat-Emitter-Type")]
        public virtual string HeatEmitterType { get; set; } = null;

        [Description("Means by which an underfloor heating system (if present) emits heat; only when wet system (underfloor).")]
        [XmlElement("Underfloor-Heat-Emitter-Type")]
        public virtual string UnderfloorHeatEmitterType { get; set; } = null;

        [Description("The type of main heating flue; only if flued appliance.")]
        [XmlElement("Main-Heating-Flue-Type")]
        public virtual string MainHeatingFlueType { get; set; } = null;

        [Description("Central heating pump in heated space?  Only when wet system (radiators or underfloor).")]
        [XmlElement("Is-Central-Heating-Pump-In-Heated-Space")]
        public virtual bool IsCentralHeatingPumpInHeatedSpace { get; set; } = false;

        [Description("Oil pump in heated space?  Only if oil boiler.")]
        [XmlElement("Is-Oil-Pump-In-Heated-Space")]
        public virtual bool IsOilPumpInHeatedSpace { get; set; } = false;

        [Description("Interlocked system?  Only when wet system (radiators or underfloor).")]
        [XmlElement("Is-Interlocked-System")]
        public virtual bool IsInterLockedSystem { get; set; } = false;

        [Description("True if there is a delayed start control separate from a controller in the database.")]
        [XmlElement("Has-Separate-Delayed-Start")]
        public virtual bool HasSeparateDelayedStart { get; set; } = false;

        [Description("Main heating appliance is HETAS approved?  Only if solid fuel.")]
        [XmlElement("Is-Main-Heating-HETAS-Approved")]
        public virtual bool IsMainHeatingHETASApproved { get; set; } = false;

        [Description("Is the boiler a condensing boiler?  If boiler efficiency is manufacturer declaration.")]
        [XmlElement("Is-Condensing-Boiler")]
        public virtual bool? IsCondensingBoiler { get; set; } = null;

        [Description("The temperature distribution of the condensing boiler.")]
        [XmlElement("Condensing-Boiler-Heat-Distribution")]
        public virtual string CondensingBoilerHeatDistribution { get; set; } = null; //55

        [Description("The temperature distribution of the heat pump, for wet systems only.")]
        [XmlElement("Heat-Pump-Heat-Distribution")]
        public virtual string HeatPumpHeatDistribution { get; set; } = null;

        [Description("Boiler type; if boiler efficiency is manufacturer declaration and fuel is gas or oil.")]
        [XmlElement("Gas-Or-Oil-Boiler-Type")]
        public virtual string GasOrOilBoilerType { get; set; } = null;

        [Description("Combi boiler type; if it is a combi boiler and boiler efficiency is manufacturer declaration.")]
        [XmlElement("Combi-Boiler-Type")]
        public virtual string CombiBoilerType { get; set; } = null;

        [Description("Case heat emission at full load in kW; if it is a range cooker boiler and boiler efficiency is manufacturer declaration.")]
        [XmlElement("Case-Heat-Emission")]
        public virtual string CaseHeatEmission { get; set; } = null;

        [Description("Heat transfer to water at full load in kW; if it is a range cooker boiler and boiler efficiency is manufacturer declaration.")]
        [XmlElement("Heat-Transfer-To-Water")]
        public virtual string HeatTransferToWater { get; set; } = null;

        [Description("Boiler type; if boiler efficiency is manufacturer declaration and fuel is solid.")]
        [XmlElement("Solid-Fuel-Boiler-Type")]
        public virtual string SolidFuelBoilerType { get; set; } = null;

        [Description("PCDF index number of the fuel type, only if Main-Fuel-Type is 99 (fuel from database).")]
        [XmlElement(ElementName = "PCDF - Fuel - Index")]
        public virtual string PCDFFuelIndex { get; set; } = null;

        [Description("Indicates whether the heating system contains a fan flue; only if boiler.")]
        [XmlElement("Is-Flue-Fan-Present")]
        public virtual bool? IsFlueFanPresent { get; set; } = null;

        [Description("The type of boiler fuel feed; only if solid fuel boiler with manufacturer declaration.")]
        [XmlElement("Boiler-Fuel-Feed")]
        public virtual string BoilerFuelFeed { get; set; } = null;

        [Description("Electric CPSU operating temperature in Celcius; only if main heating is electric CPSU.")]
        [XmlElement("Electric-CPSU-Operating-Temperature")]
        public virtual string ElectricCPSUOperatingTemperature { get; set; } = null;

        [Description(".")]
        [XmlElement("Burner-Control")]
        public virtual string BurnerControl { get; set; } = null;

        [Description(".")]
        [XmlElement("Efficiency-Type")]
        public virtual string EfficiencyType { get; set; } = null;

        [Description("To be used if main heating data is manufacturer declaration and Efficiency-Type is winter and summer.")]
        [XmlElement("Main-Heating-Efficiency-Winter")]
        public virtual string MainHeatingEfficiencyWinter { get; set; } = null;

        [Description("To be used if main heating data is manufacturer declaration and Efficiency-Type is winter and summer.")]
        [XmlElement("Main-Heating-Efficiency-Summer")]
        public virtual string MainHeatingEfficiencySummer { get; set; } = null;

        [Description("If main heating is any system other than heat network.")]
        [XmlElement("Main-Heating-Efficiency")]
        public virtual string MainHeatingEfficiency { get; set; } = null;

        [Description(".")]
        [XmlElement("Main-Heating-System-Type")]
        public virtual string MainHeatingSystemType { get; set; } = null;

        [Description("Flue Gas Heat Recovery System.")]
        [XmlElement("Has-FGHRS")]
        public virtual bool HasFGHRS { get; set; } = false;

        [Description("FGHRS index number; only if FGHRS.")]
        [XmlElement("FGHRS-Index-Number")]
        public virtual string FGHRSIndexNumber { get; set; } = null; //0

        [Description(".")]
        [XmlElement("FGHRS-Energy-Source")]
        public virtual EnergySource FGHRSEnergySource { get; set; } = null;

        [Description(".")]
        [XmlElement("Main-Heating-Declared-Values")]
        public virtual HeatingDeclaredValues MainHeatingDeclaredValues { get; set; } = null;

        [Description(".")]
        [XmlElement("Storage-Heaters")]
        public virtual StorageHeaters StorageHeaters { get; set; } = null;

        [Description("Gas and oil boilers and heat pump from database: 0, 1, 3 or 4. Other heat pump 0, 2 or 4. Other systems NA.")]
        [XmlElement("Emitter-Temperature")]
        public virtual string EmitterTemperature { get; set; } = null;

        [Description("Whether heat pump was installed under the Microgeneration Certification Scheme.")]
        [XmlElement("MCS-Installed-Heat-Pump")]
        public virtual bool? MCSInstalledHeatPump { get; set; } = null; //false

        [Description("Included for systems with a central heating pump, i.e. wet system.")]
        [XmlElement("Central-Heating-Pump-Age")]
        public virtual string CentralHeatingPumpAge { get; set; } = null;

        [Description("The ID of the time and temperature zone control from the product database.")]
        [XmlElement("Control-Index-Number")]
        public virtual string ControlIndexNumber { get; set; } = null;

        [Description("The ID of the heating system from the product database, if system from database.")]
        [XmlElement("Main-Heating-Index-Number")]
        public virtual string MainHeatingIndexNumber { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Heating-Controller-Function")]
        public virtual string HeatingControllerFunction { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Heating-Controller-Ecodesign-Class")]
        public virtual string HeatingControllerEcodesignClass { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Heating-Controller-Manufacturer")]
        public virtual string HeatingControllerManufacturer { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Heating-Controller-Model")]
        public virtual string HeatingControllerModel { get; set; } = null;

        /*

        public virtual bool ShouldSerializeIsMainHeatingHETASApproved()
        {
            return IsMainHeatingHETASApproved.HasValue;
        }
        public virtual bool ShouldSerializeIsCondensingBoiler()
        {
            return IsCondensingBoiler.HasValue;
        }
        public virtual bool ShouldSerializeIsFlueFanPresent()
        {
            return IsFlueFanPresent.HasValue;
        }
        public virtual bool ShouldSerializeIsCentralHeatingPumpInHeatedSpace()
        {
            return IsCentralHeatingPumpInHeatedSpace.HasValue;
        }
        public virtual bool ShouldSerializeIsOilPumpInHeatedSpace()
        {
            return IsOilPumpInHeatedSpace.HasValue;
        }
        public virtual bool ShouldSerializeIsInterLockedSystem()
        {
            return IsInterLockedSystem.HasValue;
        }
        public virtual bool ShouldSerializeHasSeparateDelayedStart()
        {
            return HasSeparateDelayedStart.HasValue;
        }
        public virtual bool ShouldSerializeHasLoadOrWeatherCompensation()
        {
            return HasLoadOrWeatherCompensation.HasValue;
        }
        public virtual bool ShouldSerializeHasFGHRS()
        {
            return HasFGHRS.HasValue;
        }
        public virtual bool ShouldSerializeMCSInstalledHeatPump()
        {
            return MCSInstalledHeatPump.HasValue;
        }
        */
    }
}
