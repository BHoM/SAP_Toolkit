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
using BH.oM.Environment.SAP.Stroma10;
using BH.oM.Environment.SAP.Bluebeam;
using BH.oM.Base;
using BH.oM.Quantities.Attributes;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace BH.Engine.Environment.SAP
{
    public static partial class Modify
    {
        [Description("Modify opening type from a SAP report object.")]
        [Input("sapObj", "The sap report object to modify.")]
        [Input("type", "New type name for the windows.")]
        [Input("include", "A list of openings by name to modify.")]
        [Input("uvalue", "Uvalue for the new type.")]
        [Input("gvalue", "Gvalue for the new type.")]
        [Output("sapReport", "The modified SAP Report object.")]
        public static SAPReport ModifyOpeningTypes(this SAPReport sapObj, string type, List<string> include, double uvalue = -1, double gvalue = -1)
        {
            //If no valid values have been set
            if ((uvalue < 0) && (gvalue < 0))
            {
                return sapObj;
            }

            //Handling null type input
            if (type == null || type == "")
            {
                string name = "";

                name = (uvalue > 0 ? $"uvalue_{uvalue}_{name}" : name);
                name = (gvalue > 0 ? $"gvalue_{gvalue}_{name}" : name);

                if (name == "")
                {
                    BH.Engine.Base.Compute.RecordError("Please name the opening types in the opening type iterator.");
                    return null;
                }

                type = name;
            }

            List<BH.oM.Environment.SAP.XML.OpeningType> openingTypesList = sapObj.SAP10Data.PropertyDetails.OpeningTypes.OpeningType;

            var dict = openingTypesList.RenameOpeningType(type, include, uvalue, gvalue);

            //Add the new openings to the list of existing openings
            sapObj.SAP10Data.PropertyDetails.OpeningTypes.OpeningType = openingTypesList.InsertOpeningType(dict, uvalue, gvalue);

            List<BH.oM.Environment.SAP.XML.BuildingPart> buildingPartList = new List<oM.Environment.SAP.XML.BuildingPart>();

            //For each building part
            foreach (var b in sapObj.SAP10Data.PropertyDetails.BuildingParts.BuildingPart)
            {
                BH.oM.Environment.SAP.XML.BuildingPart partObj = b;
                List<BH.oM.Environment.SAP.XML.Opening> openingList = new List<oM.Environment.SAP.XML.Opening>();

                //For each opening, check if it's mentioned in the list and then change it's opening type.
                foreach (var o in b.Openings.Opening)
                {
                    BH.oM.Environment.SAP.XML.Opening openingObj = o;

                    //Finds in the dictionary the entry with the same type
                    var item = dict.Where(x => x.Value["Name"] == o.Type).FirstOrDefault().Value;

                    if (!item.IsNullOrEmpty())
                    {
                        openingObj = openingObj.ModifyOpeningType(item["NewName"]);

                    }

                    openingList.Add(openingObj);
                }

                partObj.Openings.Opening = openingList;
                buildingPartList.Add(partObj);
            }

            sapObj.SAP10Data.PropertyDetails.BuildingParts.BuildingPart = buildingPartList;

            return sapObj;
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

        [Description("Insert opening types into the list of existing opening types.")]
        [Input("typeObj", "Existing opening types.")]
        [Input("convert", "Dictionary of the original opening type data, and the newly modified data.")]
        [Input("uvalue", "uvalue for new type.")]
        [Input("gvalue", "gvalue for new type.")]
        [Output("openingTypes", "The modified SAP openingtypes list.")]
        public static List<BH.oM.Environment.SAP.XML.OpeningType> InsertOpeningType(this List<BH.oM.Environment.SAP.XML.OpeningType> typeObj, Dictionary<string, Dictionary<string, string>> convert, double uvalue = -1, double gvalue = -1)
        {
            List <BH.oM.Environment.SAP.XML.OpeningType> modifiedOpenings = new List<oM.Environment.SAP.XML.OpeningType>();

            foreach (var item in typeObj)
            {
                modifiedOpenings.Add(item);

                if (convert.ContainsKey(item.Description))
                {
                    BH.oM.Environment.SAP.XML.OpeningType newOpening = item.ShallowClone();

                    var map = convert[item.Description];

                    newOpening.Name = map["NewName"];
                    newOpening.Description = map["NewDescription"];

                    if (uvalue > 0)
                    {
                        newOpening.UValue = uvalue.ToString();
                    }

                    if (gvalue > 0)
                    {
                        newOpening.gValue = gvalue.ToString();
                    }

                    modifiedOpenings.Add(newOpening);
                }
            }
            return modifiedOpenings;
        }

        [Description("Insert opening types into the list of existing opening types.")]
        [Input("openingTypeObjs", "Existing opening types.")]
        [Input("newType", "Name of the new type")]
        [Input("include", "A list of openings by name to modify.")]
        [Input("uvalue", "uvalue for new type.")]
        [Input("gvalue", "gvalue for new type.")]
        [Output("convert", "Dictionary of the original opening type data, and the newly modified data.")]
        public static Dictionary<string, Dictionary<string, string>> RenameOpeningType(this List<BH.oM.Environment.SAP.XML.OpeningType> openingTypeObjs, string newType, List<string> include, double uvalue = -1, double gvalue = -1)
        {
            //Gets a list of all the existing opening type names
            List<string> typeNames = openingTypeObjs.Select(x => x.Description).ToList();

            //List of all the types of openings and the highest number assigned to them
            Dictionary<string, int> counts = openingTypeObjs.Select(x => x.Name).ToList().CountOpeningType();

            //A conversion between type of opening and name assigned to them
            Dictionary<string, string> conventions = new Dictionary<string, string>
            {
                { "1", "Doors" },
                { "2", "Doors" },
                { "3", "Doors" },
                { "4", "Windows"},
                { "5", "Roof Windows"},
                { "6", "Roof Windows"}
            };

            Dictionary<string, Dictionary<string, string>> test = new Dictionary<string, Dictionary<string, string>>();

            foreach (var type in openingTypeObjs)
            {
                if (include.Contains(type.Description))
                {
                    var name = type.Name;

                    var newDesc = newType + '_' + type.Description;

                    var newName = conventions[type.Type];
                    if (counts.ContainsKey(newName))
                    {
                        counts[newName]++;
                    }
                    else
                    {
                        counts[newName] = 1;
                    }
                    newName = $"{newName} ({counts[newName]})";

                    Dictionary<string, string> typeInfo = new Dictionary<string, string>
                    {
                        {"Name", name },
                        {"NewDescription",newDesc },
                        {"NewName", newName }
                    };

                    test.Add(type.Description, typeInfo);
                }
            }

            return test;

        }

        [Description("Counts how many type of each name is listed.")]
        [Input("openingNames", "List of all opening names.")]
        [Output("openingCount", "A dictionary that counts how many of each type are named.")]
        public static Dictionary<string, int> CountOpeningType(this List<string> openingNames)
        {
            List<(string, int)> values = new List<(string, int)>();

            foreach (var i in openingNames)
            {
                var start = i.LastIndexOf("(");
                var end = i.LastIndexOf(")");
                var r = end - start - 1;

                try
                {
                    var count = int.Parse(i.Substring(start + 1, r));
                    var t = i.Substring(0, start - 1);
                    values.Add((t, count));
                }
                catch (Exception ex)
                {
                    var e = $"Opening type {i} may not be named in convention with the schema";
                    BH.Engine.Base.Compute.RecordWarning(e);
                }
            }

            //Creates a dictionary { Key: Type, Value: Max number assigned to type}
            Dictionary<string, int> results = values.GroupBy(x => x.Item1).Select(x => new { Key = x.Key, Value = x.Select(y => y.Item2).Max() }).ToDictionary(x => x.Key, x => x.Value);

            return results;
        }
    }
}

