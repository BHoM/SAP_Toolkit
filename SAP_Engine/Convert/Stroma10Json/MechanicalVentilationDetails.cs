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
            BH.oM.Environment.SAP.Stroma10.MechanicalVentilationDetails sapMechanicalVentilationDetails = new BH.oM.Environment.SAP.Stroma10.MechanicalVentilationDetails();

            sapMechanicalVentilationDetails.ID = System.Convert.ToInt32(mechanicalVentilationDetailsObject.CustomData["ID"]);

            sapMechanicalVentilationDetails.ProductName = ToAssessor(mechanicalVentilationDetailsObject.CustomData["ProductName"] as CustomObject);

            sapMechanicalVentilationDetails.DuctingType = System.Convert.ToInt32(mechanicalVentilationDetailsObject.CustomData["DuctingType"]);

            sapMechanicalVentilationDetails.SpecificFanPower = System.Convert.ToDouble(mechanicalVentilationDetailsObject.CustomData["SpecificFanPower"]);

            sapMechanicalVentilationDetails.HeatExchangerEfficiency = System.Convert.ToDouble(mechanicalVentilationDetailsObject.CustomData["HeatExchangerEfficiency"]);

            sapMechanicalVentilationDetails.DuctProductID = ToAssessor(mechanicalVentilationDetailsObject.CustomData["DuctProductID"] as CustomObject);

            return sapMechanicalVentilationDetails;
        }
    }
}
