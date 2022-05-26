using System.Linq;
using CugReportMicroservice.Dtos.DBDTOs;
using ReportingDB.DataBaseModels;

namespace ReportingDB.Extentions
{
    public static class ReportTypeWithTemplateExtentions
    {
        public static ReportTypeWithTemplateDto ToDtoModel(this ReportTypesWithTemplate model)
        {
            return new ReportTypeWithTemplateDto
            {
                Id = model.Id,
                ReportTypeId = model.ReportTypeId,
                Name = model.Name,
                TemplateId = model.TemplateId,
                LanguageId = model.LanguageId,
                ReportTypeDto = model.ReportType.ToDtoModel()
            };
        }
        
        public static ReportTypeWithTemplateDto[] ToDtoModel(this ReportTypesWithTemplate[] model)
        {
            return model.Select(x => x.ToDtoModel()).ToArray();
        }
    }
}