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
using BH.oM.Environment.SAP.XML;
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
        public static FloorDimension ToFloorDimension(SAPMarkup markup, FloorSchedule importedDimensionData)
        {
            FloorDimension f = new FloorDimension();

            f.Name = markup.Subject;
            f.Description = markup.Subject;
            f.Type = ((int)(BH.oM.Environment.SAP.TypeOfFloor)Enum.Parse(typeof(BH.oM.Environment.SAP.TypeOfFloor), markup.TFAFloorType)).ToString();
            f.Storey = markup.TFADwellingStorey.ToString();
            f.StoreyHeight = markup.TFAHeight.ToString();
            f.HeatLossArea = "0";
            f.KappaValue = "100";
            f.UValue = (importedDimensionData != null ? importedDimensionData.UValue.ToString() : "0.0");
            f.Area = markup.Area;

            return f;
        }
    }
}
