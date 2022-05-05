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

namespace BH.oM.Environment.SAP
{
    [Description("List of parts that makes up the building.")]
    public class BuildingPart : BHoMObject
    {
        [Description("An integer value which uniquely identifies the building part in the property.  The value 1 must be assigned to the main dwelling.")]
        public virtual string buildingPartNumber { get; set; } = "1";

        [Description("Identifier for the Building part - generally only required if there are more that one Building Parts of the same type e.g. West Wing and East Wing Extensions.")]
        public virtual string identifier { get; set; } = null;

        [Description("The year when this building part was constructed.")]
        public virtual string constructionYear { get; set; } = null;

        [Description("How windows are overshaded.")]
        public virtual oM.Environment.SAP.WindowOvershading Overshading { get; set; } = oM.Environment.SAP.WindowOvershading.AverageOrUnknown;

        [Description("List of openings.")]
        public virtual List<BH.oM.Environment.SAP.Opening> Openings { get; set; } = null;

        [Description("List of floors.")]
        public virtual List<BH.oM.Environment.SAP.Floor> Floors { get; set; } = null;

        [Description("List of roofs.")]
        public virtual List<BH.oM.Environment.SAP.Roof> Roofs { get; set; } = null;

        [Description("List of walls.")]
        public virtual List<BH.oM.Environment.SAP.Wall> Walls { get; set; } = null;

        [Description("List of thermal bridges.")]
        public virtual List<BH.oM.Environment.SAP.ThermalBridge> ThermalBridges { get; set; } = null;
    }
}
