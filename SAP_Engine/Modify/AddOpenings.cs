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

using System.Collections.Generic;
using System.Linq;

using BH.oM.Environment.SAP;
using BH.oM.Reflection;
using Opening = BH.oM.Environment.SAP.Opening;

namespace BH.Engine.Environment.SAP
{
    public static partial class Modify
    {
        public static Output<List<Wall>, bool> AddOpenings(this List<Wall> walls, List<Opening> openings)
        {
            double totalOpeningAreas = (double)openings.Sum(area => area.Area);
            bool alert = true;
            int j = 0;
            double areaCounter = 0;

            List<Opening> sortedOpenings = Enumerable.Reverse(openings.OrderBy(x1 => x1.Area)).ToList();
            List<Wall> sortedWalls = Enumerable.Reverse(walls.OrderBy(x1 => x1.Area)).ToList();
            List<Wall> allWalls = new List<Wall>();

            //Alert when total area of the openings exceeds the area of the largest wall within same space.
            if (sortedWalls[0].Area < totalOpeningAreas)
            {
                alert = false;
            }

            for (int i = 0; i < sortedWalls.Count; i++)
            {
                List<Opening> groupedOpenings = new List<Opening>();
                allWalls.Add(sortedWalls[i]);

                while ((areaCounter < sortedWalls[i].Area) && (j < sortedOpenings.Count))
                {
                    areaCounter += sortedOpenings[j].Area;
                    groupedOpenings.Add(sortedOpenings[j]);
                    j += 1;
                }
                allWalls[i].Openings = groupedOpenings;
                areaCounter = 0;              
            }         
            return new Output<List<Wall>, bool>()
            {
                Item1 = allWalls,
                Item2 = alert
            };
        }
    }
}

