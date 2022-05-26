using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using ReportingFramework.ReportTypesAdapter.AlgoComp.DataModels;

namespace ReportingFramework.ReportTypesAdapter.AlgoComp
{
    public class AlgoCompJabbaCsvReader : CsvReader
    {
        public List<GridPowerDataModel> GetGridPowerDataModels(string fileName)
        {
            var result = new List<GridPowerDataModel>();
            using (TextReader reader = File.OpenText(fileName))
            {
                var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture);
                csv.Configuration.Delimiter = ",";
                csv.Configuration.MissingFieldFound = null;
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    result.Add(new GridPowerDataModel()
                    {
                        DateTime = DateTime.Parse(csv.GetField<string>(0)),
                        Value = csv.GetField<double?>("grid.power")
                    });
                }
            }

            return result;
        }
        
        public List<GridPowerDataModel> GetRefData(string fileName)
        {
            var result = new List<GridPowerDataModel>();
            using (TextReader reader = File.OpenText(fileName))
            {
                int currentYear = DateTime.Now.Year;
                
                var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture);
                csv.Configuration.Delimiter = ",";
                csv.Configuration.MissingFieldFound = null;
                csv.Read();
                csv.ReadHeader();
                int i = 0;
                while (csv.Read())
                {
                    i++;
                    result.Add(new GridPowerDataModel()
                    { 
                        DateTime = DateTime.Parse(csv.GetField<string>(0)),
                        Value = csv.GetField<double?>("grid_data")
                    });
                }
            }

            return result;
        }
        
        public List<AlgoCompResultsModel> GetResultsFromCsv(string fileName)
        {
            var result = new List<AlgoCompResultsModel>();
            using (TextReader reader = File.OpenText(fileName))
            {
                
                var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture);
                csv.Configuration.Delimiter = ",";
                csv.Configuration.MissingFieldFound = null;
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    result.Add(new AlgoCompResultsModel()
                    { 
                        CaseName = csv.GetField<string>(""),
                        Algo = csv.GetField<string>("algo"),
                        GridId = csv.GetField<double>("grid_id"),
                        BatteryId = csv.GetField<string>("battery_id"),
                        BatteryCapacity = csv.GetField<double>("battery"),
                        ProductionEnergy = csv.GetField<double>("production_energy"),
                        TotalDemandEnergy = csv.GetField<double>("total_demand_energy"),
                        InjectedEnergy = csv.GetField<double>("injected_energy"),
                        MaxInjection = csv.GetField<double>("maximum_injection"),
                        ConsumptionEnergy = csv.GetField<double>("consumption_energy"),
                        Capacity = csv.GetField<double>("capacity"),
                        YearlyBatteryPrice = csv.GetField<double>("yearly_battery_price"),
                        Cycle =  csv.GetField<double>("cycle"),
                        Npv =  csv.GetField<double>("NPVs"),
                        ProductionRevenue =  csv.GetField<double>("production_revenue"),
                        ConsumptionCost =  csv.GetField<double>("consumption_cost"),
                        CapacityCost =  csv.GetField<double>("capacity_cost"),
                        OperationalCost =  csv.GetField<double>("operational_cost"),
                        IsDynamicTariff =  csv.GetField<bool>("DAM"),
                        ServiceFeeCost =  csv.GetField<double>("Advice_cost"),
                        Total =  csv.GetField<double>("Total"),
                    });
                }
            }

            return result;
        }
    }
}