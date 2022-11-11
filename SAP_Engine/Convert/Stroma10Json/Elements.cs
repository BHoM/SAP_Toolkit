using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using BH.oM.Base;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.Elements ToElements(CustomObject elementsObject)
        {
            if (elementsObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.Elements sapElements = new BH.oM.Environment.SAP.Stroma10.Elements();

            sapElements.ID = System.Convert.ToInt32(elementsObject.CustomData["Id"]);

            sapElements.Fabrics = ToFabrics((elementsObject.CustomData["Fabric"] as List<object>).Cast<CustomObject>().ToList());

            sapElements.Heatings = ToHeatings((elementsObject.CustomData["Heating"] as List<object>).Cast<CustomObject>().ToList());

            sapElements.Waters = ToWaters((elementsObject.CustomData["Water"] as List<object>).Cast<CustomObject>().ToList());

            sapElements.Ventilations = ToVentilations((elementsObject.CustomData["Ventilation"] as List<object>).Cast<CustomObject>().ToList());

            sapElements.Renewables = ToRenewables((elementsObject.CustomData["Renewable"] as List<object>).Cast<CustomObject>().ToList());

            sapElements.Overheatings = ToOverheatings((elementsObject.CustomData["Overheating"] as List<object>).Cast<CustomObject>().ToList());

            return sapElements;
        }
    }
}
