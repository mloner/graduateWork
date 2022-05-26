using MigraDoc.DocumentObjectModel;
using ReportingFramework.Common.Template.SectionTypeTemplate;

namespace ReportingFramework.Structure.SectionElements.HeaderSetter
{
    public abstract class HeaderSetter
    {
        public abstract void Set(Section section, Header header);
    }
}