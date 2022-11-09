using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.Elements ToElements(CustomObject elementsObject)
        {
            BH.oM.Environment.SAP.Stroma10.Elements sapElements = new BH.oM.Environment.SAP.Stroma10.Elements();

            sapElements.ID = System.Convert.ToInt32(elementsObject.CustomData["ID"]);

            sapElements.Fabric = (List<object>)elementsObject.CustomData["Fabric"];

            sapElements.Heating = (List<object>)elementsObject.CustomData["Heating"];

            sapElements.Water = (List<object>)elementsObject.CustomData["Water"];

            sapElements.Ventilation = (List<object>)elementsObject.CustomData["Ventilation"];

            sapElements.Renewable = (List<object>)elementsObject.CustomData["Renewable"];

            sapElements.Overheating = (List<object>)elementsObject.CustomData["Overheating"];

            return sapElements;
        }
    }
}
