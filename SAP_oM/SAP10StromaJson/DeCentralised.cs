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

namespace BH.oM.Environment.SAP.Stroma10
{
    [Description(".")]
    public class DeCentralised : BHoMObject
    {
        [Description(".")]
        public virtual int ID { get; set; } = 0;

        [Description(".")]
        public virtual double KitchenFanPower1 { get; set; } = 0;

        [Description(".")]
        public virtual double KitchenFanPower2 { get; set; } = 0;

        [Description(".")]
        public virtual double KitchenFanPower3 { get; set; } = 0;

        [Description(".")]
        public virtual double OtherRoomFanPower1 { get; set; } = 0;

        [Description(".")]
        public virtual double OtherRoomFanPower2 { get; set; } = 0;

        [Description(".")]
        public virtual double OtherRoomFanPower3 { get; set; } = 0;

        [Description(".")]
        public virtual double KitchenNumberOfFans1 { get; set; } = 0;

        [Description(".")]
        public virtual double KitchenNumberOfFans2 { get; set; } = 0;

        [Description(".")]
        public virtual double KitchenNumberOfFans3 { get; set; } = 0;

        [Description(".")]
        public virtual double OtherRoomNumberOfFans1 { get; set; } = 0;

        [Description(".")]
        public virtual double OtherRoomNumberOfFans2 { get; set; } = 0;
        [Description(".")]
        public virtual double OtherRoomNumberOfFans3 { get; set; } = 0;
    }
}
