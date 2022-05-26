using System;
using System.Text.Json;
using System.Threading.Tasks;
using CugReportMicroservice.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ReportingFramework.WebApi.Application.Host.ControllerLogger;

namespace ReportingFramework.WebApi.Application.Host.Controllers
{
    [ApiController]
    [Route("reports")]
    public class ReportsController : ControllerBase
    {
        private readonly ILogger<ReportsController> _logger;
        private readonly IReportRepository _reportRepository;
        private readonly IConfiguration _configuration;
        private readonly IReportOrchestratorHostedService _reportOrchestratorHostedService;
        private readonly IControllerLogger _controllerLogger;

        public ReportsController(
            IConfiguration configuration,
            IReportRepository reportRepository,
            ILogger<ReportsController> logger,
            IReportOrchestratorHostedService reportOrchestratorHostedService,
            IControllerLogger controllerLogger)
        {
            _reportOrchestratorHostedService = reportOrchestratorHostedService;
            _configuration = configuration;
            _logger = logger;
            _reportRepository = reportRepository;
            _controllerLogger = controllerLogger;
        }
        
        
        /// <summary>
        /// Create report
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     
        ///     {
        ///         "ReportType": 1,
        ///         "DataFolder": "Folder/Subfolder",
        ///         "CustomParameters": {
        ///             "ParamName1" : "value",
        ///             "paramName2" : 345
        ///         }
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Report created</response>
        /// <response code="400">Invalid request data</response>
        /// <response code="500">Internal error</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPost("")]
        public async Task<ActionResult<string>> CreateReport([FromBody]JsonElement reportParametersJsonElem)
        {
            _controllerLogger.Log(HttpContext, $"Params: {reportParametersJsonElem}");
            var reportGuid = await _reportOrchestratorHostedService.CreateReportAsync(reportParametersJsonElem);
            return StatusCode(StatusCodes.Status200OK, reportGuid.ToString());
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
            
            var file = await _reportOrchestratorHostedService.DownloadReportAsync(reportGuid);
            if (file == null)
            {
                return NoContent();
            }
            return File(file.Bytes, file.ContentType, file.FileName);
        }
        
        /// <summary>
        /// Download zip archive with raw data, that the report is based on
        /// </summary>
        /// <param name="reportGuid" example="812ea026-7056-45c0-93fc-12de425e6cd9">Report guid</param>
        /// <response code="200">Archive returned</response>
        /// <response code="204">Invalid guid</response>
        /// <response code="500">Internal error</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [HttpGet("download/rawdata")]
        public async Task<IActionResult> DownloadRawReportData(Guid reportGuid)
        {
            var file = await _reportOrchestratorHostedService.DownloadRawReportDataAsync(reportGuid);
            if (file == null)
            {
                return NoContent();
            }
            return File(file.Bytes, file.ContentType, file.FileName);
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
        public async Task<IActionResult> DownloadRawReportWithData(Guid reportGuid)
        {
            var file = await _reportOrchestratorHostedService.DownloadRawReportWithDataAsync(reportGuid);
            if (file == null)
            {
                return NoContent();
            }
            return File(file.Bytes, file.ContentType, file.FileName);
        }
    }
}