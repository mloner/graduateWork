using ReportingFramework.SectionAdapter.CommonSecAdapters;
using SectionModels.Pdf.SectionModels.SimulationReports.Measurement.BE;

namespace ReportingFramework.SectionAdapter.MeasurementBE
{
    public class MeasurementBE_TitleSecAdap : TitleSecAdap
    {
        protected new MeasurementBE_TtileSectionModel SectionModel
        {
            get => base.SectionModel as MeasurementBE_TtileSectionModel;
            set => base.SectionModel = value;
        }

        public MeasurementBE_TitleSecAdap()
        {
            SectionModel = new MeasurementBE_TtileSectionModel();
        }
    }
}