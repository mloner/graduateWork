using System;
using System.Threading.Tasks;
using GeneratorDBDtos.DBDTOs;
using GeneratorDBDtos.DBDTOs.Report;
using SectionModels;

namespace ReportingFramework.Dto;

public interface IReportGeneratorRepository
{
    Task<ReportDto> CreateReport(CreateReportDto reportDto);
    Task<ReportDto> GetReportByGuid(Guid reportGuid);
    Task<TemplateDto> GetTemplateById(int templateId);
    Task SetReportStatus(Guid reportGuid, ReportStatus reportStatus);
    Task SetReportLink(Guid reportGuid, string link);
}