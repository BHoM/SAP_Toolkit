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

using BH.oM.Adapter;
using BH.oM.Adapters.Excel;
using BH.oM.Environment.SAP.XML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.Environment.SAP
{
    public class SAPPullConfig : ActionConfig
    {
        [Description("Set the location of the Bluebeam SAP XML markup file.")]
        public virtual FileSettings SAPMarkupFile { get; set; } = null;

        [Description("Set the location of the Excel schedules definitions file.")]
        public virtual FileSettings ExcelFile { get; set; } = null;

        [Description("Set the Bluebeam configuration options to define how information should be pulled from the Bluebeam SAP XML markups.")]
        public virtual BluebeamConfig BluebeamConfig { get; set; } = new BluebeamConfig();

        [Description("Set the directory where heating file template XMLs can be found.")]
        public virtual string HeatingFileDirectory { get; set; } = null;

        [Description("Provide the location within the Excel schedules definitions files for pulling Floor Schedule information.")]

        public virtual CellContentsRequest FloorDefinitionsRequest { get; set; } = null;

        [Description("Provide the location within the Excel schedules definitions files for pulling Roof Schedule information.")]
        public virtual CellContentsRequest RoofDefinitionsRequest { get; set; } = null;

        [Description("Provide the location within the Excel schedules definitions files for pulling Wall Schedule information.")]
        public virtual CellContentsRequest WallDefinitionsRequest { get; set; } = null;

        [Description("Provide the location within the Excel schedules definitions files for pulling PSI Value information.")]
        public virtual CellContentsRequest PsiValuesRequest { get; set; } = null;

        [Description("Provide the location within the Excel schedules definitions files for pulling Opening Schedule information.")]
        public virtual CellContentsRequest OpeningDefinitionsRequest { get; set; } = null;

        [Description("Provide the location within the Excel schedules definitions files for pulling Opening PSI Value information.")]
        public virtual CellContentsRequest OpeningPsiValuesRequest { get; set; } = null;

        [Description("Provide the location within the Excel schedules definitions files for pulling Dwelling Schedule information.")]
        public virtual CellContentsRequest DwellingSchedulesRequest { get; set; } = null;
    }
}