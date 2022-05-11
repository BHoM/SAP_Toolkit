/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2022, the respective contributors. All rights reserved.
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
    [Description("An exposed/heat loss floor that forms part of the thermal line of the dwelling")]
    public class Floor : BHoMObject
    {
        [Description("Type of floor (exposure).")]
        public virtual TypeOfFloor Type { get; set; } = TypeOfFloor.GroundFloor;

        [Description("The total exposed area of the floor as seen from inside the dwelling (Heat loss area).")]
        public virtual double Area { get; set; } = 0;

        [Description("U-value of the floor.")]
        public virtual string uValue { get; set; } = null;

        [Description("The name of the dwelling that the floor is part of")]
        public virtual string DwellingName { get; set; } = "";

    }
}

