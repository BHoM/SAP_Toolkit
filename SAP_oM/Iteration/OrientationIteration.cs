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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Environment.SAP.XML;
using BH.oM.Environment.SAP;
using System.ComponentModel;
using BH.oM.Base;

namespace BH.oM.Environment.SAP
{
    [Description("Describe a single iteration for the orientation of the dwellings within the SAP Report. If both a mirror and a rotation are provided, the dwelling will be first mirrored and then rotated clockwise based on the rotation.")]
    public class OrientationIteration : BHoMObject, IIteration
    {
        [Description("Mirror the dwelling straight down a mirror line of the 8 compass points. If no mirror rotation is provided, then no changes to orientation will be made from it (i.e. leave blank to not mirror the dwellings).")]
        public virtual Mirror Mirror { get; set; } = Mirror.None;

        [Description("What rotation to provide to the dwelling in a clockwise direction? Rotation is scaled 1-8 based on the rotation provided. If no rotation is provided, then no changes to orientation will be made.")]
        public virtual Rotation Rotation { get; set; } = Rotation.Zero;
    }
}
