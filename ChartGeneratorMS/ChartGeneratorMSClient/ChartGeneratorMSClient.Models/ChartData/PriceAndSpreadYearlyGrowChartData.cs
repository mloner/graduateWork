namespace ChartGeneratorModels.ChartData
{
    public class PriceAndSpreadYearlyGrowChartData : global::ChartGeneratorModels.ChartGeneratorModels.ChartData
    {
        public List<int> Years { get; set; }
        public List<double> AllDays { get; set; }
        public List<double> WorkingDays { get; set; }
        public List<double> Weekends { get; set; }
        public List<double> AllDaysSpread { get; set; }
        public List<double> WorkingDaysSpread { get; set; }
        public List<double> WeekendsSpread { get; set; }

        // public override List<SectionParameterValuesDto> AsParameterValues()
        // {
        //     var res = new List<SectionParameterValuesDto>();
        //
        //     for (var i = 0; i < Years.Count; i++)
        //     {
        //         res.Add(new SectionParameterValuesDto()
        //         {
        //             SectionParameterName = "Data",
        //             Name = "Years",
        //             Datetime = new DateTime(Years[i], 01, 01, 0, 0, 0),
        //             Value = Years[i].ToString(CultureInfo.InvariantCulture)
        //         });
        //         
        //         res.Add(new SectionParameterValuesDto()
        //         {
        //             SectionParameterName = "Data",
        //             Name = "AllDays",
        //             Datetime = new DateTime(Years[i], 01, 01, 0, 0, 0),
        //             Value = AllDays[i].ToString(CultureInfo.InvariantCulture)
        //         });
        //         
        //         res.Add(new SectionParameterValuesDto()
        //         {
        //             SectionParameterName = "Data",
        //             Name = "WorkingDays",
        //             Datetime = new DateTime(Years[i], 01, 01, 0, 0, 0),
        //             Value = WorkingDays[i].ToString(CultureInfo.InvariantCulture)
        //         });
        //         
        //         res.Add(new SectionParameterValuesDto()
        //         {
        //             SectionParameterName = "Data",
        //             Name = "Weekends",
        //             Datetime = new DateTime(Years[i], 01, 01, 0, 0, 0),
        //             Value = Weekends[i].ToString(CultureInfo.InvariantCulture)
        //         });
        //         
        //         res.Add(new SectionParameterValuesDto()
        //         {
        //             SectionParameterName = "Data",
        //             Name = "AllDaysSpread",
        //             Datetime = new DateTime(Years[i], 01, 01, 0, 0, 0),
        //             Value = AllDaysSpread[i].ToString(CultureInfo.InvariantCulture)
        //         });
        //         
        //         res.Add(new SectionParameterValuesDto()
        //         {
        //             SectionParameterName = "Data",
        //             Name = "WorkingDaysSpread",
        //             Datetime = new DateTime(Years[i], 01, 01, 0, 0, 0),
        //             Value = WorkingDaysSpread[i].ToString(CultureInfo.InvariantCulture)
        //         });
        //         
        //         res.Add(new SectionParameterValuesDto()
        //         {
        //             SectionParameterName = "Data",
        //             Name = "WeekendsSpread",
        //             Datetime = new DateTime(Years[i], 01, 01, 0, 0, 0),
        //             Value = WeekendsSpread[i].ToString(CultureInfo.InvariantCulture)
        //         });
        //     }
        //     
        //     return res;
        // }
        //
        // public override ChartGeneratorMSClient.ReportGeneratorClient.Models.ChartGeneratorMSClient.Models.ChartData Init(List<SectionParameterValuesDto> sectionParameterValuesDto)
        // {
        //     Years = sectionParameterValuesDto.Where(x => x.Name == "Years")
        //         .OrderBy(x => x.Datetime)
        //         .Select(x => int.Parse(x.Value, CultureInfo.InvariantCulture)).ToList();
        //     AllDays = sectionParameterValuesDto.Where(x => x.Name == "AllDays")
        //         .OrderBy(x => x.Datetime)
        //         .Select(x => double.Parse(x.Value, CultureInfo.InvariantCulture)).ToList();
        //     WorkingDays = sectionParameterValuesDto.Where(x => x.Name == "WorkingDays")
        //         .OrderBy(x => x.Datetime)
        //         .Select(x => double.Parse(x.Value, CultureInfo.InvariantCulture)).ToList();
        //     Weekends = sectionParameterValuesDto.Where(x => x.Name == "Weekends")
        //         .OrderBy(x => x.Datetime)
        //         .Select(x => double.Parse(x.Value, CultureInfo.InvariantCulture)).ToList();
        //     
        //     AllDaysSpread = sectionParameterValuesDto.Where(x => x.Name == "AllDaysSpread")
        //         .OrderBy(x => x.Datetime)
        //         .Select(x => double.Parse(x.Value, CultureInfo.InvariantCulture)).ToList();
        //     WorkingDaysSpread = sectionParameterValuesDto.Where(x => x.Name == "WorkingDaysSpread")
        //         .OrderBy(x => x.Datetime)
        //         .Select(x => double.Parse(x.Value, CultureInfo.InvariantCulture)).ToList();
        //     WeekendsSpread = sectionParameterValuesDto.Where(x => x.Name == "WeekendsSpread")
        //         .OrderBy(x => x.Datetime)
        //         .Select(x => double.Parse(x.Value, CultureInfo.InvariantCulture)).ToList();
        //
        //     return this;
        // }
    }
}