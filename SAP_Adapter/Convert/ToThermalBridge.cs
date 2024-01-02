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
using BH.oM.Base;
using BH.oM.Environment.SAP.Bluebeam;
using SXML = BH.oM.Environment.SAP.XML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using BH.oM.Environment.SAP.Excel;

namespace BH.Adapter.SAP
{
    public static partial class Convert
    {
        public static SXML.ThermalBridge ToThermalBridge(SAPMarkup markup, PsiValueSchedule psiValue)
        {
            SXML.ThermalBridge t = new SXML.ThermalBridge();

            t.CalculationReference = markup.Subject;
            t.Type = markup.ThermalBridgeType;

            if (markup.Length <= 0.00001)
            {
                double multiplyFactor = 1;
                double thermalBridgeLength = 0;
                try
                {
                    multiplyFactor = double.Parse(markup.Comments);
                }
                catch { }

                try
                {
                    thermalBridgeLength = double.Parse(markup.ThermalBridgeLength);
                }
                catch { }

                t.Length = thermalBridgeLength * multiplyFactor;
            }
            else
                t.Length = markup.Length;

            t.PsiSource = "1";
            t.PsiValue = psiValue.PsiValue;

            return t;
        }
    }
}

