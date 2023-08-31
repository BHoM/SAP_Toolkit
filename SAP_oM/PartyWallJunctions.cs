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
    [Description("Party Wall Thermal Bridge object for SAP analysis.")]
    public class PartyWallJunctions : BHoMObject
    {
        [Description("Ground floor (normal).")]
        public virtual List<Polyline> P1 { get; set; } = new List<Polyline>();

        [Description("Ground floor (inverted).")]
        public virtual List<Polyline> P6 { get; set; } = new List<Polyline>();

        [Description("Intermediate floor within a dwelling.")]
        public virtual List<Polyline> P2 { get; set; } = new List<Polyline>();

        [Description("Intermediate floor within a dwelling.")]
        public virtual List<Polyline> P3 { get; set; } = new List<Polyline>();

        [Description("Exposed floor (normal).")]
        public virtual List<Polyline> P7 { get; set; } = new List<Polyline>();

        [Description("Exposed floor (inverted).")]
        public virtual List<Polyline> P8 { get; set; } = new List<Polyline>();

        [Description("Roof (insulation at ceiling level).")]
        public virtual List<Polyline> P4 { get; set; } = new List<Polyline>();

        [Description("Roof (insulation at rafter level).")]
        public virtual List<Polyline> P5 { get; set; } = new List<Polyline>();
    }
}

