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
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Linq;
using System.ComponentModel;
using BH.oM.Adapter;
using BH.Engine.Diffing;
using BH.oM.Environment.SAP.XML;
using BH.oM.Environment.SAP;
using BH.Engine.Base;
using System.Runtime.InteropServices.ComTypes;
using BH.oM.Environment.Elements;
using BH.oM.Base.Attributes;

namespace BH.Engine.Environment.SAP
{
    public static partial class Modify
    {
        [Description("Modify opening type from a SAP report object.")]
        [Input("sapObj", "The sap report object to modify.")]
        [Input("include", "A list of openings by name to modify.")]
        [Input("uvalue", "Uvalue for the new type.")]
        [Input("gvalue", "Gvalue for the new type.")]
        [Input("type", "New type name for the windows. For each type")]
        [Output("sapReport", "The modified SAP Report object.")]
        public static SAPReport ModifyOpeningTypes(this SAPReport sapObj, string type, List<string> include, double uvalue = double.NaN,  double gvalue = double.NaN)
        {
            if (double.IsNaN(uvalue) && double.IsNaN(gvalue))
            {
                return null;
            }

            if (type == null)
            {
                string name = string.Empty;

                if (uvalue != 0.00)
                {
                    name = $"uvalue_{uvalue}_{name}";
                }

                if (gvalue != 0.00)
                {
                    name = name = $"gvalue_{gvalue}_{name}";
                }

                type = name;
            }

            var dict = include.Select(x => (type + "_" + x)).Zip(include, (v,k) => new { Key = k, Value = v }).ToDictionary(x => x.Key, x => x.Value);
            var valid = dict.Select(x => (include.Contains(x.Value))).ToList().Any(x => x == true);

            if (valid != false)
            {
                BH.Engine.Base.Compute.RecordError("Already a window type with these names."); //come back to this
                return null;
            }

            List<BH.oM.Environment.SAP.XML.BuildingPart> buildingPartList = new List<oM.Environment.SAP.XML.BuildingPart>();

            foreach (var b in sapObj.SAP10Data.PropertyDetails.BuildingParts.BuildingPart)
            {
                BH.oM.Environment.SAP.XML.BuildingPart partObj = b;
                List<BH.oM.Environment.SAP.XML.Opening> openingList = new List<oM.Environment.SAP.XML.Opening> ();

                foreach (var o in b.Openings.Opening)
                {
                    BH.oM.Environment.SAP.XML.Opening openingObj = o;

                    if (include.Contains(o.Type))
                    {
                        openingObj = openingObj.ModifyOpeningType(dict[o.Type]);
                    }

                    openingList.Add (openingObj);
                }

                partObj.Openings.Opening = openingList;
                buildingPartList.Add (partObj);  
            }

            sapObj.SAP10Data.PropertyDetails.BuildingParts.BuildingPart = buildingPartList;

            List<BH.oM.Environment.SAP.XML.OpeningType> openingsList = sapObj.SAP10Data.PropertyDetails.OpeningTypes.OpeningType;

            openingsList = openingsList.InsertOpeningTypes(dict, uvalue, gvalue);
            sapObj.SAP10Data.PropertyDetails.OpeningTypes.OpeningType = openingsList;

            return sapObj;
        }

        [Description("Insert opening types into the list of existing opening types.")]
        [Input("typeObj", "Existing opening types.")]
        [Input("dict", "Dictionary of opening types to add into existing list.")]
        [Input("uvalue", "uvalue for new type.")]
        [Input("gvalue", "gvalue for new type.")]
        [Output("openingTypes", "The modified SAP openingtypes list.")]
        public static List<BH.oM.Environment.SAP.XML.OpeningType> InsertOpeningTypes(this List<BH.oM.Environment.SAP.XML.OpeningType> typeObj, Dictionary<string,string> dict, double uvalue, double gvalue)
        {
            List<string> typeNames = typeObj.Select(x => x.Name).ToList();

            List<BH.oM.Environment.SAP.XML.OpeningType> newTypes = new List<oM.Environment.SAP.XML.OpeningType>();

            foreach (var t in dict)
            {
                if (typeNames.Contains(t.Key))
                {
                    var test = typeObj.Where(x => x.Description == t.Key).ToList();
                    if (test.IsNullOrEmpty())
                    {
                        continue;
                    }

                    BH.oM.Environment.SAP.XML.OpeningType newOpening = test.FirstOrDefault().ShallowClone();

                    newOpening.Name = t.Value;

                    if (uvalue != 0.00)
                    {
                        newOpening.UValue = uvalue.ToString();
                    }
                    
                    if (gvalue != 0.00)
                    {
                        newOpening.gValue= gvalue.ToString();
                    }
                    newTypes.Add(newOpening);
                }
            }
            typeObj = typeObj.Concat(newTypes).ToList();
            
            return typeObj;
        }

        [Description("Change the opening types of an opening.")]
        [Input("opening", "Opening to modify the type of.")]
        [Input("type", "Type to change to.")]
        [Output("opening", "Modified opening.")]
        public static BH.oM.Environment.SAP.XML.Opening ModifyOpeningType(this BH.oM.Environment.SAP.XML.Opening opening, string type)
        {
            opening.Type = type;

            return opening;
        }

    }
}

