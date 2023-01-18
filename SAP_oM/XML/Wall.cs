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
using System.Xml.Serialization;

namespace BH.oM.Environment.SAP.XML
{
    [Serializable]
    [XmlRoot(ElementName = "SAP-Wall", IsNullable = false)]
    public class Wall : IObject
    {
        [Description("Unique name which identifies this wall within its storey.  Can be just a number, e.g. \"1\".  However, a wall cannot have the same name as an opening or a roof.")]
        [XmlElement("Name")]
        public virtual string Name { get; set; } = "Wall";

        [Description("Descriptive notes about the wall.")]
        [XmlElement("Description")]
        public virtual string Description { get; set; } = "A heat loss wall";

        [Description("Type of wall (exposure).")]
        [XmlElement("Wall-Type")]
        public virtual int Type { get; set; } = 2;

        [Description("Total wall area in square metres, inclusive of any openings.")]
        [XmlElement("Total-Wall-Area")]
        public virtual double Area { get; set; } = 0;

        [Description("Exposed wall U-value.")]
        [XmlElement("U-Value")]
        public virtual double UValue { get; set; } = 0.18;

        [Description("Whether the wall is curtain walling.")]
        [XmlElement("Is-Curtain-Walling")]
        public virtual bool CurtainWall { get; set; } = false;

        [Description("Heat capacity per unit area in kJ/m�K.")]
        [XmlElement("Kappa-Value")]
        public virtual double KappaValue { get; set; } = 14;
    }
}

