using ReportingFramework.DataModels;

namespace ReportingFramework.ReportTypesAdapter.AlgoComp.DataModels
{
    public class AlgoCompResultsModel : ResultsModel
    {
        public double? GridId { get; set; }
        public string BatteryId { get; set; }
        public double? BatteryCapacity { get; set; }
        public double? ProductionEnergy { get; set; }
        public double? TotalDemandEnergy { get; set; }
        public double? InjectedEnergy { get; set; }
        public double? ConsumptionEnergy { get; set; }
        public double? Capacity { get; set; }
        public double? YearlyBatteryPrice { get; set; }
        public double? Cycle { get; set; }
        public double? Npv { get; set; }
        public double? ProductionRevenue { get; set; }
        public double? ConsumptionCost { get; set; }
        public double? CapacityCost { get; set; }
        public double? OperationalCost { get; set; }
        public double? Total { get; set; }
        public double? MaxInjection { get; set; }
        public bool IsDynamicTariff { get; set; }
        public double ServiceFeeCost { get; set; }
        public string Algo { get; set; }
        public string CaseName { get; set; }
    }
}