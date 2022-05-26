using System;
using ReportingFramework.Structure.Sections.PeakShavComp.AlgoComp.Jabba;

namespace ReportingFramework.Structure.SectionHelpers.PeakShavingComparison.AlgoComp.Jabba
{
    public class PeakShavingComparisonAlgoComparisonJabbaSectionHelper : PdfSectionHelper
    {
        public override PdfReportSection GetSection(double version)
        {
            switch (version)
            {
                case 0.1:
                    return new AlgoComparisonPeakShavingComparisonJabbaV0_1();
                default:
                    throw new Exception();
            }
        }
    }
}