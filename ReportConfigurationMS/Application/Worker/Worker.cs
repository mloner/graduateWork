using System.Text.Json.Nodes;
using CugReportsMSClient;
using CugReportsMSClient.Dtos;
using Newtonsoft.Json.Linq;
using ReportConfigurationMS.Domain;
using ReportConfigurationMS.Domain.DTOs;
using ReportConfigurationMS.Domain.ReportParameters;
using SenderClient;
using SenderClient.JsonModels;
using CustomFile = ReportConfigurationMS.Domain.CustomFile;

namespace Worker;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IReportConfigurationRepository _reportConfigurationRepository;
    private readonly ICugReportsMSClient _cugReportsMsClient;
    private readonly ISenderClient _senderClient;
    private readonly IConfiguration _configuration;

    public Worker(
        ILogger<Worker> logger,
        IReportConfigurationRepository reportConfigurationRepository,
        ICugReportsMSClient cugReportsMsClient,
        ISenderClient senderClient,
        IConfiguration configuration)
    {
        _logger = logger;
        _reportConfigurationRepository = reportConfigurationRepository;
        _cugReportsMsClient = cugReportsMsClient;
        _senderClient = senderClient;
        _configuration = configuration;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var isRunOnStart = _configuration.GetSection("ReportConfigurationMS").GetSection("RunOnStart").Get<bool>();
        if (!isRunOnStart)
        {
            return;
        }
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            //await TestFillDatabase();
            try
            {
                DoWork();
            }
            catch (Exception e)
            {
                _logger.LogCritical($"{e.Message}\n{e.StackTrace}");
            }

            var delayMs = _configuration.GetSection("ReportConfigMS").GetSection("DelayMs").Get<int>();
            await Task.Delay(delayMs, stoppingToken);
        }
    }
    
    private async Task TestFillDatabase()
    {
        var newRequestDto = new ReportsRequestDto
        {
            ReportType = (int)ReportTypes.Maintenance,
            EmailList = new List<string>()
            {
                "nikita.romashov@aug-e.io",
                "michal.stankowski@aug-e.io",
                "adam.blazowski@aug-e.io"
            }.Aggregate((a, b) => $"{a},{b}"),
            RequestTimestamp = DateTime.Now,
            GenerationTimestamp = DateTime.Now,
            UserId = 2886,
            ReportDateFrom = null,
            ReportDateTo = null,
            CugGuid = null,
            BuildingGuid = null,
            UserGuid = default,
            AdditionalData = @"[
                {
                'cugGuid': 'f07f1fd9-86b7-404c-a0b0-f4f5f964c482',
                'BackwardHours': '24',
                'DontCheckForIssues': false,
                'inputGuids': [
                'e254df04-372e-4db3-aac4-a8633e351708',
                'a4f2cfde-535a-45ed-9e26-c7bf784bf8e8',
                'fbacc50c-5edd-4f53-9a10-becc1d361d69',
                '60f97dd1-4545-4adf-85ae-2cb2a8c8543a'
                    ]
                }
            ]"
            .Replace("'", "\"")
            .Replace("\n","")
            .Replace("\t", ""),
            Name = null,
            IsProductionRequest = false,
            RequestCulture = "en"
        };
        var request = await _reportConfigurationRepository.AddRequest(newRequestDto);

        var newScheduleDto = new ReportsScheduleDto
        {
            Granularity = null,
            PeriodInDays = null,
            ReportFrequencyId = 1,
            NextReportSendDate = DateTime.Today.AddDays(0).AddHours(5),
            GenerationTimestamp = null,
        };
        var schedule = await _reportConfigurationRepository.AddSchedule(newScheduleDto, request);
    }

    private async Task DoWork()
    {
        _logger.LogDebug("Worker. DoWork start");
        var now = DateTime.Now;
        var scheduleWithRequests = await GetReportSchedules(now);
        _logger.LogInformation($"Worker. Found {scheduleWithRequests.Count} schedules");
        CustomFile report = null;
        if (scheduleWithRequests.Any())
        {
            foreach (var scheduleDto in scheduleWithRequests)
            {
                _logger.LogInformation($"Worker. ScheduleId: {scheduleDto.ReportsScheduleId}");
                try
                {
                    _logger.LogDebug($"Worker. ScheduleId: {scheduleDto.ReportsScheduleId}. Create report start.");
                    report = await CreateReport(scheduleDto);
                }
                catch (Exception e)
                {
                    _logger.LogCritical($"Worker. ScheduleId: {scheduleDto.ReportsScheduleId}. Create report failed.");
                }

                try
                {
                    _logger.LogDebug($"Worker. ScheduleId: {scheduleDto.ReportsScheduleId}. Create report start.");
                    var result = await SendReport(report, scheduleDto);
                }
                catch (Exception e)
                {
                    _logger.LogCritical($"Worker. ScheduleId: {scheduleDto.ReportsScheduleId}. Send report failed.");
                }

                try
                {
                    _logger.LogDebug($"Worker. ScheduleId: {scheduleDto.ReportsScheduleId}. ChangeScheduleNextGenerationTime start.");
                    await ChangeScheduleNextGenerationTime(scheduleDto);
                }
                catch (Exception e)
                {
                    _logger.LogCritical($"Worker. ScheduleId: {scheduleDto.ReportsScheduleId}. ChangeScheduleNextGenerationTime failed.");
                }
                
            }
        }
        _logger.LogDebug("Worker. DoWork end");
    }

    private async Task ChangeScheduleNextGenerationTime(ReportsScheduleDto scheduleDto)
    {
        var nextGenerationDateTime =
            ReportNextGenerationDateTimeHelper.GetNextGenerationDateTime(
                DateTime.Now,
                (ReportFrequency)scheduleDto.ReportFrequencyId);
        await _reportConfigurationRepository.UpdateGenerationTimeAndNextGenerationDateTime(scheduleDto, nextGenerationDateTime);
    }

    private async Task<ICollection<ReportsScheduleDto>> GetReportSchedules(DateTime dateTime)
    {
        var schedules = await _reportConfigurationRepository.GetSchedulesForDatetime(dateTime);
        return schedules;
    }

    private async Task<CustomFile> CreateReport(ReportsScheduleDto reportsScheduleDto)
    {
        var oldJson = JsonNode.Parse(reportsScheduleDto.ReportsRequest.AdditionalData).AsArray();
        var customParams = new MaintenanceReportCustomParameters()
        {
            MinGapPeriod = new MinGapsPeriod()
            {
                PeriodType = 2,
                GapValue = int.Parse(oldJson.First()["BackwardHours"].ToString())
            },
            Cugs = oldJson.Select(x => new Cug()
            {
                CugGuid = Guid.Parse(x["cugGuid"].ToString()),
                InputGuids = x["inputGuids"].AsArray().Select(y => Guid.Parse(y.ToString())).ToList()
            }).ToList()
        };
        var reportParams = new ReportParameters()
        {
            ReportType = 2,
            CustomParameters = JObject.FromObject(customParams)
        };
        
        var reportGuid = await _cugReportsMsClient.CreateReportAsync(reportParams);
        var reportFile = await _cugReportsMsClient.DownloadReportAsync(reportGuid);
        
        return new CustomFile
        {
            Bytes = reportFile.Bytes,
            ContentType = reportFile.ContentType,
            FileName = reportFile.FileName
        };
    }
    
    private async Task<string> SendReport(CustomFile report, ReportsScheduleDto scheduleWithRequest)
    {
        SenderClient.JsonModels.CustomFile customFile = new SenderClient.JsonModels.CustomFile()
        {
            Bytes = report.Bytes,
            ContentType = report.ContentType,
            FileName = report.FileName
        };
        
        var result = await _senderClient.SendReportAsync(customFile, new EmailBase()
        {
            Recipients = scheduleWithRequest.ReportsRequest.EmailList.Split(",").ToList(),
            additionalRecipients = new List<string>()
            {
                "nikita.romashov@aug-e.io"
            },
            Subject = "ECOSCADA Maintenance Report",
            Content = "Test content",
        });

        return result;
    }
}