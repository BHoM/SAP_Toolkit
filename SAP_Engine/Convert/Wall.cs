/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2021, the respective contributors. All rights reserved.
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
using System.ComponentModel;
using BH.oM.Reflection.Attributes;

namespace BH.Engine.Environment.SAP
{
    public static partial class Convert
    {
        [Description("Convert SAP wall to XML wall.")]
        [Input("sapWall", "SAP wall to convert.")]
        [Output("xmlWall", "XML wall.")]
        public static BH.oM.Environment.SAP.XML.Wall ToXML(this BH.oM.Environment.SAP.Wall sapWall)
        {
            BH.oM.Environment.SAP.XML.Wall xmlWall = new BH.oM.Environment.SAP.XML.Wall();
            xmlWall.Name = sapWall.Name;
            xmlWall.Description = "Descriptive notes about the wall.";
            xmlWall.Type = "2"; //Type of wall (exposure). 2 = exposed wall
            xmlWall.Area = sapWall.Area;
            xmlWall.UValue = 0.18;
            xmlWall.KappaValue = 14;
            xmlWall.CurtainWall = sapWall.CurtainWall;

            return xmlWall;
        }
    }
}
