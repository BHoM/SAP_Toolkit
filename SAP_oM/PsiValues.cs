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
using BH.oM.Geometry;

namespace BH.oM.Environment.SAP
{
    [Description("PsiValues for thermal bridge.")]
    public class PsiValues : BHoMObject
    {
        [Description("Psi value forSteel lintel with perforated steel base plate.")]
        public virtual double E1 { get; set; } = double.NaN;


        [Description("Psi value forWindow lintels - tops of the windows.")]
        public virtual double E2 { get; set; } = double.NaN;


        [Description("Psi value forWindow sills - bottoms of the windows.")]
        public virtual double E3 { get; set; } = double.NaN;


        [Description("Psi value forWindow jambs - sides of the windows (left and right).")]
        public virtual double E4 { get; set; } = double.NaN;


        [Description("Psi value forGround floor (normal).")]
        public virtual double E5 { get; set; } = double.NaN;


        [Description("Psi value forGround floor (inverted).")]
        public virtual double E19 { get; set; } = double.NaN;


        [Description("Psi value forExposed floor (normal).")]
        public virtual double E20 { get; set; } = double.NaN;


        [Description("Psi value forExposed floor (inverted).")]
        public virtual double E21 { get; set; } = double.NaN;


        [Description("Psi value forBasement floor.")]
        public virtual double E22 { get; set; } = double.NaN;


        [Description("Psi value forIntermediate floor within a dwelling.")]
        public virtual double E6 { get; set; } = double.NaN;


        [Description("Psi value forParty floor - Connections between floors that are not on ground level.")]
        public virtual double E7 { get; set; } = double.NaN;


        [Description("Psi value forBalcony within a dwelling, wall insulation continuous.")]
        public virtual double E8 { get; set; } = double.NaN;


        [Description("Psi value forBalcony between dwellings, wall insulation continuous.")]
        public virtual double E9 { get; set; } = double.NaN;


        [Description("Psi value forBalconies - The part of the balcony that is attached to the building.")]
        public virtual double E23 { get; set; } = double.NaN;


        [Description("Psi value forEaves - Connections to the roof.")]
        public virtual double E10 { get; set; } = double.NaN;


        [Description("Psi value forBalcony within or between dwellings, balcony support penetrates wall insulation.")]
        public virtual double E24 { get; set; } = double.NaN;


        [Description("Psi value forEaves (insulation at rafter level).")]
        public virtual double E11 { get; set; } = double.NaN;


        [Description("Psi value forGable (insulation at ceiling level).")]
        public virtual double E12 { get; set; } = double.NaN;


        [Description("Psi value forGable (insulation at rafter level).")]
        public virtual double E13 { get; set; } = double.NaN;


        [Description("Psi value forFlat roof.")]
        public virtual double E14 { get; set; } = double.NaN;


        [Description("Psi value forFlat roof with parapet.")]
        public virtual double E15 { get; set; } = double.NaN;


        [Description("Psi value forCorner normal - Convex corners in the space, opposite of inverted.")]
        public virtual double E16 { get; set; } = double.NaN;


        [Description("Psi value forCorner inverted - Concave corners in the space.")]
        public virtual double E17 { get; set; } = double.NaN;


        [Description("Psi value forParty wall - the uprights between dwellings.")]
        public virtual double E18 { get; set; } = double.NaN;

        [Description("Psi value forStaggered something - God knows - Ross knows (Ellie's Addition: It's staggered party wall).")]
        public virtual double E25 { get; set; } = double.NaN;

        [Description("Psi value forGround floor (normal).")]
        public virtual double P1 { get; set; } = double.NaN;

        [Description("Psi value forGround floor (inverted).")]
        public virtual double P6 { get; set; } = double.NaN;

        [Description("Psi value forIntermediate floor within a dwelling.")]
        public virtual double P2 { get; set; } = double.NaN;

        [Description("Psi value forIntermediate floor within a dwelling.")]
        public virtual double P3 { get; set; } = double.NaN;

        [Description("Psi value forExposed floor (normal).")]
        public virtual double P7 { get; set; } = double.NaN;

        [Description("Psi value forExposed floor (inverted).")]
        public virtual double P8 { get; set; } = double.NaN;

        [Description("Psi value forRoof (insulation at ceiling level).")]
        public virtual double P4 { get; set; } = double.NaN;

        [Description("Psi value forRoof (insulation at rafter level).")]
        public virtual double P5 { get; set; } = double.NaN;

        [Description("Psi value forHead of roof window.")]
        public virtual double R1 { get; set; } = double.NaN;

        [Description("Psi value forSill of roof window.")]
        public virtual double R2 { get; set; } = double.NaN;

        [Description("Psi value forJamb of roof window.")]
        public virtual double R3 { get; set; } = double.NaN;

        [Description("Psi value forRidge (vaulted ceiling).")]
        public virtual double R4 { get; set; } = double.NaN;

        [Description("Psi value forRidge (inverted).")]
        public virtual double R5 { get; set; } = double.NaN;

        [Description("Psi value forFlat ceiling.")]
        public virtual double R6 { get; set; } = double.NaN;

        [Description("Psi value forFlat ceiling (inverted).")]
        public virtual double R7 { get; set; } = double.NaN;

        [Description("Psi value forRoof to wall (rafter) .")]
        public virtual double R8 { get; set; } = double.NaN;

        [Description("Psi value forRoof to wall (flat ceiling).")]
        public virtual double R9 { get; set; } = double.NaN;

        [Description("Psi value forAll other roof or room-in-roof junctions).")]
        public virtual double R10 { get; set; } = double.NaN;

        [Description("Psi value forUpstands or kerbs of rooflights.")]
        public virtual double R11 { get; set; } = double.NaN;


    }
}

