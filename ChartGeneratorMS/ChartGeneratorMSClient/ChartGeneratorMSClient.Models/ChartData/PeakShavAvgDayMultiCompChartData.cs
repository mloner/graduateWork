namespace ChartGeneratorModels.ChartData
{
    public class PeakShavAvgDayMultiCompChartData : global::ChartGeneratorModels.ChartGeneratorModels.ChartData
    {
        public Dictionary<int, double> ValuesRef { get; set; }
        public Dictionary<int, double> ValuesAlt { get; set; }
        public Dictionary<int, double> ValuesMain { get; set; }
        
        public double PeakRef { get; set; }
        public double PeakAlt { get; set; }
        public double PeakMain { get; set; }
        
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
        //     foreach (var keyValuePair in ValuesAlt)
        //     {
        //         res.Add(new SectionParameterValuesDto()
        //         {
        //             SectionParameterName = "Data",
        //             Name = "ValuesAlt",
        //             Datetime = new DateTime(1970,1,1,keyValuePair.Key,0,0),
        //             Value = keyValuePair.Value.ToString(CultureInfo.InvariantCulture)
        //         });
        //     }
        //     foreach (var keyValuePair in ValuesMain)
        //     {
        //         res.Add(new SectionParameterValuesDto()
        //         {
        //             SectionParameterName = "Data",
        //             Name = "ValuesMain",
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
        //         Name = "PeakAlt",
        //         Value = PeakAlt.ToString(CultureInfo.InvariantCulture)
        //     });
        //     res.Add(new SectionParameterValuesDto()
        //     {
        //         SectionParameterName = "Data",
        //         Name = "PeakMain",
        //         Value = PeakMain.ToString(CultureInfo.InvariantCulture)
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
        //     ValuesAlt =  sectionParameterValuesDto.Where(x => x.Name == "ValuesAlt")
        //         .Select(x => new KeyValuePair<int, double>(x.Datetime.Value.Hour,
        //             double.Parse(x.Value, CultureInfo.InvariantCulture)))
        //         .OrderBy(x => x.Key)
        //         .ToDictionary(x => x.Key, x => x.Value);
        //     ValuesMain =  sectionParameterValuesDto.Where(x => x.Name == "ValuesMain")
        //         .Select(x => new KeyValuePair<int, double>(x.Datetime.Value.Hour,
        //             double.Parse(x.Value, CultureInfo.InvariantCulture)))
        //         .OrderBy(x => x.Key)
        //         .ToDictionary(x => x.Key, x => x.Value);
        //
        //     PeakRef = double.Parse(sectionParameterValuesDto.First(x => x.Name == "PeakRef")
        //         .Value, CultureInfo.InvariantCulture);
        //     PeakAlt = double.Parse(sectionParameterValuesDto.First(x => x.Name == "PeakAlt")
        //         .Value, CultureInfo.InvariantCulture);
        //     PeakMain = double.Parse(sectionParameterValuesDto.First(x => x.Name == "PeakMain")
        //         .Value, CultureInfo.InvariantCulture);
        //     
        //
        //     return this;
        // }
    }
}