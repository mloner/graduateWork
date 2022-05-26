using System.Text.Json.Serialization;

namespace SenderClient.EmailMicroservice
{
    public interface IEmailBase
    {
        [JsonPropertyName("tracingInformation")] public ITracingInformationBase TracingInformation { get; set; }
        [JsonPropertyName("recipients")] public List<string> Recipients { get; set; }
        [JsonPropertyName("additionalRecipients")] public List<string> additionalRecipients { get; set; }
        [JsonPropertyName("subject")] public string Subject { get; set; }
        [JsonPropertyName("content")] public string Content { get; set; }
        [JsonPropertyName("contentType")] public string ContentType { get; set; }
        [JsonPropertyName("attachments")] public List<IAttachmentsBase> Attachments { get; set; }
        [JsonPropertyName("metadata")] public IMetaDataBase MetaData { get; set; }
    }
}