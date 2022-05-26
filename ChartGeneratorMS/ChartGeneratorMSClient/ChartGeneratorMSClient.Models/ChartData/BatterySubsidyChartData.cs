namespace ChartGeneratorModels.ChartData
{
    public class BatterySubsidyChartData : global::ChartGeneratorModels.ChartGeneratorModels.ChartData
    {
        public List<string> Categories { get; set; }
        public List<double> Values { get; set; }
        
        public double BatteryPrice { get; set; }

        // public override List<SectionParameterValuesDto> AsParameterValues()
        // {
        //     var res = new List<SectionParameterValuesDto>();
        //
        //     foreach (var elem in Categories)
        //     {
        //         
        //     }
        //
        //     for (var i = 0; i < Categories.Count; i++)
        //     {
        //         res.Add(new SectionParameterValuesDto()
        //         {
        //             SectionParameterName = "Data",
        //             Name = "Categories",
        //             Datetime = new DateTime(int.Parse(Categories[i], CultureInfo.InvariantCulture), 1, 1)
        //         });
        //         
        //         res.Add(new SectionParameterValuesDto()
        //         {
        //             SectionParameterName = "Data",
        //             Name = "Values",
        //             Datetime = new DateTime(int.Parse(Categories[i], CultureInfo.InvariantCulture), 1, 1),
        //             Value = Values[i].ToString(CultureInfo.InvariantCulture)
        //         });
        //     }
        //
        //     
        //     res.Add(new SectionParameterValuesDto()
        //     {
        //         SectionParameterName = "Data",
        //         Name = "BatteryPrice",
        //         Value = BatteryPrice.ToString(CultureInfo.InvariantCulture)
        //     });
        //     
        //     
        //     return res;
        // }
        //
        // public override ChartGeneratorMSClient.ReportGeneratorClient.Models.ChartGeneratorMSClient.Models.ChartData Init(List<SectionParameterValuesDto> sectionParameterValuesDto)
        // {
        //     Categories = sectionParameterValuesDto.Where(x => x.Name == "Categories")
        //         .OrderBy(x => x.Datetime)
        //         .Select(x => x.Datetime.Value.Year.ToString(CultureInfo.InvariantCulture)).ToList();
        //     
        //     Values = sectionParameterValuesDto.Where(x => x.Name == "Values")
        //         .OrderBy(x => x.Datetime)
        //         .Select(x => double.Parse(x.Value, CultureInfo.InvariantCulture)).ToList();
        //
        //     BatteryPrice = double.Parse(sectionParameterValuesDto.First(x => x.Name == "BatteryPrice").Value,
        //         CultureInfo.InvariantCulture);
        //
        //     return this;
        // }
    }
}