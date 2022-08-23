using Dominio.Interfaces.RestProvider;
using Newtonsoft.Json;
using Dominio.Classes;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Provider
{
    public class RestProvider : IRestProvider
    {
        private readonly HttpClient _client;
        public RestProvider()
        {
            _client = new HttpClient();
        }
        
        public async Task<Response<TEntity>> Get<TEntity>(string url)
        {
            try
            {
                if (url == null)
                    throw new Exception("URL vazia, não é possivel prosseguir com o request");

                var request = new HttpRequestMessage(HttpMethod.Get, new Uri(url));

                var response = await _client.SendAsync(request);
                if (response != null && response.IsSuccessStatusCode)
                {
                    var resultString = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<TEntity>(resultString);

                    return new Response<TEntity> { CodigoResposta = (int)response.StatusCode, Resposta = result };
                }

                return new Response<TEntity>()
                {
                    CodigoResposta = 0
                };
            }
            catch(Exception erro)
            {
                var resposta = new Response<TEntity>();
                resposta.Erros = new List<string>() { erro.Message };
                return resposta;
            }
        }
    }
}
