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

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Linq;
using System.ComponentModel;
using BH.oM.Adapter;
using BH.Engine.Diffing;
using BH.oM.Environment.SAP.XML;
using BH.oM.Environment.SAP;
using BH.Engine.Base;
using System.Runtime.InteropServices.ComTypes;
using BH.oM.Environment.Elements;
using BH.oM.Base;
using BH.oM.Base.Attributes;

namespace BH.Engine.Environment.SAP
{
    public static partial class Modify
    {
        [Description("Sets up a parametric study based on u and g values.")]
        [Input("sapObj", "SAPReport object to modify")]
        [Input("file", "File settings object to specify the folder to save the files.")]
        [Input("include", "A list of opening types to change in this study.")]
        [Input("psiValues", "Psi Values of all the thermal bridge objects.")]
        [Input("upperUValue", "Upper bound for uvalue.")]
        [Input("lowerUValue", "Lower bound for uvalue.")]
        [Input("uSteps", "Number of steps for uvalue.")]
        [Input("upperGValue", "Upper bound for gvalue.")]
        [Input("lowerGValue", "Lower bound for gvalue.")]
        [Input("gSteps", "Number of steps for gvalue.")]
        [MultiOutput(0, "SAPReports", "A list of the SAPReports.")]
        [MultiOutput(1, "saveFiles", "A list of file settings objects corresponding to each iteration")]
        public static Output<List<SAPReport>, List<FileSettings>> ParametricsUvalueGvalue(this SAPReport sapObj, FileSettings file, List<string> include, PsiValues psiValues, double upperUValue = -1, double lowerUValue = -1, int uSteps = 0, double upperGValue = -1, double lowerGValue = -1, int gSteps = 0)
        {
            //TODO
            if (uSteps > 0 && (upperUValue < 0 || lowerUValue < 0))
            {
                BH.Engine.Base.Compute.RecordError("UValue bounds have not been set properly.");
                return null;
            }

            if (gSteps > 0 && (upperGValue < 0 || lowerGValue < 0))
            {
                BH.Engine.Base.Compute.RecordError("GValue bounds have not been set properly.");
                return null;
            }

            List<double> uValues = new List<double>();
            List<double> gValues = new List<double>();

            if  (uSteps > 0)
            {
                double step = Math.Abs(upperUValue - lowerUValue) / uSteps;
                double start = Math.Min(upperUValue, lowerUValue);

                for (int i = 0; i <= uSteps; i++)
                {
                    uValues.Add(Math.Round(start + (step * i), 2));
                }
            }
            else
            {
                uValues.Add(-1);
            }

            if (gSteps > 0)
            {
                double step = Math.Abs(upperGValue - lowerGValue) / gSteps;
                double start = Math.Min(upperGValue, lowerGValue);

                for (int i = 0; i <= gSteps; i++)
                {
                    gValues.Add(Math.Round(start + (step * i), 2));
                }
            }
            else
            {
                gValues.Add(-1);
            }

            List<(double, double)> temp = uValues.SelectMany(u => gValues, (u, g) => (u, g)).ToList();
            List<Parameters> typeIteratorLists = new List<Parameters>();

            foreach ((var u, var g) in temp)
            {
                //Change this - it doesn't work if no u or g values are inputted
                string name = $"uvalue_{u}_gvalue_{g}";
                Parameters iteration = new Parameters
                {
                    IterationName = name
                };

                OpeningTypeIterator t = new OpeningTypeIterator
                {
                    UValue = u, 
                    GValue = g, 
                    TypeName = name, 
                    Include = include
                };

                iteration.OpeningTypes = new List<OpeningTypeIterator> { t };
                typeIteratorLists.Add(iteration);
            }

            return (sapObj.ParametricStudy(typeIteratorLists, file, psiValues));
        }  
    }
}
