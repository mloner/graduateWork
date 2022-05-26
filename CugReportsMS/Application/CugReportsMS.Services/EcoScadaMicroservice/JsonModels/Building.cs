using System;

namespace ApiService.EcoScadaMicroservice.JsonModels
{
    public class Building
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}