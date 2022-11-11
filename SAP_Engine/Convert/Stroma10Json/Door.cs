using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using BH.oM.Base;

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
    }
}
