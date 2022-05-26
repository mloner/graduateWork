using System.Linq;
using CugReportMicroservice.Dtos.DBDTOs.ReportDtos;
using ReportingDB.DataBaseModels;

namespace ReportingDB.Extentions
{
    public static class ReportExtentions
    {
        public static ReportDto ToDtoModel(this Report model)
        {
            return new ReportDto
            {
                TypeWithTemplateId = model.TypeWithTemplateId,
                Parameters = model.Parameters,
                Id = model.Id,
                ReportGuidInGenerator = model.ReportGuidInGenerator,
                TypeWithTemplateDto = model.TypeWithTemplate.ToDtoModel()
            };
        }
        
        public static ReportDto[] ToDtoModel(this Report[] model)
        {
            return model.Select(x => x.ToDtoModel()).ToArray();
        }
    }
}