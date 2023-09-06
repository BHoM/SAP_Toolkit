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
    [XmlRoot(ElementName = "SAP-Opening-Type", IsNullable = false)]
    [NoAutoConstructor]
    public class OpeningType : BHoMObject
    {
        [Description("Unique name which identifies this opening type.")]
        [XmlElement("Name")]
        public virtual string Name { get; set; } = "Window type 1";

        [Description(".")]
        [XmlElement("Description")]
        public virtual string Description { get; set; } = null; //"Double-glazed windows with aluminimum frame"

        [Description("The source of the data for this type of opening.")]
        [XmlElement("Data-Source")]
        public virtual string DataSource { get; set; } = null; //2

        [Description("The U-value.")]
        [XmlElement("U-Value")]
        public virtual string UValue { get; set; } = null; //1.4

        [Description("The (physical) type of opening that this opening type represents.")]
        [XmlElement("Type")]
        public virtual string Type { get; set; } = null; //4

        [Description("The type of glazing.")]
        [XmlElement("Glazing-Type")]
        public virtual string GlazingType { get; set; } = null;//3

        [Description("Gap between glass panes.")]
        [XmlElement(ElementName = "Glazing-Gap")]
        public virtual string GlazingGap { get; set; } = null; //1

        [Description("Is the opening argon-filled?.")]
        [XmlElement(ElementName = "IsArgonFilled")]
        public virtual bool? IsArgonFilled { get; set; } = null;

        [Description("Is the opening krypton-filled?.")]
        [XmlElement(ElementName = "IsKryptonFilled")]
        public virtual bool? IsKryptonFilled { get; set; } = null; //false

        [Description("The type of frame.")]
        [XmlElement(ElementName = "Frame-Type")]
        public virtual string FrameType { get; set; } = null; //1

        [Description("The solar transmittance; not if a door.")]
        [XmlElement("Solar-Transmittance")]
        public virtual string gValue { get; set; } = null; //0.4

        [Description("The frame factor; not if a door.")]
        [XmlElement("Frame-Factor")]
        public virtual string FrameFactor { get; set; } = null; //0.8

        
        
    }
}

