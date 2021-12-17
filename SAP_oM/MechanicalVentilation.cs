/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2021, the respective contributors. All rights reserved.
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
    [Description("Whether there has been a pressure test, include information depending on if pressure test or not.")]
    public class MechanicalVentilation : BHoMObject
    {
        [Description("The type of ventilation.")]
        public virtual TypeOfVentilation? Type { get; set; } = null;

        [Description("Is mechanical vent an approved installer scheme.")]
        public virtual bool ApprovedInstallerScheme { get; set; } = true; //maybe separate 

        [Description("Source of mechanical ventilation data; only if mechanical ventilation.")]
        public virtual VentilationDataSource DataSource { get; set; } = new VentilationDataSource();

        [Description("Number of wet rooms, including the kitchen; if mech vent data from manufacturer declaration or database (MEV c, MV, MVHR).")]
        public virtual string numWetRooms { get; set; } = "";

        [Description("Mechanical vent duct insulation; if MVHR.")]
        public virtual TypeofDuctInsulation DuctInsulation { get; set; } = new TypeofDuctInsulation(); //also in vent component ENUM DONE

        [Description("Mechanical vent duct type; if MEV c, MV or MVHR.")]
        public virtual TypeofDuct DuctType { get; set; } = new TypeofDuct(); //also in vent component ENUM DONE

        [Description("Mechanical vent system index number; if mechanical vent data from database (MEV c, MEV dc, MV, MVHR).")]
        public virtual string SystemIndexNumber { get; set; } = "2"; //also in vent component

        [Description("Mechanical ventilation system make and model; if mech vent system data is manufacturer declaration.")]
        public virtual string SystemMakeModel { get; set; } = "2"; //also in vent component

        [Description("Mechanical vent specific fan power in watts per (litres per second); if mechanical vent data from manufacturer declaration (MEV c, MV, MVHR).")]
        public virtual string SpecificFanPower { get; set; } = "2"; //also in vent component

        [Description("Mechanical vent heat recovery efficiency percentage; if mechanical vent data from manufacturer declaration (MVHR).")]
        public virtual string HeatRecoveryEfficiency { get; set; } = "2"; //also in vent component

    }
}

