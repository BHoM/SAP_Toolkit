using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Adapter;
using BH.oM.Base;

namespace BH.oM.Environment.SAP
{
    public class RunAnalysisCommand : IExecuteCommand, IObject
    {
        public virtual string InputFile { get; set; }
        //public virtual string PostURL { get; set; } = "https://ace.argylesoftware.co.uk/buroh/v2/sap-fullsapworksheet-lig-in-text-out";
        public virtual string APIKey { get; set; }
    }
}
