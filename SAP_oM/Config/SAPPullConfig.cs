using BH.oM.Adapter;
using BH.oM.Adapters.Excel;
using BH.oM.Environment.SAP.XML;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.oM.Environment.SAP
{
    public class SAPPullConfig : ActionConfig
    {
        public virtual FileSettings SAPMarkupFile { get; set; } = null;
        public virtual FileSettings ExcelFile { get; set; } = null;
        public virtual string HeatingFileDirectory { get; set; } = null;
        public virtual FlatDetails FlatDetails { get; set; } = null;
        public virtual string ConstructionYear { get; set; } = "";
        public virtual TypeOfProperty PropertyType { get; set; } = TypeOfProperty.Undefined;
        public virtual DataTypeCode ConstructionType { get; set; } = DataTypeCode.Undefined;
        public virtual CellContentsRequest FloorDefinitionsRequest { get; set; } = null;
        public virtual CellContentsRequest RoofDefinitionsRequest { get; set; } = null;
        public virtual CellContentsRequest WallDefinitionsRequest { get; set; } = null;
        public virtual CellContentsRequest PsiValuesRequest { get; set; } = null;
        public virtual CellContentsRequest OpeningDefinitionsRequest { get; set; } = null;
        public virtual CellContentsRequest OpeningPsiValuesRequest { get; set; } = null;
        public virtual CellContentsRequest DwellingSchedulesRequest { get; set; } = null;
    }
}
