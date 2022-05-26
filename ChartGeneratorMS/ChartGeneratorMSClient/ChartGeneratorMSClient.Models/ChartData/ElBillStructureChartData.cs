namespace ChartGeneratorModels.ChartData
{
    public class ElBillStructureChartData : global::ChartGeneratorModels.ChartGeneratorModels.ChartData
    {
        public Dictionary<string, double> Values { get; set; }

        // public override List<SectionParameterValuesDto> AsParameterValues()
        // {
        //     var res = new List<SectionParameterValuesDto>();
        //
        //     foreach (var keyValuePair in Values)
        //     {
        //         res.Add(new SectionParameterValuesDto()
        //         {
        //             SectionParameterName = "Data",
        //             Name = keyValuePair.Key,
        //             Value = keyValuePair.Value.ToString(CultureInfo.InvariantCulture)
        //         });
        //     }
        //     
        //     return res;
        // }
        //
        // public override ChartGeneratorMSClient.ReportGeneratorClient.Models.ChartGeneratorMSClient.Models.ChartData Init(List<SectionParameterValuesDto> sectionParameterValuesDto)
        // {
        //     Values = sectionParameterValuesDto.Select(
        //             x => new KeyValuePair<string, double>(x.Name, double.Parse(x.Value, CultureInfo.InvariantCulture)))
        //         .ToDictionary(x => x.Key, x => x.Value);
        //     
        //     return this;
        // }
    }
}