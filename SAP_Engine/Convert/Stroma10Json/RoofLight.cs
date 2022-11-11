using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using BH.oM.Base;

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
    }
}
