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
using System.Linq;
using System.Text;

namespace BH.Engine.Environment.SAP
{
    public static partial class Create
    {
        [Description("Create a Thermal Bridge iteration from a given set of Thermal Bridge values. Will check to ensure there are no duplicate values presented.")]
        [Input("values", "A collection of Thermal Bridge Values with a specified thermal bridge (e.g. E3, E4, etc.) and a new PSI Value for this iteration. Combine mulitple values (for unique thermal bridges) to produce a single iteration for a parametric study affecting different thermal bridges. If duplicates are found, an error will be thrown.")]
        [Input("name", "Provide the name of this iteration. The name should be unique across all iterations in your model, and should match any coordination with other models (over heating, daylighting, etc.) you may be running parametrics on.")]
        [Output("iteration", "A Thermal Bridge Iteration object which can be used to produce a parametric SAP study.")]
        public static ThermalBridgeIteration ThermalBridgeIteration(List<ThermalBridgeValue> values, string name)
        {
            if (values == null || values.Count == 0)
            {
                BH.Engine.Base.Compute.RecordError("Please provide a valid list of Thermal Bridge Values to create an iteration with.");
                return null;
            }

            //Check for duplicates within the values
            var unique = values.Distinct();
            if(unique.Count() != values.Count)
            {
                //We have duplicates
                string error = "You have provided duplicate Thermal Bridge Values for the following Thermal Bridges:\n\n";

                foreach(var v in unique)
                {
                    var countOfValue = values.Where(x => x.Name == v.Name).Count();
                    if(countOfValue > 1)
                        error += $" - {v.Include} - {countOfValue} occurrences.\n";
                }

                error += "\n\nPlease rectify and remove duplicate values to create a valid iteration.";
                BH.Engine.Base.Compute.RecordError(error);
                return null;
            }

            return new ThermalBridgeIteration()
            {
                Values = values,
                Name = name,
            };
        }
    }
}

