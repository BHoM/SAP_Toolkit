using BH.Adapter;
using System;

namespace BH.Adapter.SAP
{
    public partial class SAPAdapter : BHoMAdapter
    {
        public SAPAdapter()
        {
            m_AdapterSettings.UseAdapterId = false;
        }
    }
}
