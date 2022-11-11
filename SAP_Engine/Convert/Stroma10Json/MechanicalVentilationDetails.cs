using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;

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

            sapMechanicalVentilationDetails.DuctProductID = ToAssessor(mechanicalVentilationDetailsObject.CustomData["DuctProductId"] as CustomObject);

            return sapMechanicalVentilationDetails;
        }
    }
}
