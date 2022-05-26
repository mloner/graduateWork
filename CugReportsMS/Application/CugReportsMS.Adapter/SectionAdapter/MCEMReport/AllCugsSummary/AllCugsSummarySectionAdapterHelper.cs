using System;

namespace ReportingFramework.SectionAdapter.MCEMReport.AllCugsSummary
{
    public class AllCugsSummarySectionAdapterHelper : ISectionAdapterWithVersionHelper
    {
        public SectionAdapter GetSectionAdapter(double sectionVersion)
        {
            switch (sectionVersion)
            {
                case 0.1:
                    return new AllCugsSummarySectionAdapterV0_1();
                default:
                    throw new Exception();
            }
        }
    }
}