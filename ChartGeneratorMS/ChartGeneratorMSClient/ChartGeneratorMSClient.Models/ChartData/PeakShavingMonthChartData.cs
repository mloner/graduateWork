using ChartGeneratorModels.ChartData.CommonChartData;

namespace ChartGeneratorModels.ChartData
{
    public class PeakShavingMonthChartData : global::ChartGeneratorModels.ChartGeneratorModels.ChartData
    {
        public List<DateTimeSeries> GridPower { get; set; }

        // public override List<SectionParameterValuesDto> AsParameterValues()
        // {
        //     return GridPower.Select(x => new SectionParameterValuesDto
        //     {
        //         SectionParameterName = "Data",
        //         Datetime = x.DateTime,
        //         Value = x.Value.ToString(CultureInfo.InvariantCulture),
        //     }).ToList();
        // }
        //
        // public override ChartGeneratorMSClient.ReportGeneratorClient.Models.ChartGeneratorMSClient.Models.ChartData Init(List<SectionParameterValuesDto> sectionParameterValuesDto)
        // {
        //     GridPower = sectionParameterValuesDto
        //         .OrderBy(x => x.Datetime)
        //         .Select(x => new DateTimeSeries()
        //     {
        //         DateTime = x.Datetime.Value,
        //         Value = double.Parse(x.Value, CultureInfo.InvariantCulture)
        //     }).ToList();
        //     return this;
        // }
    }
}