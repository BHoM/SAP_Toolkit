using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.MechanicalVentilationDetails ToMechanicalVentilationDetails(CustomObject mechanicalVentilationDetailsObject)
        {
            if (mechanicalVentilationDetailsObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.MechanicalVentilationDetails sapMechanicalVentilationDetails = new BH.oM.Environment.SAP.Stroma10.MechanicalVentilationDetails();

            sapMechanicalVentilationDetails.ID = System.Convert.ToInt32(mechanicalVentilationDetailsObject.CustomData["Id"]);

            sapMechanicalVentilationDetails.ProductName = mechanicalVentilationDetailsObject.CustomData["ProductName"] as string;

            sapMechanicalVentilationDetails.DuctingType = System.Convert.ToInt32(mechanicalVentilationDetailsObject.CustomData["DuctingType"]);

            sapMechanicalVentilationDetails.SpecificFanPower = System.Convert.ToDouble(mechanicalVentilationDetailsObject.CustomData["Sfp"]);

            sapMechanicalVentilationDetails.HeatExchangerEfficiency = System.Convert.ToDouble(mechanicalVentilationDetailsObject.CustomData["Hee"]);

            sapMechanicalVentilationDetails.DuctProductID = (mechanicalVentilationDetailsObject.CustomData["DuctProductId"] as string);

            return sapMechanicalVentilationDetails;
        }
        public static Dictionary<string, object> FromMechanicalVentilationDetails(MechanicalVentilationDetails obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();

            if (obj == null)
                return null;

            rtn.Add("Id", obj.ID);

            rtn.Add("ProductName", obj.ProductName);

            rtn.Add("DuctingType", obj.DuctingType);

            rtn.Add("Sfp", obj.SpecificFanPower);

            rtn.Add("Hee", obj.HeatExchangerEfficiency);

            rtn.Add("DuctProductId", obj.DuctProductID);

            return rtn;
        }
    }
}
