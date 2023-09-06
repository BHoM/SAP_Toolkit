using BH.oM.Adapter;
using BH.oM.Adapters.Excel;
using BH.oM.Environment.SAP.XML;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.oM.Environment.SAP
{
    public class ArgyleConfig : ActionConfig
    {
        public virtual string OutputDirectory { get; set; } = null;
    }
}
