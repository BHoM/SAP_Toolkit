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

namespace BH.oM.Environment.SAP.Excel
{
    [Description("The details of walls from the users excel input.")]
    public class Walls : BHoMObject
    {
        [Description("The name of the dwelling the wall is located in.")]
        public virtual string Dwelling { get; set; } = string.Empty;

        [Description("The type of wall")]
        public virtual TypeOfWall Type { get; set; } = TypeOfWall.ExposedWall;

        [Description("The name of the wall.")]
        public virtual string WallName { get; set; } = string.Empty;

        [Description("If the wall is a curtain wall.")]
        public virtual bool CurtainWall { get; set; } = false;

        [Description("The uvalue of the wall")]
        public virtual double UValue { get; set; } = 0;
    }
}

