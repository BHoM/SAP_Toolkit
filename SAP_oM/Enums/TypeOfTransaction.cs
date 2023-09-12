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
    [Description(".")]
    public enum TypeOfTransaction
    {
        MarketedSale = 1,
        NonMarketedSale = 2,
        Rental_SocialThisIsForBackwardsCompatibilityOnlyAndShouldNotBeUsed = 3,
        Rental_PrivateThisIsForBackwardsCompatibilityOnlyAndShouldNotBeUsed = 4,
        NoneOfTheAbove = 5,
        NewDwelling = 6,
        NotRecordedThisIsForBackwardsCompatibilityOnlyAndShouldNotBeUsed = 7,
        Rental = 8,
        AssessmentForGreenDeal = 9,
        FollowingGreenDeal = 10,
        FitApplication = 11
    }
}