namespace ChartGeneratorModels.ChartData
{
    public class AverageHourlyChartData : ChartGeneratorModels.ChartData
    {
        public Dictionary<int, double> Demand { get; set; }
        public Dictionary<int, double> Pv { get; set; }
        public Dictionary<int, double> Dam { get; set; }
        public Dictionary<int, double> DamBuy { get; set; }
        public Dictionary<int, double> DamSell { get; set; }
        public Dictionary<int, double> BatteryEnergy { get; set; }

        // public override List<SectionParameterValuesDto> AsParameterValues()
        // {
        //     var res = new List<SectionParameterValuesDto>();
        //     
        //     foreach (var demandEl in Demand)
        //     {
        //         res.Add(new SectionParameterValuesDto()
        //         {
        //             SectionParameterName = "Data",
        //             Name = "Demand",
        //             Datetime = new DateTime(1970, 01, 01, demandEl.Key, 0, 0),
        //             Value = demandEl.Value.ToString(CultureInfo.InvariantCulture)
        //         });
        //     }
        //     foreach (var demandEl in Pv)
        //     {
        //         res.Add(new SectionParameterValuesDto()
        //         {
        //             SectionParameterName = "Data",
        //             Name = "Pv",
        //             Datetime = new DateTime(1970, 01, 01, demandEl.Key, 0, 0),
        //             Value = demandEl.Value.ToString(CultureInfo.InvariantCulture)
        //         });
        //     }
        //     foreach (var demandEl in Dam)
        //     {
        //         res.Add(new SectionParameterValuesDto()
        //         {
        //             SectionParameterName = "Data",
        //             Name = "Dam",
        //             Datetime = new DateTime(1970, 01, 01, demandEl.Key, 0, 0),
        //             Value = demandEl.Value.ToString(CultureInfo.InvariantCulture)
        //         });
        //     }
        //     foreach (var demandEl in DamBuy)
        //     {
        //         res.Add(new SectionParameterValuesDto()
        //         {
        //             SectionParameterName = "Data",
        //             Name = "DamBuy",
        //             Datetime = new DateTime(1970, 01, 01, demandEl.Key, 0, 0),
        //             Value = demandEl.Value.ToString(CultureInfo.InvariantCulture)
        //         });
        //     }
        //     foreach (var demandEl in DamSell)
        //     {
        //         res.Add(new SectionParameterValuesDto()
        //         {
        //             SectionParameterName = "Data",
        //             Name = "DamSell",
        //             Datetime = new DateTime(1970, 01, 01, demandEl.Key, 0, 0),
        //             Value = demandEl.Value.ToString(CultureInfo.InvariantCulture)
        //         });
        //     }
        //     foreach (var demandEl in BatteryEnergy)
        //     {
        //         res.Add(new SectionParameterValuesDto()
        //         {
        //             SectionParameterName = "Data",
        //             Name = "BatteryEnergy",
        //             Datetime = new DateTime(1970, 01, 01, demandEl.Key, 0, 0),
        //             Value = demandEl.Value.ToString(CultureInfo.InvariantCulture)
        //         });
        //     }
        //
        //
        //     return res;
        // }
        //
        // public override ReportingFramework.Dto.ChartGeneratorMSClient.Models.ChartData Init(List<SectionParameterValuesDto> sectionParameterValuesDto)
        // {
        //     Demand = sectionParameterValuesDto.Where(x => x.Name == "Demand")
        //         .Select(x => new KeyValuePair<int, double>(x.Datetime.Value.Hour,
        //             double.Parse(x.Value, CultureInfo.InvariantCulture)))
        //         .OrderBy(x => x.Key)
        //         .ToDictionary(x => x.Key, x => x.Value);
        //     
        //     Pv = sectionParameterValuesDto.Where(x => x.Name == "Pv")
        //         .Select(x => new KeyValuePair<int, double>(x.Datetime.Value.Hour,
        //             double.Parse(x.Value, CultureInfo.InvariantCulture)))
        //         .OrderBy(x => x.Key)
        //         .ToDictionary(x => x.Key, x => x.Value);
        //     
        //     Dam = sectionParameterValuesDto.Where(x => x.Name == "Dam")
        //         .Select(x => new KeyValuePair<int, double>(x.Datetime.Value.Hour,
        //             double.Parse(x.Value, CultureInfo.InvariantCulture)))
        //         .OrderBy(x => x.Key)
        //         .ToDictionary(x => x.Key, x => x.Value);
        //     
        //     DamBuy = sectionParameterValuesDto.Where(x => x.Name == "DamBuy")
        //         .Select(x => new KeyValuePair<int, double>(x.Datetime.Value.Hour,
        //             double.Parse(x.Value, CultureInfo.InvariantCulture)))
        //         .OrderBy(x => x.Key)
        //         .ToDictionary(x => x.Key, x => x.Value);
        //     
        //     DamSell = sectionParameterValuesDto.Where(x => x.Name == "DamSell")
        //         .Select(x => new KeyValuePair<int, double>(x.Datetime.Value.Hour,
        //             double.Parse(x.Value, CultureInfo.InvariantCulture)))
        //         .OrderBy(x => x.Key)
        //         .ToDictionary(x => x.Key, x => x.Value);
        //     
        //     BatteryEnergy = sectionParameterValuesDto.Where(x => x.Name == "BatteryEnergy")
        //         .Select(x => new KeyValuePair<int, double>(x.Datetime.Value.Hour,
        //             double.Parse(x.Value, CultureInfo.InvariantCulture)))
        //         .OrderBy(x => x.Key)
        //         .ToDictionary(x => x.Key, x => x.Value);
        //
        //     return this;
        // }
    }
}