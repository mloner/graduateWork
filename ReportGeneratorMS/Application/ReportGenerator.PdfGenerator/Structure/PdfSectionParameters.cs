using ReportingFramework.Common.TemplateLoader;
using ReportingFramework.Dto.DataModels;

namespace ReportingFramework.Structure
{
    public class PdfSectionParameters : AbstractSectionParameters
    {
        public MigraDoc.DocumentObjectModel.Section Section;
        public new PdfTemplate ReportTemplate;
        public MigraDoc.DocumentObjectModel.Document Document;
    }
}