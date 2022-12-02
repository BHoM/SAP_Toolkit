/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2022, the respective contributors. All rights reserved.
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
        public static List<BH.oM.Environment.SAP.Stroma10.RoofLight> ToRoofLights(List<CustomObject> roofLightsObject)
        {

            if (roofLightsObject == null)
                return null;

            List<BH.oM.Environment.SAP.Stroma10.RoofLight> rtn = new List<BH.oM.Environment.SAP.Stroma10.RoofLight>();
            foreach (var value in roofLightsObject)
            {
                rtn.Add(ToRoofLight(value));
            }
            return rtn;
        }
        public static BH.oM.Environment.SAP.Stroma10.RoofLight ToRoofLight(CustomObject roofLightObject)
        {
            if (roofLightObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.RoofLight sapRoofLight = new BH.oM.Environment.SAP.Stroma10.RoofLight();

            sapRoofLight.ID = System.Convert.ToInt32(roofLightObject.CustomData["Id"]);


            sapRoofLight.BHoM_Guid = (Guid.Parse(roofLightObject.CustomData["Guid"] as string));


            sapRoofLight.Name = roofLightObject.Name;


            sapRoofLight.Location = (roofLightObject.CustomData["Location"] as string);


            sapRoofLight.UValueSource = System.Convert.ToInt32(roofLightObject.CustomData["UValueSource"]); 

            
            sapRoofLight.Orientation = System.Convert.ToInt32(roofLightObject.CustomData["Orientation"]); 

            
            sapRoofLight.OverShading = System.Convert.ToInt32(roofLightObject.CustomData["OverShading"]); 

            
            sapRoofLight.GlazingType = System.Convert.ToInt32(roofLightObject.CustomData["GlazingType"]); 

            
            sapRoofLight.AirGap = System.Convert.ToInt32(roofLightObject.CustomData["AirGap"]); 

            
            sapRoofLight.FrameType = System.Convert.ToInt32(roofLightObject.CustomData["FrameType"]); 

            
            sapRoofLight.ThermalBreak = System.Convert.ToInt32(roofLightObject.CustomData["ThermalBreak"]); 

            
            sapRoofLight.Area = System.Convert.ToDouble(roofLightObject.CustomData["Area"]); 

            
            sapRoofLight.Width = System.Convert.ToInt32(roofLightObject.CustomData["Width"]);

            
            sapRoofLight.Height = System.Convert.ToInt32(roofLightObject.CustomData["Height"]); 

            
            sapRoofLight.Count = System.Convert.ToInt32(roofLightObject.CustomData["Count"]); 

            
            sapRoofLight.OverhangWidth = System.Convert.ToInt32(roofLightObject.CustomData["OverhangWidth"]); 

            
            sapRoofLight.OverhangDepth = System.Convert.ToInt32(roofLightObject.CustomData["OverhangDepth"]); 

            
            sapRoofLight.CurtainType = System.Convert.ToInt32(roofLightObject.CustomData["CurtainType"]); 

            
            sapRoofLight.FractionClosed = System.Convert.ToDouble(roofLightObject.CustomData["FractionClosed"]); 

            
            sapRoofLight.Transmittance = System.Convert.ToDouble(roofLightObject.CustomData["Transmittance"]); 

            
            sapRoofLight.FrameFactor = System.Convert.ToDouble(roofLightObject.CustomData["FrameFactor"]); 

            
            sapRoofLight.UValue = System.Convert.ToDouble(roofLightObject.CustomData["Uvalue"]); 

            
            sapRoofLight.FromXml = System.Convert.ToBoolean(roofLightObject.CustomData["FromXml"]); 

            
            sapRoofLight.OpeningType = System.Convert.ToInt32(roofLightObject.CustomData["OpeningType"]); 

            
            sapRoofLight.DoorType = System.Convert.ToInt32(roofLightObject.CustomData["DoorType"]); 


            sapRoofLight.Pitch = System.Convert.ToDouble(roofLightObject.CustomData["Pitch"]); 

            
            sapRoofLight.PitchKnown = System.Convert.ToBoolean(roofLightObject.CustomData["PitchKnown"]); 

            
            sapRoofLight.IsArgonFilled = System.Convert.ToBoolean(roofLightObject.CustomData["IsArgonFilled"]); 

            return sapRoofLight;
        }
        public static Dictionary<string, object> FromRoofLight(RoofLight obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();

            if (obj == null)
                return null;

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

