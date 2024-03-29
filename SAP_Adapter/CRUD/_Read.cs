/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2024, the respective contributors. All rights reserved.
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

using BH.oM.Adapter;
using BH.oM.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using BH.Engine.Adapter;
using System.Runtime;
using BH.oM.Environment.SAP;
using BH.oM.Environment.SAP.Bluebeam;
using BH.oM.Environment.SAP.Excel;
using SXML = BH.oM.Environment.SAP.XML;

namespace BH.Adapter.SAP
{
    public partial class SAPAdapter : BHoMAdapter
    {
        protected override IEnumerable<IBHoMObject> IRead(Type type, IList ids, ActionConfig actionConfig = null)
        {
            ISAPPullConfig pullConfig = (ISAPPullConfig)actionConfig;
            if(pullConfig == null && type != typeof(SXML.SAPReport))
            {
                //If no config and not asking for a SAP Report...
                BH.Engine.Base.Compute.RecordError($"Config provided is not a valid SAP Pull Config for pulling objects of type {type.FullName}. Please provide a valid SAP Pull Config for this type to use SAP Adapter.");
                return new List<IBHoMObject>();
            }

            if(type == typeof(SXML.SAPReport))
            {
                SAPMarkUpPullConfig config = (SAPMarkUpPullConfig)pullConfig;

                if (config != null)
                    return ReadSAPReport(config);
                else
                {
                    SAPReportPullConfig reportConfig = (SAPReportPullConfig)pullConfig;
                    if (reportConfig != null)
                        return ReadSAPReport(reportConfig);
                }
            }
            else
            {
                SAPMarkUpPullConfig config = (SAPMarkUpPullConfig)pullConfig;
                if(config == null)
                {
                    BH.Engine.Base.Compute.RecordError($"Config provided is not a valid SAP Mark Up Pull Config for pulling objects of type {type.FullName}. Please provide a valid SAP Pull Config for this type to use SAP Adapter.");
                    return new List<IBHoMObject>();
                }

                if (type == typeof(SAPMarkupSummary))
                    return ReadSAPMarkupSummary(config);
                else if (type == typeof(FloorSchedule))
                    return ReadFloorDefinitions(config);
                else if (type == typeof(RoofSchedule))
                    return ReadRoofDefinitions(config);
                else if (type == typeof(WallSchedule))
                    return ReadWallDefinitions(config);
                else if (type == typeof(PsiValueSchedule))
                    return ReadPsiValues(config);
                else if (type == typeof(OpeningSchedule))
                    return ReadOpeningDefinitions(config);
                else if (type == typeof(OpeningPsiValueSchedule))
                    return ReadOpeningPsiValues(config);
                else if (type == typeof(DwellingSchedule))
                    return ReadDwellingSchedules(config);
            }
            return null;
        }
    }
}

