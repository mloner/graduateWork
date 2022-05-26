using Newtonsoft.Json;

namespace PdfReportTemplaterClient.Dtos;

public class Meta
{
    public string name { get; set; }
    public string display_name { get; set; }
    public string encoding { get; set; }

    [JsonProperty("content-type")]
    public string ContentType { get; set; }
}