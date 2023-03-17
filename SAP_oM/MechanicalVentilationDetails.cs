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

namespace BH.oM.Environment.SAP
{
    [Description("User defined details")]
    public class MechanicalVentilationDetails : BHoMObject
    {
        [Description("Mechanical vent duct type; if MEV c, MV or MVHR.")]
        public virtual TypeofDuct DuctType { get; set; } = TypeofDuct.Flexible;

        [Description("Mechanical ventilation duct placement; if MVHR.")]
        public virtual TypeOfDuctPlacement DuctPlacement { get; set; } = TypeOfDuctPlacement.InsideHeatedEnvelope;

        [Description("Mechanical vent system index number; if mechanical vent data from database (MEV c, MEV dc, MV, MVHR).")]
        public virtual string SystemIndexNumber { get; set; } = null;

        [Description("Mechanical ventilation system make and model; if mech vent system data is manufacturer declaration.")]
        public virtual string SystemMakeModel { get; set; } = null;

        [Description("Mechanical vent specific fan power in watts per (litres per second); if mechanical vent data from manufacturer declaration (MEV c, MV, MVHR).")]
        public virtual string SpecificFanPower { get; set; } = null;

        [Description("Mechanical vent heat recovery efficiency percentage; if mechanical vent data from manufacturer declaration (MVHR).")]
        public virtual string HeatRecoveryEfficiency { get; set; } = null;
    }
}


