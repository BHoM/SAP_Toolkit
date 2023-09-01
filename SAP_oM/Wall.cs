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

namespace BH.oM.Environment.SAP
{
    [Description("A wall that forms part of the thermal line of the dwelling.")]
    public class Wall : BHoMObject
    {
        [Description("Type of wall (exposure).")]
        public virtual TypeOfWall Type { get; set; } = TypeOfWall.ExposedWall;

        [Description("The total (gross - including opening areas) surface area of the wall as seen from inside the dwelling.")]
        public virtual double Area { get; set; } = 0;

        [Description("U-value of the floor.")]
        public virtual double uValue { get; set; } = 0.18;

        [Description("Is the wall a 'curtain wall' according to the definition in the SAP guidance.")]
        public virtual bool CurtainWall { get; set; } = false;

        [Description("Heat capacity per unit area in kJ/m�K.")]
        public virtual double KappaValue { get; set; } = 14;

        [Description("Openings (windows & doors) that are hosted within the wall.")]
        public virtual List<BH.oM.Environment.SAP.Opening> Openings { get; set; } = new List<BH.oM.Environment.SAP.Opening>();

        [Description("The name of the dwelling that the opening is part of.")]
        public virtual string DwellingName { get; set; } = "";

    }
}