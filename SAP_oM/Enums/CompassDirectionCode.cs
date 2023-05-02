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
    [Description("Code which indicates the compass direction.  Like OrientationCode, but without the \"unknown\" and \"horizontal\" options.")]
    public enum CompassDirectionCode
    {
        North = 1,
        NorthEast = 2,
        East = 3,
        SouthEast = 4,
        South = 5,
        SouthWest = 6,
        West = 7,
        NorthWest = 8,
        ToBeUsedWhenThePitchIsHorizontal,
        NotRecordedForBackwardsCompatibilityOnlyDoNotUse
    }

}

/*
 * private static string FromSAPToXML(this BH.oM.Environment.SAP.CompassDirectionCode compassDirectionCode)
{
	switch (compassDirectionCode)
	{
		case BH.oM.Environment.SAP.CompassDirectionCode.North:
			return "1";

		case BH.oM.Environment.SAP.CompassDirectionCode.NorthEast:
			return "2";

		case BH.oM.Environment.SAP.CompassDirectionCode.East:
			return "3";

		case BH.oM.Environment.SAP.CompassDirectionCode.SouthEast:
			return "4";

		case BH.oM.Environment.SAP.CompassDirectionCode.South:
			return "5";

		case BH.oM.Environment.SAP.CompassDirectionCode.SouthWest:
			return "6";

		case BH.oM.Environment.SAP.CompassDirectionCode.West:
			return "7";

		case BH.oM.Environment.SAP.CompassDirectionCode.NorthWest:
			return "8";

		case BH.oM.Environment.SAP.CompassDirectionCode.ToBeUsedWhenThePitchIsHorizontal:
			return "ND";

		case BH.oM.Environment.SAP.CompassDirectionCode.NotRecordedForBackwardsCompatibilityOnlyDoNotUse:
			return "NR";

		default:
			return"";
	}
}

 */

