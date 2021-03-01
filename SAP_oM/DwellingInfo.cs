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
using System.ComponentModel;
using System.Linq;
using BH.oM.Base;

namespace BH.oM.Environment.SAP
{
    [Description("A BHoMObject for SAP analysis. Contains general info about each dwelling")]
    public class DwellingInfo : BHoMObject
    {

        [Description("Dwelling name")]
        public virtual string DwellingName { get; set; } = "";

        [Description("Full dwelling name, including window settings and glazing value")]
        public virtual string Reference { get; set; } = "";

        [Description("Dwelling number, resets with each floor")]
        public virtual int ID { get; set; } = 0;

        [Description("Orientation of each dwelling")]
        public virtual double OrientationDegrees { get; set; } = 0.0;

        [Description("Number of rooms in each dwelling")]
        public virtual int TotalRooms { get; set; } = 0;

        [Description("Number of bathrooms in each dwelling")]
        public virtual int WetRooms { get; set; } = 0;

        [Description("Number of bedrooms in each dwelling")]
        public virtual int DwellingBeds { get; set; } = 0;

        [Description("Number of sheltered sides for each dwelling")]
        public virtual int ShelteredSides { get; set; } = 0;

        [Description("States whether crossventilation is available or not for each dwelling")]
        public virtual string CrossVentilation { get; set; } = "";

    }
}
