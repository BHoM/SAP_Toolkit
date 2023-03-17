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
        [Input("sapRoof", "SAP roof to convert.")]
        [MultiOutput(0, "xmlRoof", "XML roof.")]
        [MultiOutput(1, "xmlOpening", "XML opening.")]
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

                AirChangeRate jan = new AirChangeRate();

                jan.Month = Months.January.FromSAPToXML();
                jan.Value = specialFeature.AirChangeRates.Jan;
                airChangeRates.Add(jan);

                AirChangeRate feb = new AirChangeRate();

                feb.Month = Months.February.FromSAPToXML();
                feb.Value = specialFeature.AirChangeRates.Feb;
                airChangeRates.Add(feb);

                AirChangeRate mar = new AirChangeRate();

                mar.Month = Months.March.FromSAPToXML();
                mar.Value = specialFeature.AirChangeRates.Mar;
                airChangeRates.Add(mar);

                AirChangeRate apr= new AirChangeRate();

                apr.Month = Months.April.FromSAPToXML();
                apr.Value = specialFeature.AirChangeRates.Apr;
                airChangeRates.Add(apr);

                AirChangeRate may = new AirChangeRate();

                may.Month = Months.May.FromSAPToXML();
                may.Value = specialFeature.AirChangeRates.May;
                airChangeRates.Add(may);

                AirChangeRate jun = new AirChangeRate();

                jun.Month = Months.June.FromSAPToXML();
                jun.Value = specialFeature.AirChangeRates.Jun;
                airChangeRates.Add(jun);

                AirChangeRate jul= new AirChangeRate();

                jul.Month = Months.July.FromSAPToXML();
                jul.Value = specialFeature.AirChangeRates.Jul;
                airChangeRates.Add(jul);

                AirChangeRate aug= new AirChangeRate();

                aug.Month = Months.August.FromSAPToXML();
                aug.Value = specialFeature.AirChangeRates.Aug;
                airChangeRates.Add(aug);

                AirChangeRate sep= new AirChangeRate();

                sep.Month = Months.September.FromSAPToXML();
                sep.Value = specialFeature.AirChangeRates.Sep;
                airChangeRates.Add(sep);

                AirChangeRate oct= new AirChangeRate();

                oct.Month = Months.October.FromSAPToXML();
                oct.Value = specialFeature.AirChangeRates.Oct;
                airChangeRates.Add(oct);

                AirChangeRate nov= new AirChangeRate();

                nov.Month = Months.November.FromSAPToXML();
                nov.Value = specialFeature.AirChangeRates.Nov;
                airChangeRates.Add(nov);

                AirChangeRate dec= new AirChangeRate();

                dec.Month = Months.December.FromSAPToXML();
                dec.Value = specialFeature.AirChangeRates.Dec;
                airChangeRates.Add(dec);

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


