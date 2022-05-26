using System.Text.Json;
using GeneratorDataBase;
using GeneratorDBDtos.DBDTOs.Report;
using Microsoft.AspNetCore.Mvc;
using ReportGenerator.Host.ControllerLogger;
using ReportingFramework.Dto;

namespace ReportGenerator.Host.Controllers;

[Route("reports")]
//[Authorize]
[ApiController]
public class ReportGeneratorController : ControllerBase
{
    private readonly IReportGeneratorRepository _reportGeneratorRepository;
    private readonly IReportGeneratorHostedService _reportGeneratorHostedService;
    private readonly IControllerLogger _controllerLogger;
    public ReportGeneratorController(
        IReportGeneratorHostedService reportGeneratorHostedService,
        IReportGeneratorRepository reportGeneratorRepository,
        IControllerLogger controllerLogger)
    {
        _reportGeneratorHostedService = reportGeneratorHostedService;
        _reportGeneratorRepository = reportGeneratorRepository;
        _controllerLogger = controllerLogger;
    }
    
    /// <summary>
    /// Create report
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     
    /// {
    ///    "ReportFormat": 2,
    ///    "OutputFormat": "xlsx",
    ///    "TemplateId": 6,
    ///    "LanguageId": 1,
    ///    "Sections": [
    ///    {
    ///        "Data": [
    ///        {
    ///            "InputId": "210047",
    ///            "BuildingId": "73403001-4b0e-48c0-b1bc-989660324495"
    ///        }
    ///        ],
    ///        "Type": 2,
    ///        "Subtype": 7,
    ///        "CustomParameters": null
    ///    },
    ///    {
    ///        "Data": [
    ///        {
    ///            "InputId": "210047",
    ///            "BuildingId": "73403001-4b0e-48c0-b1bc-989660324495",
    ///            "BuildingName": "Haluco",
    ///            "InputName": "solar.forecast.active_energy",
    ///            "Media": "Electricity active (kWh)"
    ///        }
    ///        ],
    ///        "Type": 2,
    ///        "Subtype": 8,
    ///        "CustomParameters": null
    ///    }
    ///    ]
    /// }
    ///
    /// </remarks>
    /// <response code="200">Report created</response>
    /// <response code="400">Invalid request data</response>
    /// <response code="500">Internal error</response>
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    [HttpPost("report")]
    public async Task<ActionResult<string>> GenerateReport([FromBody] JsonElement reportModelJson)
    {
        _controllerLogger.Log(HttpContext, $"ReportModel: {reportModelJson}");
        
        var report = await _reportGeneratorRepository.CreateReport(
            new CreateReportDto()
            {
                Parameters = reportModelJson.ToString()
            });
        await _reportGeneratorHostedService.CreateReportAsync(reportModelJson, report.Id);
        
        return StatusCode(StatusCodes.Status200OK, report.Id.ToString());
    }

    /// <summary>
    /// Download report by guid
    /// </summary>
    /// <param name="reportGuid" example="812ea026-7056-45c0-93fc-12de425e6cd9">Report guid</param>
    /// <response code="200">Report guid returned</response>
    /// <response code="204">Invalid guid</response>
    /// <response code="500">Internal error</response>
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    [HttpGet("download")]
    public async Task<IActionResult> DownloadReport(Guid reportGuid)
    {
        _controllerLogger.Log(HttpContext, $"ReportGuid: {reportGuid}");
        
        var report = await _reportGeneratorRepository.GetReportByGuid(reportGuid);
        var reportLink = report.Link;
        if (reportLink == "")
        {
            return NoContent();
        }
        return File(
            await System.IO.File.ReadAllBytesAsync(reportLink),
            System.Net.Mime.MediaTypeNames.Application.Octet,
            reportLink.Split("/").Last());
    }
    
    /// <summary>
    /// Download zip archive with report and json model, that the report is based on
    /// </summary>
    /// <param name="reportGuid" example="812ea026-7056-45c0-93fc-12de425e6cd9">Report guid</param>
    /// <response code="200">Archive returned</response>
    /// <response code="204">Invalid guid</response>
    /// <response code="500">Internal error</response>
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    [HttpGet("download/reportwithdata")]
    public async Task<IActionResult> DownloadReportWithData(Guid reportGuid)
    {
        _controllerLogger.Log(HttpContext, $"ReportGuid: {reportGuid}");
        
        var file = await _reportGeneratorHostedService.GetReportWithDataAsync(reportGuid);
        if (file == null)
        {
            return NoContent();
        }
        return File(file.Bytes, file.ContentType, file.FileName);
    }
}