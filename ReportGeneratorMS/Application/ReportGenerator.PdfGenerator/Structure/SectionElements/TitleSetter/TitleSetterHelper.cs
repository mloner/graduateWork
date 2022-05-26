using System;
using ReportingFramework.Common.Template.SectionTypeTemplate;

namespace ReportingFramework.Structure.SectionElements.TitleSetter
{
    public static class TitleSetterHelper
    {
        public static TitleSetter GetTitleSetter(TitleType titleType)
        {
            switch (titleType)
            {
                case TitleType.NoTitle:
                    return new TitleSetterNoTitle();
                case TitleType.Default:
                    return new TitleSetterDefault();
                default:
                    throw new Exception();
            }
        }
    }
}