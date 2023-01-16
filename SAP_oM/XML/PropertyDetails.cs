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
        public virtual string PropertyType { get; set; } = null;

        [Description("The building type of the Property e.g. Detached, Semi-Detached, Terrace etc. Together with the Property Type, the Built Form provides a structured description of the property.")]
        [XmlElement("Built-Form")]
        public virtual string BuiltForm { get; set; } = null;

        [Description("The size of the living area in square metres.  The living area is the room marked on a plan as the lounge or living room, or the largest public room (irrespective of usage by particular occupants), together with any rooms not separated from the lounge or living room by doors, and including any cupboards directly accessed from the lounge or living room. Living area does not, however, extend over more than one storey, even when stairs enter the living area directly.")]
        [XmlElement("Living-Area")]
        public virtual string LivingArea { get; set; } = null;

        [Description("The Area of the lowest storey in square meters including unheated or communal areas such as garages or corridors.")]
        [XmlElement("Lowest-Storey-Area")]
        public virtual string LowestStoreyArea { get; set; } = null;

        [Description("The orientation of the front of the property.")]
        [XmlElement("Orientation")]
        public virtual string Orientation { get; set; } = null;

        [Description("Type of conservatory.")]
        [XmlElement("Conservatory-Type")]
        public virtual string ConservatoryType { get; set; } = "1";

        [Description("Terrain type. Needed for wind-turbines and for applying measures.")]
        [XmlElement(ElementName = "Terrain-Type")]
        public virtual int TerrainType { get; set; }

        //may need the following : Has-Special-Feature, Special-Feature-Description,Energy-Saved-Or-Generated, Saved-Or-Generated-Fuel, Energy-Used, Energy-Used-Fule

        [Description("Is property in a smoke control area?  Only if a solid fuel appliance is used.")]
        [XmlElement("Is-In-Smoke-Control-Area")]
        public virtual bool IsInSmokeControlArea { get; set; } = true;

        [Description("What is the cold water source?  Either mains or header tank.")]
        [XmlElement(ElementName = "Cold-Water-Source")]
        public virtual int ColdWaterSource { get; set; }

        [Description("Average amount of overshading of windows.")]
        [XmlElement(ElementName = "Windows-Overshading")]
        public virtual int WindowsOvershading { get; set; }

        [Description("Average thermal mass parameter for the dwelling in kJ/m²K. If omitted it is calculated using the kappa values of each element.")]
        [XmlElement(ElementName = "Thermal-Mass-Parameter")]
        public virtual int ThermalMassParameter { get; set; }

        //May need Additional-Allowable-Electricity-Generation:

        //[Description("Additional allowable electricity generation applicable to this dwelling in kWh per square metre; only if Zero Carbon Home assessment.")]
        //[XmlElement("Additional-Allowable-Electricity-Generation")]
        //public virtual virtual string AdditionalAllowableElectricityGeneration { get; set; } = "0";

        [Description("")]
        [XmlElement(ElementName = "Gas-Smart-Meter-Present")]
        public virtual bool GasSmartMeterPresent { get; set; }

        [Description("")]
        [XmlElement(ElementName = "Electricity-Smart-Meter-Present")]
        public virtual bool ElectricitySmartMeterPresent { get; set; }

        [Description("")]
        [XmlElement(ElementName = "Is-Dwelling-Export-Capable")]
        public virtual bool IsDwellingExportCapable { get; set; }

        [Description("")]
        [XmlElement(ElementName = "PV-Connection")]
        public virtual int PVConnection { get; set; }

        [Description("Diverter present.")]
        [XmlElement(ElementName = "PV-Diverter")]
        public virtual bool PVDiverter { get; set; } = false;

        [Description("Battery capacity capacity if diverter present")]
        [XmlElement(ElementName = "Battery-Capacity")]
        public virtual int BatteryCapacity { get; set; }

        //may need Is-Wind-Turbine-Connected-To-Dwelling-Meter

        [XmlElement(ElementName = "SAP-Heating")]
        public virtual Heating Heating { get; set; }

        [XmlElement(ElementName = "SAP-Energy-Source")]
        public virtual EnergySource EnergySource { get; set; }

        [XmlElement(ElementName = "SAP-Building-Parts")]
        public virtual BuildingParts BuildingParts { get; set; }

        [XmlElement(ElementName = "SAP-Opening-Types")]
        public virtual OpeningTypes OpeningTypes { get; set; }

        [XmlElement(ElementName = "SAP-Ventilation")]
        public virtual Ventilation Ventilation { get; set; }

        [XmlElement(ElementName = "SAP-Lighting")]
        public virtual Lighting Lighting { get; set; }

        [Description("")]
        [XmlElement("SAP-Deselected-Improvements")]
        public virtual DeselectedImprovements DeselectedImprovements { get; set; } = null;

        //may need to include the following

        //[Description("")]
        //[XmlElement("SAP-Flat-Details")]
        //public virtual FlatDetails FlatDetails { get; set; } = new FlatDetails();


        [XmlElement(ElementName = "SAP-Special-Features")]
        public SpecialFeatures SpecialFeatures { get; set; }

        [Description("Design limit for total water use.")]
        [XmlElement("Design-Water-Use")]
        public virtual string DesignWaterUse { get; set; } = "1";

        [Description("")]
        [XmlElement("SAP-Cooling")]
        public virtual Cooling Cooling { get; set; } = null;

    }
}

