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
using System.Linq;
using BH.oM.Base;

namespace BH.oM.Environment.SAP
{
    [Description("Data format specification in database.")]
    public class CommunityHeatNetworksTable : BHoMObject, IPCDBObject
    {
        [Description("Unique index number for each network, assigned automatically by database software and used for control and reference purposes.")]
        public virtual string Index { get; set; } = null;

        [Description("Network version for the network identified in field 1  It is numbered from 1 upwards and incremented if the network is extended and when equipment data is amended (for example a change to a heat generator) or if the energy use information is updated.")]
        public virtual string Version { get; set; } = null;

        [Description("Date and time this record was created or last amended by the database administrator.")]
        public virtual string DBEntryUpdated { get; set; } = null;

        [Description("A short description identifying the dwellings to which the network version applies. Where the network is constructed in phases this may also indicate which phases are connected.")]
        public virtual string DescriptionOfNetwork { get; set; } = null;

        [Description("The last day of validity of this data record. Dwellings assessed after this date use a data record with a higher network version number (in the case of new dwellings the applicable assessment date is that of the as-designed assessment). Blank if there is no record with a higher network version number.")]
        public virtual string ValidityEndDate { get; set; } = null;

        [Description("The name by which the community heat network is known.")]
        public virtual string HeatNetworkName { get; set; } = null;

        [Description("The postcode of the energy centre providing heat for the network. Where there is more than one energy centre, it is the postcode for the energy centre supplying the largest amount of heat")]
        public virtual string PostcodePrimaryEnergyCentre { get; set; } = null;

        [Description("The locality in which the community heat network is situated. May be blank.")]
        public virtual string Locality { get; set; } = null;

        [Description("The post town nearest to the community heat network.")]
        public virtual string TownName { get; set; } = null;

        [Description("The administrative area in which the community heat network is situated. May be blank.")]
        public virtual string AdministrativeArea { get; set; } = null;

        [Description("The date on which the energy centre was commissioned (or re-commissioned if the network is extended) to serve all dwellings included in the assessment.Blank if it is not yet operational or if the assessment includes dwellings not yet connected.")]
        public virtual string DateInitialOperation { get; set; } = null;

        [Description("The total number of dwellings included in the assessment of the heat network.")]
        public virtual string TotalDwellingsIncluded { get; set; } = null;

        [Description("The number of flats included in the assessment of the heat network")]
        public virtual string NumberOfFlats { get; set; } = null;

        [Description("The floor area of any non-domestic buildings connected to the heat network.")]
        public virtual string NonDomesticFloorArea { get; set; } = null;

        [Description("The number of dwellings which have been constructed. This can be less than the number in field 12 if the assessment included dwellings not yet constructed.")]
        public virtual string NumberOfExistingDwellings { get; set; } = null;

        [Description("Service provision, encoded as: 1 space and water heating; 3 space heating only; 4 water heating only.If a network has separate systems for space heating and water heating, there will be a record for each.")]
        public virtual string ServiceProvision { get; set; } = null;

        [Description("Whether the record represents provisional (estimated) data or actual recorded data, encoded as 1 or 2 respectively.Provisional data may be assigned to new networks for which recorded data are not yet available.")]
        public virtual string ProvisionalOrActualData { get; set; } = null;

        [Description("The calendar year to which the data relates. Blank if provisional data.")]
        public virtual string Year { get; set; } = null;

        [Description("Whether the heat supplied to the network from the energy centre is metered. 1 for yes. 0 for no")]
        public virtual string HeatMeteringOnSupplyToNetwork { get; set; } = null;

        [Description("The annual amount of heat supplied to the network by the plant in the energy centre.")]
        public virtual string TotalMWhToNetwork { get; set; } = null;

        [Description("The annual amount of heat delivered to all customers (dwellings and non-domestic), thereby indicating the scale of the network.")]
        public virtual string TotalMWhToCustomers { get; set; } = null;

        [Description("Whether the supply of heat to each individual dwelling is metered.1 for yes, 0 for no.")]
        public virtual string IndividualDwellingHeatMetering { get; set; } = null;

        [Description("The annual amount of heat delivered to dwellings.")]
        public virtual string TotalMWhToDwellings { get; set; } = null;

        [Description("The total length of the network heat distribution pipework route. In the case of underground pipework it is the total trench length containing pipework. It includes both flow and return water pipes i.e. it is not the sum of the flow and return pipework.")]
        public virtual string DistributionRouteLength { get; set; } = null;

        [Description("The average heat loss per metre length of network heat distribution pipework route in W/m.")]
        public virtual string LinearLoss { get; set; } = null;

        [Description("Factor that allows for losses from the heat distribution network, see SAP section C3. Applicable to all connected premises.")]
        public virtual string DistrubutionLossFactor { get; set; } = null;

        [Description("Annual electrical energy for pumping in the heat distribution network in kWh/year.")]
        public virtual string PumpingElectricalEnergy { get; set; } = null;

        [Description("Annual electrical energy for pumping in the heat distribution network attributed to each dwelling, in kWh/year.")]
        public virtual string PumpingElectricalEnergyPerDwelling { get; set; } = null;

        [Description("The average carbon dioxide intensity of the heat delivered to customers. in kg/kWh. This value takes into account all factors which influence the emissions associated with the heat supplied.It is based on the heat delivered to individual dwellings, and to the building in the case of non - domestic premises.")]
        public virtual string CarbonDioxideIntensity { get; set; } = null;

        [Description("The average primary energy factor of the heat delivered to customers. This value takes into account all factors which influence the primary energy associated with the heat supplied.It is based on the heat delivered to individual dwellings, and to the building in the case of non - domestic premises.")]
        public virtual string PrimaryEnergyFactor { get; set; } = null;

        [Description("Number of separate heat sources (between 1 and 5). Heat sources are considered separate if they differ in heat source type or fuel. A set of e.g. boilers each using the same fuel are treated as one source with efficiency as defined in C2 of the SAP specification.")]
        public virtual string NumberOfHeatSources { get; set; } = null;

        [Description("Group A: Type of heat generator, encoded as 1: CHP; 2: boilers; 3: heat pump; 4: waste heat from power station; 5: geothermal.If CHP is part of the installation it is given as Group A.")]
        public virtual string HeatSourceTypeA { get; set; } = null;

        [Description("Group A: The community fuel to which the data relates, either one of community fuel codes in SAP Table 12, or 99 in the case of a fuel not in SAP Table 12.")]
        public virtual string CommunityFuelA { get; set; } = null;

        [Description("Group A: Description of the fuel in the preceding field. May be blank if field 33 is not 99.")]
        public virtual string FuelDescriptionA { get; set; } = null;

        [Description("Group A: Heat efficiency of heat source in % gross.")]
        public virtual string HeatEfficiencyA { get; set; } = null;

        [Description("Group A: Power efficiency of CHP plant in % gross. Blank if not applicable.")]
        public virtual string PowerEfficiencyA { get; set; } = null;

        [Description("Group A: The fraction of heat supplied by the community heat network attributable to the heat source.")]
        public virtual string HeatFractionA { get; set; } = null;

        [Description("Group A: The CO2  emission factor in kg/kWh for the fuel. Blank when field 33 is not 99.")]
        public virtual string CommunityFuelCO2EmissionFactorA { get; set; } = null;

        [Description("Group A: The primary energy factor for the fuel (dimensionless). Blank when field 33 is not 99.")]
        public virtual string CommunityFuelPrimaryEnergyFactorA { get; set; } = null;

        //Group B, C, D, E. Set of data in the same format as those for group A for other heat sources. n is the value in field 31.

    }
}
