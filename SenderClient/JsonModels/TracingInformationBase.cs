using System.Text.Json.Serialization;
using SenderClient.EmailMicroservice;

namespace SenderClient.JsonModels
{
    public class TracingInformationBase : ITracingInformationBase
    {
        public TracingInformationBase()
        {
        }

        public TracingInformationBase(int messageSourceId, string messageSourceType)
        {
            MessageSourceId = messageSourceId;
            MessageSourceType = messageSourceType;
        }

        [JsonPropertyName("messageSourceType")] public string MessageSourceType { get; set; }
        [JsonPropertyName("messageSourceId")] public int MessageSourceId { get; set; }
    }
}