/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2024, the respective contributors. All rights reserved.
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
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;
using BH.oM.Base;

namespace BH.oM.Environment.SAP.Bluebeam
{
    [Serializable]
    [XmlRoot(ElementName = "Markup", IsNullable = false)]
    public class SAPMarkup : BluebeamSAPObject
    {
        [XmlElement("Page_Label")]
        public virtual int PageLabel { get; set; }

        [XmlElement("Subject")]
        public virtual string Subject { get; set; }

        [XmlElement("Space")]
        public virtual string Space { get; set; }

        [XmlElement("Author")]
        public virtual string Author { get; set; }

        [XmlElement("Date")]
        public virtual string Date { get; set; }

        [XmlElement("Colour")]
        public virtual string Colour { get; set; }

        [XmlElement("Comments")]
        public virtual string Comments { get; set; }

        [XmlElement("Length")]
        public virtual double Length { get; set; }

        [XmlElement("Area")]
        public virtual double Area { get; set; }

        [XmlElement("Label")]
        public virtual string Label { get; set; }

        [Description("By default this is an XML String representation. Most software will automatically handle the conversion to a numerical representation but users can also use the Query.Depth(Markup) method if necessary.")]
        [XmlElement("Depth")]
        public virtual string Depth { get; set; }

        [XmlElement("Layer")]
        public virtual string Layer { get; set; }

        [Description("This is a custom property which can be added to Bluebeam for SAP workflow interoperability.")]
        [XmlElement("TFA-FloorType")]
        public virtual string TFAFloorType { get; set; }

        [Description("This is a custom property which can be added to Bluebeam for SAP workflow interoperability.")]
        [XmlElement("TFA-DwellingStorey")]
        public virtual int TFADwellingStorey { get; set; }

        [Description("This is a custom property which can be added to Bluebeam for SAP workflow interoperability.")]
        [XmlElement("TFA-BuildingLevel")]
        public virtual int TFABuildingLevel { get; set; }

        [Description("This is a custom property which can be added to Bluebeam for SAP workflow interoperability.")]
        [XmlElement("TFA-Height")]
        public virtual double TFAHeight { get; set; }

        [Description("This is a custom property which can be added to Bluebeam for SAP workflow interoperability.")]
        [XmlElement("Roof-Type")]
        public virtual string RoofType { get; set; }

        [Description("This is a custom property which can be added to Bluebeam for SAP workflow interoperability.")]
        [XmlElement("ThermalBridge-Type")]
        public virtual string ThermalBridgeType { get; set; }

        [Description("This is a custom property which can be added to Bluebeam for SAP workflow interoperability.")]
        [XmlElement("ThermalBridge-Length")]
        public virtual string ThermalBridgeLength { get; set; }

        [Description("This is a custom property which can be added to Bluebeam for SAP workflow interoperability.")]
        [XmlElement("Opening-Type")]
        public virtual string OpeningType { get; set; }

        [Description("This is a custom property which can be added to Bluebeam for SAP workflow interoperability.")]
        [XmlElement("Opening-Location")]
        public virtual string OpeningLocation { get; set; }

        [Description("This is a custom property which can be added to Bluebeam for SAP workflow interoperability.")]
        [XmlElement("Opening-Height")]
        public virtual double OpeningHeight { get; set; }

        [Description("This is a custom property which can be added to Bluebeam for SAP workflow interoperability.")]
        [XmlElement("Opening-Orientation")]
        public virtual string OpeningOrientation { get; set; }

        [Description("This is a custom property which can be added to Bluebeam for SAP workflow interoperability.")]
        [XmlElement("Opening-Pitch")]
        public virtual string OpeningPitch { get; set; }

        [Description("This is a custom property which can be added to Bluebeam for SAP workflow interoperability.")]
        [XmlElement("Wall-Type")]
        public virtual string WallType { get; set; }

        [Description("This is a custom property which can be added to Bluebeam for SAP workflow interoperability.")]
        [XmlElement("Wall-Height")]
        public virtual double WallHeight { get; set; }

        [Description("This is a custom property which can be added to Bluebeam for SAP workflow interoperability to determine whether this markup is for a Curtain Wall.")]
        [XmlElement("Curtain-Wall")]
        public virtual bool IsCurtainWall { get; set; }
    }
}



