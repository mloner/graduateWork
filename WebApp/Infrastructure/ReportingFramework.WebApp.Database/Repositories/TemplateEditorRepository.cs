using Microsoft.EntityFrameworkCore;
using ReportingFramework.WebApp.Database.DataBaseModels;
using ReportingFramework.WebApp.Database.Extensions;
using ReportingFramework.WebApp.Dtos.DBDtos;
using ReportingFramework.WebApp.Dtos.Repositories;

namespace ReportingFramework.WebApp.Database.Repositories
{
    public class TemplateEditorRepository : EFReposotory, ITemplateEditorRepository
    {
        public TemplateEditorRepository(
            ITemplateEditorDbContext context, 
            ICalcellationTokenProvider cancellationTokenProvider)
            : base(context, cancellationTokenProvider)
        {
        }


        public async Task<TemplateEditorDto?> GetTemplateEditorByUsername(string username)
        {
            var val = await Context.TemplateEditors.FirstOrDefaultAsync(x => x.EcoscadaUsername == username);
            if (val == null)
            {
                return null;
            }
            return val.ToDtoModel();
        }

        public async Task<TemplateEditorDto> UpdateTemplate(int id, TemplateEditorDto templateEditorDto)
        {
            var val = await Context.TemplateEditors.FirstOrDefaultAsync(x => x.Id == id);

            val.Link = templateEditorDto.Link;

            await Context.SaveChangesAsync();

            return val.ToDtoModel();
        }
    }
}