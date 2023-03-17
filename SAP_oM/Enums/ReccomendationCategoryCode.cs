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
    [Description("")]
    public enum RecommendationCategoryCode { LowerCostThisIsForBackwardsCompatibilityOnlyAndShouldNotBeUsed = 1, HigherCostThisIsForBackwardsCompatibilityOnlyAndShouldNotBeUsed = 2, 
		FurtherMeasureThisIsForBackwardsCompatibilityOnlyAndShouldNotBeUsed = 3, Deselected_ThisIsForBackwardsCompatibilityOnlyAndShouldNotBeUsed= 4, 
		NormalMeasure = 5, AlternativeMeasure = 6 }
}

/*
private static string FromSAPToXML(this BH.oM.Environment.SAP.RecommendationCategoryCode recommendationCategoryCode)
{
	switch (recommendationCategoryCode)
	{
		case BH.oM.Environment.SAP.RecommendationCategoryCode.LowerCostThisIsForBackwardsCompatibilityOnlyAndShouldNotBeUsed:
			return "1";

		case BH.oM.Environment.SAP.RecommendationCategoryCode.HigherCostThisIsForBackwardsCompatibilityOnlyAndShouldNotBeUsed:
			return "2";

		case BH.oM.Environment.SAP.RecommendationCategoryCode.FurtherMeasureThisIsForBackwardsCompatibilityOnlyAndShouldNotBeUsed:
			return "3";

		case BH.oM.Environment.SAP.RecommendationCategoryCode.DeselectedThisIsForBackwardsCompatibilityOnlyAndShouldNotBeUsed:
			return "4";

		case BH.oM.Environment.SAP.RecommendationCategoryCode.NormalMeasure:
			return "5";

		case BH.oM.Environment.SAP.RecommendationCategoryCode.AlternativeMeasure:
			return "6";

		default:
			return"";
	}
}

 */

