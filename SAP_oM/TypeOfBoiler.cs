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
    [Description("Boiler information.")]
    public class TypeOfBoiler : BHoMObject
    {

        [Description("Boiler type; if boiler efficiency is manufacturer declaration and fuel is solid.")]
        public virtual TypeOfSolidFuelBoiler SolidFuelBoilerType { get; set; } = TypeOfSolidFuelBoiler.Independent;

        [Description("")]
        public virtual TypeOfGasOrOilBoiler GasOrOilBoiler { get; set; } = TypeOfGasOrOilBoiler.Regular;

        [Description("")]
        public virtual TypeOfCombiBoiler CombiBoilerType { get; set; } = TypeOfCombiBoiler.PrimaryStorage;

        [Description("")]
        public virtual bool BoilerInterlock { get; set; } = false;
    }
}

