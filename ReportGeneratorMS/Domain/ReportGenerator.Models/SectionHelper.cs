using System.Globalization;
using ReportingFramework.Dto;

namespace SectionModels
{
    public static class SectionHelper
    {
        public static string GetPathToSection(string sectionName, double version)
        {
            var res = "";

            var sectionNameStringList = sectionName.Split("_");
            foreach (var s in sectionNameStringList)
            {
                res += s;
                res += "/";
            }
            
            res += $"V{version.ToString(CultureInfo.InvariantCulture).Replace(".", ",").Replace(",", "_")}";

            return res;
        }
        
        public static ReportPaths SetPathsForSection(ReportPaths paths, string sectionName, double sectionVersion)
        {
            paths.SectionResources = $"{paths.Data}/SectionsResources/" +
                                     $"{GetPathToSection(sectionName, sectionVersion)}";
            paths.SectionImages = $"{paths.SectionResources}/Images";
            paths.SectionIcons = $"{paths.SectionImages}/Icons";
            paths.SectionTextResourceNamespace =
                $"{paths.SectionResourcesNamespace}." +
                $"{GetPathToSection(sectionName, sectionVersion).Replace("/", ".")}." +
                $"TextResources." +
                $"{sectionName}_" +
                $"ResV{sectionVersion.ToString(CultureInfo.InvariantCulture).Replace(".", ",").Replace(",", "_")}";
            
            return paths;
        }
    }
}