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
    [Description("List of parts that makes up the building.")]
    public class PropertyDetails : BHoMObject
    {
        [Description("The type of Property, such as House, Flat = 2, Mansion, Maisonette etc. Default = 2 (Flat).")]
        public virtual string PropertyType { get; set; } = "2"; 

        [Description("The building type of the Property e.g. Detached, Semi-Detached, Terrace etc. Together with the Property Type, the Built Form provides a structured description of the property. Default value = 4 (Mid-Terrace)")]
        public virtual string BuiltForm { get; set; } = "4";

        [Description("The size of the living area in square metres.  The living area is the room marked on a plan as the lounge or living room, or the largest public room (irrespective of usage by particular occupants), together with any rooms not separated from the lounge or living room by doors, and including any cupboards directly accessed from the lounge or living room. Living area does not, however, extend over more than one storey, even when stairs enter the living area directly.")]
        public virtual string LivingArea { get; set; } = "0";

        [Description("The orientation of the front of the property. Default = 3 (East).")]
        public virtual string Orientation { get; set; } = "3";

        [Description("")]
        public virtual Heating Heating { get; set; } = null;

        [Description("")]
        public virtual List<BuildingPart> BuildingParts { get; set; } = null;

        [Description("")]
        public virtual Ventilation Ventilation { get; set; } = null;
    }
}

