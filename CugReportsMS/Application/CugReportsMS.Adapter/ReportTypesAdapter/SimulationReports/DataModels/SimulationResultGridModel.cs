using System;

namespace ReportingFramework.ReportTypesAdapter.SimulationReports.DataModels
{
    public class SimulationResultGridModel
    {
        public DateTime DateTime { get; set; }
        public int? I { get; set; }
        public ulong? Timestamp { get; set; }
        public double? Objective { get; set; }
        public double? ConstraintViolation { get; set; }
        public double? OptimizerTerminationCondition { get; set; }
        public double? GridPower { get; set; }
        public double? GridConsumptionPrice { get; set; }
        public double? GridProductionPrice { get; set; }
        public double? GridCapacityPrice { get; set; }
        public double? GridFcrPrice { get; set; }
        public double? GridGenerationPrice { get; set; }
        public double? GridConsumptionPower { get; set; }
        public double? GridProductionPower { get; set; }
        public double? GridConsumptionPowerMax { get; set; }
        public double? GridProductionPowerMax { get; set; }
        public double? GridOperationalCost { get; set; }
        public double? GridMaxCapacity { get; set; }
        public double? GridMaxPeakEnlargement { get; set; }
        public double? GridPeakEnlargement { get; set; }
        public double? GridTargetedCapacity { get; set; }
        public double? DemandPower { get; set; }
        public double? PvPower { get; set; }
        public double? BatteryPower { get; set; }
        public double? BatteryEnergy { get; set; }
        public double? BatteryMinSocBattery { get; set; }
        public double? BatteryMaxSocBattery { get; set; }
        public double? BatteryChargePowerMax { get; set; }
        public double? BatteryDischargePowerMax { get; set; }
        public double? BatteryEnergyMax { get; set; }
        public double? BatteryEnergyNFcr { get; set; }
        public double? BatteryEnergyPFcr { get; set; }
        public double? BatteryFcrReserved { get; set; }
        public double? BatteryOperationalCost { get; set; }
    }
}