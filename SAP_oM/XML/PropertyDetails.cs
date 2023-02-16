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
    [XmlRoot(ElementName = "SAP-Property-Details", IsNullable = false)]
    public class PropertyDetails : IObject
    {
        [Description("The type of Property, such as House, Flat, Mansion, Maisonette etc.")]
        [XmlElement("Property-Type")]
        public virtual string PropertyType { get; set; } = "0";

        [Description("The building type of the Property e.g. Detached, Semi-Detached, Terrace etc. Together with the Property Type, the Built Form provides a structured description of the property.")]
        [XmlElement("Built-Form")]
        public virtual string BuiltForm { get; set; } = "4";

        [Description("The size of the living area in square metres.  The living area is the room marked on a plan as the lounge or living room, or the largest public room (irrespective of usage by particular occupants), together with any rooms not separated from the lounge or living room by doors, and including any cupboards directly accessed from the lounge or living room. Living area does not, however, extend over more than one storey, even when stairs enter the living area directly.")]
        [XmlElement("Living-Area")]
        public virtual string LivingArea { get; set; } = "0";

        [Description("The Area of the lowest storey in square meters including unheated or communal areas such as garages or corridors.")]
        [XmlElement("Lowest-Storey-Area")]
        public virtual double LowestStoreyArea { get; set; } = 0;

        [Description("The orientation of the front of the property.")]
        [XmlElement("Orientation")]
        public virtual string Orientation { get; set; } = "1";

        [Description("Type of conservatory.")]
        [XmlElement("Conservatory-Type")]
        public virtual string ConservatoryType { get; set; } = "1";

        [Description("Terrain type. Needed for wind-turbines and for applying measures.")]
        [XmlElement(ElementName = "Terrain-Type")]
        public virtual string TerrainType { get; set; } = "1";

        [Description("For backwards compatibility only, do not use.")]
        [XmlElement(ElementName = "Has-Special-Feature")]
        public virtual bool HasSpecialFeature { get; set; } = false;

        [Description("For backwards compatibility only, do not use.")]
        [XmlElement(ElementName = "Special-Feature-Description")]
        public virtual string SpecialFeatureDescription { get; set; } = null;

        [Description("For backwards compatibility only, do not use.")]
        [XmlElement(ElementName = "Energy-Saved-Or-Generated")]
        public virtual double EnergySavedOrGenerated { get; set; } = 0;

        [Description("For backwards compatibility only, do not use.")]
        [XmlElement(ElementName = "Saved-Or-Generated-Fuel")]
        public virtual string SavedOrGeneratedFuel { get; set; } = null;

        [Description("For backwards compatibility only, do not use.")]
        [XmlElement(ElementName = "Energy-Used")]
        public virtual int EnergyUsed { get; set; } = 0;

        [Description("For backwards compatibility only, do not use.")]
        [XmlElement(ElementName = "Energy-Used-Fuel")]
        public virtual string EnergyUsedFuel { get; set; } = null;
       
        [Description("Is property in a smoke control area?  Only if a solid fuel appliance is used.")]
        [XmlElement("Is-In-Smoke-Control-Area")]
        public virtual string IsInSmokeControlArea { get; set; } = "true";

        [Description("What is the cold water source?  Either mains or header tank.")]
        [XmlElement(ElementName = "Cold-Water-Source")]
        public virtual string ColdWaterSource { get; set; } = "1";

        [Description("Average amount of overshading of windows.")]
        [XmlElement(ElementName = "Windows-Overshading")]
        public virtual string WindowsOvershading { get; set; } = "2";

        [Description("Average thermal mass parameter for the dwelling in kJ/m²K. If omitted it is calculated using the kappa values of each element.")]
        [XmlElement(ElementName = "Thermal-Mass-Parameter")]
        public virtual double ThermalMassParameter { get; set; } = 0;

        [Description("Additional allowable electricity generation applicable to this dwelling in kWh per square metre; only if Zero Carbon Home assessment.")]
        [XmlElement("Additional-Allowable-Electricity-Generation")]
        public virtual string AdditionalAllowableElectricityGeneration { get; set; } = "0";

        [Description("")]
        [XmlElement(ElementName = "Gas-Smart-Meter-Present")]
        public virtual bool GasSmartMeterPresent { get; set; } = false;

        [Description("")]
        [XmlElement(ElementName = "Electricity-Smart-Meter-Present")]
        public virtual bool ElectricitySmartMeterPresent { get; set; } = false;

        [Description("")]
        [XmlElement(ElementName = "Is-Dwelling-Export-Capable")]
        public virtual bool IsDwellingExportCapable { get; set; } = false;

        [Description("")]
        [XmlElement(ElementName = "PV-Connection")]
        public virtual string PVConnection { get; set; } = "0";

        [Description("Diverter present.")]
        [XmlElement(ElementName = "PV-Diverter")]
        public virtual bool? PVDiverter { get; set; } = false;

        [Description("Battery capacity capacity if diverter present")]
        [XmlElement(ElementName = "Battery-Capacity")]
        public virtual double BatteryCapacity { get; set; } = 0;

        [Description("Whether the wind turbine is connected to the Dwelling's meter.")]
        [XmlElement(ElementName = "Is-Wind-Turbine-Connected-To-Dwelling-Meter")]
        public virtual bool? IsWindTurbineConnectedToDwellingMeter { get; set; } = false;

        [Description("")]
        [XmlElement(ElementName = "SAP-Heating")]
        public virtual Heating Heating { get; set; } = null;

        [Description("")]
        [XmlElement(ElementName = "SAP-Energy-Source")]
        public virtual EnergySource EnergySource { get; set; } = null;

        [Description("Details of the significant building parts that comprise the main habitable building in the property.")]
        [XmlElement(ElementName = "SAP-Building-Parts")]
        public virtual BuildingParts BuildingParts { get; set; } = null;

        [Description("Types of exposed openings that make up a particular property.")]
        [XmlElement(ElementName = "SAP-Opening-Types")]
        public virtual OpeningTypes OpeningTypes { get; set; } = null;

        [Description("Details of the means by which the building is ventilated")]
        [XmlElement(ElementName = "SAP-Ventilation")]
        public virtual Ventilation Ventilation { get; set; } = null;

        [Description("Details of the main lighting for the property")]
        [XmlElement(ElementName = "SAP-Lighting")]
        public virtual Lighting Lighting { get; set; } = null;

        [Description("")]
        [XmlElement("SAP-Deselected-Improvements")]
        public virtual DeselectedImprovements DeselectedImprovements { get; set; } = null;

        [Description("Detials of location of flat in building")]
        [XmlElement("SAP-Flat-Details")]
        public virtual FlatDetails FlatDetails { get; set; } = null;

        [Description("")]
        [XmlElement(ElementName = "SAP-Special-Features")]
        public SpecialFeatures SpecialFeatures { get; set; } = null;

        [Description("Design limit for total water use.")]
        [XmlElement("Design-Water-Use")]
        public virtual string DesignWaterUse { get; set; } = "1";

        [Description("")]
        [XmlElement("SAP-Cooling")]
        public virtual Cooling Cooling { get; set; } = null;

    }
}

