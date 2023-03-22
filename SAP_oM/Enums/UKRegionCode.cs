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
    [Description("Code which indicates the region within the UK.")]
    public enum UKRegionCode { Borders = 1, EastAnglia = 2, EastPennines = 3, EastScotland = 4, Highland = 5, Midlands = 6,
        NorthEastEngland = 7, NorthEastScotland = 8, NorthWestEnglandAndSouthWestScotland = 9, NorthernIreland = 10, 
        Orkney = 11, SevernValley = 12, Shetland = 13, SouthEastEngland = 14, SouthWestEngland = 15, SouthernEngland = 16,
        ThamesValley = 17, Wales = 18, WestPennines = 19, WestScotland = 20, WesternIsles = 21, Jersey = 22, Guernsey = 23,
        IsleOfMan = 24 }
}

/*
private static string FromSAPToXML(this BH.oM.Environment.SAP.UKRegionCode uKRegionCode)
{
    switch (uKRegionCode)
    {
        case BH.oM.Environment.SAP.UKRegionCode.Borders:
            return "1";

        case BH.oM.Environment.SAP.UKRegionCode.EastAnglia:
            return "2";

        case BH.oM.Environment.SAP.UKRegionCode.EastPennines:
            return "3";

        case BH.oM.Environment.SAP.UKRegionCode.EastScotland:
            return "4";

        case BH.oM.Environment.SAP.UKRegionCode.Highland:
            return "5";

        case BH.oM.Environment.SAP.UKRegionCode.Midlands:
            return "6";

        case BH.oM.Environment.SAP.UKRegionCode.NorthEastEngland:
            return "7";

        case BH.oM.Environment.SAP.UKRegionCode.NorthEastScotland:
            return "8";

        case BH.oM.Environment.SAP.UKRegionCode.NorthWestEnglandAndSouthWestScotland:
            return "9";

        case BH.oM.Environment.SAP.UKRegionCode.NorthernIreland:
            return "10";

        case BH.oM.Environment.SAP.UKRegionCode.Orkney:
            return "11";

        case BH.oM.Environment.SAP.UKRegionCode.SevernValley:
            return "12";

        case BH.oM.Environment.SAP.UKRegionCode.Shetland:
            return "13";

        case BH.oM.Environment.SAP.UKRegionCode.SouthEastEngland:
            return "14";

        case BH.oM.Environment.SAP.UKRegionCode.SouthWestEngland:
            return "15";

        case BH.oM.Environment.SAP.UKRegionCode.SouthernEngland:
            return "16";

        case BH.oM.Environment.SAP.UKRegionCode.ThamesValley:
            return "17";

        case BH.oM.Environment.SAP.UKRegionCode.Wales:
            return "18";

        case BH.oM.Environment.SAP.UKRegionCode.WestPennines:
            return "19";

        case BH.oM.Environment.SAP.UKRegionCode.WestScotland:
            return "20";

        case BH.oM.Environment.SAP.UKRegionCode.WesternIsles:
            return "21";

        case BH.oM.Environment.SAP.UKRegionCode.Jersey:
            return "22";

        case BH.oM.Environment.SAP.UKRegionCode.Guernsey:
            return "23";

        case BH.oM.Environment.SAP.UKRegionCode.IsleOfMan:
            return "24";

        default:
            return "";
    }
}

*/