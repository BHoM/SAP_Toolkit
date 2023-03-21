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
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;
using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;
using BH.oM.Environment.SAP.XML;

namespace BH.oM.Environment.SAP
{
    [Description("List of parts that makes up the building.")]
    public class PropertyDetails : BHoMObject
    {
        [Description("The type of Property, such as House, Flat = 2, Mansion, Maisonette etc. Default = 2 (Flat).")]
        public virtual TypeOfProperty PropertyType { get; set; } = TypeOfProperty.Flat;

        [Description("The building type of the Property e.g. Detached, Semi-Detached, Terrace etc. Together with the Property Type, the Built Form provides a structured description of the property. Default value = 4 (Mid-Terrace)")]
        public virtual BuiltFormCode BuiltForm { get; set; } = BuiltFormCode.MidTerrace;

        [Description("The size of the living area in square metres.  The living area is the room marked on a plan as the lounge or living room, or the largest public room (irrespective of usage by particular occupants), together with any rooms not separated from the lounge or living room by doors, and including any cupboards directly accessed from the lounge or living room. Living area does not, however, extend over more than one storey, even when stairs enter the living area directly.")]
        public virtual string LivingArea { get; set; } = "0";

        [Description("The Area of the lowest storey in square meters including unheated or communal areas such as garages or corridors.")]
        public virtual string LowestStoreyArea { get; set; } = "0";

        [Description("The orientation of the front of the property. Default: East")]
        public virtual OrientationCode Orientation { get; set; } = OrientationCode.South;

        [Description("Type of conservatory.")]
        public virtual TypeOfConservatory ConservatoryType { get; set; } = TypeOfConservatory.NoConservatory;

        [Description("Type of Terrain")]
        public virtual TypeOfTerrain TerrainType { get; set; } = TypeOfTerrain.Urban;

        [Description("The average amount of overshading of windows.")]
        public virtual oM.Environment.SAP.WindowOvershading Overshading { get; set; } = oM.Environment.SAP.WindowOvershading.AverageOrUnknown;

        [Description("")]
        public virtual Heating Heating { get; set; } = null;

        [Description("")]
        public virtual EnergySource EnergySource { get; set; } = null;

        [Description("")]
        public virtual List<BuildingPart> BuildingParts { get; set; } = null;

        [Description("")]
        public virtual List<OpeningType> OpeningTypes { get; set; } = null;

        [Description("")]
        public virtual Ventilation Ventilation { get; set; } = null;

        [Description("")]
        public virtual List<Lighting> LightingDetails { get; set; } = null;

        [Description("")]
        public virtual FlatDetails FlatDetails { get; set; }

        [Description("")]
        public virtual List<SpecialFeature> SpecialFeatures { get; set; } = null;
        
    }

}

