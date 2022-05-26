using System.Collections.Generic;

namespace ReportingFramework.Dto
{
    public interface ISection
    {
        public double Version { get; set; }
        void Init(Dictionary<string, string> dictionary);

        Dictionary<string, string> SerializeRootSectionParameters();
    }
}