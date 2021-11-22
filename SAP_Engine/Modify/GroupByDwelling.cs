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

//using BH.Engine.Base;
//using BH.oM.Base;
//using BH.oM.XML.Bluebeam;
//using BH.oM.Environment.Elements;
//using BH.oM.Geometry;
//using BH.Engine.Geometry;
//using BH.Engine.Units;
//using BH.oM.Geometry.SettingOut;
//using BH.oM.Analytical.Elements;
//using System.Collections.ObjectModel;
//using System.ComponentModel;
//using BH.oM.Reflection.Attributes;
//using System;
//using System.Text;
//using System.Threading.Tasks;

//using BH.Engine.Data
using System.Collections.Generic;
using System.Linq;

using BH.oM.Environment.SAP;
using BH.oM.Reflection;
//using BH.Engine.Data.Query;
using Opening = BH.oM.Environment.SAP.Opening;

namespace BH.Engine.Environment.SAP
{
    public static partial class Modify
    {
        public static Output<List<List<Opening>>, List<List<Wall>>> GroupByDwelling (this List<Opening> openings, List<Wall> walls)
        {
            List<Opening> sortedOpenings1 = openings.OrderBy(x => x.DwellingName).ToList();
            List<Wall> sortedWalls1 = walls.OrderBy(x => x.DwellingName).ToList();

            List<List<Opening>> sortedOpenings = (List<List<Opening>>)sortedOpenings1.GroupBy(x => x.DwellingName);
            List<List<Wall>> sortedWalls = (List<List<Wall>>)sortedWalls1.GroupBy(x => x.DwellingName);

            return new Output<List<List<Opening>>, List<List<Wall>>>()
            {
                Item1 = sortedOpenings,
                Item2 = sortedWalls
            };
        }
    }
}
