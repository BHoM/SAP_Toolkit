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
    [XmlRoot(ElementName = "SAP-Opening", IsNullable = false)]
    public class Opening : IObject
    {
        [XmlElement("Location")]
        public virtual string Location { get; set; } = "Walls (1)";

        [XmlElement("Name")]
        public virtual string Name { get; set; } = "Opening";

        [XmlElement("Type")]
        public virtual string Type { get; set; } = "Windows (1)";

        [XmlElement("Height")]
        public virtual double Height { get; set; } = 0;

        [XmlElement("Width")]
        public virtual double Width { get; set; } = 0;

        [XmlElement("Pitch")]
        public virtual double Pitch { get; set; } = 0;

        [XmlElement("Orientation")]
        public virtual int Orientation { get; set; } = 3;


    }
}


