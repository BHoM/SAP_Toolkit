/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2024, the respective contributors. All rights reserved.
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

namespace BH.oM.Environment.SAP.Excel
{
    [Description("The details of roofs from the users excel input.")]
    public class DwellingSchedule : BHoMObject
    {
        [Description("The name of the dwelling the roof is located in.")]
        public virtual string DwellingTypeName { get; set; } = string.Empty;

        [Description("The type of roof")]
        public virtual int Count { get; set; } = 1;

        [Description("The storey the roof is located on.")]
        public virtual OrientationCode DwellingOrientation { get; set; } = OrientationCode.Unknown;

        [Description("Heating file name, eg HeatingFile.xml .")]
        public virtual string FileName { get; set; } = string.Empty;

        [Description("Indication of where a flat is located in a building.")]
        public virtual string Level { get; set; } = null;

        [Description("Count of number of storeys present in the block of for this dwelling.")]
        public virtual string Storeys { get; set; } = null;

        [Description("The year the dwelling was constructed.")]
        public virtual string ConstructionYear { get; set; } = "";

        [Description("The type of property for this dwelling.")]
        public virtual TypeOfProperty PropertyType { get; set; } = TypeOfProperty.Undefined;

        [Description("The type of construction for this dwelling (new build, refurb, etc.).")]
        public virtual DataTypeCode ConstructionType { get; set; } = DataTypeCode.Undefined;

        [Description("The number of wet rooms this dwelling has.")]
        public virtual double WetRooms { get; set; } = 0;

        [Description("The number of sheltered sides this dwelling has.")]
        public virtual int ShelteredSides { get; set; } = 0;
    }
}
