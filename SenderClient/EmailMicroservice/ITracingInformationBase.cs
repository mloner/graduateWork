using System.Text.Json.Serialization;

namespace SenderClient.EmailMicroservice
{
    public interface ITracingInformationBase
    {
        [JsonPropertyName("messageSourceType")] public string MessageSourceType { get; set; }
        [JsonPropertyName("messageSourceId")] public int MessageSourceId { get; set; }
    }
}