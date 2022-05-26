using System.Text.Json.Serialization;

namespace SenderClient.EmailMicroservice
{
    public interface IMetaDataBase
    {
        [JsonPropertyName("instanceGuid")] public string InstanceGuid { get; set; }
        [JsonPropertyName("aimrGuid")] public string AimrGuid { get; set; }
        [JsonPropertyName("BuildingGuid")] public string BuildingGuid { get; set; }
        [JsonPropertyName("MeasurementGuid")] public string MeasurementGuid { get; set; }
    }
}