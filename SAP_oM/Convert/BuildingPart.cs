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


namespace BH.oM.Environment.SAP.Convert
{
    public static partial class Convert
    {
        [Description("Convert SAP BuildingPart to XML BuildingPart.")]
        [Input("buildingPart", "SAP BuildingPart to convert.")]
        [Output("buildingPart", "XML BuildingPart.")]
        public static BH.oM.Environment.SAP.XML.BuildingPart xmlBuildingPart(this BH.oM.Environment.SAP.Wall sapBuildingPart)
        {
            BH.oM.Environment.SAP.XML.BuildingPart xmlBuildingPart = new BH.oM.Environment.SAP.XML.BuildingPart();
           /* xmlBuildingPart.BuildingPartNumber = ;
            xmlBuildingPart.Identifier = ;
            xmlBuildingPart.ConstructionYear = ;
            xmlBuildingPart.Overshading = ;
            xmlBuildingPart.Openings = ;
            xmlBuildingPart.Floors = ;
            xmlBuildingPart.Roofs = ;
            xmlBuildingPart.Walls = ;*/



            return xmlBuildingPart;
        }
            
    }
}
