using ReportingFramework.SectionAdapter.CommonSecAdapters;
using SectionModels.Pdf.SectionModels.SimulationReports.Savings.BE;

namespace ReportingFramework.SectionAdapter.SavingsBE
{
    public class SavingsBE_TitleSecAdap : TitleSecAdap
    {
        protected new SavingsBE_TtileSectionModel SectionModel
        {
            get => base.SectionModel as SavingsBE_TtileSectionModel;
            set => base.SectionModel = value;
        }

        public SavingsBE_TitleSecAdap()
        {
            SectionModel = new SavingsBE_TtileSectionModel();
        }
    }
}