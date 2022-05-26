using Newtonsoft.Json;

namespace ReportingFramework.DataModels.Params
{
    public class FinancialParams : Params
    {
        [JsonProperty("Financial")]
        public Financial Financial { get; set; }
    }
    
    public class _5
    {
        [JsonProperty("finance.inflation")]
        public double FinanceInflation { get; set; }

        [JsonProperty("finance.fcr_deflation")]
        public double FinanceFcrDeflation { get; set; }

        [JsonProperty("finance.discount_rate")]
        public double FinanceDiscountRate { get; set; }

        [JsonProperty("finance.loan_rate")]
        public double FinanceLoanRate { get; set; }

        [JsonProperty("finance.loan_duration")]
        public double FinanceLoanDuration { get; set; }

        [JsonProperty("finance.npv_period")]
        public double FinanceNpvPeriod { get; set; }
    }

    public class Financial
    {
        [JsonProperty("5")]
        public _5 _5 { get; set; }
    }
}