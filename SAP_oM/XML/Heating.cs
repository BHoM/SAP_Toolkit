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
    [XmlRoot(ElementName = "SAP-Heating", IsNullable = false)]
    public class Heating : IObject
    {
        [Description("The type of Water Heating present in the Property.")]
        public virtual string WaterHeatingCode { get; set; } = null;

        [Description("The type of fuel used to power the central heating e.g. Gas, Electricity.  Not used if water system is main or secondary system.")]
        public virtual string WaterFuelType { get; set; } = null;

        [Description("Hot water cylinder?")]
        public virtual bool? HasHotWaterCylinder { get; set; } = false;

        [Description("Category of heating system for the secondary heating system.")]
        public virtual string SecondaryHeatingCategory { get; set; } = null;

        [Description("Source of secondary heating system data; only if secondary heating system.")]
        public virtual string SecondaryHeatingDataSource { get; set; } = null;

        [Description("Type of secondary heating present in the property; only if required and if heating data source is SAP table.")]
        public virtual string SecondaryHeatingCode { get; set; } = null;

        [Description("The type of fuel used to power the secondary heating e.g. Gas, Electricity; only if required.")]
        public virtual string SecondaryFuelType { get; set; } = null;

        [Description("Secondary flue type; only if secondary efficiency is manufacturer declaration and if there is a flue.")]
        public virtual string SecondaryHeatingFlueType { get; set; } = null;

        [Description("The type of thermal store; not used if main heating system is community heating scheme.")]
        public virtual string ThermalStore { get; set; } = null;

        [Description("Fixed air conditioning?")]
        public virtual bool? HasFixedAirConditioning { get; set; } = false;

        [Description("The type of immersion heating; only if immersion.")]
        public virtual string ImmersionHeatingType { get; set; } = null;

        [Description("Heat pump assisted by immersion?  Only if main heating is heat pump and water heating from heat pump.")]
        public virtual bool? IsHeatPumpAssistedByImmersion { get; set; } = false;

        [Description("Immersion for summer use?  Only if main heating is solid fuel fire or room heater with boiler.")]
        public virtual bool? IsImmersionForSummerUse { get; set; } = false;

        [Description("Secondary heating appliance is HETAS approved?  Only if solid fuel.")]
        public virtual bool? IsSecondaryHeatingHETASApproved { get; set; } = false;

        [Description("Hot water store size in litres; if there is a hot water store.  Store refers to hot water store type which can be cylinder (if thermal store is 'none'), hot-water only thermal store or integrated thermal store.  Not applicable if (a) combi boiler whose data source database or (b) instantaneous combi boiler or (c) combi boiler from SAP table or (d) instantaneous water heater.")]
        public virtual string HotWaterStoreSize { get; set; } = null;

        [Description("Used when a heat pump is associated with a separate and specified hot water vessel.")]
        public virtual string HotWaterStoreHeatTransferArea { get; set; } = null;

        [Description("The source of the hot water store heat loss information; if there is a hot water store.  Not applicable if (a) combi boiler whose data source database or (b) instantaneous combi boiler or (c) combi boiler from SAP table or (d) instantaneous water heater.")]
        public virtual string HotWaterStoreHeatLossSource { get; set; } = null;

        [Description("Hot water store declared loss in kWh/day; only if there is a hot water store and if manufacturer declared loss.  Not applicable if (a) combi boiler whose data source database or (b) instantaneous combi boiler or (c) combi boiler from SAP table or (d) instantaneous water heater.")]
        public virtual string HotWaterStoreHeatLoss { get; set; } = null;

        [Description("Hot water store insulation; only if there is a hot water store and if loss from SAP table.  Not applicable if (a) combi boiler whose data source database or (b) instantaneous combi boiler or (c) combi boiler from SAP table or (d) instantaneous water heater.")]
        public virtual string HotWaterStoreInsulationType { get; set; } = null;

        [Description("Hot water store insulation thickness in mm; only if there is a hot water store and if loss from SAP table.  Not applicable if (a) combi boiler whose data source database or (b) instantaneous combi boiler or (c) combi boiler from SAP table or (d) instantaneous water heater.")]
        public virtual string HotWaterInsulationThickness { get; set; } = null;

        [Description("Thermal store connected to boiler by no more than 1.5 m of insulated pipework?  Only if thermal store.  Not applicable if combi boiler or instantaneous water heater.")]
        public virtual bool? IsThermalStoreNearBoiler { get; set; } = false;

        [Description("Thermal store or CPSU in airing cupboard?  Only if (a) boiler with integrated or hot-water-only thermal store, or (b) main heating is CPSU.")]
        public virtual bool? IsThermalStoreOrCPSUInAiringCupboard { get; set; } = false;

        [Description("Hot water cylinder thermostat?  Not applicable if combi boiler or instantaneous water heater.")]
        public virtual bool? HasCylinderThermostat { get; set; } = false;

        [Description("Hot water cylinder in heated space?  Not applicable if combi boiler or instantaneous water heater.")]
        public virtual bool? IsCylinderInHeatedSpace { get; set; } = false;

        [Description(">Hot water separately timed?  Not applicable if combi boiler or instantaneous water heater.")]
        public virtual bool? IsHotWaterSeperatlyTimed { get; set; } = false;

        [Description("")]
        public virtual string CommunityHeatingSystems { get; set; } = null;

        [Description("")]
        public virtual string MainHeatingDetails { get; set; } = null;

        [Description("")]
        public virtual string HeatingDesignWaterUse { get; set; } = null;

        [Description("")]
        public virtual string MainHeatingSystemsInteraction { get; set; } = null;

        [Description("Use when manufacturer’s declared values.")]
        public virtual string SecondaryHeatingDeclaredValues { get; set; } = null;

        [Description("Not applicable to combi boiler or instantaneous water heater.")]
        public virtual string PrimaryPipeworkInsulation { get; set; } = null;

        [Description("")]
        public virtual string SolarHeatingDetails { get; set; } = null;

        [Description("Waste Water Heat Recovery System.")]
        public virtual string InstantaneousWHRS { get; set; } = null;

        [Description("")]
        public virtual string StorageWHRS { get; set; } = null;
    }
}
