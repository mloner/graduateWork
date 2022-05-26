using CugReportMicroservice.Dtos.DBDTOs;
using CugReportMicroservice.Dtos.DBDTOs.ReportDtos;


namespace CugReportMicroservice.Dtos
{
    public interface IReportRepository
    {
        Task<ReportDto> CreateReportAsync(CreateReportDto reportDto);
        Task<int> GetReportFormatByTypeWithTemplateId(int reportTypeWithTemplateId);
        Task<string> GetReportOutputFormatByTypeWithTemplateId(int reportTypeWithTemplateId);
        Task<int> GetReportTypeIdByReportTypeWithTemplateId(int reportWithTemplateTypeId);
        
        Task<int?> GetReportLanguageByTypeWithTemplateId(int reportWithTemplateTypeId);

        Task<int> GetReportTypeNumByReportTypeWithTemplateId(int reportWithTemplateTypeId);

        Task<bool> IsValidReportType(int reportTypeId);

        Task<ReportDto[]> GetReportsAsync();
        Task<ReportDto> GetReportByReportIdAsync(int reportId);
        Task<ReportDto[]> GetReportsByTaskIdAsync(int taskId);
        
        Task<ReportDto> UpdateReportAsync(int reportId, ReportDto reportDto);
        
        
        
        Task<string> GetReportNameByTypeWithTemplateId(int typeId);
        
        Task<List<SectionDto>> GetSectionsByReportTypeWithTemplateId(int reportTypeWithTemplateId);
        
        Task<string> GetOutputFormatByRepotTypeWithTemplateId(int reportType);
        
        Task<string> GetTemplateIdByReportTypeWithTemplateId(int reportTypeWithTemplateId);

        Task<ReportDto> GetReportDtoByGuidReportInGenerator(Guid reportGuid);
    }
}