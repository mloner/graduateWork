namespace ApiService.EcoScadaMicroservice.JsonModels
{
    public class Medium
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string MediumTypeId { get; set; }
        public string PrimaryUnit { get; set; }
        public string PrimaryUnitPerHour { get; set; }
        public string SecondaryUnit { get; set; }
        public string SecondaryUnitPerHour { get; set; }
        public string PrimaryFactor { get; set; }
        public string SecondaryFactor { get; set; }
    }
}