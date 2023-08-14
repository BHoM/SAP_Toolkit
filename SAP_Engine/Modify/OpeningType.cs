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
using BH.oM.Environment.SAP.JSON;

namespace BH.Engine.Environment.SAP
{
    public static partial class Modify
    {
        [Description("Modify opening type from a SAP report object.")]
        [Input("sapObj", "The sap report object to modify.")]
        [Input("include", "A list of openings by name to modify.")]
        [Input("uvalue", "Uvalue for the new type.")]
        [Input("gvalue", "Gvalue for the new type.")]
        [MultiOutput(0, "sapReport", "The modified SAP Report object.")]
        [MultiOutput(1, "changesToOpeningTypes", "Tracking the changes made to the uvalues and gvalue to the opening types.")]
        public static Output<SAPReport, List<BH.oM.Environment.SAP.JSON.OpeningType>> ModifyOpeningTypes(this SAPReport sapObj, List<string> include, double uvalue = -1, double gvalue = -1)
        {
            //Check for null input of sap report
            if (include == null || ((uvalue < 0) && (gvalue < 0)) || sapObj == null)
            {
                return null;
            }

            //QA file - track changes to uvalue and gvalue of opening type
            List<BH.oM.Environment.SAP.JSON.OpeningType> changes = new List<oM.Environment.SAP.JSON.OpeningType>();

            //List of existing opening types
            List<BH.oM.Environment.SAP.XML.OpeningType> openingTypesList = new List<oM.Environment.SAP.XML.OpeningType>();

            List<BH.oM.Environment.SAP.XML.OpeningType> toRename = new List<oM.Environment.SAP.XML.OpeningType>();

            foreach (var o in sapObj.SAP10Data.PropertyDetails.OpeningTypes.OpeningType)
            {
                BH.oM.Environment.SAP.XML.OpeningType typeObj = o;

                if (include.Contains(typeObj.Description))
                {
                    //QA file
                    BH.oM.Environment.SAP.JSON.OpeningType typeChanges = new oM.Environment.SAP.JSON.OpeningType
                    {
                        Type = typeObj.Description,
                        Name = typeObj.Name
                    };

                    typeChanges.UValue = (uvalue > 0 ? new Changes { Initial = o.UValue, Final = uvalue.ToString() } : null);
                    typeChanges.GValue = (gvalue > 0 ? new Changes { Initial = o.gValue, Final = gvalue.ToString() } : null);
                    changes.Add(typeChanges);

                    //Modify opening type uvalue and/or gvalue
                    BH.oM.Environment.SAP.XML.OpeningType newType = typeObj.ShallowClone().ModifyOpeningType(uvalue, gvalue);
                    openingTypesList.Add(newType);
                    toRename.Add(typeObj);
                }
                else
                {
                    openingTypesList.Add(o);
                }
            }
            openingTypesList.RenameOpeningType(toRename);
            sapObj.SAP10Data.PropertyDetails.OpeningTypes.OpeningType = openingTypesList.RenameOpeningType(toRename);

            return new Output<SAPReport, List<BH.oM.Environment.SAP.JSON.OpeningType>>() { Item1 = sapObj, Item2 = changes };
        }

        [Description("Change the opening types of an opening.")]
        [Input("type", "Opening type to modify.")]
        [Input("uvalue", "Uvalue for the new type.")]
        [Input("gvalue", "Gvalue for the new type.")]
        [Output("openingType", "Modified opening.")]
        public static BH.oM.Environment.SAP.XML.OpeningType ModifyOpeningType(this BH.oM.Environment.SAP.XML.OpeningType type, double uvalue = -1, double gvalue = -1)
        {
            //If uvalue is valid
            if (uvalue > 0)
            {
                type.UValue = uvalue.ToString();
            }

            //IF gvalue is valid
            if (gvalue > 0)
            {
                type.gValue = gvalue.ToString();
            }

            return type;
        }


        [Description("Add opening types into the list of all opening types.")]
        [Input("added", "Modified and unmodified opening types.")]
        [Input("toAdd", "Unmodified opening types that need to be added")]
        [Output("types", "All of the opening types in one list.")]
        public static List<BH.oM.Environment.SAP.XML.OpeningType> RenameOpeningType(this List<BH.oM.Environment.SAP.XML.OpeningType> added, List<BH.oM.Environment.SAP.XML.OpeningType> toAdd)
        {
            //List of all the types of openings and the highest number assigned to them
            Dictionary<string, int> counts = added.Select(x => x.Name).ToList().CountOpeningType();

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

            //For each opening type that needs to be added
            foreach (var type in toAdd)
            {
                BH.oM.Environment.SAP.XML.OpeningType opening = type;

                //New description is the old description and old schema approved name
                string newDesc = $"{type.Description}: {type.Name}";

                //Finds the equivalent value based on the type from the conventions dictionary
                var newName = conventions[type.Type];

                //If no related item in the counts dictionary adds it and if so, takes the value
                if (counts.ContainsKey(newName)) counts[newName]++;
                else counts[newName] = 1;

                //New name of object that is along with the schema
                newName = $"{newName} ({counts[newName]})";

                //Assigning the name and description
                opening.Name = newName;
                opening.Description = newDesc;

                //Add to list
                added = added.Append(opening).ToList();
                //added.Add(opening);
            }
           
            return added;

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

