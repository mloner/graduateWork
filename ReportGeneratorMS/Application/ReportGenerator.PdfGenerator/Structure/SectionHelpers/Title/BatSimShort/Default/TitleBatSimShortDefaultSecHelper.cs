using System;
using ReportingFramework.Structure.Sections.Title.BatSimShort.Default;

namespace ReportingFramework.Structure.SectionHelpers.Title.BatSimShort.Default
{
    public class TitleBatSimShortDefaultSecHelper : PdfSectionHelper
    {
        public override PdfReportSection GetSection(double version)
        {
            switch (version)
            {
                case 0.1:
                    return new TitleBatSimShortDefaultV0_1();
                default:
                    throw new Exception();
            }
        }
    }
}