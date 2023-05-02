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
using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.oM.Environment.SAP.Stroma10
{
    [Description(".")]
    public class WaterHeating : BHoMObject
    {
        public virtual int ID { get; set; } = 0;
        public virtual SolarWater SolarWater { get; set; } = null;
        public virtual int System { get; set; } = 0;
        public virtual int Fuel { get; set; } = 0;
        public virtual Cylinder Cylinder { get; set; } = null;
        public virtual double CombinedPrimaryStorageUnitTemperature { get; set; } = 0;
        public virtual CommunityWater CommunityWater { get; set; } = null;
        public virtual Thermal2 Thermal2 { get; set; } = null;
        public virtual int CombiType { get; set; } = 0;
        public virtual WasteWaterHeatRecovery WasteWaterHeatRecovery { get; set; } = null;
        public virtual FlueGasHeatRecovery FlueGasHeatRecovery { get; set; } = null;
        public virtual bool DomesticHotWaterVessel { get; set; } = false;
        public virtual List<ShowerUnit> ShowerUnits { get; set; } = null;
        public virtual int WaterSource { get; set; } = 0;
        public virtual int NumberOfBaths { get; set; } = 0;
        public virtual string ControllerManufacturer { get; set; } = null;
        public virtual string Model { get; set; } = null;
    }
}
