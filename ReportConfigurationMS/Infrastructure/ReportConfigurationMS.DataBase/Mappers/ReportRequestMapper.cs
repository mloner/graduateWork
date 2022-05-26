using ReportConfigurationMS.DataBase.Models;
using ReportConfigurationMS.Domain.DTOs;

namespace ReportConfigurationMS.DataBase.Mappers;

public static class ReportRequestMapper
{
    public static TReportsRequest ToDomain(this ReportsRequestDto dto)
    {
        return new TReportsRequest
        {
            Id = dto.Id,
            ReportType = dto.ReportType,
            EmailList = dto.EmailList,
            RequestTimestamp = dto.RequestTimestamp,
            GenerationTimestamp = dto.GenerationTimestamp,
            UserId = dto.UserId,
            ReportDateFrom = dto.ReportDateFrom,
            ReportDateTo = dto.ReportDateTo,
            CugGuid = dto.CugGuid,
            BuildingGuid = dto.BuildingGuid,
            UserGuid = dto.UserGuid,
            AdditionalData = dto.AdditionalData,
            Name = dto.Name,
            IsProductionRequest = dto.IsProductionRequest,
            RequestCulture = dto.RequestCulture,
        };
    }

    public static TReportsRequest[] ToDomain(this ReportsRequestDto[] dtos)
    { 
        return dtos.Select(x => x.ToDomain()).ToArray();
    }
    public static ReportsRequestDto ToDto(this TReportsRequest model)
    {
        return new ReportsRequestDto
        {
            Id = model.Id,
            ReportType = model.ReportType,
            EmailList = model.EmailList,
            RequestTimestamp = model.RequestTimestamp,
            GenerationTimestamp = model.GenerationTimestamp,
            UserId = model.UserId,
            ReportDateFrom = model.ReportDateFrom,
            ReportDateTo = model.ReportDateTo,
            CugGuid = model.CugGuid,
            BuildingGuid = model.BuildingGuid,
            UserGuid = model.UserGuid,
            AdditionalData = model.AdditionalData,
            Name = model.Name,
            IsProductionRequest = model.IsProductionRequest,
            RequestCulture = model.RequestCulture,
        };
    }
    
    public static ReportsRequestDto[] ToDto(this TReportsRequest[] models)
    { 
        return models.Select(x => x.ToDto()).ToArray();
    }
}