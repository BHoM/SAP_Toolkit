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
    [Description("The opening type defines the thermal properties of a series of openings")]
    public class OpeningType : BHoMObject
    {
        [Description("The source of the data for this type of opening.")]
        public virtual OpeningDataSource DataSource { get; set; } = OpeningDataSource.ManufacturerDeclaration;

        [Description("The type of opening e.g. solid door, glazed window or rooflight. This should be selected in line with the SAP 2012 guidance")]
        public virtual TypeOfOpening Type { get; set; } = TypeOfOpening.GlazedWindow;

        [Description("The type of glazing; if U-value is from BFRC or manufacturer declaration, give as one of: single, double, triple")]
        public virtual TypeOfGlazing GlazingType { get; set; } = TypeOfGlazing.NotAppicable;

        [Description("The U-value or thermal conductance of an opening including panes, panels and frame")]
        public virtual double uValue { get; set; } = 1.4;

        [Description("The g-value or solar heat transmittance of the glazed/transparent part of an opening")]
        public virtual double gValue { get; set; } = 0.4;

        [Description("The fraction of the total opening area that is glazed/transparent e.g. a value of 0.8 means 20% of the opening area is frame")]
        public virtual double FrameFactor { get; set; } = 0.8;
    }
}