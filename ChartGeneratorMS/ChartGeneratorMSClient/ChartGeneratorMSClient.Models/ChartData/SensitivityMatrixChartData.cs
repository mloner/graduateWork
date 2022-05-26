namespace ChartGeneratorModels.ChartData
{
    public class SensitivityMatrixChartData : global::ChartGeneratorModels.ChartGeneratorModels.ChartData
    {
        public List<double> XAxis { get; set; }
        public List<double> YAxis { get; set; }
        public List<List<double>> Values { get; set; }
        
        // public override List<SectionParameterValuesDto> AsParameterValues()
        // {
        //     var res = new List<SectionParameterValuesDto>();
        //     
        //     //xAxis
        //     res.Add(new SectionParameterValuesDto()
        //     {
        //         SectionParameterName = "Data",
        //         Name = $"xAxis",
        //         Value = XAxis.Select(x => x.ToString(CultureInfo.InvariantCulture)).Aggregate((x, y) => $"{x};{y}")
        //     });
        //     //yAxis
        //     res.Add(new SectionParameterValuesDto()
        //     {
        //         SectionParameterName = "Data",
        //         Name = $"yAxis",
        //         Value = YAxis.Select(x => x.ToString(CultureInfo.InvariantCulture)).Aggregate((x, y) => $"{x};{y}")
        //     });
        //     //values
        //     foreach (var row in Values)
        //     {
        //         res.Add(new SectionParameterValuesDto()
        //         {
        //             SectionParameterName = "Data",
        //             Name = "Values",
        //             Value = row.Select(x => x.ToString(CultureInfo.InvariantCulture)).Aggregate((x, y) => $"{x};{y}")
        //         });
        //     }
        //
        //     return res;
        // }
        //
        // public override ChartGeneratorMSClient.ReportGeneratorClient.Models.ChartGeneratorMSClient.Models.ChartData Init(List<SectionParameterValuesDto> sectionParameterValuesDto)
        // {
        //     XAxis = sectionParameterValuesDto.First(x => x.Name == "xAxis").Value.Split(";")
        //         .Select(x => double.Parse(x, CultureInfo.InvariantCulture)).ToList();
        //     YAxis = sectionParameterValuesDto.First(x => x.Name == "yAxis").Value.Split(";")
        //         .Select(x => double.Parse(x, CultureInfo.InvariantCulture)).ToList();
        //     Values = sectionParameterValuesDto.Where(x => x.Name == "Values").Select(x => x.Value)
        //         .Select(x => x.Split(";").Select(x => double.Parse(x, CultureInfo.InvariantCulture))
        //             .ToList()).ToList();
        //     return this;
        // }
    }
}