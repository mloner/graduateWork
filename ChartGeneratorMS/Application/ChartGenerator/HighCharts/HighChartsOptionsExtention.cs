using Highsoft.Web.Mvc.Stocks;

namespace ChartGenerator.HighCharts
{
    public static class HighChartsOptionsExtention
    {
        public static string GetGlobalSettings(this Highsoft.Web.Mvc.Stocks.HighsoftNamespace ns, Global global, Lang lang)
        {
            return ns.SetOptions(global, lang)
                .Replace("<script type='text/javascript'>Highstock.setOptions(", "")
                .Replace(");</script>", "");
        }
        
        public static string GetGlobalSettings(this Highsoft.Web.Mvc.Charts.HighsoftNamespace ns, Highsoft.Web.Mvc.Charts.Global global, Highsoft.Web.Mvc.Charts.Lang lang)
        {
            return ns.SetOptions(global, lang)
                .Replace("<script type='text/javascript'>Highcharts.setOptions(", "")
                .Replace(");</script>", "");
        }
    }
}