using ReportingFramework.SectionAdapter.CommonSecAdapters;
using SectionModels.Pdf.SectionModels.SimulationReports.AdviceP1Inv.NL;

namespace ReportingFramework.SectionAdapter.AdviceP1InvNL
{
    public class AdviceP1InvNL_TitleSecAdap : TitleSecAdap
    {
        protected new AdviceP1InvNL_TtileSectionModel SectionModel
        {
            get => base.SectionModel as AdviceP1InvNL_TtileSectionModel;
            set => base.SectionModel = value;
        }

        public AdviceP1InvNL_TitleSecAdap()
        {
            SectionModel = new AdviceP1InvNL_TtileSectionModel();
        }
    }
}