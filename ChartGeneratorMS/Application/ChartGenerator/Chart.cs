using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Resources;
using ChartGeneratorModels;
using ChartGeneratorModels.ChartGeneratorModels;
using Highsoft.Web.Mvc.Charts;
using Highsoft.Web.Mvc.Stocks;

namespace ChartGenerator
{
    public abstract class Chart : IChart
    {
        public List<ResourceManager> ResourceManagers { get; set; } 
        public ChartData _data { get; set; }
        public ChartGeneratorModels.ChartSettings.ChartSettings _settings { get; set; }
        public Highcharts HcOptions { get; set; }
        public Highstock HsOptions { get; set; }
        public string ChartName { get; set; }
        public string Json { get; set; }
        public string ImageType { get; set; }
        
        protected Chart()
        {
            ImageType = "png";
            ResourceManagers = new List<ResourceManager>()
            {
                CommonResource.ResourceManager
            };
        }
        
        public abstract void Generate();
        public Highstock CreateHighStocksOptions()
        {
            var hc = new Highstock();

            hc.Chart = new Highsoft.Web.Mvc.Stocks.Chart()
            {
                BackgroundColor = "rgba(0,0,0,0)",
                Style = new PropertyCollection()
                {
                    {"fontFamily", "[fontFamily]"}
                }
            };
            hc.Credits = new Highsoft.Web.Mvc.Stocks.Credits()
            {
                Enabled = false 
            };
            hc.Title = new Highsoft.Web.Mvc.Stocks.Title()
            {
                Text = ""
            };

            return hc;
        }
        public Highcharts CreateHighchartsOptions()
        {
            HcOptions = new Highcharts();

            HcOptions.Chart = new Highsoft.Web.Mvc.Charts.Chart()
            {
                BackgroundColor = "rgba(0,0,0,0)",
                Style = new PropertyCollection()
                {
                    {"fontFamily", "[fontFamily]"}
                }
            };
            HcOptions.Credits = new Highsoft.Web.Mvc.Charts.Credits()
            {
                Enabled = false 
            };
            HcOptions.Title = new Highsoft.Web.Mvc.Charts.Title()
            {
                Text = ""
            };

            return HcOptions;
        }

        public void SetChartJson()
        {
            if (HcOptions != null)
            {
                Json = new Highsoft.Web.Mvc.Charts.HighsoftNamespace().GetJsonOptions(HcOptions);
            }
            else if (HsOptions != null)
            {
                Json = new Highsoft.Web.Mvc.Stocks.HighsoftNamespace().GetJsonOptions(HsOptions);
            }
            else
            {
                throw new Exception("Chart options is null");
            }
        }
        
        public void SetChartFont(FontEnum font)
        {
            Json = Json.Replace("[fontFamily]", font.Desc());
        }
        
        public string GetTranslationString(string key)
        {
            string res = "";
            foreach (var resourceManager in ResourceManagers.AsEnumerable().Reverse())
            {
                try
                {
                    res = resourceManager.GetString(key, new CultureInfo(_settings.Language.Desc()));
                    if (res == null)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        return res;
                    }
                }
                catch (Exception e)
                {
                    // ignored
                }
            }

            res = $"### {key}";
            Console.WriteLine(res);
            return res;
        }

        protected List<string> GetPaybackPeriodWord(string pbPerMonths)
        {
            var res = new List<string>();
            int pvPerMonthsInt = int.Parse(pbPerMonths);
            int monthsDec = pvPerMonthsInt % 12;
            int years = (pvPerMonthsInt - monthsDec) / 12;

            if (years > 0)
            {
                // var yearsWord = years > 1 ?
                //     _settings.GetTranslationString(ChartSettings.TranslScope.Global, "Years").ToLower() :
                //     _settings.GetTranslationString(ChartSettings.TranslScope.Global, "Year").ToLower();
                // res.Add($"{years} {yearsWord}");
            }

            if (monthsDec > 0)
            {
                // var monthsWord = monthsDec > 1 ? 
                //     _settings.GetTranslationString(ChartSettings.TranslScope.Global, "Months").ToLower() :
                //     _settings.GetTranslationString(ChartSettings.TranslScope.Global, "Month").ToLower();
                // res.Add($"{monthsDec * 12 / 10} {monthsWord}");
            }

            return res;
        }
        
        protected List<string> GetPaybackPeriodWord(List<int> pbPeriodYearsMonths, ChartGeneratorModels.ChartSettings.ChartSettings chartSettings)
        {
            var res = new List<string>();
            int monthsDec = pbPeriodYearsMonths[1];
            int years = pbPeriodYearsMonths[0];

            // if (years > 0)
            // {
            //     var yearsWord = years > 1 ?
            //         chartSettings.GetTranslationString(ChartSettings.TranslScope.Global, "Years").ToLower() :
            //         chartSettings.GetTranslationString(ChartSettings.TranslScope.Global, "Year").ToLower();
            //     res.Add($"{years} {yearsWord}");
            // }
            //
            // if (monthsDec > 0)
            // {
            //     var monthsWord = monthsDec > 1 ? 
            //         chartSettings.GetTranslationString(ChartSettings.TranslScope.Global, "Months").ToLower() :
            //         chartSettings.GetTranslationString(ChartSettings.TranslScope.Global, "Month").ToLower();
            //     res.Add($"{monthsDec} {monthsWord}");
            // }

            return res;
        }
        
        protected List<double> GetPaybackPeriodYearsMonths(int pbPeriodMonths)
        {
            var res = new List<double>();
            int monthsDec = pbPeriodMonths % 12;
            int years = (pbPeriodMonths - monthsDec) / 12;

            if (years > 0)
            {
                res.Add(years);
            }

            if (monthsDec > 0)
            {
                res.Add(monthsDec);
            }

            return res;
        }
    }
}