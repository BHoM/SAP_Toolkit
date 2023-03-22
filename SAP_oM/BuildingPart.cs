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

namespace BH.oM.Environment.SAP
{
    [Description("List of parts that makes up the building.")]
    public class BuildingPart : BHoMObject
    {
        [Description("Identifier for the Building part - generally only required if there are more that one Building Parts of the same type e.g. West Wing and East Wing Extensions.")]
        public virtual string Identifier { get; set; } = null;

        [Description("The year when this building part was constructed.")]
        public virtual string ConstructionYear { get; set; } = "2012";

        [Description("List of roofs.")]
        public virtual List<BH.oM.Environment.SAP.Roof> Roofs { get; set; } = null;

        [Description("List of floors.")]
        public virtual List<BH.oM.Environment.SAP.FloorDimension> Floors { get; set; } = null;

        [Description("List of thermal bridges.")]
        public virtual List<BH.oM.Environment.SAP.ThermalBridge> ThermalBridges { get; set; } = null;

        [Description("Further Global thermal bridge information.")]
        public virtual ThermalBridgeInfo ThermalBridgeInfo { get; set;} = null;

        [Description("List of walls.")]
        public virtual List<BH.oM.Environment.SAP.Wall> Walls { get; set; } = null;
    }
}

