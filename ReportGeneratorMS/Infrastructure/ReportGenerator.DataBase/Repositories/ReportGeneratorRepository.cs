using GeneratorDataBase.DataBaseModels;
using GeneratorDBDtos.DBDTOs;
using GeneratorDBDtos.DBDTOs.Report;
using Microsoft.EntityFrameworkCore;
using ReportingFramework.Dto;
using SectionModels;

namespace GeneratorDataBase.Repositories
{
    public class ReportGeneratorRepository : EfRepository, IReportGeneratorRepository
    {
        public ReportGeneratorRepository(IReportGeneratorDbContext context, ICalcellationTokenProvider cancellationTokenProvider)
            : base(context, cancellationTokenProvider)
        {
        }

        public async Task<ReportDto> CreateReport(CreateReportDto reportDto)
        {
            var report = await Context.Reports.AddAsync(new Report
            {
                Id = Guid.NewGuid(),
                Parameters = reportDto.Parameters,
                StatusId = (int)ReportStatus.Processing,
                Link = null
            });
            await Context.SaveChangesAsync();
            
            return new ReportDto()
            {
                Id = report.Entity.Id,
                Parameters = report.Entity.Parameters,
                StatusId = (ReportStatus)report.Entity.StatusId,
                Link = report.Entity.Link
            };
        }

        public async Task<ReportDto> GetReportByGuid(Guid reportGuid)
        {
           var report = await Context.Reports.FirstAsync(x => x.Id == reportGuid);
           return new ReportDto()
           {
               Id = report.Id,
               Parameters = report.Parameters,
               StatusId = (ReportStatus)report.StatusId,
               Link = report.Link
           };
        }

        public async Task<TemplateDto> GetTemplateById(int templateId)
        {
            var template =  await Context.Templates
                .Include(x => x.GlobalSettings)
                .Include(x => x.Styles)
                .Include(x => x.SectionToTemplateRelations)
                .Include(x => x.SectionTypeTemplates)
                .FirstAsync(x => x.Id == templateId);
            
            var templateDto =  new TemplateDto
            {
                Id = template.Id,
                Name = template.Name,
                
                GlobalSettingsId = template.GlobalSettingsId,
                GlobalSettings = template.GlobalSettings?.Value,
                
                StylesId = template.StylesId,
                Styles = template.Styles?.Value,
                
                SectionToTemplateRelationsId = template.SectionToTemplateRelationsId,
                SectionToTemplateRelations = template.SectionToTemplateRelations?.Value,
                
                SectionTypeTemplatesId = template.SectionTypeTemplatesId,
                SectionTypeTemplates = template.SectionTypeTemplates?.Value,
            };

            //template full json string
            templateDto.TemplateFull += "{";
            if (templateDto.GlobalSettingsId != null)
            {
                templateDto.TemplateFull += $"\"GlobalSettings\" : {templateDto.GlobalSettings},";
            }
            if (templateDto.StylesId != null)
            {
                templateDto.TemplateFull += $"\"Styles\" : {templateDto.Styles},";
            }
            if (templateDto.SectionToTemplateRelationsId != null)
            {
                templateDto.TemplateFull += $"\"SectionToTemplateRelations\" : {templateDto.SectionToTemplateRelations},";
            }
            if (templateDto.SectionTypeTemplatesId != null)
            {
                templateDto.TemplateFull += $"\"SectionTypeTemplates\" : {templateDto.SectionTypeTemplates},";
            }
            // if (templateDto.TemplateFilePathsId != null)
            // {
            //     templateDto.TemplateFull += $"\"TemplateFilePaths\" : {templateDto.TemplateFilePaths},";
            // }

            templateDto.TemplateFull = templateDto.TemplateFull.Substring(0, templateDto.TemplateFull.Length - 1);
            templateDto.TemplateFull += "}";
            
            return templateDto;
        }

        public async Task SetReportStatus(Guid reportGuid, ReportStatus reportStatus)
        {
            var report = Context.Reports.First(x => x.Id == reportGuid);
            report.StatusId = (int)reportStatus;
            await Context.SaveChangesAsync();
        }

        public async Task SetReportLink(Guid reportGuid, string link)
        {
            var report = Context.Reports.First(x => x.Id == reportGuid);
            report.Link = link;
            await Context.SaveChangesAsync();
        }
    }
}