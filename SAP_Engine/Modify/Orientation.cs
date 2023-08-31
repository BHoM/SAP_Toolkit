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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base.Attributes;
using BH.oM.Environment.SAP;

using System.ComponentModel;

using BH.Engine.Base;
using System.IO;
using BH.oM.Adapter;
using BH.oM.Base;
using BH.oM.Environment.SAP.XML;
using System.Runtime.InteropServices.ComTypes;
using BH.oM.Adapter.Commands;

using BH.oM.Environment.SAP.JSON;

namespace BH.Engine.Environment.SAP
{
    public static partial class Modify
    {
        [Description("Modify the orientation of a dwelling by either mirroring or rotating or both :).")]
        [Input("sapObj", "Input the SAPReport object to modify.")]
        [Input("rotation", "How much the dwelling is rotated by.")]
        [Input("mirrorLine", "The line to mirror across.")]
        [MultiOutput(0, "sapReport", "The modified SAP Report object.")]
        [MultiOutput(1, "changesToOrientation", "Tracking the changes made to the orientation of the dwelling and the Photovoltaic arrays.")]
        [MultiOutput(2, "changesToOpenings", "Tracking the changes made to the orientation of the openings.")]
        public static Output<SAPReport, Orientation, List<BH.oM.Environment.SAP.JSON.Opening>> ModifyOrientations(this SAPReport sapObj, Rotation rotation, Mirror mirrorLine)
        {
            //Null sapObj input
            if (sapObj == null)
            {
                BH.Engine.Base.Compute.RecordError("No sap object inputted to mirror.");
                return null;
            }

            //If rotation is null/None and mirrorLine is null/None
            if ((rotation == Rotation.Zero || rotation == Rotation.ThreeHundredSixty) && (mirrorLine == null || (mirrorLine == Mirror.None)))
            {
                return new Output<SAPReport, Orientation, List<oM.Environment.SAP.JSON.Opening>>()
                {
                    Item1 = sapObj,
                    Item2 = new Orientation(),
                    Item3 = new List<BH.oM.Environment.SAP.JSON.Opening>()
                };
            };

            //QA File - tracks changes of orientation of dwelling and photovoltaic arrays
            Orientation changes = new Orientation();

            BH.oM.Environment.SAP.XML.PropertyDetails propertyDetailsObj = sapObj.SAP10Data.PropertyDetails;

            //Rotate the orientation of the dwelling if the orientation of the dwelling is not null
            if (propertyDetailsObj.Orientation != null)
            {
                string orientation = propertyDetailsObj.Orientation.ModifyOrientation(rotation, mirrorLine);

                //QA file
                changes.DwellingOrientation = new Changes { Initial = propertyDetailsObj.Orientation, Final = orientation };

                propertyDetailsObj.Orientation = orientation;
            }
            else
            {
                BH.Engine.Base.Compute.RecordError("Please input an orientation for the dwelling.");
            }

            //Rotate the PV in EnergySource
            if (propertyDetailsObj.EnergySource != null && propertyDetailsObj.EnergySource.PhotovoltaicArrays != null && propertyDetailsObj.EnergySource.PhotovoltaicArrays.PhotovoltaicArray != null)
            {
                //List of existing PVArrays in Energy source
                List<BH.oM.Environment.SAP.XML.PhotovoltaicArray> PVArrays = propertyDetailsObj.EnergySource.PhotovoltaicArrays.PhotovoltaicArray;

                //Assign the list of modified arrays to the property details obj
                var pvModifications = PVArrays.OrientationPV(rotation, mirrorLine);

                propertyDetailsObj.EnergySource.PhotovoltaicArrays.PhotovoltaicArray = pvModifications.Item1;
                changes.PVEnergySource = pvModifications.Item2;
            }

            //QA File - tracks changes of orientation of photovoltaic arrays
            List<Changes> pvFGHRS = new List<Changes>();

            //Rotate the PV in MainHeating
            //Checking if Mainheating object is defined and if it isn't: side eye
            if (propertyDetailsObj.Heating != null && propertyDetailsObj.Heating.MainHeatingDetails != null && propertyDetailsObj.Heating.MainHeatingDetails.MainHeating != null)
            {
                //List of existing heating systems in report
                List<MainHeating> heatingObjs = propertyDetailsObj.Heating.MainHeatingDetails.MainHeating;

                //For each heating system
                foreach (var heating in heatingObjs)
                {
                    //Check if pv is defined in the report
                    if (heating.FGHRSEnergySource != null && heating.FGHRSEnergySource.PhotovoltaicArrays != null && heating.FGHRSEnergySource.PhotovoltaicArrays.PhotovoltaicArray != null)
                    {
                        //A list of existing PV arrays in the Main Heating section
                        List<BH.oM.Environment.SAP.XML.PhotovoltaicArray> fghrsPVArrays = heating.FGHRSEnergySource.PhotovoltaicArrays.PhotovoltaicArray;

                        var pvModifications = fghrsPVArrays.OrientationPV(rotation, mirrorLine);

                        heating.FGHRSEnergySource.PhotovoltaicArrays.PhotovoltaicArray = pvModifications.Item1;

                        pvFGHRS = pvFGHRS.Concat(pvModifications.Item2).ToList();
                    }
                }
                propertyDetailsObj.Heating.MainHeatingDetails.MainHeating = heatingObjs;
                changes.PVHeating = pvFGHRS;
            }

            var openingModification = propertyDetailsObj.OrientationOpening(rotation, mirrorLine);

            sapObj.SAP10Data.PropertyDetails = openingModification.Item1;
            List<BH.oM.Environment.SAP.JSON.Opening> openingChanges = openingModification.Item2;

            return new Output<SAPReport, Orientation, List<BH.oM.Environment.SAP.JSON.Opening>>() { Item1 = sapObj, Item2 = changes, Item3 = openingChanges };
        }

        [Description("Modify the orientation of the openings.")]
        [Input("propertyDetailsObj", "PropertyDetails object to modify the openings within.")]
        [Input("rotation", "Line to rotate across.")]
        [MultiOutput(0, "propertyDetails", "Modified property details object.")]
        [MultiOutput(1, "changesToOpenings", "Tracking the changes made to the orientation of the openings.")]
        public static Output<BH.oM.Environment.SAP.XML.PropertyDetails, List<BH.oM.Environment.SAP.JSON.Opening>> OrientationOpening(this BH.oM.Environment.SAP.XML.PropertyDetails propertyDetailsObj, Rotation rotation, Mirror mirrorLine)
        {
            //QA file - tracking changes to the orientation of openings
            List<BH.oM.Environment.SAP.JSON.Opening> openingChanges = new List<oM.Environment.SAP.JSON.Opening>();

            //Rotate each opening in the dwelling
            List<BH.oM.Environment.SAP.XML.BuildingPart> buildingPartObj = propertyDetailsObj.BuildingParts.BuildingPart;
            List<BH.oM.Environment.SAP.XML.OpeningType> types = propertyDetailsObj.OpeningTypes.OpeningType;

            //Dictionary for the conversion between the name of the type given by the user and the name of the opening that matches the schema.
            Dictionary<string, string> typeMap = types.Select(x => new { Key = x.Name, Value = x.Description }).ToDictionary(x => x.Key, x => x.Value);

            foreach (var b in buildingPartObj)
            {
                //List of existing openings
                List<BH.oM.Environment.SAP.XML.Opening> openingObjs = b.Openings.Opening;
                foreach (var o in openingObjs)
                {
                    if (o.Orientation == "0" || o.Orientation == "9")
                    {
                        continue;
                    }

                    //Find the new orientation of the opening
                    string orientation = o.Orientation.ModifyOrientation(rotation, mirrorLine);

                    //QA file
                    BH.oM.Environment.SAP.JSON.Opening change = new oM.Environment.SAP.JSON.Opening
                    {
                        Name = o.Name,
                        Type = typeMap[o.Type],
                        Location = o.Location
                    };
                    change.Orientation = new Changes { Initial = $"{(CompassDirectionCode)(Int32.Parse(o.Orientation))}", Final = $"{(CompassDirectionCode)(Int32.Parse(orientation))}" };
                    openingChanges.Add(change);

                    //Changing orientation
                    o.Orientation = orientation;
                }
                b.Openings.Opening = openingObjs;
            }
            propertyDetailsObj.BuildingParts.BuildingPart = buildingPartObj;

            return new Output<BH.oM.Environment.SAP.XML.PropertyDetails, List<BH.oM.Environment.SAP.JSON.Opening>>() { Item1 = propertyDetailsObj, Item2 = openingChanges };
        }

        [Description("Modify the orientation of the PV.")]
        [Input("pvArrays", "List of photovoltaic arrays to modify the orientation of.")]
        [Input("rotation", "Line to rotate across.")]
        [MultiOutput(0, "PVarrayObject", "Modified property details object.")]
        [MultiOutput(1, "changesToPV", "Tracking the changes made to the orientation of the Photovoltaic arrays.")]
        public static Output<List<BH.oM.Environment.SAP.XML.PhotovoltaicArray>, List<Changes>> OrientationPV(this List<BH.oM.Environment.SAP.XML.PhotovoltaicArray> pvArrays, Rotation rotation, Mirror mirrorLine)
        {
            //QA file - tracking changes to the orientation of photovoltaic arrays
            List<Changes> pvChanges = new List<Changes>();

            //For each pv array
            foreach (var array in pvArrays)
            {
                if (array != null)
                {
                    //If array orientation is ND - horizontal or NR not defined
                    if (array.Orientation == "ND" || array.Orientation == "NR" || array.Orientation == null)
                    {
                        array.Orientation = "ND";
                        continue;
                    }

                    //Find the rotateed orientation
                    string orientation = array.Orientation.ModifyOrientation(rotation, mirrorLine);

                    //QA file - tracking change to array
                    Changes change = new Changes { Initial = $"{(CompassDirectionCode)(Int32.Parse(array.Orientation))}", Final = $"{(CompassDirectionCode)(Int32.Parse(orientation))}" };
                    pvChanges.Add(change);

                    //Assign new orientation to array
                    array.Orientation = orientation;
                }
                else
                {
                    continue;
                }
            }
            return new Output<List<BH.oM.Environment.SAP.XML.PhotovoltaicArray>, List<Changes>>() { Item1 = pvArrays, Item2 = pvChanges };
        }

        [Description("Change compass direction by mirroring across common lines.")]
        [Input("orientation", "Orientation to switch.")]
        [Input("mirrorLine", "Line to mirror across.")]
        [Output("Orientation", "New orientation.")]
        public static string ModifyOrientation(this string orientation, Rotation rotation, Mirror mirrorLine)
        {
            orientation = orientation.OrientationMirror(mirrorLine).OrientationRotate(rotation); 

            return orientation;
        }

        [Description("Change compass direction by mirroring across common lines.")]
        [Input("orientation", "Orientation to switch.")]
        [Input("mirrorLine", "Line to mirror across.")]
        [Output("Orientation", "New orientation.")]
        public static string OrientationMirror(this string orientation, Mirror mirrorLine)
        {
            //IF orientation is null or horizontal or not defined
            if (orientation == null || orientation == "0" || orientation == "9" || orientation == "ND" || orientation == "NR")
            {
                BH.Engine.Base.Compute.RecordWarning("Object does not have an orientation that can be mirrored.");
                return orientation;
            }

            List<int> compassPoints = new List<int> { (int)mirrorLine, (int)mirrorLine + 4 };

            //Mirror the orientation over the selected line
            int orientationValue = Int32.Parse(orientation);
            int distance = compassPoints.Select(x => (x - orientationValue)).ToList().Min();
            int compassDirection = (orientationValue + 2 * (distance)) % 8;

            if (compassDirection <= 0)
            {
                compassDirection += 8;
            }

            return compassDirection.ToString();
        }

        [Description("Rotate orientation to new orientation.")]
        [Input("orientation", "Orientation to switch.")]
        [Input("rotation", "How much the dwelling is rotated by.")]
        [Output("Orientation", "New orientation.")]
        public static string OrientationRotate(this string orientation, Rotation rotation)
        {
            //IF orientation is null or horizontal or not defined
            if (orientation == null || orientation == "0" || orientation == "9" || orientation == "ND" || orientation == "NR")
            {
                return orientation;
            }

            if (rotation == null || rotation == Rotation.Zero || rotation == Rotation.ThreeHundredSixty)
            {
                return orientation;
            }
            
            int compassDirection = (Int32.Parse(orientation) +(int)rotation) % 8;

            if (compassDirection <= 0)
            {
                compassDirection += 8;
            }
            return compassDirection.ToString();
        }
    }
}

