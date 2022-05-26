namespace ChartGeneratorModels.ChartData
{
    public class DistributionHourlyChartData : global::ChartGeneratorModels.ChartGeneratorModels.ChartData
    {
        public Dictionary<TimeSpan, Dictionary<double, double>> Values;
        
        // public override List<SectionParameterValuesDto> AsParameterValues()
        // {
        //     var res = new List<SectionParameterValuesDto>();
        //     
        //     foreach (var hourPart in Values)
        //     {
        //         foreach (var hourPartValues in hourPart.Value)
        //         {
        //             res.Add(new SectionParameterValuesDto()
        //             {
        //                 SectionParameterName = "Data",
        //                 Datetime = new DateTime(2000, 01, 01, hourPart.Key.Hours, hourPart.Key.Minutes, 0),
        //                 Name = hourPartValues.Key.ToString(CultureInfo.InvariantCulture),
        //                 Value = hourPartValues.Value.ToString(CultureInfo.InvariantCulture)
        //             });
        //         }
        //     }
        //
        //     return res;
        // }
        //
        // public override ChartGeneratorMSClient.ReportGeneratorClient.Models.ChartGeneratorMSClient.Models.ChartData Init(List<SectionParameterValuesDto> sectionParameterValuesDto)
        // {
        //     Values = sectionParameterValuesDto
        //         .GroupBy(x => x.Datetime)
        //         .OrderBy(x => x.Key)
        //         .ToDictionary
        //         (
        //             g1 => new TimeSpan(g1.Key.Value.Hour, g1.Key.Value.Minute, 0),
        //             g1 => g1.ToDictionary(
        //                 g2 => double.Parse(g2.Name, CultureInfo.InvariantCulture),
        //                 g2 => double.Parse(g2.Value, CultureInfo.InvariantCulture))
        //         );
        //
        //     return this;
        // }
    }
}