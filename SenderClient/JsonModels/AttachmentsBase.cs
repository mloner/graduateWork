using System.Text.Json.Serialization;
using SenderClient.EmailMicroservice;

namespace SenderClient.JsonModels
{
    public class AttachmentsBase : IAttachmentsBase
    {
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("attachment")] public string Attachment { get; set; }
        [JsonPropertyName("contentType")] public string ContentType { get; set; }
    }
}