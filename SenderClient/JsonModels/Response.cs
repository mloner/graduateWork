using System.Text.Json.Serialization;

namespace SenderClient.JsonModels
{
    public class Response
    {
        [JsonPropertyName("erorors")] public List<Errors> Erorors { get; set; }
    }

    public class Errors
    {
        [JsonPropertyName("code")] public string Code { get; set; }
        [JsonPropertyName("message")] public string Message { get; set; }
    }
}