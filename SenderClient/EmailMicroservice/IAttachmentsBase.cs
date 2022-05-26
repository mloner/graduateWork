using System.Text.Json.Serialization;

namespace SenderClient.EmailMicroservice
{
    public interface IAttachmentsBase
    {
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("attachment")] public string Attachment { get; set; }
        [JsonPropertyName("contentType")] public string ContentType { get; set; }
    }
}