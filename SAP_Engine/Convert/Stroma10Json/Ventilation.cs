using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.Ventilation ToVentilation(CustomObject ventilationObject)
        {
            BH.oM.Environment.SAP.Stroma10.Ventilation sapVentilation = new BH.oM.Environment.SAP.Stroma10.Ventilation();

            sapVentilation.ID = System.Convert.ToInt32(ventilationObject.CustomData["ID"]);
           

            sapVentilation.ChimneysMain = System.Convert.ToInt32(ventilationObject.CustomData["ChimneysMain"]); 

        
            sapVentilation.ChimneysSec = System.Convert.ToInt32(ventilationObject.CustomData["ChimneysSec"]);


            sapVentilation.ChimneysOther = System.Convert.ToInt32(ventilationObject.CustomData["ChimneysOther"]);


            sapVentilation.Chimneys = System.Convert.ToInt32(ventilationObject.CustomData["Chimneys"]); 

        
            sapVentilation.ChimneysClosedFire = System.Convert.ToInt32(ventilationObject.CustomData["ChimneysClosedFire"]);

        
            sapVentilation.ChimneysClosedFireMain = System.Convert.ToInt32(ventilationObject.CustomData["ChimneysClosedFireMain"]);

        
            sapVentilation.ChimneysClosedFireSec = System.Convert.ToInt32(ventilationObject.CustomData["ChimneysClosedFireSec"]); 

        
            sapVentilation.ChimneysClosedFireOther = System.Convert.ToInt32(ventilationObject.CustomData["ChimneysClosedFireOther"]); 

        
            sapVentilation.FluesSolidBoiler = System.Convert.ToInt32(ventilationObject.CustomData["FluesSolidBoiler"]); 

        
            sapVentilation.FluesSolidBoilerMain = System.Convert.ToInt32(ventilationObject.CustomData["FluesSolidBoilerMain"]); 

        
            sapVentilation.FluesSolidBoilerSec = System.Convert.ToInt32(ventilationObject.CustomData["FluesSolidBoilerSec"]); 

        
            sapVentilation.FluesSolidBoilerOther = System.Convert.ToInt32(ventilationObject.CustomData["FluesSolidBoilerOther"]); 

        
            sapVentilation.FluesOtherHeater = System.Convert.ToInt32(ventilationObject.CustomData["FluesOtherHeater"]);

        
            sapVentilation.FluesOtherHeaterMain = System.Convert.ToInt32(ventilationObject.CustomData["FluesOtherHeaterMain"]); 

        
            sapVentilation.FluesOtherHeaterSec = System.Convert.ToInt32(ventilationObject.CustomData["FluesOtherHeaterSec"]); 

        
            sapVentilation.FluesOtherHeaterOther = System.Convert.ToInt32(ventilationObject.CustomData["FluesOtherHeaterOther"]); 

        
            sapVentilation.ChimneyBlocked = System.Convert.ToInt32(ventilationObject.CustomData["ChimneyBlocked"]); 

        
            sapVentilation.FluesMain = System.Convert.ToInt32(ventilationObject.CustomData["FluesMain"]); 

        
            sapVentilation.FluesSec = System.Convert.ToInt32(ventilationObject.CustomData["FluesSec"]); 

        
            sapVentilation.FluesOther = System.Convert.ToInt32(ventilationObject.CustomData["FluesOther"]); 

        
            sapVentilation.Flues = System.Convert.ToInt32(ventilationObject.CustomData["Flues"]); 

        
            sapVentilation.Fans = System.Convert.ToInt32(ventilationObject.CustomData["Fans"]); 

        
            sapVentilation.Vents = System.Convert.ToInt32(ventilationObject.CustomData["Vents"]); 


            sapVentilation.Fires = System.Convert.ToInt32(ventilationObject.CustomData["Fires"]); 
        

            sapVentilation.Shelter = System.Convert.ToDouble(ventilationObject.CustomData["Shelter"]); 
        

            sapVentilation.MechanicalVentilation = System.Convert.ToInt32(ventilationObject.CustomData["MechanicalVentilation"]); 
        

            sapVentilation.Parameters = System.Convert.ToInt32(ventilationObject.CustomData["Parameters"]); 
        

            sapVentilation.WetRooms = System.Convert.ToInt32(ventilationObject.CustomData["WetRooms"]); 

        
            sapVentilation.DuctType = System.Convert.ToInt32(ventilationObject.CustomData["DuctType"]); 

        
            sapVentilation.DuctSpec = System.Convert.ToInt32(ventilationObject.CustomData["DuctSpec"]); 

        
            sapVentilation.SystemPosition = System.Convert.ToInt32(ventilationObject.CustomData["SystemPosition"]); 

        
            sapVentilation.ProductID = System.Convert.ToInt32(ventilationObject.CustomData["ProductID"]); 

        
            sapVentilation.ApprovedScheme = System.Convert.ToBoolean(ventilationObject.CustomData["ApprovedScheme"]);  

        
            sapVentilation.MeasuredInstallation  = System.Convert.ToBoolean(ventilationObject.CustomData["MeasuredInstallation "]); 

        
            sapVentilation.MeasuredSpecificFanPower = System.Convert.ToDouble(ventilationObject.CustomData["MeasuredSpecificFanPower"]);


            sapVentilation.DeCentralised= ToDeCentralised(ventilationObject.CustomData["DeCentralised"] as CustomObject);


            sapVentilation.MechanicalVentilationDetails = ToMechanicalVentilationDetails(ventilationObject.CustomData["MyDetails"] as CustomObject);

        
            sapVentilation.Pressure = System.Convert.ToInt32(ventilationObject.CustomData["Pressure"]); 

        
            sapVentilation.DesignAir = System.Convert.ToDouble(ventilationObject.CustomData["DesignAir"]); 

        
            sapVentilation.AssumedAir = System.Convert.ToDouble(ventilationObject.CustomData["AssumedAir"]); 

        
            sapVentilation.MeasuredAir = System.Convert.ToDouble(ventilationObject.CustomData["MeasuredAir"]); 

        
            sapVentilation.MeasuredPulse = System.Convert.ToDouble(ventilationObject.CustomData["MeasuredPulse"]); 


            sapVentilation.DateAir  = System.Convert.ToDateTime(ventilationObject.CustomData["DateAir "]);

        
            sapVentilation.AverageAirPermeability  = System.Convert.ToBoolean(ventilationObject.CustomData["AverageAirPermeability "]); 

        
            sapVentilation.ConstructType = System.Convert.ToInt32(ventilationObject.CustomData["ConstructType"]); 

        
            sapVentilation.LobbyDetail = System.Convert.ToInt32(ventilationObject.CustomData["LobbyDetail"]); 

        
            sapVentilation.FloorDetail = System.Convert.ToInt32(ventilationObject.CustomData["VentilationDetail"]); 

        
            sapVentilation.Draught = System.Convert.ToDouble(ventilationObject.CustomData["Draught"]); 

        
            sapVentilation.MultiSystem  = System.Convert.ToBoolean(ventilationObject.CustomData["MultiSystem "]); 

        
            sapVentilation.DuctPlacement = System.Convert.ToInt32(ventilationObject.CustomData["DuctPlacement"]);


            sapVentilation.ComplianceVent = ToComplianceVent(ventilationObject.CustomData["ComplianceVent"] as CustomObject);
        

            sapVentilation.PressureTestResult = System.Convert.ToDouble(ventilationObject.CustomData["PressureTestResult"]); 


            return sapVentilation;
        }
    }
}
