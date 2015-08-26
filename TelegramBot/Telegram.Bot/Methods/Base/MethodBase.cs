using TelegramBot.Telegram.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Telegram.Bot.Methods.Base
{
    internal abstract class MethodBase<TParameter,TResult>
    {
        protected HttpClient HttpClient
        {
            get;private set;
        }
        
        public abstract string MethodName { get; }

        public abstract HttpVerb HttpVerb { get; }

        public Response<TResult> Execute(TParameter parameter,HttpClient httpClient)
        {
            HttpClient = httpClient;

            HttpResponseMessage response = null;

            if (HttpVerb == HttpVerb.Get)
            {
                response = SendGetRequest(parameter);
                
            }
            else if (HttpVerb == HttpVerb.Post)
            {

                if (ShouldSendInMultipleFormData(parameter))
                {
                    response = SendMultipleFormDataRequest(parameter);
                }
                else
                {
                    response = SendPostRequest(parameter);
                }
            }

            var content = response.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<Response<TResult>>(content);

            return result;
        }

        private HttpResponseMessage SendMultipleFormDataRequest(TParameter parameter)
        {
            var dicParameters = GetDictionaryParameters(parameter);

            var content = new MultipartFormDataContent();

            foreach (var keyValuePair in dicParameters)
            {
                if (keyValuePair.Value != null)
                {
                    var stingHeader = new StringContent(keyValuePair.Value);
                    content.Add(stingHeader, keyValuePair.Key);
                }

            }

            var parameterProperties = GetProperties(parameter);

            foreach (var property in parameterProperties)
            {
                if (property.Name.EndsWith("Stream"))
                {
                    var name = property.Name.Substring(0, property.Name.Length - 6);
                    var stream = property.GetValue(parameter) as Stream;
                    var propertyFileName = parameterProperties
                        .Single(q=>q.Name.EndsWith("FileName") && q.Name.StartsWith(name));

                    var fileName = "\"" + propertyFileName.GetValue(parameter) as string + "\"";

                    var fileContent = new StreamContent(stream);

                    fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                    {
                        FileName = fileName,
                        Name = name.ToLower()
                    };

                    content.Add(fileContent);
                }   
            }

            return HttpClient.PostAsync(MethodName, content).Result;
        }

        private HttpResponseMessage SendPostRequest(TParameter parameter)
        {
            var dicParameters = GetDictionaryParameters(parameter);
            return HttpClient.PostAsync(MethodName, new FormUrlEncodedContent(dicParameters)).Result;
        }

        private HttpResponseMessage SendGetRequest(TParameter parameter)
        {
            var dicParameters = GetDictionaryParameters(parameter);
            var query = new FormUrlEncodedContent(dicParameters).ReadAsStringAsync().Result;
            if (query.Length > 0)
                return HttpClient.GetAsync(MethodName + "?" + query).Result;
            else
                return HttpClient.GetAsync(MethodName).Result;
        }

        private bool ShouldSendInMultipleFormData(TParameter parameter)
        {
            var properties = GetProperties(parameter);

            foreach (var property in properties)
            {
                if (property.Name.EndsWith("Stream", StringComparison.Ordinal))
                    return true;
            }

            return false;
        }

        private static PropertyInfo[] GetProperties(object obj)
        {
            return obj.GetType().GetProperties();
        }

        private Dictionary<string,string> GetDictionaryParameters(TParameter parameter)
        {
            JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var paramJson = JsonConvert.SerializeObject(parameter, JsonSerializerSettings);
            var jObject = JObject.Parse(paramJson);
            var dic = new Dictionary<string, string>();

            foreach (var token in jObject.Children())
            {
                var property = token as JProperty;
                dic[property.Name] = property.Value.ToString();
            }

            return dic;
        }
    }
}
