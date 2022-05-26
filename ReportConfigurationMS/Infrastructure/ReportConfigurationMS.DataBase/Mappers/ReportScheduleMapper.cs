using ReportConfigurationMS.DataBase.Models;
using ReportConfigurationMS.Domain.DTOs;

namespace ReportConfigurationMS.DataBase.Mappers;

public static class ReportScheduleMapper
{
    public static TReportsSchedule ToDomain(this ReportsScheduleDto dto)
    {
        return new TReportsSchedule
        {
            ReportsScheduleId = dto.ReportsScheduleId,
            ReportsRequestId = dto.ReportsRequestId,
            Granularity = dto.Granularity,
            PeriodInDays = dto.PeriodInDays,
            ReportFrequencyId = dto.ReportFrequencyId,
            NextReportSendDate = dto.NextReportSendDate,
            GenerationTimestamp = dto.GenerationTimestamp,
        };
    }

    public static TReportsSchedule[] ToDomain(this ReportsScheduleDto[] dtos)
    { 
        return dtos.Select(x => x.ToDomain()).ToArray();
    }
    public static ReportsScheduleDto ToDto(this TReportsSchedule model)
    {
        return new ReportsScheduleDto
        {
            ReportsScheduleId = model.ReportsScheduleId,
            ReportsRequestId = model.ReportsRequestId,
            Granularity = model.Granularity,
            PeriodInDays = model.PeriodInDays,
            ReportFrequencyId = model.ReportFrequencyId,
            NextReportSendDate = model.NextReportSendDate,
            GenerationTimestamp = model.GenerationTimestamp,
            ReportsRequest = model.ReportsRequest.ToDto()
        };
    }
    
    public static ReportsScheduleDto[] ToDto(this TReportsSchedule[] models)
    { 
        return models.Select(x => x.ToDto()).ToArray();
    }
}