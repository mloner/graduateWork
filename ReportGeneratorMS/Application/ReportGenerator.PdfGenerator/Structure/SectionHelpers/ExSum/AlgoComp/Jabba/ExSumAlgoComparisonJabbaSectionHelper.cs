using System;
using ReportingFramework.Structure.Sections.ExSum.AlgoComp.Jabba;

namespace ReportingFramework.Structure.SectionHelpers.ExSum.AlgoComp.Jabba
{
    public class ExSumAlgoComparisonJabbaSectionHelper : PdfSectionHelper
    {
        public override PdfReportSection GetSection(double version)
        {
            switch (version)
            {
                case 0.1:
                    return new ExecutiveSummaryAlgoComparisonJabbaV0_1();
                default:
                    throw new Exception();
            }
        }
    }
}