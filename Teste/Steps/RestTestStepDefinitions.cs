using Dominio;
using Core;
using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;
using Dominio.Interfaces.RestProvider;
using Core.Provider;
using Dominio.Provider.Models;

namespace Teste
{
    [Binding]
    public class RestTestStepDefinitions
    {
        string _url;
        string _tipo;
        Response<List<PessoaModel>> respostaPessoa;
        Response<List<PostModel>> respostaPost;
        IProvedorRest _provider;

        [Given(@"Dado que tenho uma URL ""([^""]*)""")]
        public void GivenDadoQueTenhoUmaURL(string url)
        {
            _url = url;
        }

        [Given(@"Tenho o Tipo ""([^""]*)""")]
        public void GivenTenhoOTipo(string tipo)
        {
            _tipo = tipo;
        }

        [When(@"Quando fizer o Get")]
        public async Task WhenQuandoFizerOGetAsync()
        {
            _provider = new ProvedorRest();
            if (_tipo == "Pessoa")
            {
                respostaPessoa = await _provider.Get<List<PessoaModel>>(_url);
            }
            else
            {
                respostaPost = await _provider.Get<List<PostModel>>(_url);
            }
        }

        [Then(@"vou ter resposta")]
        public void ThenVouTerResposta()
        {
            if (_tipo == "Pessoa")
                Assert.NotNull(respostaPessoa.Resposta);

            if (_tipo == "post")
                Assert.NotNull(respostaPost.Resposta);
        }

        [Then(@"não vou ter erros")]
        public void ThenNaoVouTerErros()
        {
            if (_tipo == "Pessoa")
                Assert.Null(respostaPessoa.Erros);

            if (_tipo == "post")
                Assert.Null(respostaPost.Erros);
        }

        [Then(@"não vou ter resposta")]
        public void ThenNaoVouTerResposta()
        {
            if (_tipo == "Pessoa")
                Assert.Null(respostaPessoa.Resposta);

            if (_tipo == "post")
                Assert.Null(respostaPost.Resposta);
        }

        [Then(@"vou ter erro")]
        public void ThenVouTerErro()
        {
            if (_tipo == "Pessoa")
                Assert.NotNull(respostaPessoa.Erros);

            if (_tipo == "post")
                Assert.NotNull(respostaPost.Erros);
        }


        [Then(@"Vou obter Status code ""([^""]*)""")]
        public void ThenVouObterStatusCode(string statusCodeEsperado)
        {
            if (_tipo == "Pessoa")
                Assert.True(respostaPessoa.CodigoResposta == int.Parse(statusCodeEsperado));

            if (_tipo == "post")
                Assert.True(respostaPost.CodigoResposta == int.Parse(statusCodeEsperado));
        }

    }
}
