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

using BH.oM.Geometry;
using BH.Engine.Geometry;
using BH.oM.Environment.Elements;

namespace BH.Engine.Environment.SAP
{
    public static class BalconyLines
    {
        public static List<Polyline> ComputeBalconyLines(List<Panel> panels, Polyline baseCurve, Polyline dwellingPerimeter)
        {
            //Work out balcony lines on the dwelling perimeter
            List<Polyline> balconyLines = panels.SelectMany(y => y.Polyline().SplitAtPoints(y.Polyline().ControlPoints)).ToList();
            balconyLines = balconyLines.Where(y => y.ControlPoints.Where(z => z.IsOnCurve(baseCurve)).Count() == y.ControlPoints.Count).ToList(); //Filter out to only the lines on the base curve

            List<Point> dwellingControlPoints = dwellingPerimeter.IControlPoints();
            balconyLines = balconyLines.SelectMany(y => y.SplitAtPoints(dwellingControlPoints)).ToList(); //Split to the dwelling
            List<Polyline> e23Lines = new List<Polyline>();

            foreach (Polyline e23 in balconyLines)
            {
                if (e23.ControlPoints.Where(y => y.IIsOnCurve(dwellingPerimeter)).Count() == e23.ControlPoints.Count)
                    e23Lines.Add(e23);
            }

            return e23Lines;
        }
    }
}

