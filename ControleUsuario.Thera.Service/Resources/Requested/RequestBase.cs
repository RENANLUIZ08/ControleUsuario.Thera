using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ControleUsuario.Thera.Service.Resources.Requested
{
    public class RequestBase : IRequestBase
    {
        private readonly IHttpClientWrapper client;

        private readonly JsonSerializerSettings JsonSettings;

        private string Route { get; set; } = "";

        public void SetRoute(string url, string route)
        {
            Route = $"{url}{route}";
        }

        public RequestBase(string type, string key)
        {
            client = new HttpClientBase(type, key);
            JsonSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
        }

        public RequestBase()
        {
            client = new HttpClientBase();
            JsonSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
        }

        public void Dispose()
        {
            client.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<T> GetAsync<T>(string param = "", object data = null)
        {
            var response = await SendRequestAsync(HttpMethod.Get, Route + param, data);
            return await ProcessResponse<T>(response);
        }

        public async Task<T> PostAsync<T>(string param = "", object data = null, Dictionary<string, string> headers = null)
        {
            try
            {
                var response = await SendRequestAsync(HttpMethod.Post, Route + param, data, headers);

                return await ProcessResponse<T>(response);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<T> PutAsync<T>(string param = "", object data = null, Dictionary<string, string> headers = null)
        {
            try
            {
                var response = await SendRequestAsync(HttpMethod.Put, Route + param, data, headers);

                return await ProcessResponse<T>(response);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        #region Private Methods
        private async Task<T> ProcessResponse<T>(HttpResponseMessage response)
        {
            var data = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return await Task.FromResult(JsonConvert.DeserializeObject<T>(data, JsonSettings));
            }

            throw new ArgumentException(data);
        }

        private async Task<HttpResponseMessage> SendRequestAsync(HttpMethod method, string url, object data = null, Dictionary<string, string> headers = null)
        {
            using (var requestMessage = new HttpRequestMessage(method, url))
            {
                await SetContent(data, requestMessage);

                if (headers != null)
                {
                    foreach (var i in headers)
                    {
                        requestMessage.Headers.Add(i.Key, i.Value);
                    }
                }

                return await client.SendAsync(requestMessage);
            }
        }

        private async Task SetContent(object data, HttpRequestMessage requestMessage)
        {
            if (data != null)
            {
                var content = await Task.FromResult(JsonConvert.SerializeObject(data, JsonSettings));
                requestMessage.Content = new StringContent(content, Encoding.UTF8, "application/json");

            }
        }

        #endregion
    }
}
