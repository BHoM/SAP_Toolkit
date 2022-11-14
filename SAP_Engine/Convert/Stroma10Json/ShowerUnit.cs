using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

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

            sapShowerUnit.Name = showerUnitObject.Name;


            sapShowerUnit.Type = System.Convert.ToInt32(showerUnitObject.CustomData["Type"]);


            sapShowerUnit.ShowerWasteWaterHeatRecoverySystem = System.Convert.ToInt32(showerUnitObject.CustomData["ShowerWwhrs"]);


            sapShowerUnit.OverRide = System.Convert.ToBoolean(showerUnitObject.CustomData["OverRide"]);


            sapShowerUnit.Flow = System.Convert.ToDouble(showerUnitObject.CustomData["Flow"]);


            sapShowerUnit.Power = System.Convert.ToDouble(showerUnitObject.CustomData["Power"]);

            return sapShowerUnit;
        }
        public static Dictionary<string, object> FromShowerUnit(ShowerUnit obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();

            rtn.Add("Id", obj.ID);
            rtn.Add("Guid", obj.BHoM_Guid.ToString());
            rtn.Add("Name", obj.Name);
            rtn.Add("Type", obj.Type);
            rtn.Add("ShowerWwhrs", obj.ShowerWasteWaterHeatRecoverySystem);
            rtn.Add("OverRide", obj.OverRide);
            rtn.Add("Flow", obj.Flow);
            rtn.Add("Power", obj.Power);


            return rtn;
        }
    }
}
