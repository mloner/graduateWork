using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ApiService.EcoScadaMicroservice.JsonModels;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ApiService.EcoScadaMicroservice
{
    public static class EcoScadaMicroserviceClient
    {
        private static readonly string Env =  Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        private static readonly Guid UserGuid = Guid.Parse("5E096E0C-791C-41E5-AC00-47CCCBA97CAF");
        private static readonly string ConfigurationMS = Configuration
            .GetSection("Api")
            .GetSection("Microservices")
            .GetSection("ConfigurationMicroservice")
            .GetSection("Url")
            .Value;
        private static readonly string ValuesMS = Configuration
            .GetSection("Api")
            .GetSection("Microservices")
            .GetSection("ValuesMicroservice")
            .GetSection("Url")
            .Value;
        private static IConfiguration Configuration => new ConfigurationBuilder()
            .AddJsonFile($"appsettings.{Env}.json", false)
            .Build();
        
        private static async Task<string> SendGetRequest(string requestUrl)
        {
            var apiKey = Configuration.GetSection("Api").GetSection("EcoscadaApiKey").Value;
            var request = WebRequest.Create(requestUrl) as HttpWebRequest;
            request.PreAuthenticate = true;
            request.KeepAlive = true;
            request.Accept = "application/json";

            request.Headers["Authorization"] = "Bearer " + apiKey;
            request.Timeout = 600000;
            request.Method = "GET";
            var response = (HttpWebResponse) await request.GetResponseAsync();
            string json;
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                json = await reader.ReadToEndAsync();
            }
            response.Close();
            return json;
        }
        public static async Task<string> SendPostRequest(string requestUrl, string requestData)
        {
            var client  = new HttpClient();
            client.DefaultRequestHeaders.Add("X-EcoSCADA-UserGuid", UserGuid.ToString());

            var responseInfo = await client.PostAsync(requestUrl, new StringContent(requestData, Encoding.UTF8, "application/json"));
            
            return responseInfo.ReasonPhrase;
        }

        public static async Task<IEnumerable<Cug>> GetCugsForUser(Guid userGuid)
        {
            return JsonConvert.DeserializeObject<IEnumerable<Cug>>(
                await SendGetRequest(
                    $"{ConfigurationMS}/cugs"));
        }
        public static async Task<Cug> GetCugByGuid(Guid cugGuid)
        {
            return JsonConvert.DeserializeObject<Cug>(
                await SendGetRequest(
                    $"{ConfigurationMS}/cugs/{cugGuid}"));
        }
        public static async Task<IEnumerable<Building>> GetBuildingsByCug(Guid cugGuid)
        {
            return JsonConvert.DeserializeObject<IEnumerable<Building>>(
                await SendGetRequest(
                    $"{ConfigurationMS}/buildings?cugGuid=" + cugGuid));
        }
        public static async Task<Building> GetBuildingByGuid(Guid buildingGuid)
        {
            return JsonConvert.DeserializeObject<Building>(
                await SendGetRequest(
                    $"{ConfigurationMS}/buildings/{buildingGuid}"));
        }
        public static async Task<IEnumerable<Measurement>> GetMeasurementsByBuilding(Guid buildingGuid)
        {
            return JsonConvert.DeserializeObject<IEnumerable<Measurement>>(
                await SendGetRequest(
                    $"{ConfigurationMS}/measurements?buildingGuid=" +
                    buildingGuid));
        }
        public static async Task<Measurement> GetMeasurementByGuid(Guid measurementGuid)
        {
            return JsonConvert.DeserializeObject<Measurement>(
                await SendGetRequest(
                    $"{ConfigurationMS}/measurements/{measurementGuid}"));
        }
        public static async Task<IEnumerable<MeasurementValue>> GetMeasurementValues(Guid measurementGuid, DateTime from, DateTime to)
        {
            return JsonConvert.DeserializeObject<IEnumerable<MeasurementValue>>(
                await SendGetRequest(
                $"{ConfigurationMS}" +
                $"/measurement/{measurementGuid}?from="
                + from.ToString("yyyy-MM-dd") + "&to=" + to.ToString("yyyy-MM-dd")));
        }
        public static async Task<IEnumerable<MeasurementValue>> GetMeasurementValues(Guid measurementGuid, DateTime from, DateTime to, int gateTimeId)
        {
            return JsonConvert.DeserializeObject<IEnumerable<MeasurementValue>>(
                await SendGetRequest(
                $"{ConfigurationMS}/measurement/{measurementGuid}?from="
                + from.ToString("yyyy-MM-dd") + "?to=" + to.ToString("yyyy-MM-dd") + "?gateTimeId=" + gateTimeId)); 
        }
        public static async Task<Input> GetInputByGuid(Guid inputGuid)
        {
            return JsonConvert.DeserializeObject<IEnumerable<Input>>(
                await SendGetRequest(
                    $"{ConfigurationMS}" +
                    $"/inputs?inputGuids={inputGuid}")).First();
        }
        public static async Task<MeasurementValue> GetInputLastValue(Guid inputGuid)
        {
            // return new MeasurementValue()
            // {
            //     DateTime = DateTime.Now,
            //     Value = 123
            // };
            return JsonConvert.DeserializeObject<MeasurementValue>(
                await SendGetRequest(
                    $"{ValuesMS}" +
                    $"/input/{inputGuid}/raw/last"));
        }
        public static async Task<Aimr> GetAimrByGuid(Guid aimrGuid)
        {
            return JsonConvert.DeserializeObject<Aimr>(
                await SendGetRequest(
                    $"{ConfigurationMS}" +
                    $"/aimrs/{aimrGuid}"));
        }
        public static async Task<IEnumerable<AimrType>> GetAimrTypes()
        {
            return JsonConvert.DeserializeObject<IEnumerable<AimrType>>(
                await SendGetRequest(
                    $"{ConfigurationMS}" +
                    $"/aimrs/types"));
        }
        public static async Task<IEnumerable<Cug>> GetAllCugs()
        {
            return JsonConvert.DeserializeObject<List<Cug>>(
                await SendGetRequest(
                    $"{ConfigurationMS}/cugs/"));
        }
    }
}