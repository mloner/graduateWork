using System;
using Newtonsoft.Json;

namespace ApiService.EcoScadaMicroservice.JsonModels
{
    public class MeasurementValue
    {
        [JsonProperty("v")] 
        public double? Value { get; set; }
        
        [JsonProperty("ts")] 
        public DateTime DateTime { get; set; }
        
        [JsonProperty("tp")] 
        public int? Tp { get; set; }
    }
}