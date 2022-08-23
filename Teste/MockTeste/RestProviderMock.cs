using Dominio.Interfaces.RestProvider;
using Dominio.Provider.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using Dominio.Models;
using Bogus;
using Newtonsoft.Json;

namespace Teste.MockTeste
{
    class RestProviderMock : IProvedorRest
    {
        string jsonPessoas;
        string jsonPost;
        public bool DevefalharNoGetPessoas { get; set; }
        public bool DevefalharNoGetPost { get; set; }
        public RestProviderMock(int nPessoas, int nPost)
        {
            jsonPessoas = JsonConvert.SerializeObject(new Faker<PessoaModel>("pt_BR")
                .RuleFor(p => p.Id, f => f.IndexFaker)
                .RuleFor(p => p.Nome, f => f.Name.FullName())
                .RuleFor(p => p.NomeUsuario, f => f.Name.FirstName())
                .RuleFor(p => p.Email, f => f.Internet.Email(f.Person.FirstName).ToLower())
                .RuleFor(p => p.Contato, f => f.Phone.PhoneNumber())
                .RuleFor(p => p.WebSite, f => f.Internet.Url())
                .RuleFor(p => p.Endereco, f => new addressModel()
                {
                    Rua = f.Address.City(),
                    Cidade = f.Address.City(),
                    CEP = f.Address.ZipCode(),
                    Localizacao = new GeoModel()
                    {
                        Latitude = f.Address.Latitude().ToString(),
                        Longitude = f.Address.Longitude().ToString()
                    }
                })
                .RuleFor(p => p.Empresa, f => new companyModel()
                {
                    NomeEmresa = f.Company.CompanyName()
                }).Generate(nPessoas));

            jsonPost = JsonConvert.SerializeObject(new Faker<PostModel>("pt_BR")
                .RuleFor(p => p.Id, f => f.IndexFaker)
                .RuleFor(p => p.Titulo, f => f.Lorem.Text())
                .RuleFor(p => p.Corpo, f => f.Lorem.Paragraph())
                .Generate(nPost));

        }
        public Task<Response<TEntity>> Get<TEntity>(string url)
        {
            return Task.Run(() =>
            {
                var json = string.Empty;
                if(url.Contains("user"))
                {
                    json = jsonPessoas;
                    if (DevefalharNoGetPessoas)
                        throw new Exception("Falha ao obter dados de pessoa");
                }
                else
                {
                    json = jsonPost;
                    if (DevefalharNoGetPost)
                        throw new Exception("Falha ao obter dados de posts");
                }
                var result = JsonConvert.DeserializeObject<TEntity>(json);
                return new Response<TEntity> { CodigoResposta = 200, Resposta = result };
            });
        }
    }
}
