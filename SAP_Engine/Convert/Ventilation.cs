/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2022, the respective contributors. All rights reserved.
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using BH.oM.Base.Attributes;

namespace BH.Engine.Environment.SAP
{
    public static partial class Convert
    {
        [Description("Convert SAP ventilation to XML ventilation.")]
        [Input("sapVentilation", "SAP ventilation to convert.")]
        [Output("xmlVentilation", "XML ventilation.")]
        public static BH.oM.Environment.SAP.XML.Ventilation ToXML(this BH.oM.Environment.SAP.Ventilation sapVentilation)
        {
            BH.oM.Environment.SAP.XML.Ventilation xmlVentilation = new BH.oM.Environment.SAP.XML.Ventilation();

            xmlVentilation.numOpenFireplaces = sapVentilation.VentilationRates.OpenFireplaces;
            xmlVentilation.numOpenFlues = sapVentilation.VentilationRates.OpenFlues;
            xmlVentilation.numFluelessGasFires = sapVentilation.VentilationRates.FluelessGasFires;
            xmlVentilation.PressureTest = sapVentilation.AirPermability.PressureTest.FromSAPToXML();
            xmlVentilation.AirPermability = sapVentilation.AirPermability.DesignAirPermability;
            xmlVentilation.numShelteredSides = sapVentilation.numShelteredSides;
            xmlVentilation.Type = sapVentilation.VentilationStrategy.Type.FromSAPToXML();
            xmlVentilation.MechanicalVentilationDataSource = sapVentilation.VentilationStrategy.DetailsTakenFrom.FromSAPToXML();
            xmlVentilation.MechanicalVentSystemIndexNumber = sapVentilation.VentilationStrategy.MechVentSystemIndexNumber;
            xmlVentilation.MechanicalVentSystemMakeModel = sapVentilation.VentilationStrategy.MechVentDetails.SystemMakeModel;
            xmlVentilation.numWetRooms = sapVentilation.VentilationStrategy.numWetRooms;
            xmlVentilation.MechanicalVentSpecificFanPower = sapVentilation.VentilationStrategy.MechVentDetails.SpecificFanPower;
            xmlVentilation.MechanicalVentHeatRecoveryEfficiency = sapVentilation.VentilationStrategy.MechVentDetails.HeatRecoveryEfficiency;
            xmlVentilation.MechanicalVentDuctType = sapVentilation.VentilationStrategy.MechVentDetails.DuctType.FromSAPToXML();
            xmlVentilation.MechanicalVentDuctInsulation = sapVentilation.VentilationStrategy.DuctInsulationType.FromSAPToXML();
            xmlVentilation.ExtractFansCount = sapVentilation.VentilationRates.FansCount;
            xmlVentilation.PSVCount = sapVentilation.VentilationRates.PSVCount;
            xmlVentilation.IsMechanicalVentApprovedInstallerScheme = sapVentilation.VentilationStrategy.ApprovedInstallation;
            xmlVentilation.MechanicalVentDuctsIndexNumber = sapVentilation.VentilationStrategy.MechVentSystemIndexNumber;

            return xmlVentilation;
        }

        private static string FromSAPToXML(this BH.oM.Environment.SAP.PressureTestCode? pressureTestCode)
        {
            switch (pressureTestCode)
            {
                case BH.oM.Environment.SAP.PressureTestCode.YesMeasured:
                    return "1";

                case BH.oM.Environment.SAP.PressureTestCode.YesDesignValue:
                    return "2";

                case BH.oM.Environment.SAP.PressureTestCode.NoAssumedForCalc:
                    return "3";

                case BH.oM.Environment.SAP.PressureTestCode.ExisitingDwellingSAPAlgorithm:
                    return "4";

                case BH.oM.Environment.SAP.PressureTestCode.NewDwellingAverage:
                    return "5";

                case BH.oM.Environment.SAP.PressureTestCode.YesExistingDwelling:
                    return "6";

                default:
                    return "";
            }
        }

        private static string FromSAPToXML(this BH.oM.Environment.SAP.TypeOfVentilation? typeOfVentilation)
        {
            switch (typeOfVentilation)
            {
                case BH.oM.Environment.SAP.TypeOfVentilation.NaturalIntermittentExtractFans:
                    return "1";

                case BH.oM.Environment.SAP.TypeOfVentilation.NaturalPassiveVents:
                    return "2";

                case BH.oM.Environment.SAP.TypeOfVentilation.PositiveInputFromLoft:
                    return "3";

                case BH.oM.Environment.SAP.TypeOfVentilation.PositiveInputFromOutside:
                    return "4";

                case BH.oM.Environment.SAP.TypeOfVentilation.MEVc:
                    return "5";

                case BH.oM.Environment.SAP.TypeOfVentilation.MEVdc:
                    return "6";

                case BH.oM.Environment.SAP.TypeOfVentilation.MV:
                    return "7";

                case BH.oM.Environment.SAP.TypeOfVentilation.MVHR:
                    return "8";

                case BH.oM.Environment.SAP.TypeOfVentilation.NaturalIntermittentExtractFansAndPassiveVents:
                    return "10";

                default:
                    return "";
            }
        }

        private static string FromSAPToXML(this BH.oM.Environment.SAP.VentilationDataSource? dataSource)
        {
            switch (dataSource)
            {
                case BH.oM.Environment.SAP.VentilationDataSource.FromDatabase:
                    return "1";

                case BH.oM.Environment.SAP.VentilationDataSource.ManufacturerDeclaration:
                    return "2";

                case BH.oM.Environment.SAP.VentilationDataSource.SAPTable:
                    return "3";

                default:
                    return "";
            }
        }

        private static string FromSAPToXML(this BH.oM.Environment.SAP.TypeofDuct? typeofDuct)
        {
            switch (typeofDuct)
            {
                case BH.oM.Environment.SAP.TypeofDuct.Flexible:
                    return "1";

                case BH.oM.Environment.SAP.TypeofDuct.Rigid:
                    return "2";

                case BH.oM.Environment.SAP.TypeofDuct.SemiRigid:
                    return "3";

                default:
                    return "";
            }
        }

        private static string FromSAPToXML(this BH.oM.Environment.SAP.TypeofDuctInsulation? ductInsulation)
        {
            switch (ductInsulation)
            {
                case BH.oM.Environment.SAP.TypeofDuctInsulation.NotInsulated:
                    return "1";

                case BH.oM.Environment.SAP.TypeofDuctInsulation.Insulated:
                    return "2";

                default:
                    return "";
            }
        }
    }
}
