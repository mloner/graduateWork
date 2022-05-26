using ReportingFramework.SectionAdapter.CommonSecAdapters;
using SectionModels.Pdf.SectionModels.SimulationReports.Savings.NL;

namespace ReportingFramework.SectionAdapter.SavingsNL
{
    public class SavingsNL_TitleSecAdap : TitleSecAdap
    {
        protected new SavingsNL_TtileSectionModel SectionModel
        {
            get => base.SectionModel as SavingsNL_TtileSectionModel;
            set => base.SectionModel = value;
        }

        public SavingsNL_TitleSecAdap()
        {
            SectionModel = new SavingsNL_TtileSectionModel();
        }
    }
}