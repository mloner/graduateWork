using System;
using Newtonsoft.Json;

namespace ApiService.MetadataMicroservice.JsonMoedls
{
    public class Component
    {
        [JsonProperty("componentId")]
        public int ComponentId { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("componentTypeId")]
        public int ComponentTypeId { get; set; }
        
        [JsonProperty("dateAdded")]
        public DateTime? DateAdded { get; set; }
        
        [JsonProperty("notDeleted")]
        public bool NotDeleted { get; set; }
    }
}