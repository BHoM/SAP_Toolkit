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
using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static List<BH.oM.Environment.SAP.Stroma10.Window> ToWindows(List<CustomObject> windowsObject)
        {
            if (windowsObject == null)
                return null;

            List<BH.oM.Environment.SAP.Stroma10.Window> rtn = new List<BH.oM.Environment.SAP.Stroma10.Window>();
            foreach (var value in windowsObject)
            {
                rtn.Add(ToWindow(value));
            }

            return rtn;
        }

        public static BH.oM.Environment.SAP.Stroma10.Window ToWindow(CustomObject windowObject)
        {
            if (windowObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.Window sapWindow = new BH.oM.Environment.SAP.Stroma10.Window();
            sapWindow.ID = System.Convert.ToInt32(windowObject.CustomData["Id"]);
            sapWindow.GUID = (windowObject.CustomData["Guid"] as string);
            sapWindow.Name = windowObject.Name;
            sapWindow.Location = windowObject.CustomData["Location"] as string;
            sapWindow.UValueSource = System.Convert.ToInt32(windowObject.CustomData["UValueSource"]);
            sapWindow.Orientation = System.Convert.ToInt32(windowObject.CustomData["Orientation"]);
            sapWindow.OverShading = System.Convert.ToInt32(windowObject.CustomData["OverShading"]);
            sapWindow.GlazingType = System.Convert.ToInt32(windowObject.CustomData["GlazingType"]);
            sapWindow.AirGap = System.Convert.ToInt32(windowObject.CustomData["AirGap"]);
            sapWindow.FrameType = System.Convert.ToInt32(windowObject.CustomData["FrameType"]);
            sapWindow.ThermalBreak = System.Convert.ToInt32(windowObject.CustomData["ThermalBreak"]);
            sapWindow.Area = System.Convert.ToDouble(windowObject.CustomData["Area"]);
            sapWindow.Width = System.Convert.ToInt32(windowObject.CustomData["Width"]);
            sapWindow.Height = System.Convert.ToInt32(windowObject.CustomData["Height"]);
            sapWindow.Count = System.Convert.ToInt32(windowObject.CustomData["Count"]);
            sapWindow.OverhangWidth = System.Convert.ToInt32(windowObject.CustomData["OverhangWidth"]);
            sapWindow.OverhangDepth = System.Convert.ToInt32(windowObject.CustomData["OverhangDepth"]);
            sapWindow.CurtainType = System.Convert.ToInt32(windowObject.CustomData["CurtainType"]);
            sapWindow.FractionClosed = System.Convert.ToDouble(windowObject.CustomData["FractionClosed"]);
            sapWindow.Transmittance = System.Convert.ToDouble(windowObject.CustomData["Transmittance"]);
            sapWindow.FrameFactor = System.Convert.ToDouble(windowObject.CustomData["FrameFactor"]);
            sapWindow.UValue = System.Convert.ToDouble(windowObject.CustomData["Uvalue"]);
            sapWindow.FromXml = System.Convert.ToBoolean(windowObject.CustomData["FromXml"]);
            sapWindow.OpeningType = System.Convert.ToInt32(windowObject.CustomData["OpeningType"]);
            sapWindow.DoorType = System.Convert.ToInt32(windowObject.CustomData["DoorType"]);
            sapWindow.Pitch = System.Convert.ToDouble(windowObject.CustomData["Pitch"]);
            sapWindow.PitchKnown = System.Convert.ToBoolean(windowObject.CustomData["PitchKnown"]);
            sapWindow.IsArgonFilled = System.Convert.ToBoolean(windowObject.CustomData["IsArgonFilled"]);

            return sapWindow;
        }

        public static Dictionary<string, object> FromWindow(Window obj)
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
