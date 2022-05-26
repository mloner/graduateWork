using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CugReportMicroservice.Dtos;
using CugReportMicroservice.Dtos.DBDTOs;
using CugReportMicroservice.Dtos.DBDTOs.ReportDtos;
using Microsoft.EntityFrameworkCore;
using ReportingDB.DataBaseModels;
using ReportingDB.Extentions;

namespace ReportingDB.Repositories
{
    public class ReportRepository : ReportingEfRepository, IReportRepository
    {
        public ReportRepository(CugReportMSDbContext context, ICalcellationTokenProvider cancellationTokenProvider)
            : base(context, cancellationTokenProvider)
        {
        }
        
        public async Task<ReportDto> CreateReportAsync(CreateReportDto reportDto)
        {
            var report = await Context.Reports.AddAsync(new Report
            {
                TypeWithTemplateId = reportDto.TypeWithTemplateId,
                Parameters = reportDto.Parameters
            });
            await Context.SaveChangesAsync();
            return await GetReportDtoById(report.Entity.Id);
        }

        private async Task<ReportDto> GetReportDtoById(int reportId)
        {
            return (await Context.Reports
                .Include(x => x.TypeWithTemplate)
                .ThenInclude(x => x.ReportType)
                .FirstAsync(x => x.Id == reportId)).ToDtoModel();
        }
        public async Task<int> GetReportFormatByTypeWithTemplateId(int reportTypeWithTemplateId)
        {
            var reportTypeId = await GetReportTypeIdByReportTypeWithTemplateId(reportTypeWithTemplateId);
            return (await Context.ReportTypes.FirstAsync(x => x.Id == reportTypeId)).FormatId;
        }
        public async Task<string> GetReportOutputFormatByTypeWithTemplateId(int reportTypeWithTemplateId)
        {
            var reportTypeId = await GetReportTypeIdByReportTypeWithTemplateId(reportTypeWithTemplateId);
            return (await Context.ReportTypes.FirstAsync(x => x.Id == reportTypeId)).OutputFormat;
        }
        
        public async Task<int?> GetReportLanguageByTypeWithTemplateId(int reportTypeWithTemplateId)
        {
           return (await Context.ReportTypesWithTemplates.FirstAsync(x => x.Id == reportTypeWithTemplateId)).LanguageId;
        }
        public async Task<int> GetReportTypeIdByReportTypeWithTemplateId(int reportWithTemplateTypeId)
        {
            var reportTypeWithTemplate =
                await Context.ReportTypesWithTemplates
                    .Include(x => x.ReportType)
                    .FirstOrDefaultAsync(x => x.Id == reportWithTemplateTypeId);
            return reportTypeWithTemplate.ReportTypeId;
        }
        
        public async Task<int> GetReportTypeNumByReportTypeWithTemplateId(int reportWithTemplateTypeId)
        {
            var reportTypeWithTemplate = await Context.ReportTypesWithTemplates.Include(x => x.ReportType).FirstAsync(x => x.Id == reportWithTemplateTypeId);
            return reportTypeWithTemplate.ReportType.TypeNum;
        }

        public async Task<bool> IsValidReportType(int reportTypeId)
        {
            return await Context.ReportTypesWithTemplates.AnyAsync(x => x.Id == reportTypeId);
        }

        public async Task<List<SectionDto>> GetSectionsByReportTypeWithTemplateId(int reportTypeWithTemplateId)
        {
            var reportTypeId = await GetReportTypeIdByReportTypeWithTemplateId(reportTypeWithTemplateId);
            var sections = Context.Sections
                .Where(x => x.ReportTypeId == reportTypeId && x.Enabled == true)
                .OrderBy(x => x.OrderNum)
                .ToArray();
        
            
            return sections.ToDtoModel().ToList();
        }
        public async Task<string> GetTemplateIdByReportTypeWithTemplateId(int reportTypeWithTemplateId)
        {
            return (await Context.ReportTypesWithTemplates.FirstAsync(x => x.Id == reportTypeWithTemplateId)).TemplateId;
        }

        public async Task<ReportDto> GetReportDtoByGuidReportInGenerator(Guid reportGuid)
        {
            return (await Context.Reports
                .Include(x => x.TypeWithTemplate)
                .ThenInclude(x => x.ReportType)
                .FirstAsync(x => x.ReportGuidInGenerator == reportGuid)).ToDtoModel();
        }


        public async Task<string> GetOutputFormatByRepotTypeWithTemplateId(int reportType)
        {
            var reportTypeId = await GetReportTypeIdByReportTypeWithTemplateId(reportType);
            return (await Context.ReportTypes.FirstAsync(x => x.Id == reportTypeId)).OutputFormat;
        }
        
        
        public Task<ReportDto[]> GetReportsAsync()
        {
            throw new NotImplementedException();
        }
        
        public Task<ReportDto> GetReportByReportIdAsync(int reportId)
        {
            throw new NotImplementedException();
        }
        
        public Task<ReportDto[]> GetReportsByTaskIdAsync(int taskId)
        {
            throw new NotImplementedException();
        }
        
        
        
        public async Task<ReportDto> UpdateReportAsync(int reportId, ReportDto reportDto)
        {
            var report = await Context.Reports.FirstAsync(x => x.Id == reportId);

            report.ReportGuidInGenerator = reportDto.ReportGuidInGenerator;
            
            await Context.SaveChangesAsync(CancellationToken);
            return report.ToDtoModel();
        }
        
        
        
        public async Task<string> GetReportNameByTypeWithTemplateId(int typeId)
        {
            var reportTypeId = await GetReportTypeIdByReportTypeWithTemplateId(typeId);
            return (await Context.ReportTypes.FirstAsync(x => x.Id == reportTypeId)).Name;
        }
    }
}