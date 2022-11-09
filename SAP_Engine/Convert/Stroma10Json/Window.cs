using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static List<BH.oM.Environment.SAP.Stroma10.Window> ToWindows(CustomObject windowsObject)
        {
            List<BH.oM.Environment.SAP.Stroma10.Window> rtn = new List<BH.oM.Environment.SAP.Stroma10.Window>();
            foreach (var value in windowsObject.CustomData["Windows"] as List<CustomObject>)
            {
                rtn.Add(ToWindow(value));
            }
            return rtn;
        }
        public static BH.oM.Environment.SAP.Stroma10.Window ToWindow(CustomObject windowObject)
        {
            BH.oM.Environment.SAP.Stroma10.Window sapWindow = new BH.oM.Environment.SAP.Stroma10.Window();

            sapWindow.ID = System.Convert.ToInt32(windowObject.CustomData["ID"]);

            sapWindow.BHoM_Guid = (Guid)windowObject.CustomData["GUID"];
            
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

            sapWindow.UValue = System.Convert.ToDouble(windowObject.CustomData["UValue"]);

            sapWindow.FromXml = System.Convert.ToBoolean(windowObject.CustomData["FromXml"]);

            sapWindow.OpeningType = System.Convert.ToInt32(windowObject.CustomData["OpeningType"]);

            sapWindow.DoorType = System.Convert.ToInt32(windowObject.CustomData["DoorType"]);

            sapWindow.Pitch = System.Convert.ToDouble(windowObject.CustomData["Pitch"]);

            sapWindow.PitchKnown = System.Convert.ToBoolean(windowObject.CustomData["PitcheKnown"]);

            sapWindow.IsArgonFilled = System.Convert.ToBoolean(windowObject.CustomData["IsArgonFilled"]);

            return sapWindow;
        }
    }
}
