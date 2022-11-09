using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.HydroGeneration ToHydroGeneration(CustomObject hydroGenerationObject)
        {
            BH.oM.Environment.SAP.Stroma10.HydroGeneration sapHydroGeneration = new BH.oM.Environment.SAP.Stroma10.HydroGeneration();

            sapHydroGeneration.ID = System.Convert.ToInt32(hydroGenerationObject.CustomData["ID"]);

            sapHydroGeneration.Yearly = System.Convert.ToBoolean(hydroGenerationObject.CustomData["Yearly"]);

            sapHydroGeneration.Include = System.Convert.ToBoolean(hydroGenerationObject.CustomData["Include"]);

            sapHydroGeneration.HydroGenerated = System.Convert.ToDouble(hydroGenerationObject.CustomData["HydroGenerated"]);
            
            sapHydroGeneration.ConnectedToMeter = System.Convert.ToBoolean(hydroGenerationObject.CustomData["ConnectedToMeter"]);
            
            sapHydroGeneration.TotalArea = System.Convert.ToDouble(hydroGenerationObject.CustomData["TotalArea"]);

            sapHydroGeneration.MonthlyValues = ToMonthlyValues(hydroGenerationObject.CustomData["MonthlyValues"] as CustomObject);

            sapHydroGeneration.Certificate = (hydroGenerationObject.CustomData["Certificate"] as CustomObject);

            return sapHydroGeneration;
        }
    }
}
