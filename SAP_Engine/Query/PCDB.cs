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
using System.Net;
using System.IO;

using BH.oM.Environment.MaterialFragments;

using BH.oM.Reflection.Attributes;
using System.ComponentModel;

namespace BH.Engine.Environment.SAP
{
    public static partial class Query
    {   /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        [Description("Query performance characteristics of specific products.")]
        [Input("ProductType", "mech vent/heat pump/boiler etc.")]
        [Input("ProductIndex", "Unique ID for specific product make and model.")]
        [Input("run", "Toggle to activate the component.")]
        [Output("PCDB", "Performance characteristics of the specified product.")]
        public static BH.oM.Environment.SAP.MEVcAndMVHRTable PCDB(this BH.oM.Environment.SAP.ProductType ProductType, string ProductIndex = null, bool run = false)
        {
            if (!run)
                return null;

            WebClient readWeb = new WebClient();
            Stream stream = readWeb.OpenRead("http://www.boilers.org.uk/data1/pcdf2012.dat");
            StreamReader reader = new StreamReader(stream);
            String content = reader.ReadToEnd();
            string[] contentSplit = content.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.None);

            if (ProductType == BH.oM.Environment.SAP.ProductType.MEVcAndMVHR) //probably make enum for this
            {
                string firstLine = contentSplit.Where(x => x.StartsWith("# Table 323")).FirstOrDefault();//read row from "# Table 323"
                string lastLine = contentSplit.Where(x => x.StartsWith("# ... end of Table 323")).FirstOrDefault(); //to "# ... end of Table 323"
                List<string> allLinesForTable = new List<string>();
                for (int x = Array.IndexOf(contentSplit, firstLine); x < Array.IndexOf(contentSplit, lastLine); x++)
                {
                    allLinesForTable.Add(contentSplit[x]);
                }
                string lineIsStartingWith = allLinesForTable.Where(x => x.StartsWith(ProductIndex)).FirstOrDefault();
                if (lineIsStartingWith == null)
                {
                    return null;
                }
                List<string> dividedStrings = lineIsStartingWith.Split(',').ToList();
                BH.oM.Environment.SAP.MEVcAndMVHRTable sapTable = new oM.Environment.SAP.MEVcAndMVHRTable();
                sapTable.Index = ProductIndex;
                sapTable.ManufacturerRefNo = dividedStrings[1];
                sapTable.Status = dividedStrings[2];
                sapTable.DBEntryUpdated = dividedStrings[3];
                sapTable.ManufacturerName = dividedStrings[4];
                sapTable.BrandName = dividedStrings[5];
                sapTable.ModelName = dividedStrings[6];
                sapTable.ModelQualifier = dividedStrings[7];
                sapTable.FirstManufYear = dividedStrings[8];
                sapTable.FinalManufYear = dividedStrings[9];
                sapTable.MainType = dividedStrings[10];
                sapTable.IntegralOnly = dividedStrings[11];
                sapTable.DuctType = dividedStrings[12];
                sapTable.DuctSize = dividedStrings[13];
                sapTable.SummerByPass = dividedStrings[14];
                sapTable.NumExhaustTerminalConfig = dividedStrings[15];
                sapTable.TestFlowRatesBasis = dividedStrings[16];
                sapTable.AddidtionalWetRooms = dividedStrings[17];
                sapTable.TestFlowRate = dividedStrings[18];
                sapTable.FanSpeedSetting = dividedStrings[19];
                sapTable.ApplicableFlowRate = dividedStrings[20];
                sapTable.SpecificFanPower = dividedStrings[21];
                sapTable.HeatExchangerEfficiency = dividedStrings[22];

                return sapTable;
            }
            else // add if statement for rest of enum
            {
                BH.oM.Environment.SAP.MEVcAndMVHRTable a = new BH.oM.Environment.SAP.MEVcAndMVHRTable();
                return a;
            }

        }
    }

}