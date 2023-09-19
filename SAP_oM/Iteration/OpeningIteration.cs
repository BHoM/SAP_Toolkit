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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Environment.SAP.XML;
using BH.oM.Environment.SAP;
using System.ComponentModel;
using BH.oM.Base;

namespace BH.oM.Environment.SAP
{
    [Description("Describe a single opening iteration for all the openings within the SAP context.")]
    public class OpeningIteration : BHoMObject, IIteration
    {
        [Description("New width of all the openings. Must be a positive number. If left blank, no changes to width will be made.")]
        public virtual double Width { get; set; } = double.NaN;

        [Description("New height of the all the openings. Must be a positive number. If left blank, no changes to height will be made.")]
        public virtual double Height { get; set; } = double.NaN;

        [Description("New pitch of all the openings. Set as the pitch of roof containing roof window. If left blank, no changes to pitch will be made.")]
        public virtual string Pitch { get; set; } = null;

        [Description("A list of Opening names to make changes to. If this is left blank, then all openings in the SAP report will be updated based on the values of this iteration.")]
        public virtual List<string> Include { get; set; } = null;

        [Description("Provide the name of this iteration. The name should be unique across all iterations in your model, and should match any coordination with other models (over heating, daylighting, etc.) you may be running parametrics on.")]
        public override string Name { get; set; } = null;
    }
}
