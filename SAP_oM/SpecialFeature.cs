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
using BH.oM.Environment.SAP.XML;

namespace BH.oM.Environment.SAP
{
    [Description("SpecialFeature")]
    public class SpecialFeature : BHoMObject
    {
        [Description("Emissions saved in kg/year.")]
        public virtual double EmissionsSaved { get; set; } = 0;

        [Description("Additional emissions in kg/year.")]
        public virtual double EmissionsCreated { get; set; } = 0;

        [Description("Energy saved or generated in kWh/year.")]
        public virtual double EnergySavedOrGenerated { get; set; } = 0;

        [Description("")]
        public virtual string SavedOrGeneratedFuel { get; set; } = "1";

        [Description("Energy used in kWh/year.")]
        public virtual double EnergyUsed { get; set; } = 0;

        [Description("")]
        public virtual TypeOfHeatingFuel EnergyUsedFuel { get; set; } = TypeOfHeatingFuel.MainsGas;

        [Description("Air Change Rate for each month")]
        public virtual List<MonthlyValues> AirChangeRates { get; set; } = null;

        [Description("")]
        public virtual string Description { get; set; } = null;


    }
}


