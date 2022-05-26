using System.Collections.Generic;

namespace ApiService.MetadataMicroservice.JsonMoedls
{
    public class ComponentWithParametersWithValues : Component
    {
        public List<ComponentParameterWithValue> ComponentParameters { get; set; }
    }
}