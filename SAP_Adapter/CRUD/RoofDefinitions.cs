using BH.Engine.Adapter;
using BH.oM.Base;
using BH.oM.Environment.SAP;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using BH.oM.Adapters.Excel;
using BH.Adapter.Excel;
using System.Linq;
using BH.oM.Environment.SAP.Excel;

namespace BH.Adapter.SAP
{
    public partial class SAPAdapter
    {
        private List<Roofs> ReadRoofDefinitions(SAPConfig config)
        {
            if (config.ExcelFile == null)
            {
                BH.Engine.Base.Compute.RecordError($"Please provide a valid SAP Excel file location.");
                return new List<Roofs>();
            }

            string fullFileName = config.ExcelFile.GetFullFileName();
            if (string.IsNullOrEmpty(fullFileName) || !File.Exists(fullFileName))
            {
                BH.Engine.Base.Compute.RecordError($"Could not load file from {fullFileName}. Check the file exists.");
                return new List<Roofs>();
            }

            if (config.RoofDefinitionsRequest == null)
            {
                BH.Engine.Base.Compute.RecordError($"Please provide a valid Roof Definitions Request stating the worksheet and range to read from Excel for the Roof Definition objects.");
                return new List<Roofs>();
            }

            ExcelAdapter excelAdapter = new ExcelAdapter(config.ExcelFile);
            List<TableRow> excelRows = excelAdapter.Pull(config.RoofDefinitionsRequest).OfType<TableRow>().ToList();

            List<Roofs> roofDefinitions = new List<Roofs>();

            foreach (var tableRow in excelRows)
            {
                if (tableRow.Content.Count < 4)
                    continue;

                var content = tableRow.Content.OfType<CellContents>().ToList();

                Roofs roofDefinition = new Roofs();
                roofDefinition.Dwelling = content[0].Value.ToString();
                roofDefinition.Storey = content[2].Value.ToString();

                var type = Enum.Parse(typeof(TypeOfRoof), content[1].Value.ToString());
                if (type != null)
                    roofDefinition.Type = (TypeOfRoof)type;

                try
                {
                    roofDefinition.UValue = double.Parse(content[3].Value.ToString());
                }
                catch
                {

                }

                roofDefinitions.Add(roofDefinition);
            }

            return roofDefinitions;
        }
    }
}
