using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ChartGenerator.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ChartGenerator.HighCharts
{
	public class HighchartsClient : IHighchartsClient, IDisposable
	{
		private readonly HighchartsSetting _settings;
		private readonly HttpClient _httpClient;

		private readonly IConfiguration _configuration;
		private readonly ILogger<HighchartsClient> _logger;

		public HighchartsClient(IConfiguration configuration,
			ILogger<HighchartsClient> logger)
		{
			_configuration = configuration;
			_logger = logger;
			
			_httpClient = new HttpClient();
			_settings = new HighchartsSetting()
			{
				ServerAddress = _configuration
					.GetSection("Api")
					.GetSection("Microservices")
					.GetSection("Highcharts")
					.GetSection("Url")
					.Value,
				ExportImageType = "image/png",
				ScaleFactor = 2,
				ImageWidth = 1500,
				PauseLengthBetweenRequestsMilliseconds = 0,
				AttemptCount = 3
			};
		}
		
		public class WebClientEx : WebClient
		{
			private CookieContainer _cookieContainer = new CookieContainer();
			protected override WebRequest GetWebRequest(Uri address)
			{
				WebRequest request = base.GetWebRequest(address);
				if (request is HttpWebRequest)
				{
					(request as HttpWebRequest).CookieContainer = _cookieContainer;
					(request as HttpWebRequest).UserAgent = @"PostmanRuntime/7.26.10";
				}
				return request;
			}
		}

		private Dictionary<string, object> GetRequestSettings(string data, bool async, bool isSvg, int scale = 2, string globalOptions = "")
		{
			return new Dictionary<string, object>()
			{
				{ "async", async},
				{ "type", _settings.ExportImageType},
				{ "width", false },
				{ isSvg ? "svg" : "infile", data },
				{ "scale", scale },
				{ "constr" , "Chart" },
				{ "globalOptions", globalOptions }
			};
		}

		public async Task<string> MakeRequest(Dictionary<string, object> data)
		{
			using (var client = new WebClientEx())
			{
				_logger.LogDebug($"RequestData: {JsonConvert.SerializeObject(data)}");
				
				var response = await client.UploadValuesTaskAsync(new Uri(_settings.ServerAddress), data.ToNameValueCollection());
				return System.Text.Encoding.UTF8.GetString(response);
			}
		}
		
		public async Task<string> GetChartImageLinkFromOptions(string options, string globalOptions = "")
		{
			Thread.Sleep(_settings.PauseLengthBetweenRequestsMilliseconds);
			var filePath = "";
			var scale = _settings.ScaleFactor;
			for (int attemptNumber = 0; attemptNumber < _settings.AttemptCount; attemptNumber++)
			{
				_logger.LogDebug($"Get chart. Attempt {attemptNumber + 1}/{_settings.AttemptCount}");
				try
				{
					var request = GetRequestSettings(
						data: options,
						async: true,
						isSvg: false,
						globalOptions: globalOptions,
						scale: scale);
					if (attemptNumber > 2 && scale > 2)
					{
						scale--;
					}
					var response = await MakeRequest(request);
					filePath = response;

					return $"{_settings.ServerAddress}{filePath}";
				}
				catch (Exception e)
				{
					// ignored
				}
			}
			_logger.LogCritical($"GetChartImageLinkFromOptionsAsync !!!!!!ChartError!!!!!!\n{options}");
			
			return $"{_settings.ServerAddress}{filePath}";
		}
		
		public static void DownloadImage(string url, string filename)
		{
			WebClient client = null;
			Stream stream = null;
			Bitmap bitmap = null;
			try
			{
				client = new WebClient();
				stream = client.OpenRead(url);
				bitmap = new Bitmap(stream);
				
				if (bitmap != null)
				{
					bitmap.Save(filename, ImageFormat.Png);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine($"Failed to download chart:{e.Message}");	
			}
			finally
			{
				if (stream != null)
				{
					stream.Flush();
					stream.Close();	
				}

				if (client != null)
				{
					client.Dispose();
				}
			}
		}

		public void Dispose()
		{
			_httpClient.Dispose();
		}
	}
}
