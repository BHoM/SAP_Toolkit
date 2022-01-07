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
 *
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using BH.oM.Base;

namespace BH.oM.Environment.SAP
{
    //Needed if possible to convert all SAP objects to what's defined in the XML schema
    [Description("Additional information about the fans.")]
    public class ExtraFanDetails : BHoMObject
    {
        [Description("MEV dc, number of fans in room, kitchen; if mechanical vent data from database or manufacturer declaration (MEV dc).")]
        public virtual int KitchenRoomFans { get; set; } = 0; 

        [Description("MEV dc, specific fan power of fans in room, kitchen, in watts per (litres per second); if mechanical vent data from manufacturer declaration (MEV dc).")]
        public virtual string KitchenRoomFansSpecificPower { get; set; } = ""; 

        [Description("MEV dc, number of fans via duct, kitchen; if mechanical vent data from database or manufacturer declaration (MEV dc).")]
        public virtual int KitchenDuctFans { get; set; } = 0;

        [Description("MEV dc, specific fan power of fans via duct, kitchen, in watts per (litres per second); if mechanical vent data from manufacturer declaration (MEV dc).")]
        public virtual string KitchenDuctFansSpecificPower { get; set; } = "";

        [Description("MEV dc, number of fans through wall, kitchen; if mechanical vent data from database or manufacturer declaration (MEV dc).")]
        public virtual int KitchenWallFans { get; set; } = 0; 

        [Description("MEV dc, specific fan power of fans through wall, kitchen, in watts per (litres per second); if mechanical vent data from manufacturer declaration (MEV dc).")]
        public virtual string KitchenWallFansSpecificPower { get; set; } = ""; 

        [Description("MEV dc, number of fans in room, rooms other than kitchen; if mechanical vent data from database or manufacturer declaration (MEV dc).")]
        public virtual int nonKitchenRoomFans { get; set; } = 0;

        [Description("MEV dc, specific fan power of fans in room, rooms other than kitchen, in watts per (litres per second); if mechanical vent data from manufacturer declaration (MEV dc).")]
        public virtual string nonKitchenRoomFansSpecificPower { get; set; } = ""; 

        [Description("MEV dc, number of fans via duct, rooms other than kitchen; if mechanical vent data from database or manufacturer declaration (MEV dc).")]
        public virtual int nonKitchenDuctFans { get; set; } = 0; 

        [Description("MEV dc, specific fan power of fans via duct, rooms other than kitchen, in watts per (litres per second); if mechanical vent data from manufacturer declaration (MEV dc).")]
        public virtual string nonKitchenDuctFansSpecificPower { get; set; } = ""; 

        [Description("MEV dc, number of fans through wall, rooms other than kitchen; if mechanical vent data from database or manufacturer declaration (MEV dc).")]
        public virtual int nonKitchenWallFans { get; set; } = 0; 

        [Description("MEV dc, specific fan power of fans through wall, rooms other than kitchen, in watts per (litres per second); if mechanical vent data from manufacturer declaration (MEV dc).")]
        public virtual string nonKitchenWallFansSpecificPower { get; set; } = ""; 
    }
}
*/
