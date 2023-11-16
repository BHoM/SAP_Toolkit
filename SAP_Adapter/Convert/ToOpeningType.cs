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

using BH.oM.Base.Attributes;
using BH.oM.Base;
using BH.oM.Environment.SAP.Bluebeam;
using SXML = BH.oM.Environment.SAP.XML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using BH.oM.Environment.SAP.Excel;

namespace BH.Adapter.SAP
{
    public static partial class Convert
    {
        public static SXML.OpeningType ToOpeningType(OpeningSchedule openingDefinition, string openingType, string openingTypeName)
        {
            SXML.OpeningType type = new SXML.OpeningType();

            type.Name = openingTypeName;
            type.Description = openingDefinition.OpeningType;
            type.DataSource = ((int)openingDefinition.DataSource).ToString();
            type.UValue = openingDefinition.UValue.ToString();
            type.Type = openingType;
            type.GlazingType = ((int)openingDefinition.TypeOfGlazing).ToString();
            type.GlazingType = ((int)openingDefinition.GlazingGap).ToString();
            type.IsArgonFilled = openingDefinition.ArgonFilled;
            type.IsKryptonFilled = openingDefinition.KryptonFilled;
            type.FrameType = ((int)openingDefinition.FrameType).ToString();
            type.GValue = openingDefinition.GValue.ToString();
            type.FrameFactor = openingDefinition.FrameFactor.ToString();
            type.IntersectsFloor = openingDefinition.FloorIntersection;

            return type;
        }
    }
}
