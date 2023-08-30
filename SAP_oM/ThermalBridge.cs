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
    [Description("A thermal bridge between two thermal elements of the dwelling.")]
    public class ThermalBridge : BHoMObject
    {
        [Description("The thermal bridge type reference according to Table K1 in SAP 2012.")]
        public virtual TypeOfThermalBridge Reference { get; set; } = TypeOfThermalBridge.OtherLintels;

        [Description("The length of the thermal bridge.")]
        public virtual double Length { get; set; } = 0;

        [Description("The psi-value (heat loss per linear metre) to be applied to the thermal bridge.")]
        public virtual double PsiValue { get; set; } = 1;

        [Description("The source of the psi-value applied to the thermal bridge.")]
        public virtual PsiSourceCode Source { get; set; } = PsiSourceCode.SAPTableDefault;

        [Description("Reference to the details of the calculation of the psi-value.")]
        public virtual string CalculationReference { get; set; } = null;
    }
}

