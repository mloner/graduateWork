namespace ChartGeneratorModels.ChartData
{
    public class PerfExplWeekChartData : global::ChartGeneratorModels.ChartGeneratorModels.ChartData
    {
        public Dictionary<DateTime, double> Demand { get; set; }
        public Dictionary<DateTime, double> Pv { get; set; }
        public Dictionary<DateTime, double> Battery { get; set; }
        public Dictionary<DateTime, double> Dam { get; set; }
        
        // public override List<SectionParameterValuesDto> AsParameterValues()
        // {
        //     var res = new List<SectionParameterValuesDto>();
        //     
        //     for (var i = 0; i < Demand.Count; i++)
        //     {
        //         //Demand
        //         res.Add(new SectionParameterValuesDto()
        //         {
        //             SectionParameterName = "Data",
        //             Name = "Demand",
        //             Datetime = Demand.Keys.ToList()[i],
        //             Value = Demand.Values.ToList()[i].ToString(CultureInfo.InvariantCulture)
        //         });
        //         
        //         //Pv
        //         res.Add(new SectionParameterValuesDto()
        //         {
        //             SectionParameterName = "Data",
        //             Name = "Pv",
        //             Datetime = Demand.Keys.ToList()[i],
        //             Value = Pv.Values.ToList()[i].ToString(CultureInfo.InvariantCulture)
        //         });
        //         
        //         //Battery
        //         res.Add(new SectionParameterValuesDto()
        //         {
        //             SectionParameterName = "Data",
        //             Name = "Battery",
        //             Datetime = Demand.Keys.ToList()[i],
        //             Value = Battery.Values.ToList()[i].ToString(CultureInfo.InvariantCulture)
        //         });
        //         
        //         //Dam
        //         res.Add(new SectionParameterValuesDto()
        //         {
        //             SectionParameterName = "Data",
        //             Name = "Dam",
        //             Datetime = Demand.Keys.ToList()[i],
        //             Value = Dam.Values.ToList()[i].ToString(CultureInfo.InvariantCulture)
        //         });
        //     }
        //     
        //     return res;
        // }
        //
        // public override ChartGeneratorMSClient.ReportGeneratorClient.Models.ChartGeneratorMSClient.Models.ChartData Init(List<SectionParameterValuesDto> sectionParameterValuesDto)
        // {
        //     Demand = sectionParameterValuesDto
        //         .Where(x => x.Name == "Demand")
        //         .OrderBy(x => x.Datetime)
        //         .Select(x => new KeyValuePair<DateTime,double>(x.Datetime.Value,
        //             double.Parse(x.Value, CultureInfo.InvariantCulture)))
        //         .ToDictionary(x => x.Key, x => x.Value);
        //     Pv = sectionParameterValuesDto
        //         .Where(x => x.Name == "Pv")
        //         .OrderBy(x => x.Datetime)
        //         .Select(x => new KeyValuePair<DateTime,double>(x.Datetime.Value,
        //             double.Parse(x.Value, CultureInfo.InvariantCulture)))
        //         .ToDictionary(x => x.Key, x => x.Value);
        //     Battery = sectionParameterValuesDto
        //         .Where(x => x.Name == "Battery")
        //         .OrderBy(x => x.Datetime)
        //         .Select(x => new KeyValuePair<DateTime,double>(x.Datetime.Value,
        //             double.Parse(x.Value, CultureInfo.InvariantCulture)))
        //         .ToDictionary(x => x.Key, x => x.Value);
        //     Dam = sectionParameterValuesDto
        //         .Where(x => x.Name == "Dam")
        //         .OrderBy(x => x.Datetime)
        //         .Select(x => new KeyValuePair<DateTime,double>(x.Datetime.Value,
        //             double.Parse(x.Value, CultureInfo.InvariantCulture)))
        //         .ToDictionary(x => x.Key, x => x.Value);
        //     
        //     return this;
        // }
    }
}