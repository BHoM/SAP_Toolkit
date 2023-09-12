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
    [Description("Describe a single iteration for wall changes within the SAP Context. If values for both UValue and Curtain Wall are provided, both will be applied to the walls specified, i.e. they will not be blended to produce one iteration for the UValue change, one for Curtain Wall change, and one for both.")]
    public class WallIteration : IObject
    {
        [Description("New UValue of wall.")]
        public virtual double UValue { get; set; } = -1;

        [Description("Is this a curtain wall.")]
        public virtual bool? CurtainWall { get; set; } = null;

        [Description("A list of walls by name to make changed to.")]
        public virtual List<string> Include { get; set; } = null;
    }
}
