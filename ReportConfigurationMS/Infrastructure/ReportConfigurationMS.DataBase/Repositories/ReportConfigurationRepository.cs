using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReportConfigurationMS.DataBase.Mappers;
using ReportConfigurationMS.DataBase.Models;
using ReportConfigurationMS.Domain;
using ReportConfigurationMS.Domain.DTOs;

namespace ReportConfigurationMS.DataBase.Repositories;

public class ReportConfigurationRepository : EfRepository,  IReportConfigurationRepository
{
    
    public ReportConfigurationRepository(
        IServiceScopeFactory scopeFactory)
        : base( scopeFactory)
    {
    }

    private ReportConfigurationDbContext GetContext()
    {
        return _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<ReportConfigurationDbContext>();
    }

    public async Task<ReportsScheduleDto> AddSchedule(ReportsScheduleDto reportsScheduleDto, ReportsRequestDto reportsRequestDto)
    {
        var context = GetContext();
        var schedule = await context.TReportsSchedules.AddAsync(reportsScheduleDto.ToDomain());
        
        var request = await context.TReportsRequests.FirstOrDefaultAsync(x => x.Id == reportsRequestDto.Id);
        if (request == null)
        {
            throw new Exception("No such request");
        }
        schedule.Entity.ReportsRequest = request;
        await context.SaveChangesAsync();

        return schedule.Entity.ToDto();
    }

    public async Task<ReportsScheduleDto> GetSchedule(int scheduleId)
    {
        var context = GetContext();
        var schedule = await context.TReportsSchedules.FirstOrDefaultAsync(x => x.ReportsScheduleId == scheduleId);
        if (schedule == null)
        {
            throw new Exception("No such schedule");
        }

        return schedule.ToDto();
    }

    public async Task<ICollection<ReportsScheduleDto>> GetSchedulesForDatetime(DateTime dateTime)
    {
        var context = GetContext();
        var schedules = context.TReportsSchedules
            .Include(x => x.ReportsRequest)
            .Where(x =>
            x.NextReportSendDate.Date == dateTime.Date
            && x.NextReportSendDate.TimeOfDay <= dateTime.TimeOfDay);
        if (!schedules.Any())
        {
            return new List<ReportsScheduleDto>();
        }

        return schedules.ToArray().ToDto();

    }

    public async Task<ReportsRequestDto> AddRequest(ReportsRequestDto reportsRequestDto)
    {
        var context = GetContext();
        var request = await context.TReportsRequests.AddAsync(reportsRequestDto.ToDomain());
        await context.SaveChangesAsync();

        return request.Entity.ToDto();
    }

    public async Task<ReportsRequestDto> GetRequest(int requestId)
    {
        var context = GetContext();
        var request = await context.TReportsRequests.FirstOrDefaultAsync(x => x.Id == requestId);
        if (request == null)
        {
            throw new Exception("No such request");
        }

        return request.ToDto();
    }

    public async Task UpdateGenerationTimeAndNextGenerationDateTime(ReportsScheduleDto scheduleDto, DateTime nextGenerationDateTime)
    {
        var context = GetContext();
        var schedule = await context.TReportsSchedules.FirstOrDefaultAsync(x => x.ReportsScheduleId == scheduleDto.ReportsScheduleId);
        if (schedule == null)
        {
            throw new Exception("No such schedule");
        }
        schedule.GenerationTimestamp = DateTime.Now;
        schedule.NextReportSendDate = nextGenerationDateTime;
        await context.SaveChangesAsync();
    }
}