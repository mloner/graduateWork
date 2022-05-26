namespace ChartGeneratorModels.ChartData
{
    public class PeakShavAvgDayChartData : global::ChartGeneratorModels.ChartGeneratorModels.ChartData
    {
        public Dictionary<int, double> ValuesRef { get; set; }
        public Dictionary<int, double> ValuesBest { get; set; }
        
        public double PeakRef { get; set; }
        public double PeakBest { get; set; }
        public double? PeakTariff { get; set; }
        
        
        // public override List<SectionParameterValuesDto> AsParameterValues()
        // {
        //     var res = new List<SectionParameterValuesDto>();
        //
        //     foreach (var keyValuePair in ValuesRef)
        //     {
        //         res.Add(new SectionParameterValuesDto()
        //         {
        //             SectionParameterName = "Data",
        //             Name = "ValuesRef",
        //             Datetime = new DateTime(1970,1,1,keyValuePair.Key,0,0),
        //             Value = keyValuePair.Value.ToString(CultureInfo.InvariantCulture)
        //         });
        //     }
        //     foreach (var keyValuePair in ValuesBest)
        //     {
        //         res.Add(new SectionParameterValuesDto()
        //         {
        //             SectionParameterName = "Data",
        //             Name = "ValuesBest",
        //             Datetime = new DateTime(1970,1,1,keyValuePair.Key,0,0),
        //             Value = keyValuePair.Value.ToString(CultureInfo.InvariantCulture)
        //         });
        //     }
        //     
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
        //     ValuesRef =  sectionParameterValuesDto.Where(x => x.Name == "ValuesRef")
        //         .Select(x => new KeyValuePair<int, double>(x.Datetime.Value.Hour,
        //             double.Parse(x.Value, CultureInfo.InvariantCulture)))
        //         .OrderBy(x => x.Key)
        //         .ToDictionary(x => x.Key, x => x.Value);
        //     
        //     ValuesBest =  sectionParameterValuesDto.Where(x => x.Name == "ValuesBest")
        //         .Select(x => new KeyValuePair<int, double>(x.Datetime.Value.Hour,
        //             double.Parse(x.Value, CultureInfo.InvariantCulture)))
        //         .OrderBy(x => x.Key)
        //         .ToDictionary(x => x.Key, x => x.Value);
        //
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
        //
        //
        //     return this;
        // }
    }
}