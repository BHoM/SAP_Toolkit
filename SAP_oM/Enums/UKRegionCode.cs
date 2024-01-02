/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2024, the respective contributors. All rights reserved.
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
    [Description("Code which indicates the region within the UK.")]
    public enum UKRegionCode
    {
        Borders = 1,
        EastAnglia = 2,
        EastPennines = 3,
        EastScotland = 4,
        Highland = 5,
        Midlands = 6,
        NorthEastEngland = 7,
        NorthEastScotland = 8,
        NorthWestEnglandAndSouthWestScotland = 9,
        NorthernIreland = 10,
        Orkney = 11,
        SevernValley = 12,
        Shetland = 13,
        SouthEastEngland = 14,
        SouthWestEngland = 15,
        SouthernEngland = 16,
        ThamesValley = 17,
        Wales = 18,
        WestPennines = 19,
        WestScotland = 20,
        WesternIsles = 21,
        Jersey = 22,
        Guernsey = 23,
        IsleOfMan = 24
    }
}
