using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static List<BH.oM.Environment.SAP.Stroma10.ShowerUnit> ToShowerUnits(CustomObject showerUnitsObject)
        {
            if (showerUnitsObject == null)
                return null;

            List<BH.oM.Environment.SAP.Stroma10.ShowerUnit> rtn = new List<BH.oM.Environment.SAP.Stroma10.ShowerUnit>();
            foreach (var value in showerUnitsObject.CustomData["ShowerUnits"] as List<CustomObject>)
            {
                rtn.Add(ToShowerUnit(value));
            }
            return rtn;
        }
        public static BH.oM.Environment.SAP.Stroma10.ShowerUnit ToShowerUnit(CustomObject showerUnitObject)
        {
            BH.oM.Environment.SAP.Stroma10.ShowerUnit sapShowerUnit = new BH.oM.Environment.SAP.Stroma10.ShowerUnit();

            if (showerUnitObject == null)
                return null;

            sapShowerUnit.ID = System.Convert.ToInt32(showerUnitObject.CustomData["Id"]);


            sapShowerUnit.BHoM_Guid = (Guid.Parse(showerUnitObject.CustomData["Guid"] as string));


            sapShowerUnit.Type = System.Convert.ToInt32(showerUnitObject.CustomData["Type"]);


            sapShowerUnit.ShowerWasteWaterHeatRecoverySystem = System.Convert.ToInt32(showerUnitObject.CustomData["ShowerWwhrs"]);


            sapShowerUnit.OverRide = System.Convert.ToBoolean(showerUnitObject.CustomData["OverRide"]);


            sapShowerUnit.Flow = System.Convert.ToDouble(showerUnitObject.CustomData["Flow"]);


            sapShowerUnit.Power = System.Convert.ToDouble(showerUnitObject.CustomData["Power"]);

            return sapShowerUnit;
        }
    }
}
