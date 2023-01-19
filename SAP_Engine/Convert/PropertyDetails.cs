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

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.ComponentModel;
//using BH.oM.Base.Attributes;
//using BH.oM.Base;

//namespace BH.Engine.Environment.SAP
//{
//    public static partial class Convert
//    {
//        [Description("Convert SAP PropertyDetails to XML PropertyDetails.")]
//        [Input("sapPropertyDetails", "SAP PropertyDeatils to convert.")]
//        [Output("xmlPropertyDetails", "XML PropertyDetails.")]
//        public static BH.oM.Environment.SAP.XML.PropertyDetails ToXML(this oM.Environment.SAP.PropertyDetails sapPropertyDetails)
//        {
//            BH.oM.Environment.SAP.XML.PropertyDetails xmlPropertyDetails = new BH.oM.Environment.SAP.XML.PropertyDetails();
//            List<BH.oM.Environment.SAP.OpeningType> openingTypes = new List<oM.Environment.SAP.OpeningType>();
//            if (sapPropertyDetails.Heating == null)
//            {
//                xmlPropertyDetails.Heating = null;
//                xmlPropertyDetails.Cooling = null;
//            }

//            if (sapPropertyDetails.BuildingParts == null)
//            {
//                xmlPropertyDetails.BuildingParts = null;
//                xmlPropertyDetails.OpeningTypes = null;
//            }

//            if (sapPropertyDetails.Ventilation == null)
//            {
//                xmlPropertyDetails.Ventilation = null;
//            }

//            if (sapPropertyDetails.Heating != null)
//            {
//                var outputs = sapPropertyDetails.Heating.ToXML();
//                xmlPropertyDetails.Heating = outputs.Item1;
//                xmlPropertyDetails.Cooling = outputs.Item2;
//            }

//            if (sapPropertyDetails.BuildingParts != null)
//            {
//                var outputs = sapPropertyDetails.BuildingParts.ToXML();
//                xmlPropertyDetails.BuildingParts = outputs.Item1;
//                xmlPropertyDetails.OpeningTypes = outputs.Item2;
//            }

//            if (sapPropertyDetails.Ventilation != null)
//            {
//                xmlPropertyDetails.Ventilation = sapPropertyDetails.Ventilation.ToXML();
//            }

//            xmlPropertyDetails.PropertyType = sapPropertyDetails.PropertyType;
//            xmlPropertyDetails.BuiltForm = sapPropertyDetails.BuiltForm;
//            xmlPropertyDetails.LivingArea = sapPropertyDetails.LivingArea;
//            xmlPropertyDetails.Orientation = sapPropertyDetails.Orientation;

//            return xmlPropertyDetails;
//        }
//    }
//}
