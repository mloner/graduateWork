namespace ChartGeneratorModels.ChartData
{
    public class NetMetChartData : global::ChartGeneratorModels.ChartGeneratorModels.ChartData
    {
        public List<int> Categories { get; set; }
        public List<double> Netted { get; set; }
        public List<double> Injected { get; set; }
        public List<double> SelfConsumed { get; set; }

        // public override List<SectionParameterValuesDto> AsParameterValues()
        // {
        //     var res = new List<SectionParameterValuesDto>();
        //
        //     foreach (var el in Categories)
        //     {
        //         res.Add(new SectionParameterValuesDto()
        //         {
        //             SectionParameterName = "Data",
        //             Name = "Categories",
        //             Datetime = new DateTime(el, 1, 1)
        //         });
        //     }
        //     
        //     for (var i = 0; i < Netted.Count; i++)
        //     {
        //         res.Add(new SectionParameterValuesDto()
        //         {
        //             SectionParameterName = "Data",
        //             Name = "Netted",
        //             Datetime = new DateTime(Categories[i], 1, 1),
        //             Value = Netted[i].ToString(CultureInfo.InvariantCulture)
        //         });
        //     }
        //     
        //     for (var i = 0; i < Injected.Count; i++)
        //     {
        //         res.Add(new SectionParameterValuesDto()
        //         {
        //             SectionParameterName = "Data",
        //             Name = "Injected",
        //             Datetime = new DateTime(Categories[i], 1, 1),
        //             Value = Injected[i].ToString(CultureInfo.InvariantCulture)
        //         });
        //     }
        //     
        //     for (var i = 0; i < SelfConsumed.Count; i++)
        //     {
        //         res.Add(new SectionParameterValuesDto()
        //         {
        //             SectionParameterName = "Data",
        //             Name = "SelfConsumed",
        //             Datetime = new DateTime(Categories[i], 1, 1),
        //             Value = SelfConsumed[i].ToString(CultureInfo.InvariantCulture)
        //         });
        //     }
        //
        //     return res;
        // }
        //
        // public override ChartGeneratorMSClient.ReportGeneratorClient.Models.ChartGeneratorMSClient.Models.ChartData Init(List<SectionParameterValuesDto> sectionParameterValuesDto)
        // {
        //     Categories = sectionParameterValuesDto.Where(x => x.Name == "Categories")
        //         .OrderBy(x => x.Datetime)
        //         .Select(x => x.Datetime.Value.Year).ToList();
        //     Netted = sectionParameterValuesDto.Where(x => x.Name == "Netted")
        //         .OrderBy(x => x.Datetime)
        //         .Select(x => double.Parse(x.Value, CultureInfo.InvariantCulture)).ToList();
        //     Injected = sectionParameterValuesDto.Where(x => x.Name == "Injected")
        //         .OrderBy(x => x.Datetime)
        //         .Select(x => double.Parse(x.Value, CultureInfo.InvariantCulture)).ToList();
        //     SelfConsumed = sectionParameterValuesDto.Where(x => x.Name == "SelfConsumed")
        //         .OrderBy(x => x.Datetime)
        //         .Select(x => double.Parse(x.Value, CultureInfo.InvariantCulture)).ToList();
        //
        //
        //     return this;
        // }
    }
}