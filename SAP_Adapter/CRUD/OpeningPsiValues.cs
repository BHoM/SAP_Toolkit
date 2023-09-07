﻿using BH.Engine.Adapter;
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
        private List<OpeningPsiValues> ReadOpeningPsiValues(SAPPullConfig config)
        {
            if (config.ExcelFile == null)
            {
                BH.Engine.Base.Compute.RecordError($"Please provide a valid SAP Excel file location.");
                return new List<OpeningPsiValues>();
            }

            string fullFileName = config.ExcelFile.GetFullFileName();
            if (string.IsNullOrEmpty(fullFileName) || !File.Exists(fullFileName))
            {
                BH.Engine.Base.Compute.RecordError($"Could not load file from {fullFileName}. Check the file exists.");
                return new List<OpeningPsiValues>();
            }

            if (config.OpeningPsiValuesRequest == null)
            {
                BH.Engine.Base.Compute.RecordError($"Please provide a valid Opening Psi Values Request stating the worksheet and range to read from Excel for the Opening Psi Values objects.");
                return new List<OpeningPsiValues>();
            }

            ExcelAdapter excelAdapter = new ExcelAdapter(config.ExcelFile);
            List<TableRow> excelRows = excelAdapter.Pull(config.OpeningPsiValuesRequest).OfType<TableRow>().ToList();

            List<OpeningPsiValues> openingPsiValues = new List<OpeningPsiValues>();

            foreach (var tableRow in excelRows)
            {
                if (tableRow.Content.Count < 1)
                    continue;

                var content = tableRow.Content.OfType<CellContents>().ToList();

                OpeningPsiValues openingPsiValue = new OpeningPsiValues();
                openingPsiValue.OpeningType = content[0].Value.ToString();

                try
                {
                    openingPsiValue.FloorIntersection = bool.Parse(content[1].Value.ToString());
                }
                catch { }

                PsiValues psiValue = new PsiValues();
                psiValue.Type = content[1].Value.ToString();
                psiValue.ThermalBridgeName = content[1].Value.ToString();

                try
                {
                    psiValue.PsiValue = double.Parse(content[2].Value.ToString());
                }
                catch { }

                openingPsiValue.PsiValues.Add(psiValue);

                openingPsiValues.Add(openingPsiValue);
            }

            //Group the psiValues by the Opening Type
            var uniqueOpenings = openingPsiValues.Select(x => x.OpeningType).Distinct().ToList();

            List<OpeningPsiValues> groupedPsiValues = new List<OpeningPsiValues>();

            foreach(var opening in uniqueOpenings)
            {
                OpeningPsiValues openingPsiValue = new OpeningPsiValues();
                openingPsiValue.OpeningType = opening;

                var psiValues = openingPsiValues.Where(x => x.OpeningType == opening).SelectMany(x => x.PsiValues).ToList();
                openingPsiValue.PsiValues = psiValues;

                var floorIntersection = openingPsiValues.Where(x => x.OpeningType == opening).Select(x => x.FloorIntersection).ToList();
                openingPsiValue.FloorIntersection = floorIntersection.Any(x => x);

                groupedPsiValues.Add(openingPsiValue);
            }

            return groupedPsiValues;
        }
    }
}