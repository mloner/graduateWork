using ReportingFramework.SectionAdapter.CommonSecAdapters;
using SectionModels.Pdf.SectionModels.SimulationReports.Measurement.NL;

namespace ReportingFramework.SectionAdapter.MeasurementNL
{
    public class MeasurementNL_TitleSecAdap : TitleSecAdap
    {
        protected new MeasurementNL_TtileSectionModel SectionModel
        {
            get => base.SectionModel as MeasurementNL_TtileSectionModel;
            set => base.SectionModel = value;
        }

        public MeasurementNL_TitleSecAdap()
        {
            SectionModel = new MeasurementNL_TtileSectionModel();
        }
    }
}