namespace ChartGeneratorModels.ChartData
{
    public class PeakShavMonthlyChartData : global::ChartGeneratorModels.ChartGeneratorModels.ChartData
    {
        public List<DateTime> Categories { get; set; }
        public List<double> ValuesRef { get; set; }
        public List<double> ValuesBest { get; set; }
        public double? PeakTariff { get; set; }
        public double PeakRef{ get; set; }
        public double PeakBest { get; set; }
        
        // public override List<SectionParameterValuesDto> AsParameterValues()
        // {
        //     var res = new List<SectionParameterValuesDto>();
        //
        //     //Categories
        //     foreach (var dateTime in Categories)
        //     {
        //         res.Add(new SectionParameterValuesDto()
        //         {
        //             SectionParameterName = "Data",
        //             Name = "Categories",
        //             Datetime = dateTime
        //         });
        //     }
        //     //ValuesRef
        //     foreach (var d in ValuesRef)
        //     {
        //         res.Add(new SectionParameterValuesDto()
        //         {
        //             SectionParameterName = "Data",
        //             Name = "ValuesRef",
        //             Value = d.ToString(CultureInfo.InvariantCulture)
        //         });
        //     }
        //     //ValuesBest
        //     foreach (var d in ValuesBest)
        //     {
        //         res.Add(new SectionParameterValuesDto()
        //         {
        //             SectionParameterName = "Data",
        //             Name = "ValuesBest",
        //             Value = d.ToString(CultureInfo.InvariantCulture)
        //         });
        //     }
        //     res.Add(new SectionParameterValuesDto()
        //     {
        //         SectionParameterName = "Data",
        //         Name = "PeakRef",
        //         Value = PeakRef.ToString(CultureInfo.InvariantCulture)
        //     });
        //     res.Add(new SectionParameterValuesDto()
        //     {
        //         SectionParameterName = "Data",
        //         Name = "PeakBest",
        //         Value = PeakBest.ToString(CultureInfo.InvariantCulture)
        //     });
        //     res.Add(new SectionParameterValuesDto()
        //     {
        //         SectionParameterName = "Data",
        //         Name = "PeakTariff",
        //         Value = PeakTariff?.ToString(CultureInfo.InvariantCulture)
        //     });
        //     
        //     return res;
        // }
        //
        // public override ChartGeneratorMSClient.ReportGeneratorClient.Models.ChartGeneratorMSClient.Models.ChartData Init(List<SectionParameterValuesDto> sectionParameterValuesDto)
        // {
        //     Categories = sectionParameterValuesDto.Where(x => x.Name == "Categories")
        //         .OrderBy(x => x.Datetime)
        //         .Select(x => x.Datetime.Value).ToList();
        //     ValuesRef = sectionParameterValuesDto.Where(x => x.Name == "ValuesRef")
        //         .Select(x => double.Parse(x.Value, CultureInfo.InvariantCulture)).ToList();
        //     ValuesBest = sectionParameterValuesDto.Where(x => x.Name == "ValuesBest")
        //         .Select(x => double.Parse(x.Value, CultureInfo.InvariantCulture)).ToList();
        //     PeakRef = double.Parse(sectionParameterValuesDto.First(x => x.Name == "PeakRef")
        //         .Value, CultureInfo.InvariantCulture);
        //     PeakBest = double.Parse(sectionParameterValuesDto.First(x => x.Name == "PeakBest")
        //         .Value, CultureInfo.InvariantCulture);
        //     try
        //     {
        //         PeakTariff = double.Parse(sectionParameterValuesDto.First(x => x.Name == "PeakTariff")
        //             .Value, CultureInfo.InvariantCulture);
        //     }
        //     catch (Exception e)
        //     {
        //         PeakTariff = null;
        //     }
        //     
        //     return this;
        // }
    }
}