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
    [Description("An object that holds the main results from a SAPReport.")]
    public class SAPExcelResults : IObject
    {
        [Description("Result Type")]
        public virtual string Type { get; set; } = "Dwelling";

        [Description("The type of dwelling (the plot reference).")]
        public virtual string Dwelling { get; set; } = null;

        [Description("The type of dwelling (the plot reference).")]
        public virtual int DwellingCount { get; set; } = 1;

        [Description("The name of the iteration file.")]
        public virtual string Iteration { get; set; } = null;

        [Description("The total floor area of the dwelling..")]
        public virtual double TFA { get; set; } = 0;

        [Description("The total floor area of the dwelling..")]
        public virtual double FloorAreaPerType { get; set; } = 0;

        [Description("The total wall area of the dwelling.")]
        public virtual double WallArea { get; set; } = 0;

        [Description("The total window area of the dwelling.")]
        public virtual double WindowArea { get; set; } = 0;

        [Description("The total window area of the dwelling.")]
        public virtual double WallToFloor { get; set; } = 0;

        [Description("The total window area of the dwelling.")]
        public virtual double WindowToFloor { get; set; } = 0;

        [Description("The total window area of the dwelling.")]
        public virtual double WindowToWall { get; set; } = 0;

        [Description("The total window area of the dwelling.")]
        public virtual double NotionalWindow { get; set; } = 0;

        [Description("The total window area of the dwelling.")]
        public virtual double WindowToWall2 { get; set; } = 0;

        [Description("The DER of the property.")]
        public virtual double DER { get; set; } = 0;

        [Description(".")]
        public virtual double TER { get; set; } = 0;

        [Description(".")]
        public virtual double DERTERImprovement { get; set; } = 0;

        [Description(".")]
        public virtual double DPER { get; set; } = 0;

        [Description(".")]
        public virtual double TPER { get; set; } = 0;

        [Description(".")]
        public virtual double DPERTPERImprovement { get; set; } = 0;

        [Description(".")]
        public virtual double DFEE { get; set; } = 0;

        [Description(".")]
        public virtual double TFEE { get; set; } = 0;

        [Description(".")]
        public virtual double DFEETFEEImprovement { get; set; } = 0;

        [Description(".")]
        public virtual double DERXTFA { get; set; } = 0;

        [Description(".")]
        public virtual double TERXTFA { get; set; } = 0;

        [Description(".")]
        public virtual double DPERXTFA { get; set; } = 0;

        [Description(".")]
        public virtual double TPERXTFA { get; set; } = 0;

        [Description(".")]
        public virtual double DFEEXTFA { get; set; } = 0;

        [Description(".")]
        public virtual double TFEEXTFA { get; set; } = 0;
    }
}