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
    [Description("A thermal bridge between two thermal elements of the dwelling")]
    public class ThermalBridge : BHoMObject
    {
        [Description("The thermal bridge type reference according to Table K1 in SAP 2012")]
        public virtual string Reference { get; set; } = "E2";

        [Description("The length of the thermal bridge")]
        public virtual double Length { get; set; } = 0;

        [Description("The psi-value (heat loss per linear metre) to be applied to the thermal bridge")]
        public virtual double PsiValue { get; set; } = 1;

        [Description("The source of the psi-value applied to the thermal bridge")]
        public virtual string Source { get; set; } = "";

        [Description("The name of the dwelling that the thermal bridge is part of")]
        public virtual string DwellingName { get; set; } = "";
    }
}
/*
 *             <SAP-Thermal-Bridge>
              <Thermal-Bridge-Type>E17</Thermal-Bridge-Type>
              <Length>5.2</Length>
              <Psi-Value>-0.14</Psi-Value>
              <Psi-Value-Source>3</Psi-Value-Source>
            </SAP-Thermal-Bridge>

    */