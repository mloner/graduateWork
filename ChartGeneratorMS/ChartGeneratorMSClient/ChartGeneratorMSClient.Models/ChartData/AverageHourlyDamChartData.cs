namespace ChartGeneratorModels.ChartData
{
    public class AverageHourlyDamChartData : global::ChartGeneratorModels.ChartGeneratorModels.ChartData
    {
        public Dictionary<int, double> AllDays { get; set; }
        public Dictionary<int, double> WorkingDays { get; set; }
        public Dictionary<int, double> Weekends { get; set; }

        // public override List<SectionParameterValuesDto> AsParameterValues()
        // {
        //     var res = new List<SectionParameterValuesDto>();
        //     
        //     foreach (var demandEl in AllDays)
        //     {
        //         res.Add(new SectionParameterValuesDto()
        //         {
        //             SectionParameterName = "Data",
        //             Name = "AllDays",
        //             Datetime = new DateTime(1970, 01, 01, demandEl.Key, 0, 0),
        //             Value = demandEl.Value.ToString(CultureInfo.InvariantCulture)
        //         });
        //     }
        //     foreach (var demandEl in WorkingDays)
        //     {
        //         res.Add(new SectionParameterValuesDto()
        //         {
        //             SectionParameterName = "Data",
        //             Name = "WorkingDays",
        //             Datetime = new DateTime(1970, 01, 01, demandEl.Key, 0, 0),
        //             Value = demandEl.Value.ToString(CultureInfo.InvariantCulture)
        //         });
        //     }
        //     foreach (var demandEl in Weekends)
        //     {
        //         res.Add(new SectionParameterValuesDto()
        //         {
        //             SectionParameterName = "Data",
        //             Name = "Weekends",
        //             Datetime = new DateTime(1970, 01, 01, demandEl.Key, 0, 0),
        //             Value = demandEl.Value.ToString(CultureInfo.InvariantCulture)
        //         });
        //     }
        //
        //
        //     return res;
        // }
        //
        // public override ChartGeneratorClient.ReportGeneratorClient.Models.ChChartGeneratorMSClient.ModelshartData Init(List<SectionParameterValuesDto> sectionParameterValuesDto)
        // {
        //     AllDays = sectionParameterValuesDto.Where(x => x.Name == "AllDays")
        //         .Select(x => new KeyValuePair<int, double>(x.Datetime.Value.Hour,
        //             double.Parse(x.Value, CultureInfo.InvariantCulture)))
        //         .OrderBy(x => x.Key)
        //         .ToDictionary(x => x.Key, x => x.Value);
        //     
        //     WorkingDays = sectionParameterValuesDto.Where(x => x.Name == "WorkingDays")
        //         .Select(x => new KeyValuePair<int, double>(x.Datetime.Value.Hour,
        //             double.Parse(x.Value, CultureInfo.InvariantCulture)))
        //         .OrderBy(x => x.Key)
        //         .ToDictionary(x => x.Key, x => x.Value);
        //     
        //     Weekends = sectionParameterValuesDto.Where(x => x.Name == "Weekends")
        //         .Select(x => new KeyValuePair<int, double>(x.Datetime.Value.Hour,
        //             double.Parse(x.Value, CultureInfo.InvariantCulture)))
        //         .OrderBy(x => x.Key)
        //         .ToDictionary(x => x.Key, x => x.Value);
        //
        //     return this;
        // }
    }
}