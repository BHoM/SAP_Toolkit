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
    [Description("External Thermal Bridge object for SAP analysis.")]
    public class ExternalJunctions : BHoMObject
    {

        [Description("Steel lintel with perforated steel base plate.")]
        public virtual List<Polyline> E1 { get; set; } = new List<Polyline>();


        [Description("Window lintels - tops of the windows.")]
        public virtual List<Polyline> E2 { get; set; } = new List<Polyline>();


        [Description("Window sills - bottoms of the windows.")]
        public virtual List<Polyline> E3 { get; set; } = new List<Polyline>();


        [Description("Window jambs - sides of the windows (left and right).")]
        public virtual List<Polyline> E4 { get; set; } = new List<Polyline>();


        [Description("Ground floor (normal).")]
        public virtual List<Polyline> E5 { get; set; } = new List<Polyline>();


        [Description("Ground floor (inverted).")]
        public virtual List<Polyline> E19 { get; set; } = new List<Polyline>();


        [Description("Exposed floor (normal).")]
        public virtual List<Polyline> E20 { get; set; } = new List<Polyline>();


        [Description("Exposed floor (inverted).")]
        public virtual List<Polyline> E21 { get; set; } = new List<Polyline>();


        [Description("Basement floor.")]
        public virtual List<Polyline> E22 { get; set; } = new List<Polyline>();


        [Description("Intermediate floor within a dwelling.")]
        public virtual List<Polyline> E6 { get; set; } = new List<Polyline>();


        [Description("Party floor - Connections between floors that are not on ground level.")]
        public virtual List<Polyline> E7 { get; set; } = new List<Polyline>();


        [Description("Balcony within a dwelling, wall insulation continuous.")]
        public virtual List<Polyline> E8 { get; set; } = new List<Polyline>();


        [Description("Balcony between dwellings, wall insulation continuous.")]
        public virtual List<Polyline> E9 { get; set; } = new List<Polyline>();


        [Description("Balconies - The part of the balcony that is attached to the building.")]
        public virtual List<Polyline> E23 { get; set; } = new List<Polyline>();


        [Description("Eaves - Connections to the roof.")]
        public virtual List<Polyline> E10 { get; set; } = new List<Polyline>();


        [Description("Balcony within or between dwellings, balcony support penetrates wall insulation.")]
        public virtual List<Polyline> E24 { get; set; } = new List<Polyline>();


        [Description("Eaves (insulation at rafter level).")]
        public virtual List<Polyline> E11 { get; set; } = new List<Polyline>();


        [Description("Gable (insulation at ceiling level).")]
        public virtual List<Polyline> E12 { get; set; } = new List<Polyline>();


        [Description("Gable (insulation at rafter level).")]
        public virtual List<Polyline> E13 { get; set; } = new List<Polyline>();


        [Description("Flat roof.")]
        public virtual List<Polyline> E14 { get; set; } = new List<Polyline>();


        [Description("Flat roof with parapet.")]
        public virtual List<Polyline> E15 { get; set; } = new List<Polyline>();


        [Description("Corner normal - Convex corners in the space, opposite of inverted.")]
        public virtual List<Polyline> E16 { get; set; } = new List<Polyline>();


        [Description("Corner inverted - Concave corners in the space.")]
        public virtual List<Polyline> E17 { get; set; } = new List<Polyline>();


        [Description("Party wall - the uprights between dwellings.")]
        public virtual List<Polyline> E18 { get; set; } = new List<Polyline>();


        [Description("Staggered something - God knows - Ross knows (Ellie's Addition: It's staggered party wall).")]
        public virtual List<Polyline> E25 { get; set; } = new List<Polyline>();

    }
}

