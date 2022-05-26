using ClosedXML.Excel;
using ReportingFramework.Dto.DataModels;

namespace ExcelGenerator.Structure
{
    public class ExcelSectionParameters : AbstractSectionParameters
    {
        public IXLWorkbook OutWorkbook;
    }
}