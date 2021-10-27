using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Reflection;
using BH.oM.Adapter;
using BH.oM.Environment.SAP;

namespace BH.Adapter.SAP
{
    public partial class SAPAdapter
    {
        public override Output<List<object>, bool> Execute(IExecuteCommand command, ActionConfig actionConfig = null)
        {
            var output = new Output<List<object>, bool>() { Item1 = null, Item2 = false };

            output.Item2 = RunCommand(command as dynamic);

            return output;
        }

        public bool RunCommand(RunAnalysisCommand command)
        {
            return true;
        }
    }
}
