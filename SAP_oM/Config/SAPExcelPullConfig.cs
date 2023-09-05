using System;
using System.Collections.Generic;
using System.Text;
using BH.oM.Adapters.Excel;
using BH.oM.Base;

namespace BH.oM.Environment.SAP
{
    public class SAPExcelPullConfig : BHoMObject
    {
        public virtual CellContentsRequest CellContentsRequest { get; set; } = null;
    }
}
