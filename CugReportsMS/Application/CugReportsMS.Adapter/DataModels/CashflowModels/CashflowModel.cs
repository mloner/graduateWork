namespace ReportingFramework.DataModels.CashflowModels
{
    public class CashflowModel
    {
        public int Id { get; set; }
        
        public double Consumption { get; set; }
        public double Production { get; set; }
        public double Netted { get; set; }
        public double Fixed { get; set; }
        public double EnergyCost { get; set; }
        public double Capacity { get; set; }
        public double SelfConsumed { get; set; }
        public double Taxes { get; set; }
        public double TotalElectricityCost { get; set; }
        public double AdviceCost { get; set; }
        public double Generation { get; set; }
        public double Investment { get; set; }
        public double Total { get; set; }
        
        public double ConsumptionRef {get;set;}
        public double ProductionRef {get;set;}
        public double NettedRef {get;set;}
        public double FixedRef { get; set; }
        public double EnergyCostRef {get;set;}
        public double CapacityRef {get;set;}
        public double SelfConsumedRef { get; set; }
        public double TaxesRef {get;set;}
        public double TotalElectricityCostRef {get;set;}
        public double AdviceCostRef { get; set; }
        public double GenerationRef {get;set;}
        public double InvestmentRef {get;set;}
        public double TotalRef {get;set;}
        
        
        public double Differences { get; set; }
        public double DifferencesDiscount { get; set; }
        
        public double Npv { get; set; }
        
    }
}