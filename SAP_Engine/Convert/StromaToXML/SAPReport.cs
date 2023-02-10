/////*
//// * This file is part of the Buildings and Habitats object Model (BHoM)
//// * Copyright (c) 2015 - 2023, the respective contributors. All rights reserved.
//// *
//// * Each contributor holds copyright over their respective contributions.
//// * The project versioning (Git) records all such contribution source information.
//// *                                           
//// *                                                                              
//// * The BHoM is free software: you can redistribute it and/or modify         
//// * it under the terms of the GNU Lesser General Public License as published by  
//// * the Free Software Foundation, either version 3.0 of the License, or          
//// * (at your option) any later version.                                          
//// *                                                                              
//// * The BHoM is distributed in the hope that it will be useful,              
//// * but WITHOUT ANY WARRANTY; without even the implied warranty of               
//// * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
//// * GNU Lesser General Public License for more details.                          
//// *                                                                            
//// * You should have received a copy of the GNU Lesser General Public License     
//// * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
//// */

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.ComponentModel;
//using BH.oM.Base.Attributes;
//using BH.oM.Base;
//using BH.oM.Environment.SAP;

//namespace BH.Engine.Environment.SAP
//{
//    public static partial class Convert
//    {
//        [Description("Convert Stroma10 to XML report header.")]
//        [Input("Stroma Root", "Stroma properties to convert")]
//        [Output("xmlReportHeader", "XML ReportHeader.")]
//        public static Output<BH.oM.Environment.SAP.XML.ReportHeader,BH.oM.Environment.SAP.XML.SAP10Data> ToXML(this oM.Environment.SAP.Stroma10.Root sapRoot)
//        {
//            //REPORTHEADER
//            BH.oM.Environment.SAP.XML.ReportHeader xmlReportHeader = new BH.oM.Environment.SAP.XML.ReportHeader();

//            xmlReportHeader.ReportReferenceNumber = null;
//            xmlReportHeader.InspectionDate = sapRoot.Dwellings[1].DwellingVersions[1].DwellingDetails.DateOfAssessment;
//            xmlReportHeader.ReportType = null;
//            xmlReportHeader.CompletionDate = sapRoot.Dwellings[1].DwellingVersions[1].DwellingDetails.DateOfAssessment;
//            xmlReportHeader.RegistrationDate = sapRoot.Dwellings[1].DwellingVersions[1].DwellingDetails.DateOfAssessment;
//            xmlReportHeader.Status = "entered";
//            xmlReportHeader.LanguageCode = "1";
//            xmlReportHeader.Tenure = sapRoot.Dwellings[1].DwellingVersions[1].DwellingDetails.TenureType.FromStromaToXML();
//            xmlReportHeader.TransactionType = sapRoot.Dwellings[1].DwellingVersions[1].DwellingDetails.TransactionType.ToString();//Add - Not correctly aligned
//            xmlReportHeader.SellerCommissionReport = null;
//            xmlReportHeader.PropertyType = sapRoot.Dwellings[1].DwellingVersions[1].DwellingDetails.PropertyType.ToString();//Add - Not correctly aligned

//            BH.oM.Environment.SAP.XML.HomeInspector xmlHomeInspector = new oM.Environment.SAP.XML.HomeInspector();
//            BH.oM.Environment.SAP.XML.Address xmlContactAddress = new oM.Environment.SAP.XML.Address();

//            xmlHomeInspector.Name = sapRoot.Assessor.FirstName + sapRoot.Assessor.LastName;
//            xmlHomeInspector.NotifyLodgement = null;

//            xmlContactAddress.AddressLine1 = sapRoot.Assessor.Address.AddressLine1;
//            xmlContactAddress.AddressLine2 = sapRoot.Assessor.Address.AddressLine2;
//            xmlContactAddress.AddressLine3 = sapRoot.Assessor.Address.AddressLine3;
//            xmlContactAddress.PostTown = sapRoot.Assessor.Address.City;
//            xmlContactAddress.Postcode= sapRoot.Assessor.Address.Postcode;
//            xmlHomeInspector.ContactAddress = xmlContactAddress;

//            xmlHomeInspector.WebSite= sapRoot.Assessor.WebSite;
//            xmlHomeInspector.EMail = sapRoot.Assessor.Email;
//            xmlHomeInspector.Fax = sapRoot.Assessor.Fax;
//            xmlHomeInspector.Telephone= sapRoot.Assessor.Telephone;
//            xmlHomeInspector.CompanyName= sapRoot.Assessor.CompanyName;
//            xmlHomeInspector.SchemeName = null;
//            xmlHomeInspector.SchemeWebSite = null;
//            xmlHomeInspector.SchemeWebSite = null;
//            xmlHomeInspector.IdentificationNumber = null;
//            xmlReportHeader.HomeInspector = xmlHomeInspector;

//            BH.oM.Environment.SAP.XML.Property xmlProperty = new oM.Environment.SAP.XML.Property();
//            BH.oM.Environment.SAP.XML.Address xmlPropertyAddress = new oM.Environment.SAP.XML.Address();

//            xmlPropertyAddress.AddressLine2 = sapRoot.Address.AddressLine2;
//            xmlPropertyAddress.AddressLine3 = sapRoot.Address.AddressLine3;
//            xmlPropertyAddress.PostTown = sapRoot.Address.City;
//            xmlPropertyAddress.Postcode = sapRoot.Address.Postcode;
//            xmlProperty.Address = xmlPropertyAddress;

//            xmlProperty.UniquePropertyReferenceNumber = null;
//            xmlProperty.SiteReference = null;
//            xmlProperty.PlotReference= null;

//            xmlReportHeader.Property = xmlProperty;

//            xmlReportHeader.RegionCode = null;
//            xmlReportHeader.CountryCode = sapRoot.Address.City.FromStromaToXML();
//            xmlReportHeader.RelatedPartyDisclosure.RelatedPartyDisclosureNumber = sapRoot.Dwellings[1].DwellingVersions[1].DwellingDetails.RelatedParty.ToString();

//            //SAP10Data

//            BH.oM.Environment.SAP.XML.SAP10Data xmlSAP10Data = new BH.oM.Environment.SAP.XML.SAP10Data();
//            xmlSAP10Data.DataType = "1";
//            xmlSAP10Data.PropertyDetails = sapRoot.Dwellings.ToXML();


            
//            return new Output<BH.oM.Environment.SAP.XML.ReportHeader, BH.oM.Environment.SAP.XML.SAP10Data>() { Item1 = xmlReportHeader, Item2 = xmlSAP10Data };


//        }
//        private static string FromStromaToXML(this int tenureType)
//        {
//            switch (tenureType)
//            {
//                case 0:
//                    return "ND";

//                case 1:
//                    return "1";

//                case 2:
//                    return "2";

//                case 3:
//                    return "3";

//                case 4:
//                    return "4";

//                default:
//                    return "ND";
//            }
//        }
//        private static string FromStromaToXML(this string country)
//        {
//            switch (country)
//            {
//                case "England":
//                    return "ENG";

//                case "Wales":
//                    return "WLS";

//                case "Scotland":
//                    return "SCT";

//                case "Northern Ireland":
//                    return "NIR";

//                default:
//                    return null;
//            }
//        }

//    }
//}
