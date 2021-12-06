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
        public virtual string APIKey { get; set; }
        public virtual string PostURL { get; set; }
    }
}
