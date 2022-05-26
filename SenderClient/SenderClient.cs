using System.Net;
using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SenderClient.EmailMicroservice;
using SenderClient.JsonModels;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace SenderClient;

public class SenderClient : ISenderClient
{
    private SenderClientSettings _settings;
    private readonly IConfiguration _configuration;

    public SenderClient(IConfiguration configuration)
    {
        _configuration = configuration;
        _settings = new SenderClientSettings()
        {
            ServerAddress = _configuration
                .GetSection("Api")
                .GetSection("Microservices")
                .GetSection("EmailMicroservice")
                .GetSection("Url")
                .Value,
            ApiKey = _configuration
                .GetSection("Api")
                .GetSection("Microservices")
                .GetSection("EmailMicroservice")
                .GetSection("ApiKey")
                .Value
        };
    }

    public void Init(SenderClientSettings settings)
    {
        _settings = settings;
    }
    public async Task SendReport()
    {
        
    }
    private async Task<string> SendGetRequest(string apiRequest, Guid userGuid)
    {
        var apiKey = _settings.ApiKey;
        var request = WebRequest.Create(apiRequest) as HttpWebRequest;
        request.PreAuthenticate = true;
        request.KeepAlive = true;
        request.Accept = "application/json";

        request.Headers.Add("X-EcoSCADA-UserGuid", userGuid.ToString());
        request.Timeout = 600000;
        request.Method = "GET";
        var response = (HttpWebResponse) await request.GetResponseAsync();
        string json;
        using (var reader = new StreamReader(response.GetResponseStream()))
        {
            json = await reader.ReadToEndAsync();
        }

        response.Close();
        return json;
    }
    private async Task<string> SendPostRequest(string apiRequest, Guid userGuid, string jsonString)
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("X-EcoSCADA-UserGuid", userGuid.ToString());

        var responseInfo = await client.PostAsync(apiRequest,
            new StringContent(jsonString, Encoding.UTF8, "application/json"));
        if (responseInfo.IsSuccessStatusCode)
        {
            return "OK";
        }

        var resultString = await responseInfo.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<Response>(resultString);
        if (result == null)
        {
            return "error 500";
        }

        return result.Erorors.FirstOrDefault().Message;
    }
    public async Task<string> SendEmail(IEmailBase email, Guid userGuid)
    {
        var jsonString = JsonSerializer.Serialize(email);
        var response = await SendPostRequest($"{_settings.ServerAddress}/messaging/Email", userGuid, jsonString);
        return response;
    }
    public async Task SendReportAsync(string filePath, IEmailBase emailBase)
    {
        var reportAsBytes = await System.IO.File.ReadAllBytesAsync(filePath);
        var reportAsBase64String = Convert.ToBase64String(reportAsBytes);
        var mail = emailBase;

        var fileNameWithExtension = Path.GetFileName(filePath);
        var attachmentFileName = fileNameWithExtension.Split(".").First();
        var attachmentFileType = fileNameWithExtension.Split(".").Last();
        mail.TracingInformation ??= new TracingInformationBase(messageSourceId: 30, messageSourceType: "Advisory");
        mail.ContentType = "string";
        mail.Attachments = new List<IAttachmentsBase>()
        {
            new AttachmentsBase
            {
                Name = $"{attachmentFileName}.{attachmentFileType}",
                ContentType = attachmentFileType,
                Attachment = reportAsBase64String,
            }
        };
        mail.MetaData = new MetaDataBase
        {
            InstanceGuid = "A9D57E83-82DA-4973-9009-17ED5BC40A45",
            AimrGuid = "A9D57E83-82DA-4973-9009-17ED5BC40A45",
            BuildingGuid = "A9D57E83-82DA-4973-9009-17ED5BC40A45",
            MeasurementGuid = "A9D57E83-82DA-4973-9009-17ED5BC40A45"
        };
            
        await SendEmail(mail, new Guid("214E066B-67A7-4F5A-81AF-8085C0889DE7"));
    }
    
    public async Task<string?> SendReportAsync(CustomFile file, IEmailBase emailBase)
    {
        var reportAsBytes = file.Bytes;
        var reportAsBase64String = Convert.ToBase64String(reportAsBytes);
        var mail = emailBase;

        var attachmentFileName = file.FileName;
        var attachmentFileType = file.ContentType;
        mail.TracingInformation ??= new TracingInformationBase(messageSourceId: 30, messageSourceType: "Advisory");
        mail.ContentType = "string";
        mail.Attachments = new List<IAttachmentsBase>()
        {
            new AttachmentsBase
            {
                Name = $"{attachmentFileName}.{attachmentFileType}",
                ContentType = attachmentFileType,
                Attachment = reportAsBase64String,
            }
        };
        mail.MetaData = new MetaDataBase
        {
            InstanceGuid = "A9D57E83-82DA-4973-9009-17ED5BC40A45",
            AimrGuid = "A9D57E83-82DA-4973-9009-17ED5BC40A45",
            BuildingGuid = "A9D57E83-82DA-4973-9009-17ED5BC40A45",
            MeasurementGuid = "A9D57E83-82DA-4973-9009-17ED5BC40A45"
        };
            
        var result = await SendEmail(mail, new Guid("78D1BF79-ADD3-4477-9B88-FEA90AE56549"));
        return result;
    }
}