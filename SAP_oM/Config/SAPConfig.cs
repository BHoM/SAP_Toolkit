using BH.oM.Adapter;
using BH.oM.Environment.SAP.XML;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.oM.Environment.SAP
{
    public class SAPConfig : ActionConfig
    {
        public virtual FileSettings SAPMarkupFile { get; set; } = null;
        public virtual FileSettings ExcelFile { get; set; } = null;
        public virtual string HeatingFileDirectory { get; set; } = null;
        public virtual FlatDetails FlatDetails { get; set; } = null;
        public virtual string ConstructionYear { get; set; } = "";
        public virtual TypeOfProperty PropertyType { get; set; } = TypeOfProperty.Undefined;
        public virtual DataTypeCode ConstructionType { get; set; } = DataTypeCode.Undefined;
        public virtual SAPExcelPullConfig FloorDefinitionsRequest { get; set; } = null;
        public virtual SAPExcelPullConfig RoofDefinitionsRequest { get; set; } = null;
        public virtual SAPExcelPullConfig WallDefinitionsRequest { get; set; } = null;
        public virtual SAPExcelPullConfig PsiValuesRequest { get; set; } = null;
        public virtual SAPExcelPullConfig OpeningDefinitionsRequest { get; set; } = null;
        public virtual SAPExcelPullConfig OpeningPsiValuesRequest { get; set; } = null;
        public virtual SAPExcelPullConfig DwellingSchedulesRequest { get; set; } = null;
    }
}
