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
using BH.oM.Geometry;

namespace BH.oM.Environment.SAP
{
    [Description("A ThermalBridges object for SAP analysis.")]
    public class ThermalBridgesCurves : BHoMObject
    {
        [Description("Dwelling name.")]
        public virtual string DwellingName { get; set; } = "";

        [Description("Full dwelling name, including window settings and glazing value.")]
        public virtual string Reference { get; set; } = "";

        [Description("Dwelling number, resets with each floor.")]
        public virtual int ID { get; set; } = 0;

        [Description("External Junctions.")]
        public virtual ExternalJunctions ExternalJunctions { get; set; } = new ExternalJunctions();

        [Description("Party Junctions.")]
        public virtual PartyWallJunctions  PartyJunctions { get; set; } = new PartyWallJunctions();

        [Description("Roof Junctions.")]
        public virtual RoofJunctions RoofJunctions { get; set; } = new RoofJunctions();

    }
}

