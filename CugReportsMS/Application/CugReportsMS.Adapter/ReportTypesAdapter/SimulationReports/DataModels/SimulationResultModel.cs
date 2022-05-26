using ReportingFramework.DataModels;

namespace ReportingFramework.ReportTypesAdapter.SimulationReports.DataModels
{
    public class SimulationResultModel : ResultsModel
    {
        public int GridId { get; set; }
        public int BatteryId { get; set; }
        public string Algo { get; set; }
        public double BatteryCapacity { get; set; }
        public double ProductionEnergy { get; set; }
        public double TotalDemandEnergy { get; set; }
        public double InjectedEnergy { get; set; }
        public double MaxInjection { get; set; }
        public double ConsumptionEnergy { get; set; }
        public double Capacity { get; set; }
        public double Investment { get; set; }
        public double CyclesUsed { get; set; }
        public double Npv { get; set; }
        public double ProductionRevenue { get; set; }
        public double Netted { get; set; }
        public double ConsumptionCost { get; set; }
        public double CapacityCost { get; set; }
        public double OperationalCost { get; set; }
        public bool IsDam { get; set; }
        public double AdviceCost { get; set; }
        public double Total { get; set; }
        public double Csr { get; set; }
        public double BuyPrice { get; set; }
        public double SellPrice { get; set; }
    }
}