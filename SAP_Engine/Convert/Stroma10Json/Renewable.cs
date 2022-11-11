using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static List<BH.oM.Environment.SAP.Stroma10.Renewable> ToRenewables(List<CustomObject> renewablesObject)
        {
            if (renewablesObject == null)
                return null;

            List<BH.oM.Environment.SAP.Stroma10.Renewable> rtn = new List<BH.oM.Environment.SAP.Stroma10.Renewable>();
            foreach (var value in renewablesObject)
            {
                rtn.Add(ToRenewable(value));
            }
            return rtn;
        }
        public static BH.oM.Environment.SAP.Stroma10.Renewable ToRenewable(CustomObject renewableObject)
        {
            if (renewableObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.Renewable sapRenewable = new BH.oM.Environment.SAP.Stroma10.Renewable();

            sapRenewable.ID = System.Convert.ToInt32(renewableObject.CustomData["Id"]);

            sapRenewable.WindTurbine = ToWindTurbine(renewableObject.CustomData["WindTurbine"] as CustomObject);
            
            sapRenewable.Photovoltaic = ToPhotovoltaic(renewableObject.CustomData["Photovoltaic"] as CustomObject);

            sapRenewable.Special = ToSpecial(renewableObject.CustomData["Special"] as CustomObject);

            sapRenewable.AdditionalGeneration = ToAdditionalGeneration(renewableObject.CustomData["AAEGeneration"] as CustomObject);

            sapRenewable.HydroGeneration = ToHydroGeneration(renewableObject.CustomData["HydroGeneration"] as CustomObject);

            return sapRenewable;
        }
    }
}
