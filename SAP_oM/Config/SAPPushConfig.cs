using BH.oM.Adapter;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.oM.Environment.SAP
{
    public class SAPPushConfig : ActionConfig
    {
        public virtual string OutputDirectory { get; set; } = null;
    }
}
