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
//using BH.oM.Base.Attributes;
//using System;
//using System.Text;
//using System.Threading.Tasks;

//using BH.Engine.Data
using System.Collections.Generic;
using System.Linq;

using BH.oM.Environment.SAP;
using BH.oM.Base;
//using BH.Engine.Data.Query;
using Opening = BH.oM.Environment.SAP.Opening;

namespace BH.Engine.Environment.SAP
{
    public static partial class Modify
    {
        public static Output<List<List<Wall>>, List<List<Opening>>, List<List<Floor>>, List<List<LivingArea>>> GroupByDwelling (this List<Opening> openings, List<Wall> walls, List<Floor> floors, List<LivingArea> livingAreas)
        {
            //List<Opening> sortedOpenings = openings.OrderBy(x => x.DwellingName).ToList();
            //List<Wall> sortedWalls = walls.OrderBy(x => x.DwellingName).ToList();

           
            List<List<Opening>> groupedOpenings = openings.OrderBy(x => x.DwellingName)
                                                          .ToList()
                                                          .GroupBy(x => x.DwellingName)
                                                          .Select(grp => grp.ToList())
                                                          .ToList();

            List<List<Wall>> groupedWalls = walls.OrderBy(x => x.DwellingName)
                                                          .ToList()
                                                          .GroupBy(x => x.DwellingName)
                                                          .Select(grp => grp.ToList())
                                                          .ToList();

            List<List<Floor>> groupedTFA = floors.OrderBy(x => x.DwellingName)
                                                          .ToList()
                                                          .GroupBy(x => x.DwellingName)
                                                          .Select(grp => grp.ToList())
                                                          .ToList();

            List<List<LivingArea>> groupedLivingAreas = livingAreas.OrderBy(x => x.DwellingName)
                                                          .ToList()
                                                          .GroupBy(x => x.DwellingName)
                                                          .Select(grp => grp.ToList())
                                                          .ToList();

            return new Output<List<List<Wall>>, List<List<Opening>>, List<List<Floor>>, List<List<LivingArea>>>()
            {
                Item1 = groupedWalls,
                Item2 = groupedOpenings,
                Item3 = groupedTFA,
                Item4 = groupedLivingAreas
            };
        }
    }
}


