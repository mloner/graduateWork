using System;
using ReportingFramework.Common.Template.SectionTypeTemplate;

namespace ReportingFramework.Structure.SectionElements.HeaderSetter
{
    public static class HeaderSetterHelper
    {
        public static HeaderSetter GetHeaderSetter(HeaderType headerType)
        {
            switch (headerType)
            {
                case HeaderType.NoHeader:
                    return new HeaderSetterNoHeader();
                default:
                    throw new Exception();
            }
        }
    }
}