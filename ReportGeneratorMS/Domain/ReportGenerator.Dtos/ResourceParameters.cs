using System.Globalization;

namespace ReportingFramework.Dto
{
    public class ResourceParameters
    {
        public ReportPaths Paths { get; set; }
        public CultureInfo CultureInfo { get; set; }
    }
}