using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.HydroGeneration ToHydroGeneration(CustomObject hydroGenerationObject)
        {
            if (hydroGenerationObject == null)
                return null;
            
            BH.oM.Environment.SAP.Stroma10.HydroGeneration sapHydroGeneration = new BH.oM.Environment.SAP.Stroma10.HydroGeneration();

            sapHydroGeneration.ID = System.Convert.ToInt32(hydroGenerationObject.CustomData["Id"]);

            sapHydroGeneration.Yearly = System.Convert.ToBoolean(hydroGenerationObject.CustomData["Yearly"]);

            sapHydroGeneration.Include = System.Convert.ToBoolean(hydroGenerationObject.CustomData["Include"]);

            sapHydroGeneration.HydroGenerated = System.Convert.ToDouble(hydroGenerationObject.CustomData["HydroGenerated"]);
            
            sapHydroGeneration.ConnectedToMeter = System.Convert.ToBoolean(hydroGenerationObject.CustomData["ConnectedToMeter"]);
            
            sapHydroGeneration.TotalArea = System.Convert.ToDouble(hydroGenerationObject.CustomData["TotalArea"]);

            sapHydroGeneration.MonthlyValues = ToMonthlyValues(hydroGenerationObject.CustomData["MonthlyValues"] as CustomObject);

            sapHydroGeneration.Certificate = (hydroGenerationObject.CustomData["Certificate"] as string);

            return sapHydroGeneration;
        }
        public static Dictionary<string, object> FromHydroGeneration(HydroGeneration obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();

            if (obj == null)
                return null;

            rtn.Add("Id", obj.ID);

            rtn.Add("Yearly", obj.Yearly);

            rtn.Add("Include", obj.Include);

            rtn.Add("HydroGenerated", obj.HydroGenerated);

            rtn.Add("ConnectedToMeter", obj.ConnectedToMeter);

            rtn.Add("TotalArea", obj.TotalArea);

            rtn.Add("MonthlyValues", FromMonthlyValues(obj.MonthlyValues));

            rtn.Add("Certificate", obj.Certificate);

            return rtn;
        }
    }
}
