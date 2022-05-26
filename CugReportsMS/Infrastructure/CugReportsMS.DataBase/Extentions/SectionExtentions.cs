using System.Linq;
using CugReportMicroservice.Dtos.DBDTOs;
using ReportingDB.DataBaseModels;

namespace ReportingDB.Extentions
{
    public static class SectionExtentions
    {
        public static SectionDto ToDtoModel(this Section model)
        {
            return new SectionDto
            {
                Id = model.Id,
                ReportTypeId = model.ReportTypeId,
                SectionNum = model.SectionNum,
                Name = model.Name,
                OrderNum = model.OrderNum,
                Enabled = model.Enabled
            };
        }
        
        public static SectionDto[] ToDtoModel(this Section[] model)
        {
            return model.Select(x => x.ToDtoModel()).ToArray();
        }
    }
}