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
using BH.oM.Base.Attributes;

namespace BH.oM.Environment.SAP.XML
{
    [Serializable]
    [XmlRoot(ElementName = "SAP-Opening", IsNullable = false)]
    [NoAutoConstructor]
    public class Opening : BHoMObject
    {
        [Description("Name of the wall or roof which contains the opening.")]
        [XmlElement("Location")]
        public virtual string Location { get; set; } = "Walls (1)";

        [Description("Unique name which identifies this opening.  Can be just a number, e.g. \"1\".  However, an opening cannot have the same name as a wall.")]
        [XmlElement("Name")]
        public virtual string Name { get; set; } = "Opening";

        [Description("The name of the SAP-Opening-Type for this opening.")]
        [XmlElement("Type")]
        public virtual string Type { get; set; } = "Windows (1)";

        [Description("The height of the opening in metres.  If the Height field is used to record the opening area, set the Width to 1.")]
        [XmlElement("Height")]
        public virtual double Height { get; set; } = -1;

        [Description("The width of the opening in metres.  If the Width field is used to record the opening area, set the Height to 1.")]
        [XmlElement("Width")]
        public virtual double Width { get; set; } = -1;

        [Description("Compass direction in which the opening faces.")]
        [XmlElement("Orientation")]
        public virtual string Orientation { get; set; } = "0";//3

        [Description("Pitch of roof containing roof window.")]
        [XmlElement("Pitch")]
        public virtual string Pitch { get; set; } = null;
    }
}


