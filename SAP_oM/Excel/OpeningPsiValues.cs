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
using BH.oM.Geometry;

namespace BH.oM.Environment.SAP.Excel
{
    [Description("PsiValues for thermal bridge.")]
    public class OpeningPsiValues : BHoMObject
    {
        [Description("Opening Type.")]
        public virtual string OpeningType { get; set; } = string.Empty;

        [Description("Psi value forWindow lintels - tops of the windows.")]
        public virtual List<PsiValues> PsiValues { get; set; } = new List<PsiValues>();

        [Description("Psi value forWindow jambs - sides of the windows (left and right).")]
        public virtual bool FloorIntersection { get; set; } = false;
    }
}