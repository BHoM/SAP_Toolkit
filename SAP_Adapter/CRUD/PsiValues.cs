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
        private List<PsiValues> ReadPsiValues(SAPConfig config)
        {
            if (config.ExcelFile == null)
            {
                BH.Engine.Base.Compute.RecordError($"Please provide a valid SAP Excel file location.");
                return new List<PsiValues>();
            }

            string fullFileName = config.ExcelFile.GetFullFileName();
            if (string.IsNullOrEmpty(fullFileName) || !File.Exists(fullFileName))
            {
                BH.Engine.Base.Compute.RecordError($"Could not load file from {fullFileName}. Check the file exists.");
                return new List<PsiValues>();
            }

            if (config.PsiValuesRequest == null || config.PsiValuesRequest.CellContentsRequest == null)
            {
                BH.Engine.Base.Compute.RecordError($"Please provide a valid Psi Values Request stating the worksheet and range to read from Excel for the Psi Value objects.");
                return new List<PsiValues>();
            }

            ExcelAdapter excelAdapter = new ExcelAdapter(config.ExcelFile);
            List<TableRow> excelRows = excelAdapter.Pull(config.PsiValuesRequest.CellContentsRequest).OfType<TableRow>().ToList();

            List<PsiValues> psiValues = new List<PsiValues>();

            foreach (var tableRow in excelRows)
            {
                if (tableRow.Content.Count < 3)
                    return null;

                PsiValues psiValue = new PsiValues();
                psiValue.Type = tableRow.Content[0].ToString();
                psiValue.ThermalBridgeName = tableRow.Content[1].ToString();

                try
                {
                    psiValue.PsiValue = double.Parse(tableRow.Content[2].ToString());
                }
                catch { }

                psiValues.Add(psiValue);
            }

            return psiValues;
        }
    }
}
