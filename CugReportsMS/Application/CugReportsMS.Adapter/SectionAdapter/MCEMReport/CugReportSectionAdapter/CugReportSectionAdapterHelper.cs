using System;

namespace ReportingFramework.SectionAdapter.MCEMReport.CugReportSectionAdapter
{
    public class CugReportSectionAdapterHelper : ISectionAdapterWithVersionHelper
    {
        public SectionAdapter GetSectionAdapter(double sectionVersion)
        {
            switch (sectionVersion)
            {
                case 0.1:
                    return new CugReportSectionAdapterV0_1();
                default:
                    throw new Exception();
            }
        }
    }
}