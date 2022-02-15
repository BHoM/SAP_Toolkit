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
    [XmlRoot(ElementName = "SAP-Community-Heating-System", IsNullable = false)]
    public class CommunityHeatingSystem : IObject
    {
        [Description("Specifies what kind of heating the community system is used for.")]
        [XmlElement("Community-Heating-Use")]
        public virtual string CommunityHeatingUse { get; set; } = null;

        [Description("Community heating, hot water cylinder in dwelling?")]
        [XmlElement("Is-Community-Heating-Cylinder-In-Dwelling")]
        public virtual string IsCommunityHeatingCylinderInDwelling { get; set; } = null;

        [Description("Community heating distribution")]
        [XmlElement("Community-Heating-Distribution-Type")]
        public virtual string CommunityHeatingDistributionType { get; set; } = null;

        [Description("")]
        [XmlElement("Community-Heat-Sources")]
        public virtual CommunityHeatSources CommunityHeatSources { get; set; } = new CommunityHeatSources();

        [Description("Used when Community-Heating-Distribution-Type is calculated.")]
        [XmlElement("Community-Heating-Distribution-Loss-Factor")]
        public virtual string CommunityHeatingDistributionLossFactor { get; set; } = null;

        [Description("Used for hot-water-only systems.")]
        [XmlElement("Charging-Linked-To-Heat-Use")]
        public virtual string ChargingLinkedToHeatUse { get; set; } = null;

        [Description("Index number of heat network, if applicable.")]
        [XmlElement("Heat-Network-Index-Number")]
        public virtual string HeatNetworkIndexNumber { get; set; } = null;
    }
}