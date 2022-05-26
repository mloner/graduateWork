using ReportingFramework.SectionAdapter.CommonSecAdapters;
using SectionModels.Pdf.SectionModels.SimulationReports.AdviceP1Inv.BE;

namespace ReportingFramework.SectionAdapter.AdviceP1InvBE
{
    public class AdviceP1InvBE_TitleSecAdap : TitleSecAdap
    {
        protected new AdviceP1InvBE_TtileSectionModel SectionModel
        {
            get => base.SectionModel as AdviceP1InvBE_TtileSectionModel;
            set => base.SectionModel = value;
        }

        public AdviceP1InvBE_TitleSecAdap()
        {
            SectionModel = new AdviceP1InvBE_TtileSectionModel();
        }
    }
}