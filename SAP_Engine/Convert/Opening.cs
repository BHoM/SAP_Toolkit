/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2022, the respective contributors. All rights reserved.
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
using System.Xml.Serialization;
using System.ComponentModel;
using BH.oM.Reflection.Attributes;

namespace BH.Engine.Environment.SAP
{
    public static partial class Convert
    {
        [Description("Convert SAP opening to XML opening.")]
        [Input("sapOpening","SAP opening to convert.")]
        [Output("xmlOpening","XML opening.")]
        public static BH.oM.Environment.SAP.XML.Opening ToXML(this BH.oM.Environment.SAP.Opening sapOpening)
        {
            BH.oM.Environment.SAP.XML.Opening xmlOpening = new BH.oM.Environment.SAP.XML.Opening();
            xmlOpening.Name = sapOpening.Name;
            xmlOpening.Type = sapOpening.OpeningType.Name;
            xmlOpening.Location = sapOpening.Host;
            xmlOpening.Orientation = sapOpening.OrientationDegrees.ToString();
            xmlOpening.Width = "6.1";
            xmlOpening.Height = "1.2";
            
            return xmlOpening;
        }
    }
}

