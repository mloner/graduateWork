using Newtonsoft.Json;

namespace ReportingFramework.DataModels.CustomerData
{
    public class CustomerData
    {
        [JsonProperty("customer_metadata")]
        public CustomerMetadata_ CustomerMetadata_ { get; set; }
    }
    public class Building
    {
        [JsonProperty("customer")]
        public string Customer { get; set; }

        [JsonProperty("e-mail")]
        public string EMail { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("building_name")]
        public string BuildingName { get; set; }

        [JsonProperty("size_PV_kWp")]
        public string SizePVKWp { get; set; }

        [JsonProperty("grid.active_energy.import")]
        public string GridActiveEnergyImport { get; set; }

        [JsonProperty("grid.active_energy.export")]
        public string GridActiveEnergyExport { get; set; }

        [JsonProperty("solar.active_energy.export")]
        public string SolarActiveEnergyExport { get; set; }
    }

    public class Tariffs
    {
        [JsonProperty("high")]
        public string High { get; set; }

        [JsonProperty("low")]
        public string Low { get; set; }

        [JsonProperty("feed-in")]
        public string FeedIn { get; set; }
    }

    public class ElectricityPrices
    {
        [JsonProperty("Country")]
        public string Country { get; set; }

        [JsonProperty("Region")]
        public string Region { get; set; }

        [JsonProperty("DSO")]
        public string DSO { get; set; }

        [JsonProperty("tariffs")]
        public Tariffs Tariffs { get; set; }
    }

    public class Cug
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("building")]
        public Building Building { get; set; }

        [JsonProperty("electricity_prices")]
        public ElectricityPrices ElectricityPrices { get; set; }
    }

    public class Task
    {
        [JsonProperty("task_type")]
        public string TaskType { get; set; }

        [JsonProperty("cug")]
        public Cug Cug { get; set; }
    }

    public class CustomerMetadata_
    {
        [JsonProperty("reseller")]
        public string Reseller { get; set; }

        [JsonProperty("request")]
        public string Request { get; set; }

        [JsonProperty("task")]
        public Task Task { get; set; }
    }
}