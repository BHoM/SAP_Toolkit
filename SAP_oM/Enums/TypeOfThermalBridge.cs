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
    [Description("Code which indicates a particular type of thermal bridge.")]
    public enum TypeOfThermalBridge { NotDefined = 1, SteelLintelWithPerforatedBase, OtherLintel, Sill, Jamb, GroundFloor_Normal,
        IntermediateFloorWithinDwelling, PartyFloorBetweenDwellings, BalconyWithinDwelling_InsulationContinous, BalconyBetweenDwellings_InsulationContinous,
        Eaves_InsulationAtCeiling, Eaves_InsulationAtRafters, Gable_InsulationAtCeiling, Gable_InsulationAtRafter, FlatRoof, FlatRoofWithParapet,
        Corner_Normal, Corner_Inverted, PartyWallBetweenDwellings, GroundFloor_Inverted, ExposedFloor_Normal, ExposedFloor_Inverted, BasementFloor,
        Balcony_SupportPenetratesWallInsulation, Eaves_InsulationAtCeiling_Inverted, StaggeredPartyWall }
    //P
    //,GroundFloor,ItermediateFloorWithinADwelling, IntermediateFloorBetweenDwellings, Roof_InsulationAtCeiling, Roof_InsulationAtRafters, GroundFloor_Inverted, ExposedFloor_Normal, ExposedFloor_Inverted, 
    //R
    //, HeadOfRoofWindow, SillOfRoofWindow, JambOfRoofWinodw, Ridge_VaultedCeiling, Ridge_Inverted, FlatCeiling, FlatCeiling_Inverted, RoofToWall_Rafter, RoofToWall_FlatCeiling,AllOtherRoofJunction, UpstandsOrKerbs, OtherType1, OtherType2
}
}

