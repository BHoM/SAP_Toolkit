using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using BH.oM.Base;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.Cylinder ToCylinder(CustomObject cylinderObject)
        {
            BH.oM.Environment.SAP.Stroma10.Cylinder sapCylinder = new BH.oM.Environment.SAP.Stroma10.Cylinder();

            sapCylinder.ID = System.Convert.ToInt32(cylinderObject.CustomData["ID"]);

            
            sapCylinder.Volume  = System.Convert.ToDouble(cylinderObject.CustomData["Volume "]); 

            
            sapCylinder.ManufacturerSpecified = System.Convert.ToBoolean(cylinderObject.CustomData["ManufacturerSpecified"]);  

            
            sapCylinder.DeclaredLoss = System.Convert.ToDouble(cylinderObject.CustomData["DeclaredLoss"]);  

            
            sapCylinder.Insulation = System.Convert.ToInt32(cylinderObject.CustomData["Insulation"]);  

            
            sapCylinder.InsulationThick  = System.Convert.ToDouble(cylinderObject.CustomData["InsulationThick "]); 

            
            sapCylinder.InHeatedSpace = System.Convert.ToBoolean(cylinderObject.CustomData["InHeatedSpace"]);  

            
            sapCylinder.Thermostat = System.Convert.ToBoolean(cylinderObject.CustomData["Thermostat"]);  

            
            sapCylinder.PipeWorkInsulated = System.Convert.ToBoolean(cylinderObject.CustomData["PipeWorkInsulated"]);  

            
            sapCylinder.PipeWorkInsulation  = System.Convert.ToInt32(cylinderObject.CustomData["PipeWorkInsulation "]); 

            
            sapCylinder.Timed = System.Convert.ToBoolean(cylinderObject.CustomData["Timed"]);  

            
            sapCylinder.SummerImmersion = System.Convert.ToBoolean(cylinderObject.CustomData["SummerImmersion"]);  

            
            sapCylinder.Immersion = System.Convert.ToInt32(cylinderObject.CustomData["Immersion"]);  

            
            sapCylinder.ImmersionHeater = System.Convert.ToBoolean(cylinderObject.CustomData["ImmersionHeater"]);  

            
            sapCylinder.HeatPumpExchanger  = System.Convert.ToDouble(cylinderObject.CustomData["HeatPumpExchanger "]); 

            
            sapCylinder.Manufacturer = (cylinderObject.CustomData["Manufacturer"] as CustomObject);  

            
            sapCylinder.Model = (cylinderObject.CustomData["Model"] as CustomObject);  

            
            sapCylinder.CommissioningCertificate  = (cylinderObject.CustomData["CommissioningCertificate "] as CustomObject); 

            return sapCylinder;
        }
    }
}
