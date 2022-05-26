using System.Linq;
using CugReportMicroservice.Dtos.DBDTOs;
using ReportingDB.DataBaseModels;

namespace ReportingDB.Extentions
{
    public static class ReportTypeExtentions
    {
        public static ReportTypeDto ToDtoModel(this ReportType model)
        {
            return new ReportTypeDto
            {
                Id = model.Id,
                Name = model.Name,
                TypeNum = model.TypeNum,
                FormatId = model.FormatId,
                OutputFormat = model.OutputFormat,
            };
        }
        
        public static ReportTypeDto[] ToDtoModel(this ReportType[] model)
        {
            return model.Select(x => x.ToDtoModel()).ToArray();
        }
    }
}