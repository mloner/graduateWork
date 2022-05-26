using MigraDoc.DocumentObjectModel;
using ReportingFramework.Common.Template.SectionTypeTemplate;

namespace ReportingFramework.Structure.SectionElements.FooterSetter
{
    public abstract class FooterSetter
    {
        public abstract void Set(Section section, Footer footer, ParagraphFormat footerStyle);
    }
}