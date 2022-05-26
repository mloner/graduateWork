using System;

namespace ApiService.EcoScadaMicroservice.JsonModels
{
    public class Input
    {
        public string Name { get; set; }
        public Guid Guid { get; set; }
        public string Sign { get; set; }
        public string Factor { get; set; }
        
        public string Id { get; set; }
        public string SupplierName { get; set; }
        public string Scaling { get; set; }
        public string Offset { get; set; }
        public object Description { get; set; }
        public object Virtual { get; set; }
        public object Eanid { get; set; }
        public bool IsMeterBidirectional { get; set; }
        public Medium Medium { get; set; }
        public GateTime GateTime { get; set; }
        public string AimrGuid { get; set; }
        public string InputNumber { get; set; }
        public string InputType { get; set; }
        public object StartDate { get; set; }
        public object EndDate { get; set; }
        public bool Commercial { get; set; }
        public bool IsIncludedInRaport { get; set; }
    }

}