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
    [Description("An individual result for a single iteration of a SAP analysis on a dwelling.")]
    public class SAPResult : IObject
    {

        [Description("The name of the dwelling (the plot reference).")]
        public virtual string DwellingName { get; set; } = "";

        [Description("The number of dwellings in the block that match this dwelling type.")]
        public virtual int DwellingCount { get; set; } = 1;

        [Description("The name of the iteration analysed.")]
        public virtual string Iteration { get; set; } = null;

        [Description("The floor area of a single dwelling of this type. Also referred to as the Total Floor Area (TFA).")]
        public virtual double TotalFloorArea { get; set; } = 0;

        [Description("The total floor area of the dwelling type, calculated as the TotalFloorArea multiplied by the DwellingCount.")]
        public virtual double FloorAreaByBlock { get; set; } = 0;

        [Description("The total wall area of the dwelling.")]
        public virtual double WallArea { get; set; } = 0;

        [Description("The total window area of the dwelling.")]
        public virtual double WindowArea { get; set; } = 0;

        [Description("The ratio of walls to floor for the dwelling.")]
        public virtual double WallToFloor { get; set; } = 0;

        [Description("The ratio of windows to floor for the dwelling.")]
        public virtual double WindowToFloor { get; set; } = 0;

        [Description("The ratio of window to wall for the dwelling.")]
        public virtual double WindowToWall { get; set; } = 0;

        [Description("The total notional window area of the dwelling as your benchmark.")]
        public virtual double NotionalWindow { get; set; } = 0;

        [Description("The ratio of the notional window to wall for the dwelling.")]
        public virtual double NotionalWindowToWall { get; set; } = 0;

        [Description("The Dwelling Emission Rate (DER) - calculated as part of the analysis.")]
        public virtual double DER { get; set; } = 0;

        [Description("The Target Emission Rate (TER) for the dwelling.")]
        public virtual double TER { get; set; } = 0;

        [Description("The improvement of Emission Rate between the Target (TER) and actual (DER). Calculated as ( (TER - DER) / TER).")]
        public virtual double DERTERImprovement { get; set; } = 0;

        [Description("The Dwelling Primary Energy Rating (DPER) for the dwelling - calculated as part of the analysis.")]
        public virtual double DPER { get; set; } = 0;

        [Description("The Target Primary Energy Rating (TPER) for the dwelling.")]
        public virtual double TPER { get; set; } = 0;

        [Description("The improvement of Primary Energy Rating between the Target (TPER) and actual (DPER). Calculated as ( (TPER - DPER) / TPER).")]
        public virtual double DPERTPERImprovement { get; set; } = 0;

        [Description("The Dwelling Fabric Energy Efficiency (DFEE) for the dwelling - calculated as part of the analysis.")]
        public virtual double DFEE { get; set; } = 0;

        [Description("The Target Fabric Energy Efficiency (TFEE) for the dwelling.")]
        public virtual double TFEE { get; set; } = 0;

        [Description("The improvement of Fabric Energy Efficiency between the Target (TFEE) and actual (DFEE). Calculated as ( (TFEE - DFEE) / TFEE).")]
        public virtual double DFEETFEEImprovement { get; set; } = 0;

        [Description("Calculation of the Dwelling Emission Rate (DER) multiplied by the total floor area for the dwelling type, calculated as the DER multiplied by FloorAreaByBlock.")]
        public virtual double BlockDER { get; set; } = 0;

        [Description("Calculation of the Target Emission Rate (TER) multiplied by the total floor area for the dwelling type, calculated as the TER multiplied by FloorAreaByBlock.")]
        public virtual double BlockTER { get; set; } = 0;

        [Description("Calculation of the Dwelling Primary Energy Rating (DPER) multiplied by the total floor area for the dwelling type, calculated as the DPER multiplied by the FloorAreaByBlock.")]
        public virtual double BlockDPER { get; set; } = 0;

        [Description("Calculation of the Target Primary Energy Rating (TPER) multiplied by the total floor area for the dwelling type, calculated as the TPER multiplied by the FloorAreaByBlock.")]
        public virtual double BlockTPER { get; set; } = 0;

        [Description("Calculation of the Dwelling Fabric Energy Efficiency (DFEE) multiplied by the total floor area for the dwelling type, calculated as the DFEE multiplied by the FloorAreaByBlock.")]
        public virtual double BlockDFEE { get; set; } = 0;

        [Description("Calculation of the Target Fabric Energy Efficiency (TFEE) multiplied by the total floor area for the dwelling type, calculated as the TFEE multiplied by the FloorAreaByBlock.")]
        public virtual double BlockTFEE { get; set; } = 0;
    }
}