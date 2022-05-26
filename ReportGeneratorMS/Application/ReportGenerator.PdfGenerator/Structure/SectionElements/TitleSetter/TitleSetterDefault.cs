using MigraDoc.DocumentObjectModel;
using ReportingFramework.Common.Template.SectionTypeTemplate;

namespace ReportingFramework.Structure.SectionElements.TitleSetter
{
    public class TitleSetterDefault : TitleSetter
    {
        public override void Set(Section section, Title title, ParagraphFormat titleStyle, string titleText)
        {
            var par = section.AddParagraph();
            par.AddText(titleText);
            par.Format = titleStyle;
        }
    }
}