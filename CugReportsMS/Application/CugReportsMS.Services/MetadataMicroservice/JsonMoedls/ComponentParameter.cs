using Newtonsoft.Json;

namespace ApiService.MetadataMicroservice.JsonMoedls
{
    public class ComponentParameter
    {
        [JsonProperty("componentParameterId")]
        public int ComponentParameterId { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("componentTypeId")]
        public int ComponentTypeId { get; set; }
        
        [JsonProperty("pythonParam")]
        public string PythonParam { get; set; }
        
        [JsonProperty("unit")]
        public string Unit { get; set; }
        
        [JsonProperty("desctiption")]
        public string Desctiption { get; set; }
        
        [JsonProperty("validity")]
        public bool Validity { get; set; }
        
        [JsonProperty("notDeleted")]
        public bool NotDeleted { get; set; }
    }
}