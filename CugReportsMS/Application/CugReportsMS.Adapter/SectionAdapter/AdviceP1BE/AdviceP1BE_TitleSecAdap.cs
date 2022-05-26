using ReportingFramework.SectionAdapter.CommonSecAdapters;
using SectionModels.Pdf.SectionModels.SimulationReports.AdviceP1.BE;

namespace ReportingFramework.SectionAdapter.AdviceP1BE
{
    public class AdviceP1BE_TitleSecAdap : TitleSecAdap
    {
        protected new AdviceP1BE_TtileSectionModel SectionModel
        {
            get => base.SectionModel as AdviceP1BE_TtileSectionModel;
            set => base.SectionModel = value;
        }

        public AdviceP1BE_TitleSecAdap()
        {
            SectionModel = new AdviceP1BE_TtileSectionModel();
        }
    }
}