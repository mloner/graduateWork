using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PdfReportTemplaterClient;
using ReportingFramework.WebApp.Dtos.DBDtos;
using ReportingFramework.WebApp.Dtos.Repositories;

namespace ReportingFramweork.WebApp.Backend.Controllers
{
    [Route("editors")]
    [ApiController]
    public class TemplateEditorController: ControllerBase
    {
        private readonly ITemplateEditorRepository _templateEditorRepository;
        private readonly IPdfReportTemplaterClient _pdfReportTemplaterClient;
        
        public TemplateEditorController(
            ITemplateEditorRepository templateEditorRepository,
            IPdfReportTemplaterClient pdfReportTemplaterClient)
        {
            _templateEditorRepository = templateEditorRepository;
            _pdfReportTemplaterClient = pdfReportTemplaterClient;
        }

        [Authorize]
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<string>> GetEditorLink(string username)
        {
            var editor = await _templateEditorRepository.GetTemplateEditorByUsername(username);
            if (editor == null)
            {
                return NotFound();
            }
            var changedTemplateDto = new TemplateEditorDto()
            {
                Link = await _pdfReportTemplaterClient.GetEditorLinkAsync(editor.Token)
            };
            editor = await _templateEditorRepository.UpdateTemplate(editor.Id, changedTemplateDto);
            return Ok(editor.Link);
        }
    }
}