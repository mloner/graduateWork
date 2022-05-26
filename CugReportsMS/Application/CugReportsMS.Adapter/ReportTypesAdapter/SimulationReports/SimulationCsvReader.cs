using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using ReportingFramework.ReportTypesAdapter.SimulationReports.DataModels;

namespace ReportingFramework.ReportTypesAdapter.SimulationReports
{
    public class SimulationCsvReader : CsvReader
    {
        public List<SimulationResultGridModel> GetGridResults(string fileName)
        {
            var result = new List<SimulationResultGridModel>();
            using (TextReader reader = File.OpenText(fileName))
            {
                var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture);
                csv.Configuration.Delimiter = ",";
                csv.Configuration.MissingFieldFound = null;
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    result.Add(new SimulationResultGridModel()
                    { 
                        DateTime = csv.GetField<DateTime>("time"),
                        Timestamp = csv.GetField<ulong?>("timestamp"),
                        GridPower = csv.GetField<double?>("grid.power"),
                        
                        GridConsumptionPrice = csv.GetField<double?>("grid.consumption_price"),
                        GridProductionPrice = csv.GetField<double?>("grid.production_price"),
                        GridCapacityPrice = csv.GetField<double?>("grid.capacity_price"),
                        GridFcrPrice = csv.GetField<double?>("grid.fcr_price"),
                        GridGenerationPrice = csv.GetField<double?>("grid.generation_price"),
                        
                        GridConsumptionPower = csv.GetField<double?>("grid.consumption_power"),
                        GridProductionPower = csv.GetField<double?>("grid.production_power"),
                        
                        GridOperationalCost = csv.GetField<double?>("grid.operational_cost"),
                        GridMaxCapacity = csv.GetField<double?>("grid.maximum_capacity"),
                        GridPeakEnlargement = csv.GetField<double?>("grid.peak_enlargement"),
                        GridTargetedCapacity = csv.GetField<double?>("grid.targeted_capacity"),
                        
                        DemandPower = csv.GetField<double?>("demand.power"),
                        PvPower = csv.GetField<double?>("pv.power"),
                        BatteryPower = csv.GetField<double?>("battery.power"),
                        BatteryEnergy = csv.GetField<double?>("battery.energy"),
                    });
                }
            }

            return result;
        }
        
        public List<SimulationResultModel> GetResults(string fileName)
        {
            var result = new List<SimulationResultModel>();
            using (TextReader reader = File.OpenText(fileName))
            {
                var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture);
                csv.Configuration.Delimiter = ",";
                csv.Configuration.MissingFieldFound = null;
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    result.Add(new SimulationResultModel()
                    { 
                        CaseId = csv.GetField<int>(0),
                        GridId = csv.GetField<int>("grid_id"),
                        BatteryId = csv.GetField<int>("battery_id"),
                        Algo = csv.GetField<string>("algo"),
                        BatteryCapacity = csv.GetField<double>("battery"),
                        ProductionEnergy = csv.GetField<double>("production_energy"),
                        TotalDemandEnergy = csv.GetField<double>("total_demand_energy"),
                        InjectedEnergy = csv.GetField<double>("injected_energy"),
                        MaxInjection = csv.GetField<double>("maximum_injection"),
                        ConsumptionEnergy = csv.GetField<double>("consumption_energy"),
                        Capacity = csv.GetField<double>("capacity"),
                        Investment = csv.GetField<double>("investments"),
                        CyclesUsed = csv.GetField<double>("cycle"),
                        Npv = csv.GetField<double>("NPVs"),
                        ProductionRevenue = csv.GetField<double>("production_revenue"),
                        ConsumptionCost = csv.GetField<double>("consumption_cost"),
                        CapacityCost = csv.GetField<double>("capacity_cost"),
                        OperationalCost = csv.GetField<double>("operational_cost"),
                        IsDam = csv.GetField<bool>("DAM"),
                        AdviceCost =  csv.GetField<double>("Advice_cost"),
                        Total = csv.GetField<double>("Total"),
                        Csr = csv.GetField<double>("scr, %"),
                        Netted = csv.GetField<double>("netted"),
                        BuyPrice = csv.GetField<double>("buy_price"),
                        SellPrice = csv.GetField<double>("sell_price"),
                    });
                }
            }

            return result;
        }
    }
}