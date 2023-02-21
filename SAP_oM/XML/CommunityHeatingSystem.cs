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
    [XmlRoot(ElementName = "SAP-Community-Heating-System", IsNullable = false)]
    public class CommunityHeatingSystem : IObject
    {
        [Description("The name of the community heating system")]
        [XmlElement(ElementName = "Community-Heating-Name")]
        public virtual string CommunityHeatingName {get; set;} = null;

        [Description("the community heating CO2 emission factor")]
        [XmlElement(ElementName = "Community-Heating-CO2-Emission-Factor")]
        public virtual string CommunityHeatingCO2EmissionFactor { get; set; } = null;

        [Description("The community heating Primary Energy Factor")]
        [XmlElement(ElementName = "Community-Heating-Primary-Energy-Factor")]
        public virtual string CommunityHeatingPrimaryEnergyFactor { get; set; } = null;

        [Description("Specifies what kind of heating the community system is used for.")]
        [XmlElement("Community-Heating-Use")]
        public virtual string CommunityHeatingUse { get; set; } = "3";

        [Description("Community heating, hot water cylinder in dwelling?")]
        [XmlElement("Is-Community-Heating-Cylinder-In-Dwelling")]
        public virtual bool? IsCommunityHeatingCylinderInDwelling { get; set; } = null;

        [Description("Heat interface unit in Dwelling?")]
        [XmlElement(ElementName = "Is-HIU-In-Dwelling")]
        public virtual bool? IsHeatInterfaceUnitInDwelling { get; set; } = null;

        [Description("Heat Interface Unit index number, if present.")]
        [XmlElement(ElementName = "HIU-Index-Number")]
        public virtual string HeatInterfaceUnitIndexNumber { get; set; } = null;

        [Description("Community heating distribution")]
        [XmlElement("Community-Heating-Distribution-Type")]
        public virtual string CommunityHeatingDistributionType { get; set; } = "8";

        [Description("")]
        [XmlElement("Community-Heat-Sources")]
        public virtual CommunityHeatSources CommunityHeatSources { get; set; } = null;

        [Description("Used when Community-Heating-Distribution-Type is calculated.")]
        [XmlElement("Community-Heating-Distribution-Loss-Factor")]
        public virtual string CommunityHeatingDistributionLossFactor { get; set; } = null;

        [Description("Used for hot-water-only systems.")]
        [XmlElement("Charging-Linked-To-Heat-Use")]
        public virtual bool? ChargingLinkedToHeatUse { get; set; } = null;

        [Description("Index number of heat network, if applicable.")]
        [XmlElement("Heat-Network-Index-Number")]
        public virtual string HeatNetworkIndexNumber { get; set; } = null;

        [Description("The name by which the sub community heat network is known.")]
        [XmlElement(ElementName = "Sub-Network-Name")]
        public virtual string SubNetworkName { get; set; } = null;

        [Description("Whether the heat network is existing or new.")]
        [XmlElement(ElementName = "Heat-Network-Existing")]
        public virtual bool HeatNetworkExisting { get; set; } = false;
    }
}
