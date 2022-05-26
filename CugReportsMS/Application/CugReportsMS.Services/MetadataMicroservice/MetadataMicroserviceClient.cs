using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ApiService.MetadataMicroservice.JsonMoedls;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ApiService.MetadataMicroservice
{
    public static class MetadataMicroserviceClient
    {
        private static readonly string Env =  Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        private static IConfiguration Configuration => new ConfigurationBuilder()
            .AddJsonFile($"appsettings.{Env}.json", false)
            .Build();
        private static string RootAddress =>
            Configuration
                .GetSection("Api")
                .GetSection("Microservices")
                .GetSection("MetadataMicroservice")
                .GetSection("Url").Value;
        
        private static async Task<string> SendGetRequest(string requestUrl)
        {
            var apiKey = Configuration
                .GetSection("Api")
                .GetSection("Microservices")
                .GetSection("MetadataMicroservice")
                .GetSection("ApiKey").Value;
            var request = WebRequest.Create(requestUrl) as HttpWebRequest;
            request.PreAuthenticate = true;
            request.KeepAlive = true;
            request.Accept = "application/json";

            request.Headers["X-EcoSCADA-UserGuid"] = apiKey;
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
        private static async Task<string> SendPostRequest(string requestUrl, string requestData)
        {
            var client  = new HttpClient();

            var responseInfo = await client.PostAsync(requestUrl, new StringContent(requestData, Encoding.UTF8, "application/json"));
            
            return responseInfo.ReasonPhrase;
        }
        public static async Task<IEnumerable<Component>> GetComponentsByTypeId(int componentTypeId)
        {
            return JsonConvert.DeserializeObject<IEnumerable<Component>>(
                await SendGetRequest(
                    $"{RootAddress}/components/componentTypeId={componentTypeId}"));
        }
        public static async Task<ComponentWithParametersWithValues> GetComponentWithParametersWithValueByComponentId(int componentId)
        {
            var component = await GetComponentById(componentId);
            var componentParametersValues = await GetComponentParameterValuesByComponenId(componentId);
            var res = new ComponentWithParametersWithValues
            {
                ComponentId = componentId,
                Name = component.Name,
                ComponentTypeId = component.ComponentTypeId,
                DateAdded = component.DateAdded,
                NotDeleted = component.NotDeleted,

                ComponentParameters = new List<ComponentParameterWithValue>()
            };
            foreach (var paramValue in componentParametersValues)
            {
                var componentParameter = await GetComponentParameterById(paramValue.ComponentParameterId);
                res.ComponentParameters.Add(new ComponentParameterWithValue()
                {
                    ComponentParameterId = paramValue.ComponentParameterId,
                    Name = componentParameter.Name,
                    ComponentTypeId = componentParameter.ComponentTypeId,
                    PythonParam = componentParameter.PythonParam,
                    Unit = componentParameter.Unit,
                    Desctiption = componentParameter.Desctiption,
                    Validity = componentParameter.Validity,
                    NotDeleted = componentParameter.NotDeleted,
                    Value = paramValue.Value
                });
            }

            return res;
        }
        public static async Task<IEnumerable<ComponentParameterValue>> GetComponentParameterValuesByComponenId(int componentId)
        {
            return JsonConvert.DeserializeObject<IEnumerable<ComponentParameterValue>>(
                await SendGetRequest(
                    $"{RootAddress}/components/values/componentId={componentId}"));
        }
        public static async Task<ComponentParameter> GetComponentParameterById(int componentParameterId)
        {
            return JsonConvert.DeserializeObject<ComponentParameter>(
                await SendGetRequest(
                    $"{RootAddress}/components/parameters/{componentParameterId}"));
        }
        public static async Task<Component> GetComponentById(int componentId)
        {
            return JsonConvert.DeserializeObject<Component>(
                await SendGetRequest(
                    $"{RootAddress}/components/{componentId}"));
        }
        public static async Task<IEnumerable<ComponentParameter>> GetComponentParametersByComponentTypeId(int componentTypeId)
        {
            return JsonConvert.DeserializeObject<IEnumerable<ComponentParameter>>(
                await SendGetRequest(
                    $"{RootAddress}/components/parameters/type={componentTypeId}"));
        }
        public static async Task<ComponentParameterValue> GetComponentParameterValueByComponentIdAndParameterId(int componentId, int componentParamId)
        {
            return JsonConvert.DeserializeObject<ComponentParameterValue>(
                await SendGetRequest(
                    $"{RootAddress}/components/values/paramId={componentParamId},componentId={componentId}"));
        }
        public static async Task<IEnumerable<Component>> GetComponentsByParameterIdAndValue(int parameterId, string value)
        {
            return JsonConvert.DeserializeObject<IEnumerable<Component>>(
                await SendGetRequest(
                    $"{RootAddress}/components/paramId={parameterId},value={value}"));
        }
    }
}