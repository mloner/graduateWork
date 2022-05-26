using Newtonsoft.Json;

namespace ApiService.MetadataMicroservice.JsonMoedls
{
    public class ComponentParameterValue
    {
        [JsonProperty("componentValueId")]
        public int СomponentValueId { get; set; }
        
        [JsonProperty("value")]
        public string Value { get; set; }
        
        [JsonProperty("componentId")]
        public int ComponentId { get; set; }
        
        [JsonProperty("componentParameterId")]
        public int ComponentParameterId { get; set; }
    }
}