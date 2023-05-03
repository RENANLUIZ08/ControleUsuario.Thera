using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ControleUsuario.Thera.Service.Resources
{

    public interface IHttpClientWrapper : IDisposable
    {
        /// <summary>
        /// Enviar uma requisição
        /// </summary>
        /// <param name="request">Dados da mensagem da requisição</param>
        /// <returns>resposta da requisição</returns>
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
    }

    public class HttpClientBase : IHttpClientWrapper
    {
        private readonly HttpClient client;

        public HttpClientBase(string type, string key)
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.CacheControl = CacheControlHeaderValue.Parse("no-cache, no-store");
            client.DefaultRequestHeaders.Pragma.Add(new NameValueHeaderValue("no-cache"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(type, key);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public HttpClientBase()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.CacheControl = CacheControlHeaderValue.Parse("no-cache, no-store");
            client.DefaultRequestHeaders.Pragma.Add(new NameValueHeaderValue("no-cache"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Enviar uma requisição
        /// </summary>
        /// <param name="requestMessage">Dados da mensagem da requisição</param>
        /// <returns>resposta da requisição</returns>
        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage requestMessage)
        {
            var response = await client.SendAsync(requestMessage);
            return response;
        }

        public void Dispose()
        {
            client.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
