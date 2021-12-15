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
    public class PressureTest : BHoMObject
    {
        [Description("Whether there has been a pressure test, or whether an assumed value is used for the air permeability.")]
        public virtual PressureTestCode PressureTestType { get; set; } = new PressureTestCode(); //  SAP

        [Description("Air permeability; only if pressure test (yes or assumed).")]
        public virtual string AirPermability { get; set; } = ""; //in convert method, based on pressuretestcode

        [Description("The type of ground floor; only if no pressure test.")] //Can't find types. but to implement in convert, based on pressure test
        public virtual string GroundFloorType { get; set; } = "1";

        [Description("The construction of the walls; only if no pressure test.")]//Can't find types. but to implement in convert, based on pressure test
        public virtual string WallType { get; set; } = "1";

        [Description("Is there a draft lobby?  Only if no pressure test.")]
        public virtual bool HasDraughtLobby { get; set; } = false;

        [Description("Draughtstripping percentage; only if no pressure test.")]
        public virtual string DraughtStripping { get; set; } = "10";

    }
}

