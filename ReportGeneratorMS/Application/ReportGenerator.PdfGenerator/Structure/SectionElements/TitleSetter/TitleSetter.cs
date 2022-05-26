using MigraDoc.DocumentObjectModel;
using ReportingFramework.Common.Template.SectionTypeTemplate;

namespace ReportingFramework.Structure.SectionElements.TitleSetter
{
    public abstract class TitleSetter
    {
        public abstract void Set(Section section, Title title, ParagraphFormat titleStyle, string titleText);
    }
}