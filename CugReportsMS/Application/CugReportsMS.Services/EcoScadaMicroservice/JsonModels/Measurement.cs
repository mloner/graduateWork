using System;
using System.Collections.Generic;

namespace ApiService.EcoScadaMicroservice.JsonModels
{
    public class Measurement
    {
        public string Name { get; set; }
        public Guid Guid { get; set; }
        public bool IsTotal { get; set; }
        
        public string Id { get; set; }
        public string Virtual { get; set; }
        public string ShortName { get; set; }
        public string Formula { get; set; }
        public Medium Medium { get; set; }
        public GateTime GateTime { get; set; }
        public List<Input> Inputs { get; set; }
        public List<Property> Properties { get; set; }

    }

    
}