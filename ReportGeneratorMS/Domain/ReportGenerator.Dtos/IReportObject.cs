using System.Collections.Generic;

namespace ReportingFramework.Dto
{
    public interface IReportObject
    {
        int TypeEnum { get; }
        int SubTypeEnum { get; }
        string Name { get; set; }
        List<IReportObject> ChildObjects { get; set; }
        Dictionary<string, string> Parameters { get; set; }

       // IReportObject Create(SectionDto sectionDto, ResourceParameters resourceParameters);
       // List<SectionParameterValuesDto> ContentAsParameterValues();

        //public abstract void Init(ResourceParameters resourceParameters, ITemplate template, INumberFormatter numberFormatter);
    }
}