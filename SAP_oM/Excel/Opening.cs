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
    [Description("The details of roofs from the users excel input.")]
    public class OpeningExcel : BHoMObject
    {
        [Description("The type of the opening.")]
        public virtual string OpeningType { get; set; } = string.Empty;

        [Description("The uvalue of the opening.")]
        public virtual double UValue { get; set; } = 0;

        [Description("The gvalue of the opening.")]
        public virtual double GValue { get; set; } = 0;

        [Description("The type of glazing.")]
        public virtual TypeOfGlazing TypeOfGlazing { get; set; } = TypeOfGlazing.DoubleLowEHard02;

        [Description("The glazing gap.")]
        public virtual GlazingGap GlazingGap { get; set; } = GlazingGap.SixteenOrMore;

        [Description("The frame factor of the opening.")]
        public virtual double FrameFactor { get; set; } = 0;

        [Description("The type of frame.")]
        public virtual TypeOfFrame FrameType { get; set; } = TypeOfFrame.Wood;

        [Description("If the opening is argon filled.")]
        public virtual bool ArgonFilled { get; set; } = false;

        [Description("If the opening is krypton filled.")]
        public virtual bool KryptonFilled { get; set; } = false;

        [Description("The data source for the opening.")]
        public virtual OpeningDataSource DataSource { get; set; } = OpeningDataSource.ManufacturerDeclaration;

        [Description("Does the opening intersect with the floor?")]
        public virtual bool FloorIntersection { get; set; } = false;
    }
}