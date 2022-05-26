using System.Collections.Generic;

namespace ApiService.EcoScadaMicroservice.JsonModels
{
    public class MeasurementDetails : Measurement
    {
        public IEnumerable<Input> Inputs { get; set; }
    }
}