using System;
using ReportingFramework.Common.Template.SectionTypeTemplate;

namespace ReportingFramework.Structure.SectionElements.FooterSetter
{
    public static class FooterSetterHelper
    {
        public static FooterSetter GetFooterSetter(FooterType footerType)
        {
            switch (footerType)
            {
                case FooterType.NoFooter:
                    return new FooterSetterNoFooter();
                case FooterType.JabbaStyle:
                    return new FooterSetterJabbaStyle();
                default:
                    throw new Exception();
            }
        }
    }
}