using ReportConfigurationMS.Domain.DTOs;

namespace ReportConfigurationMS.Domain;

public interface IReportConfigurationRepository
{
    Task<ReportsScheduleDto> AddSchedule(ReportsScheduleDto reportsScheduleDto, ReportsRequestDto reportsRequestDto);
    Task<ReportsScheduleDto> GetSchedule(int scheduleId);
    Task<ICollection<ReportsScheduleDto>> GetSchedulesForDatetime(DateTime dateTime);
    

    Task<ReportsRequestDto> AddRequest(ReportsRequestDto reportsRequestDto);
    Task<ReportsRequestDto> GetRequest(int requestId);

    Task UpdateGenerationTimeAndNextGenerationDateTime(ReportsScheduleDto scheduleDto, DateTime nextGenerationDateTime);
}