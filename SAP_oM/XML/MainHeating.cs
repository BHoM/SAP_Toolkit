/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2022, the respective contributors. All rights reserved.
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
        public virtual int? MainHeatingNumber { get; set; } = null;
        
        [Description("Category of heating system for the main heating system.")]
        public virtual string MainHeatingCategory { get; set; } = null;

        [Description("Source of main heating system data.")]
        public virtual string MainHeatingDataSource { get; set; } = null;

        [Description("The ID of the heating system from the product database, if system from database.")]
        public virtual string MainHeatingIndexNumber { get; set; } = null;

        [Description("Is the boiler a condensing boiler?  If boiler efficiency is manufacturer declaration.")]
        public virtual bool? IsCondensingBoiler { get; set; } = false;

        [Description("Boiler type; if boiler efficiency is manufacturer declaration and fuel is gas or oil.")]
        public virtual string GasOrOilBoilerType { get; set; } = null;

        [Description("Combi boiler type; if it is a combi boiler and boiler efficiency is manufacturer declaration.")]
        public virtual string CombiBoilerType { get; set; } = null;

        [Description("Case heat emission at full load in kW; if it is a range cooker boiler and boiler efficiency is manufacturer declaration.")]
        public virtual string CaseHeatEmission { get; set; } = null;

        [Description("Heat transfer to water at full load in kW; if it is a range cooker boiler and boiler efficiency is manufacturer declaration.")]
        public virtual string HeatTransferToWater { get; set; } = null;

        [Description("Boiler type; if boiler efficiency is manufacturer declaration and fuel is solid.")]
        public virtual string SolidFuelBoilerType { get; set; } = null;

        [Description("Main heating code; when heating data source is SAP table.")]
        public virtual string MainHeatingCode { get; set; } = null;

        [Description("The type of fuel used to power the central heating e.g. Gas, Electricity; not used if main heating system is community heating scheme.")]
        public virtual string MainFuelType { get; set; } = null;

        [Description("Type of Main Control for the Heating System.")]
        public virtual string MainHeatingControl { get; set; } = null;

        [Description("Identifies the means by which the central heating system (if present) emits heat; only when wet system (radiators or underfloor).")]
        public virtual string HeatEmitterType { get; set; } = null;

        [Description("Means by which an underfloor heating system (if present) emits heat; only when wet system (underfloor).")]
        public virtual string UnderfloorHeatEmitterType { get; set; } = null;

        [Description("The type of main heating flue; only if flued appliance.")]
        public virtual string MainHeatingFlueType { get; set; } = null;

        [Description("Indicates whether the heating system contains a fan flue; only if boiler.")]
        public virtual bool? IsFlueFanPresent { get; set; } = false;

        [Description("Central heating pump in heated space?  Only when wet system (radiators or underfloor).")]
        public virtual bool? IsCentralHeatingPumpInHeatedSpace { get; set; } = false;

        [Description("Oil pump in heated space?  Only if oil boiler.")]
        public virtual bool? IsOilPumpInHeatedSpace { get; set; } = false;

        [Description("Interlocked system?  Only when wet system (radiators or underfloor).")]
        public virtual bool? IsInterLockedSystem { get; set; } = false;

        [Description("True if there is a delayed start control separate from a controller in the database.")]
        public virtual bool? HasSeparateDelayedStart { get; set; } = false;

        [Description("For backward compatibility only, do not use.")]
        public virtual bool? HasLoadOrWeatherCompensation { get; set; } = null;

        [Description("The type of boiler fuel feed; only if solid fuel boiler with manufacturer declaration.")]
        public virtual string BoilerFuelFeed { get; set; } = null;

        [Description("Main heating appliance is HETAS approved?  Only if solid fuel.")]
        public virtual bool? IsMainHeatingHETASApproved { get; set; } = false;

        [Description("Electric CPSU operating temperature in Celcius; only if main heating is electric CPSU.")]
        public virtual string ElectricCPSUOperatingTemperature { get; set; } = null;

        [Description("Has load or weather compensation?")]
        public virtual string LoadOrWeatherCompensation { get; set; } = null;

        [Description("Fraction of main heating provided by this system, is 1 if only one main system.")]
        public virtual int? MainHeatingFraction { get; set; } = null;

        [Description("")]
        public virtual string BurnerControl { get; set; } = null;

        [Description("")]
        public virtual string EfficiencyType { get; set; } = null;

        [Description("To be used if main heating data is manufacturer declaration and Efficiency-Type is winter and summer.")]
        public virtual string MainHeatingEfficiencyWinter { get; set; } = null;

        [Description("To be used if main heating data is manufacturer declaration and Efficiency-Type is winter and summer.")]
        public virtual string MainHeatingEfficiencySummer { get; set; } = null;

        [Description("Flue Gas Heat Recovery System.")]
        public virtual bool? HasFGHRS { get; set; } = false;

        [Description("FGHRS index number; only if FGHRS")]
        public virtual string FGHRSIndexNumber { get; set; } = null;

        [Description("")]
        public virtual string FGHRSEnergySource { get; set; } = null;

        [Description("")]
        public virtual string MainHeatingDeclaredValues { get; set; } = null;

        [Description("")]
        public virtual string StorageHeaters { get; set; } = null;

        [Description("Gas and oil boilers and heat pump from database: 0, 1, 3 or 4. Other heat pump 0, 2 or 4. Other systems NA.")]
        public virtual string EmitterTemperature { get; set; } = null;

        [Description("Whether heat pump was installed under the Microgeneration Certification Scheme.")]
        public virtual bool? MCSInstalledHeatPump { get; set; } = false;

        [Description("Included for systems with a central heating pump, i.e. wet system.")]
        public virtual string CentralHeatingPumpAge { get; set; } = null;

        [Description("The ID of the controller from the product database.")]
        public virtual string CompensatingControllerIndexNumber { get; set; } = null;

        [Description("The ID of the time and temperature zone control from the product database.")]
        public virtual string TTZCIndexNumber { get; set; } = null;
    }
}