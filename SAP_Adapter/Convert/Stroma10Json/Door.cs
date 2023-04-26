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
using System.Text;
using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static List<BH.oM.Environment.SAP.Stroma10.Door> ToDoors(List<CustomObject> doorsObject)
        {
            if (doorsObject == null)
                return null;

            List<BH.oM.Environment.SAP.Stroma10.Door> rtn = new List<BH.oM.Environment.SAP.Stroma10.Door>();
            foreach (var value in doorsObject)
            {
                rtn.Add(ToDoor(value));
            }

            return rtn;
        }

        public static BH.oM.Environment.SAP.Stroma10.Door ToDoor(CustomObject doorObject)
        {
            if (doorObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.Door sapDoor = new BH.oM.Environment.SAP.Stroma10.Door();
            sapDoor.ID = System.Convert.ToInt32(doorObject.CustomData["Id"]);
            sapDoor.BHoM_Guid = (Guid.Parse(doorObject.CustomData["Guid"] as string));
            sapDoor.Name = doorObject.Name;
            sapDoor.Location = (doorObject.CustomData["Location"] as string);
            sapDoor.UValueSource = System.Convert.ToInt32(doorObject.CustomData["UValueSource"]);
            sapDoor.Orientation = System.Convert.ToInt32(doorObject.CustomData["Orientation"]);
            sapDoor.OverShading = System.Convert.ToInt32(doorObject.CustomData["OverShading"]);
            sapDoor.GlazingType = System.Convert.ToInt32(doorObject.CustomData["GlazingType"]);
            sapDoor.AirGap = System.Convert.ToInt32(doorObject.CustomData["AirGap"]);
            sapDoor.FrameType = System.Convert.ToInt32(doorObject.CustomData["FrameType"]);
            sapDoor.ThermalBreak = System.Convert.ToInt32(doorObject.CustomData["ThermalBreak"]);
            sapDoor.Area = System.Convert.ToDouble(doorObject.CustomData["Area"]);
            sapDoor.Width = System.Convert.ToInt32(doorObject.CustomData["Width"]);
            sapDoor.Height = System.Convert.ToInt32(doorObject.CustomData["Height"]);
            sapDoor.Count = System.Convert.ToInt32(doorObject.CustomData["Count"]);
            sapDoor.OverhangWidth = System.Convert.ToInt32(doorObject.CustomData["OverhangWidth"]);
            sapDoor.OverhangDepth = System.Convert.ToInt32(doorObject.CustomData["OverhangDepth"]);
            sapDoor.CurtainType = System.Convert.ToInt32(doorObject.CustomData["CurtainType"]);
            sapDoor.FractionClosed = System.Convert.ToDouble(doorObject.CustomData["FractionClosed"]);
            sapDoor.Transmittance = System.Convert.ToDouble(doorObject.CustomData["Transmittance"]);
            sapDoor.FrameFactor = System.Convert.ToDouble(doorObject.CustomData["FrameFactor"]);
            sapDoor.UValue = System.Convert.ToDouble(doorObject.CustomData["Uvalue"]);
            sapDoor.FromXml = System.Convert.ToBoolean(doorObject.CustomData["FromXml"]);
            sapDoor.OpeningType = System.Convert.ToInt32(doorObject.CustomData["OpeningType"]);
            sapDoor.DoorType = System.Convert.ToInt32(doorObject.CustomData["DoorType"]);
            sapDoor.Pitch = System.Convert.ToDouble(doorObject.CustomData["Pitch"]);
            sapDoor.PitchKnown = System.Convert.ToBoolean(doorObject.CustomData["PitchKnown"]);
            sapDoor.IsArgonFilled = System.Convert.ToBoolean(doorObject.CustomData["IsArgonFilled"]);

            return sapDoor;
        }

        public static Dictionary<string, object> FromDoor(Door obj)
        {
            if (obj == null)
                return null;

            Dictionary<string, object> rtn = new Dictionary<string, object>();
            rtn.Add("Id", obj.ID);
            rtn.Add("Guid", obj.BHoM_Guid.ToString());
            rtn.Add("Name", obj.Name);
            rtn.Add("Location", obj.Location);
            rtn.Add("UValueSource", obj.UValueSource);
            rtn.Add("Orientation", obj.Orientation);
            rtn.Add("OverShading", obj.OverShading);
            rtn.Add("GlazingType", obj.GlazingType);
            rtn.Add("AirGap", obj.AirGap);
            rtn.Add("FrameType", obj.FrameType);
            rtn.Add("ThermalBreak", obj.ThermalBreak);
            rtn.Add("Area", obj.Area);
            rtn.Add("Width", obj.Width);
            rtn.Add("Height", obj.Height);
            rtn.Add("Count", obj.Count);
            rtn.Add("OverhangWidth", obj.OverhangWidth);
            rtn.Add("OverhangDepth", obj.OverhangDepth);
            rtn.Add("CurtainType", obj.CurtainType);
            rtn.Add("FractionClosed", obj.FractionClosed);
            rtn.Add("Transmittance", obj.Transmittance);
            rtn.Add("FrameFactor", obj.FrameFactor);
            rtn.Add("Uvalue", obj.UValue);
            rtn.Add("FromXml", obj.FromXml);
            rtn.Add("OpeningType", obj.OpeningType);
            rtn.Add("DoorType", obj.DoorType);
            rtn.Add("Pitch", obj.Pitch);
            rtn.Add("PitchKnown", obj.PitchKnown);
            rtn.Add("IsArgonFilled", obj.IsArgonFilled);

            return rtn;
        }
    }
}
