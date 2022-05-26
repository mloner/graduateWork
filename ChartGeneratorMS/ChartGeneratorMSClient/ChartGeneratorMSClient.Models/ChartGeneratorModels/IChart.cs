namespace ChartGeneratorModels.ChartGeneratorModels
{
    public interface IChart
    {
        Highsoft.Web.Mvc.Charts.Highcharts HcOptions { get; set; }
        Highsoft.Web.Mvc.Stocks.Highstock HsOptions { get; set; }

        string ChartName { get; set; }
        string Json { get; set; }
        
        string ImageType { get; set; }
    }
}