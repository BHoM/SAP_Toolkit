using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.ElementSelections ToElementSelections(CustomObject elementSelectionsObject)
        {
            if (elementSelectionsObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.ElementSelections sapElementSelections = new BH.oM.Environment.SAP.Stroma10.ElementSelections();

            sapElementSelections.ID = System.Convert.ToInt32(elementSelectionsObject.CustomData["Id"]);

            sapElementSelections.FabricElement = elementSelectionsObject.CustomData["FabricElement"] as string;

            sapElementSelections.VentilationElement = elementSelectionsObject.CustomData["VentilationElement"] as string;

            sapElementSelections.HeatingElement = elementSelectionsObject.CustomData["HeatingElement"] as string;

            sapElementSelections.WaterElement = elementSelectionsObject.CustomData["WaterElement"] as string;

            sapElementSelections.RenewableElement = elementSelectionsObject.CustomData["RenewableElement"] as string;

            sapElementSelections.OverheatingElement = elementSelectionsObject.CustomData["OverheatingElement"] as string;
           
            return sapElementSelections;
        }
    }
}
