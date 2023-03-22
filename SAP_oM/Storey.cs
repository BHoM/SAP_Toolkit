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
    [Description("Storey Details.")]
    public class Storey : BHoMObject
    {
        [Description("The storey number within the dwelling e.g. 0 = lowest floor.")]
        public virtual int StoreyNumber { get; set; } = 0;

        [Description("The total floor area of the storey within the dwelling, measured to the internal surface of the walls.")]
        public virtual double Area { get; set; } = 0;

        [Description("The average floor to ceiling height of the storey within the dwelling, measured as per SAP 2012 Conventions 2.03.")]
        public virtual double Height { get; set; } = 0;

    }

}

