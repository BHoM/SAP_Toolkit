/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2024, the respective contributors. All rights reserved.
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

using BH.oM.Base.Attributes;
using BH.oM.Environment.SAP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Linq;

namespace BH.Engine.Environment.SAP
{
    public static partial class Create
    {
        [Description("Create a collection of Opening Type Iterations from provided min/max values and the number of steps. One iteration object will be created for U Values, and one for G Values. The calculation of values will be done as the maximum value minus the minimum value, divided the number of steps, with each iteration then being the minimum value plus each step value for each iteration until the maximum value is met. The final iteration object will have the maximum value provided. If you do not wish to do iterations for one of the value types, then leave the inputs for those values empty. E.G. if you only wish to do iterations for G Values, then leave the U Value inputs empty and no U Value iterations will be created.")]
        [Input("minGValue", "The minimum G Value for the iterations - the first iteration object for G Values will be given this value. If this value is provided, then you MUST also provide a maximum G Value. Leave blank to ignore producing G Value iterations.")]
        [Input("maxGValue", "The maximum G Value for the iterations - the last iteration object for G Values will be given this value. If this value is provided, then you MUST also provide a minimum G Value. Leave blank to ignore producing G Value iterations.")]
        [Input("steps", "The number of increments for iterations between the minimum and maximum value. If only 1 step is provided, then only two iterations will be provided (one for the minimum and one for the maximum).")]
        [Input("typesToInclude", "Specify the type of openings which the iteration objects should be applied to. If left blank, then all opening types within the SAP Report will have these iterations provided.")]
        [Output("openingTypeIterations", "A collection of iterations to be applied to SAP Reports for Parametric Studies.")]
        public static List<OpeningTypeGValueIteration> OpeningTypeGValueIteration(double minGValue = double.NaN, double maxGValue = double.NaN, int steps = 1, List<string> typesToInclude = null)
        {
            if (double.IsNaN(minGValue) ^ double.IsNaN(maxGValue))
            {
                //Exlusive or - only if either value is NaN which means the other value is not a NaN - if both are a NaN then they will be ignored
                BH.Engine.Base.Compute.RecordError("Please provide both a minimum and a maximum G Value to calculate the number of Opening Type Iterations for GValues.");
                return new List<OpeningTypeGValueIteration>();
            }

            List<OpeningTypeGValueIteration> gValueIterations = new List<OpeningTypeGValueIteration>();

            if (!double.IsNaN(minGValue) && !double.IsNaN(maxGValue))
            {
                double diff = maxGValue - minGValue;
                double step = diff / (double)(steps - 1); //-1 so that the final step is the max value

                for (double x = minGValue; x <= maxGValue; x += step)
                {
                    OpeningTypeGValueIteration iteration = new OpeningTypeGValueIteration();
                    iteration.GValue = x;
                    iteration.Include = typesToInclude;

                    gValueIterations.Add(iteration);
                }

                if ((gValueIterations.Last().GValue  - maxGValue) > BH.oM.Geometry.Tolerance.Distance)
                {
                    OpeningTypeGValueIteration iteration = new OpeningTypeGValueIteration();
                    iteration.GValue = maxGValue;
                    iteration.Include = typesToInclude;
                    gValueIterations.Add(iteration);
                }
            }

            return gValueIterations;
        }
    }
}

