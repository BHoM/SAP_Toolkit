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

using BH.oM.Geometry;
using BH.Engine.Geometry;
using BH.oM.Environment.Elements;

namespace BH.Engine.Environment.SAP
{
    public static class PartyFloors
    {
        public static List<Polyline> CalculatePartyFloors(List<Panel> panels, List<Polyline> existingPartyFloors)
        {
            List<Polyline> balconiesOnDwellingLines = panels.SelectMany(y => y.Polyline().SplitAtPoints(y.Polyline().ControlPoints)).ToList();
            List<Point> controlPoints = balconiesOnDwellingLines.SelectMany(x => x.ControlPoints).ToList();

            List<Polyline> fixedPartyFloors = new List<Polyline>();

            foreach (Polyline p in existingPartyFloors)
            {
                //Remove any overlap with a balcony
                List<Point> cuttingPoints = controlPoints.Where(x => x.IsOnCurve(p)).ToList();

                List<Polyline> split = p.SplitAtPoints(cuttingPoints);

                foreach (Polyline s in split)
                {
                    if (balconiesOnDwellingLines.Where(y => s.Centre().IsOnCurve(y)).Count() == 0)
                        fixedPartyFloors.Add(s);
                }
            }

            return fixedPartyFloors;
        }
    }
}
