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
using System.Net;
using BH.oM.Base;

namespace BH.oM.Environment.SAP.Stroma10
{
    [Description(".")]
    public class DwellingVersion : BHoMObject
    {
        public virtual int ID { get; set; } = 0;
        public virtual string ReportReferenceNumber { get; set; } = null;
        public virtual string Reference { get; set; } = null;
        public virtual Address Address { get; set; } = null;
        public virtual string GUID { get; set; } = null;
        public virtual bool Selected { get; set; } = true;
        public virtual DwellingDetails DwellingDetails { get; set; } = null;
        public virtual double TotalFloorArea { get; set; } = 0;
        public virtual double TotalVolume { get; set; } = 0;
        public virtual List<Dimension> Dimensions { get; set; } = null;
        public virtual double LivingArea { get; set; } = 0;
        public virtual double LivingAreaFraction { get; set; } = 0;
        public virtual double AirTestResult { get; set; } = 0;
        public virtual bool GrossAreas { get; set; } = true;
        public virtual List<Floor> Floors { get; set; } = null;
        public virtual List<Wall> Walls { get; set; } = null;
        public virtual List<Roof> Roofs { get; set; } = null;
        public virtual List<PartyFloor> PartyFloors { get; set; } = null;
        public virtual List<PartyWall> PartyWalls { get; set; } = null;
        public virtual List<PartyCeiling> PartyCeilings { get; set; } = null;
        public virtual List<InteriorFloor> InteriorFloors { get; set; } = null;
        public virtual List<InteriorWall> InteriorWalls { get; set; } = null;
        public virtual List<InteriorCeiling> InteriorCeilings { get; set; } = null;
        public virtual List<Door> Doors { get; set; } = null;
        public virtual List<Window> Windows { get; set; } = null;
        public virtual List<RoofLight> RoofLights { get; set; } = null;
        public virtual Ventilation Ventilation { get; set; } = null;
        public virtual Renewable Renewable { get; set; } = null;
        public virtual Overheating Overheating { get; set; } = null;
        public virtual List<object> DwellingPhotos { get; set; } = null;
        public virtual ElementSelections ElementSelections { get; set; } = null;
        public virtual Thermal Thermal { get; set; } = null;
        public virtual CoolingSystem CoolingSystem { get; set; } = null;
        public virtual PrimaryHeating PrimaryHeating { get; set; } = null;
        public virtual PrimaryHeating2 PrimaryHeating2 { get; set; } = null;
        public virtual SecondaryHeating SecondaryHeating { get; set; } = null;
        public virtual WaterHeating WaterHeating { get; set; } = null;
        public virtual double SecondaryHeatingFraction { get; set; } = 0;
        public virtual int HeatSystemInteraction { get; set; } = 0;
        public virtual bool WaterOnlyHeatPump { get; set; } = false;
        public virtual double LowestFloorArea { get; set; } = 0;
    }
}
