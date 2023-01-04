/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2023, the respective contributors. All rights reserved.
 *
 * Each contributor holds copyright over their respective contributions.
 * The project versioning (Git) records all such contribution source information.
 *                                           
 *                                                                              
 * The BHoM is free software: you can redistribute it and/or modify         
 * it under the terms of the GNU Lesser General Public License as published by  
 * the Free Software Foundation, either version 3.0 of the License, or          
 * (at your option) any later version.                                          
 *                                                                              
 * The BHoM is distributed in the hope that it will be useful,              
 * but WITHOUT ANY WARRANTY; without even the implied warranty of               
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
 * GNU Lesser General Public License for more details.                          
 *                                                                            
 * You should have received a copy of the GNU Lesser General Public License     
 * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
 */
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
        public static List<BH.oM.Environment.SAP.Stroma10.Ventilation> ToVentilations(List<CustomObject> ventilationsObject)
        {
            if (ventilationsObject == null)
                return null;
            List<BH.oM.Environment.SAP.Stroma10.Ventilation> rtn = new List<BH.oM.Environment.SAP.Stroma10.Ventilation>();
            foreach (var value in ventilationsObject)
            {
                rtn.Add(ToVentilation(value));
            }

            return rtn;
        }

        public static BH.oM.Environment.SAP.Stroma10.Ventilation ToVentilation(CustomObject ventilationObject)
        {
            BH.oM.Environment.SAP.Stroma10.Ventilation sapVentilation = new BH.oM.Environment.SAP.Stroma10.Ventilation();
            if (ventilationObject == null)
                return null;
            sapVentilation.ID = System.Convert.ToInt32(ventilationObject.CustomData["Id"]);
            sapVentilation.ChimneysMain = System.Convert.ToInt32(ventilationObject.CustomData["ChimneysMain"]);
            sapVentilation.ChimneysSecondary = System.Convert.ToInt32(ventilationObject.CustomData["ChimneysSec"]);
            sapVentilation.ChimneysOther = System.Convert.ToInt32(ventilationObject.CustomData["ChimneysOther"]);
            sapVentilation.Chimneys = System.Convert.ToInt32(ventilationObject.CustomData["Chimneys"]);
            sapVentilation.ChimneysClosedFire = System.Convert.ToInt32(ventilationObject.CustomData["ChimneysClosedFire"]);
            sapVentilation.ChimneysClosedFireMain = System.Convert.ToInt32(ventilationObject.CustomData["ChimneysClosedFireMain"]);
            sapVentilation.ChimneysClosedFireSecondary = System.Convert.ToInt32(ventilationObject.CustomData["ChimneysClosedFireSec"]);
            sapVentilation.ChimneysClosedFireOther = System.Convert.ToInt32(ventilationObject.CustomData["ChimneysClosedFireOther"]);
            sapVentilation.FluesSolidBoiler = System.Convert.ToInt32(ventilationObject.CustomData["FluesSolidBoiler"]);
            sapVentilation.FluesSolidBoilerMain = System.Convert.ToInt32(ventilationObject.CustomData["FluesSolidBoilerMain"]);
            sapVentilation.FluesSolidBoilerSecondary = System.Convert.ToInt32(ventilationObject.CustomData["FluesSolidBoilerSec"]);
            sapVentilation.FluesSolidBoilerOther = System.Convert.ToInt32(ventilationObject.CustomData["FluesSolidBoilerOther"]);
            sapVentilation.FluesOtherHeater = System.Convert.ToInt32(ventilationObject.CustomData["FluesOtherHeater"]);
            sapVentilation.FluesOtherHeaterMain = System.Convert.ToInt32(ventilationObject.CustomData["FluesOtherHeaterMain"]);
            sapVentilation.FluesOtherHeaterSecondary = System.Convert.ToInt32(ventilationObject.CustomData["FluesOtherHeaterSec"]);
            sapVentilation.FluesOtherHeaterOther = System.Convert.ToInt32(ventilationObject.CustomData["FluesOtherHeaterOther"]);
            sapVentilation.ChimneyBlocked = System.Convert.ToInt32(ventilationObject.CustomData["ChimneyBlocked"]);
            sapVentilation.FluesMain = System.Convert.ToInt32(ventilationObject.CustomData["FluesMain"]);
            sapVentilation.FluesSecondary = System.Convert.ToInt32(ventilationObject.CustomData["FluesSec"]);
            sapVentilation.FluesOther = System.Convert.ToInt32(ventilationObject.CustomData["FluesOther"]);
            sapVentilation.Flues = System.Convert.ToInt32(ventilationObject.CustomData["Flues"]);
            sapVentilation.Fans = System.Convert.ToInt32(ventilationObject.CustomData["Fans"]);
            sapVentilation.Vents = System.Convert.ToInt32(ventilationObject.CustomData["Vents"]);
            sapVentilation.Fires = System.Convert.ToInt32(ventilationObject.CustomData["Fires"]);
            sapVentilation.Shelter = System.Convert.ToDouble(ventilationObject.CustomData["Shelter"]);
            sapVentilation.MechanicalVentilation = System.Convert.ToInt32(ventilationObject.CustomData["MechVent"]);
            sapVentilation.Parameters = System.Convert.ToInt32(ventilationObject.CustomData["Parameters"]);
            sapVentilation.WetRooms = System.Convert.ToInt32(ventilationObject.CustomData["WetRooms"]);
            sapVentilation.DuctType = System.Convert.ToInt32(ventilationObject.CustomData["DuctType"]);
            sapVentilation.DuctSpecification = System.Convert.ToInt32(ventilationObject.CustomData["DuctSpec"]);
            sapVentilation.SystemPosition = System.Convert.ToInt32(ventilationObject.CustomData["SystemPosition"]);
            sapVentilation.ProductID = System.Convert.ToInt32(ventilationObject.CustomData["ProductId"]);
            sapVentilation.ApprovedScheme = System.Convert.ToBoolean(ventilationObject.CustomData["ApprovedScheme"]);
            sapVentilation.MeasuredInstallation = System.Convert.ToBoolean(ventilationObject.CustomData["MeasuredInstallation"]);
            sapVentilation.MeasuredSpecificFanPower = System.Convert.ToDouble(ventilationObject.CustomData["MeasuredSfp"]);
            sapVentilation.DeCentralised = ToDeCentralised(ventilationObject.CustomData["DeCentralised"] as CustomObject);
            sapVentilation.MechanicalVentilationDetails = ToMechanicalVentilationDetails(ventilationObject.CustomData["MvDetails"] as CustomObject);
            sapVentilation.Pressure = System.Convert.ToInt32(ventilationObject.CustomData["Pressure"]);
            sapVentilation.DesignAir = System.Convert.ToDouble(ventilationObject.CustomData["DesignAir"]);
            sapVentilation.AssumedAir = System.Convert.ToDouble(ventilationObject.CustomData["AssumedAir"]);
            sapVentilation.MeasuredAir = System.Convert.ToDouble(ventilationObject.CustomData["MeasuredAir"]);
            sapVentilation.MeasuredPulse = System.Convert.ToDouble(ventilationObject.CustomData["MeasuredPulse"]);
            sapVentilation.DateAir = System.Convert.ToDateTime(ventilationObject.CustomData["DateAir"]);
            sapVentilation.AverageAirPermeability = System.Convert.ToBoolean(ventilationObject.CustomData["AveragePerm"]);
            sapVentilation.ConstructType = System.Convert.ToInt32(ventilationObject.CustomData["ConstructType"]);
            sapVentilation.LobbyDetail = System.Convert.ToInt32(ventilationObject.CustomData["LobbyDetail"]);
            sapVentilation.FloorDetail = System.Convert.ToInt32(ventilationObject.CustomData["FloorDetail"]);
            sapVentilation.Draught = System.Convert.ToDouble(ventilationObject.CustomData["Draught"]);
            sapVentilation.MultiSystem = System.Convert.ToBoolean(ventilationObject.CustomData["MultiSystem"]);
            sapVentilation.DuctPlacement = System.Convert.ToInt32(ventilationObject.CustomData["DuctPlacement"]);
            sapVentilation.ComplianceVent = ToComplianceVent(ventilationObject.CustomData["ComplianceVent"] as CustomObject);
            sapVentilation.PressureTestResult = System.Convert.ToDouble(ventilationObject.CustomData["PressureTestResult"]);
            return sapVentilation;
        }

        public static Dictionary<string, object> FromVentilation(Ventilation obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();
            if (obj == null)
                return null;
            rtn.Add("Id", obj.ID);
            rtn.Add("ChimneysMain", obj.ChimneysMain);
            rtn.Add("ChimneysSec", obj.ChimneysSecondary);
            rtn.Add("ChimneysOther", obj.ChimneysOther);
            rtn.Add("Chimneys", obj.Chimneys);
            rtn.Add("ChimneysClosedFire", obj.ChimneysClosedFire);
            rtn.Add("ChimneysClosedFireMain", obj.ChimneysClosedFireMain);
            rtn.Add("ChimneysClosedFireSec", obj.ChimneysClosedFireSecondary);
            rtn.Add("ChimneysClosedFireOther", obj.ChimneysClosedFireOther);
            rtn.Add("FluesSolidBoiler", obj.FluesSolidBoiler);
            rtn.Add("FluesSolidBoilerMain", obj.FluesSolidBoilerMain);
            rtn.Add("FluesSolidBoilerSec", obj.FluesSolidBoilerSecondary);
            rtn.Add("FluesSolidBoilerOther", obj.FluesSolidBoilerOther);
            rtn.Add("FluesOtherHeater", obj.FluesOtherHeater);
            rtn.Add("FluesOtherHeaterMain", obj.FluesOtherHeaterMain);
            rtn.Add("FluesOtherHeaterSec", obj.FluesOtherHeaterSecondary);
            rtn.Add("FluesOtherHeaterOther", obj.FluesOtherHeaterOther);
            rtn.Add("ChimneyBlocked", obj.ChimneyBlocked);
            rtn.Add("FluesMain", obj.FluesMain);
            rtn.Add("FluesSec", obj.FluesSecondary);
            rtn.Add("FluesOther", obj.FluesOther);
            rtn.Add("Flues", obj.Flues);
            rtn.Add("Fans", obj.Fans);
            rtn.Add("Vents", obj.Vents);
            rtn.Add("Fires", obj.Fires);
            rtn.Add("Shelter", obj.Shelter);
            rtn.Add("MechVent", obj.MechanicalVentilation);
            rtn.Add("Parameters", obj.Parameters);
            rtn.Add("WetRooms", obj.WetRooms);
            rtn.Add("DuctType", obj.DuctType);
            rtn.Add("DuctSpec", obj.DuctSpecification);
            rtn.Add("SystemPosition", obj.SystemPosition);
            rtn.Add("ProductId", obj.ProductID);
            rtn.Add("ApprovedScheme", obj.ApprovedScheme);
            rtn.Add("MeasuredInstallation", obj.MeasuredInstallation);
            rtn.Add("MeasuredSfp", obj.MeasuredSpecificFanPower);
            if (obj.DeCentralised == null)
                obj.DeCentralised = new BH.oM.Environment.SAP.Stroma10.DeCentralised();
            rtn.Add("DeCentralised", FromDeCentralised(obj.DeCentralised));
            if (obj.MechanicalVentilationDetails == null)
                obj.MechanicalVentilationDetails = new BH.oM.Environment.SAP.Stroma10.MechanicalVentilationDetails();
            rtn.Add("MvDetails", FromMechanicalVentilationDetails(obj.MechanicalVentilationDetails));
            rtn.Add("Pressure", obj.Pressure);
            rtn.Add("DesignAir", obj.DesignAir);
            rtn.Add("AssumedAir", obj.AssumedAir);
            rtn.Add("MeasuredAir", obj.MeasuredAir);
            rtn.Add("MeasuredPulse", obj.MeasuredPulse);
            rtn.Add("DateAir", obj.DateAir.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"));
            rtn.Add("AveragePerm", obj.AverageAirPermeability);
            rtn.Add("ConstructType", obj.ConstructType);
            rtn.Add("LobbyDetail", obj.LobbyDetail);
            rtn.Add("FloorDetail", obj.FloorDetail);
            rtn.Add("Draught", obj.Draught);
            rtn.Add("MultiSystem", obj.MultiSystem);
            rtn.Add("DuctPlacement", obj.DuctPlacement);
            if (obj.ComplianceVent == null)
                obj.ComplianceVent = new BH.oM.Environment.SAP.Stroma10.ComplianceVent();
            rtn.Add("ComplianceVent", FromComplianceVent(obj.ComplianceVent));
            rtn.Add("PressureTestResult", obj.PressureTestResult);
            return rtn;
        }
    }
}
