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
        private List<Walls> ReadWallDefinitions(SAPConfig config)
        {
            if (config.ExcelFile == null)
            {
                BH.Engine.Base.Compute.RecordError($"Please provide a valid SAP Excel file location.");
                return new List<Walls>();
            }

            string fullFileName = config.ExcelFile.GetFullFileName();
            if (string.IsNullOrEmpty(fullFileName) || !File.Exists(fullFileName))
            {
                BH.Engine.Base.Compute.RecordError($"Could not load file from {fullFileName}. Check the file exists.");
                return new List<Walls>();
            }

            if (config.WallDefinitionsRequest == null || config.WallDefinitionsRequest.CellContentsRequest == null)
            {
                BH.Engine.Base.Compute.RecordError($"Please provide a valid Wall Definitions Request stating the worksheet and range to read from Excel for the Wall Definition objects.");
                return new List<Walls>();
            }

            ExcelAdapter excelAdapter = new ExcelAdapter(config.ExcelFile);
            List<TableRow> excelRows = excelAdapter.Pull(config.WallDefinitionsRequest.CellContentsRequest).OfType<TableRow>().ToList();

            List<Walls> wallDefinitions = new List<Walls>();

            foreach (var tableRow in excelRows)
            {
                if (tableRow.Content.Count < 5)
                    continue;

                var content = tableRow.Content.OfType<CellContents>().ToList();

                Walls wallDefinition = new Walls();
                wallDefinition.Dwelling = content[0].Value.ToString();
                wallDefinition.Storey = content[2].Value.ToString();

                var type = Enum.Parse(typeof(TypeOfWall), content[1].Value.ToString());
                if (type != null)
                    wallDefinition.Type = (TypeOfWall)type;

                try
                {
                    wallDefinition.UValue = double.Parse(content[4].Value.ToString());
                }
                catch { }

                try
                {
                    wallDefinition.CurtainWall = bool.Parse(content[3].Value.ToString());
                }
                catch { }

                wallDefinitions.Add(wallDefinition);
            }

            return wallDefinitions;
        }
    }
}
