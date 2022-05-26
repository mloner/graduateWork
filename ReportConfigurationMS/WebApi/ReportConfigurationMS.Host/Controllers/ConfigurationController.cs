using Microsoft.AspNetCore.Mvc;
using ReportConfigurationMS.Domain;
using ReportConfigurationMS.Domain.DTOs;

namespace ReportConfigurationMS.Host.Controllers;

[ApiController]
[Route("configurations")]
public class ConfigurationController : ControllerBase
{
    private readonly ILogger<ConfigurationController> _logger;
    private readonly IReportConfigurationRepository _reportConfigurationRepository;

    public ConfigurationController(
        ILogger<ConfigurationController> logger,
        IReportConfigurationRepository reportConfigurationRepository)
    {
        _logger = logger;
        _reportConfigurationRepository = reportConfigurationRepository;
    }

   
}