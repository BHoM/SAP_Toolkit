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
using System.ComponentModel;
using System.Linq;
using BH.oM.Base;

namespace BH.oM.Environment.SAP.Stroma10
{
    [Description("")]
    public class Water : BHoMObject
    {
        [Description("")]
        public virtual int ID { get; set; } = 0;

        [Description("")]
        public virtual string Guid { get; set; }

        [Description("")]
        public virtual int ItemID { get; set; } = 0;

        [Description("")]
        public virtual int ElementType { get; set; } = 0;

        [Description("")]
        public virtual string ElementTypeName { get; set; } = null;

        [Description("")]
        public virtual Ventilation Ventilation { get; set; } = null;

        [Description("")]
        public virtual Renewable Renewable { get; set; } = null;

        [Description("")]
        public virtual Overheating Overheating { get; set; } = null;

        [Description("")]
        public virtual List<Door> Doors { get; set; } = null;

        [Description("")]
        public virtual List<Window> Windows { get; set; } = null;

        [Description("")]
        public virtual List<RoofLight> RoofLights { get; set; } = null; 

        [Description("")]
        public virtual List<Floor> Floors { get; set; } = null;

        [Description("")]
        public virtual List<Wall> Walls { get; set; } = null;

        [Description("")]
        public virtual List<Roof> Roofs { get; set; } = null;

        [Description("")]
        public virtual List<PartyFloor> PartyFloors { get; set; } = null;

        [Description("")]
        public virtual List<PartyWall> PartyWalls { get; set; } = null;

        [Description("")]
        public virtual List<PartyCeiling> PartyCeilings { get; set; } = null;

        [Description("")]
        public virtual List<InteriorFloor> InteriorFloors { get; set; } = null;

        [Description("")]
        public virtual List<InteriorWall> InteriorWalls { get; set; } = null; 

        [Description("")]
        public virtual List<InteriorCeiling> InteriorCeilings { get; set; } = null;

        [Description("")]
        public virtual Thermal Thermal { get; set; } = null;

        [Description("")]
        public virtual CoolingSystem CoolingSystem { get; set; } = null;

        [Description("")]
        public virtual PrimaryHeating PrimaryHeating { get; set; } = null;

        [Description("")]
        public virtual PrimaryHeating2 PrimaryHeating2 { get; set; } = null;

        [Description("")]
        public virtual SecondaryHeating SecondaryHeating { get; set; } = null;

        [Description("")]
        public virtual WaterHeating WaterHeating { get; set; } = null;

    }
}
