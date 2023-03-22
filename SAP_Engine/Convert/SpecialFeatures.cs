///*
// * This file is part of the Buildings and Habitats object Model (BHoM)
// * Copyright (c) 2015 - 2023, the respective contributors. All rights reserved.
// *
// * Each contributor holds copyright over their respective contributions.
// * The project versioning (Git) records all such contribution source information.
// *                                           
// *                                                                              
// * The BHoM is free software: you can redistribute it and/or modify         
// * it under the terms of the GNU Lesser General Public License as published by  
// * the Free Software Foundation, either version 3.0 of the License, or          
// * (at your option) any later version.                                          
// *                                                                              
// * The BHoM is distributed in the hope that it will be useful,              
// * but WITHOUT ANY WARRANTY; without even the implied warranty of               
// * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
// * GNU Lesser General Public License for more details.                          
// *                                                                            
// * You should have received a copy of the GNU Lesser General Public License     
// * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
// */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using BH.oM.Base.Attributes;
using BH.oM.Base;
using BH.oM.Environment.SAP.XML;
using BH.oM.Environment.SAP;

namespace BH.Engine.Environment.SAP
{
    public static partial class Convert
    {
        [Description("Convert SAP Special Feature to XML Special Fetaures.")]
        [Input("sapRoof", "SAP special feature to convert.")]
        [Output("SpecialFeature", "The xml Special Feature converted")]
        public static BH.oM.Environment.SAP.XML.SpecialFeatures ToXML(this List<BH.oM.Environment.SAP.SpecialFeature> sapSpecialFeatures)
        {
            List<BH.oM.Environment.SAP.XML.SpecialFeature> specialFeatures = new List<BH.oM.Environment.SAP.XML.SpecialFeature>();

            foreach (var specialFeature in sapSpecialFeatures)
            {
                BH.oM.Environment.SAP.XML.SpecialFeature xmlSpecialFeature= new BH.oM.Environment.SAP.XML.SpecialFeature();

                xmlSpecialFeature.Description = specialFeature.Description;
                xmlSpecialFeature.EnergyFeature.EnergySavedOrGenerated = specialFeature.EnergySavedOrGenerated;
                xmlSpecialFeature.EnergyFeature.SavedOrGeneratedFuel = specialFeature.SavedOrGeneratedFuel;
                xmlSpecialFeature.EnergyFeature.EnergyUsed = specialFeature.EnergyUsed;
                xmlSpecialFeature.EnergyFeature.EnergyUsedFuel = specialFeature.EnergyUsedFuel.FromSAPToXML();


                //This is messed up - But its friday 
                List<AirChangeRate> airChangeRates = new List<AirChangeRate>();

                foreach (var monthData in specialFeature.AirChangeRates)
                {
                    AirChangeRate month = new AirChangeRate();
                    month.Month = monthData.Month.FromSAPToXML();
                    month.Value = monthData.Value;

                    airChangeRates.Add(month);

                }

                xmlSpecialFeature.EnergyFeature.AirChangeRates.AirChangeRate = airChangeRates;

                xmlSpecialFeature.EmissionsFeature.EmissionsSaved = specialFeature.EmissionsSaved;

                xmlSpecialFeature.EmissionsFeature.EmissionsCreated= specialFeature.EmissionsCreated;

                specialFeatures.Add(xmlSpecialFeature);
            }

            SpecialFeatures xmlSpecialFeatures  = new SpecialFeatures();
            xmlSpecialFeatures.SpecialFeature = specialFeatures;

            return xmlSpecialFeatures;
            
        }
        private static string FromSAPToXML(this BH.oM.Environment.SAP.Months months)
        {
            switch (months)
            {
                case BH.oM.Environment.SAP.Months.January:

                    return "Jan";

                case BH.oM.Environment.SAP.Months.February:

                    return "Feb";

                case BH.oM.Environment.SAP.Months.March:

                    return "Mar";

                case BH.oM.Environment.SAP.Months.April:

                    return "Apr";

                case BH.oM.Environment.SAP.Months.May:

                    return "May";

                case BH.oM.Environment.SAP.Months.June:

                    return "Jun";

                case BH.oM.Environment.SAP.Months.July:

                    return "Jul";

                case BH.oM.Environment.SAP.Months.August:

                    return "Aug";

                case BH.oM.Environment.SAP.Months.September:

                    return "Sep";

                case BH.oM.Environment.SAP.Months.October:

                    return "Oct";

                case BH.oM.Environment.SAP.Months.November:

                    return "Nov";

                case BH.oM.Environment.SAP.Months.December:

                    return "Dec";

                default:
                    return "";
            }
        }
    }
   
}


