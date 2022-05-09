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

        [Description("The orientation of the front of the property.")]
        [XmlElement("Orientation")]
        public virtual string Orientation { get; set; } = null;

        [Description("Type of conservatory.")]
        [XmlElement("Conservatory-Type")]
        public virtual string ConservatoryType { get; set; } = "1";

        [Description("Is property in a smoke control area?  Only if a solid fuel appliance is used.")]
        [XmlElement("Is-In-Smoke-Control-Area")]
        public virtual bool IsInSmokeControlArea { get; set; } = true;

        [Description("Additional allowable electricity generation applicable to this dwelling in kWh per square metre; only if Zero Carbon Home assessment.")]
        [XmlElement("Additional-Allowable-Electricity-Generation")]
        public virtual string AdditionalAllowableElectricityGeneration { get; set; } = "0";

        [Description("")]
        [XmlElement("SAP-Heating")]
        public virtual Heating Heating { get; set; } = new Heating();

        [Description("")]
        [XmlElement("SAP-Energy-Source")]
        public virtual EnergySource EnergySource { get; set; } = new EnergySource();

        [Description("")]
        [XmlElement("SAP-Building-Parts")]
        public virtual BuildingParts BuildingParts { get; set; } = new BuildingParts();

        [Description("")]
        [XmlElement("SAP-Opening-Types")]
        public virtual OpeningTypes OpeningTypes { get; set; } = new OpeningTypes();

        [Description("")]
        [XmlElement("SAP-Ventilation")]
        public virtual Ventilation Ventilation { get; set; } = new Ventilation();

        [Description("")]
        [XmlElement("SAP-Deselected-Improvements")]
        public virtual DeselectedImprovements DeselectedImprovements { get; set; } = null;

        [Description("")]
        [XmlElement("SAP-Flat-Details")]
        public virtual FlatDetails FlatDetails { get; set; } = new FlatDetails();

        [Description("For backwards compatibility, do not use")]
        [XmlElement("SAP-Special-Features")]
        public virtual SpecialFeatures SpecialFeatures { get; set; } = null;

        [Description("Design limit for total water use.")]
        [XmlElement("Design-Water-Use")]
        public virtual string DesignWaterUse { get; set; } = "1";

        [Description("")]
        [XmlElement("SAP-Cooling")]
        public virtual Cooling Cooling { get; set; } = null;
        
    }
}
