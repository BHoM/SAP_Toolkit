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
using BH.oM.Adapter.Commands;
using BH.oM.Base;

using BH.oM.Geometry;

namespace BH.oM.Environment.SAP
{
    [Description("Roof Junction Thermal Bridge object for SAP analysis.")]
    public class RoofJunctions : BHoMObject
    {

        [Description("Head of roof window.")]
        public virtual List<Polyline> R1 { get; set; } = new List<Polyline>();

        [Description("Sill of roof window.")]
        public virtual List<Polyline> R2 { get; set; } = new List<Polyline>();

        [Description("Jamb of roof window.")]
        public virtual List<Polyline> R3 { get; set; } = new List<Polyline>();

        [Description("Ridge (vaulted ceiling).")]
        public virtual List<Polyline> R4 { get; set; } = new List<Polyline>();

        [Description("Ridge (inverted).")]
        public virtual List<Polyline> R5 { get; set; } = new List<Polyline>();

        [Description("Flat ceiling.")]
        public virtual List<Polyline> R6 { get; set; } = new List<Polyline>();

        [Description("Flat ceiling (inverted).")]
        public virtual List<Polyline> R7 { get; set; } = new List<Polyline>();

        [Description("Roof to wall (rafter) .")]
        public virtual List<Polyline> R8 { get; set; } = new List<Polyline>();

        [Description("Roof to wall (flat ceiling).")]
        public virtual List<Polyline> R9 { get; set; } = new List<Polyline>();

        [Description("All other roof or room-in-roof junctions).")]
        public virtual List<Polyline> R10 { get; set; } = new List<Polyline>();

        [Description("Upstands or kerbs of rooflights.")]
        public virtual List<Polyline> R11 { get; set; } = new List<Polyline>();
    }
}

