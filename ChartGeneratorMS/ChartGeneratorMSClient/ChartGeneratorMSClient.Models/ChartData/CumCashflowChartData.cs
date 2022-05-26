namespace ChartGeneratorModels.ChartData
{
    public class CumCashflowChartData : global::ChartGeneratorModels.ChartGeneratorModels.ChartData
    {
        public List<CumCashflowChartDataItem> Items { get; set; }
        public List<int> PaybackPeriod { get; set; }
        
        
        // public override List<SectionParameterValuesDto> AsParameterValues()
        // {
        //     var res = new List<SectionParameterValuesDto>();
        //
        //     //cumcashflow data
        //     foreach (var item in Items)
        //     {
        //         res.Add(new SectionParameterValuesDto()
        //         {
        //             SectionParameterName = "Data",
        //             Name = "CumCashflow",
        //             Datetime = new DateTime(item.Year, 1, 1),
        //             Value = item.Value.ToString(CultureInfo.InvariantCulture)
        //         });
        //     }
        //     
        //     //payback period
        //     //years
        //     res.Add(new SectionParameterValuesDto()
        //     {
        //         SectionParameterName = "Data",
        //         Name = "PaybackPeriodYears",
        //         Value = PaybackPeriod[0].ToString(CultureInfo.InvariantCulture)
        //     });
        //     //months
        //     res.Add(new SectionParameterValuesDto()
        //     {
        //         SectionParameterName = "Data",
        //         Name = "PaybackPeriodMonths",
        //         Value = PaybackPeriod[1].ToString(CultureInfo.InvariantCulture)
        //     });
        //
        //     return res;
        // }
        // public override ChartGeneratorMSClient.ReportGeneratorClient.Models.ChartGeneratorMSClient.Models.ChartData Init(List<SectionParameterValuesDto> sectionParameterValuesDto)
        // {
        //     //cumcashflow data
        //     Items = sectionParameterValuesDto.Where(x => x.Name == "CumCashflow")
        //         .Select(x => new CumCashflowChartDataItem()
        //         {
        //             Year = x.Datetime.Value.Year,
        //             Value = double.Parse(x.Value, CultureInfo.InvariantCulture)
        //         })
        //         .OrderBy(x => x.Year)
        //         .ToList();
        //     
        //     //payback period
        //     var paybackPeriodYears = int.Parse(sectionParameterValuesDto
        //         .First(x => x.Name == "PaybackPeriodYears").Value, CultureInfo.InvariantCulture);
        //     var paybackPeriodMonths = int.Parse(sectionParameterValuesDto
        //         .First(x => x.Name == "PaybackPeriodMonths").Value, CultureInfo.InvariantCulture);
        //     PaybackPeriod = new List<int>();
        //     PaybackPeriod.Add(paybackPeriodYears);
        //     PaybackPeriod.Add(paybackPeriodMonths);
        //     
        //     return this;
        // }
    }

    public class CumCashflowChartDataItem
    {
        public int Year { get; set; }
        public double Value { get; set; }
    }
}