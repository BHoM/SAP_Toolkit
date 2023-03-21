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
using System.Xml.Serialization;
using BH.oM.Base;
using BH.oM.Environment.SAP.XML;

namespace BH.oM.Environment.SAP
{
    [Description("Whether there has been a pressure test, include information depending on if pressure test or not.")]
    public class CommunityHeatingSystem : BHoMObject
    {

        [Description("the community heating CO2 emission factor")]
        public virtual string CommunityHeatingCO2EmissionFactor { get; set; } = null;

        [Description("The community heating Primary Energy Factor")]
        public virtual string CommunityHeatingPrimaryEnergyFactor { get; set; } = null;

        [Description("Specifies what kind of heating the community system is used for.")]
        public virtual CommunityHeatingUseCode CommunityHeatingUse { get; set; } = CommunityHeatingUseCode.SpaceAndWaterHeating;

        [Description("Community Heat Sources.")]
        public virtual List<CommunityHeatSource> CommunityHeatSources { get; set;} = new List<CommunityHeatSource>();   

        [Description("Community heating, hot water cylinder in dwelling?")]
        public virtual bool? IsCommunityHeatingCylinderInDwelling { get; set; } = null;

        [Description("Heat interface unit in Dwelling?")]
        public virtual bool? IsHeatInterfaceUnitInDwelling { get; set; } = null;

        [Description("Heat Interface Unit index number, if present.")]
        public virtual string HeatInterfaceUnitIndexNumber { get; set; } = null;

        [Description("Community heating distribution")]
        public virtual HeatingDistributionCode CommunityHeatingDistributionType { get; set; } = HeatingDistributionCode.NetworkCompliantWithCodeOfPractice;

        [Description("Used when Community-Heating-Distribution-Type is calculated.")]
        public virtual string CommunityHeatingDistributionLossFactor { get; set; } = null;

        [Description("Used for hot-water-only systems.")]
        public virtual bool? ChargingLinkedToHeatUse { get; set; } = null;

        [Description("Index number of heat network, if applicable.")]
        public virtual string HeatNetworkIndexNumber { get; set; } = null;

        [Description("The name by which the sub community heat network is known.")]
        public virtual string SubNetworkName { get; set; } = null;

        [Description("Whether the heat network is existing or new.")]
        public virtual bool HeatNetworkExisting { get; set; } = false;
    }
}

