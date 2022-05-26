using ReportingFramework.SectionAdapter.CommonSecAdapters;
using SectionModels.Pdf.SectionModels.SimulationReports.AdviceP1.NL;

namespace ReportingFramework.SectionAdapter.AdviceP1NL
{
    public class AdviceP1NL_TitleSecAdap : TitleSecAdap
    {
        protected new AdviceP1NL_TtileSectionModel SectionModel
        {
            get => base.SectionModel as AdviceP1NL_TtileSectionModel;
            set => base.SectionModel = value;
        }

        public AdviceP1NL_TitleSecAdap()
        {
            SectionModel = new AdviceP1NL_TtileSectionModel();
        }
    }
}