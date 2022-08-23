using SuperCore.Interfaces.Repository;
using SuperCore.Interfaces.Service;
using SuperCore.Service;
using Dominio.Interfaces.RestProvider;
using System;
using TechTalk.SpecFlow;
using Teste.MockTeste;
using FakeItEasy;
using SuperCore.Entidade;
using System.Collections.Generic;
using Dominio.Provider.Models;
using Xunit;
using System.Threading.Tasks;

namespace Teste
{
    [Binding]
    public class DesenvolvimentoETesteDeUsuarioServiceStepDefinitions
    {
        IPessoaRepository _pessoaRepository;
        IEmpresaRepository _empresarepository;
        IEnderecoRepository _enderecorepository;
        ICoordenadasRepository _coordenadasRepository;
        IPostRepository _postRepository;
        IProvedorRest _provedor;
        ISyncService _pessoaService;
        Exception _exception;
        bool _deveFalharnoSyncUsuarios;
        bool _deveFalharnoSyncPosts;
        int _posts;
        int _pessoas;

        [Given(@"Que obtenho ""([^""]*)"" usuarios e ""([^""]*)"" posts para baixar")]
        public void GivenQueObtenhoUsuariosEPostsParaBaixar(string numeroDeUsuarios, string numeroDePosts)
        {
            _posts = int.Parse(numeroDePosts);
            _pessoas = int.Parse(numeroDeUsuarios);
        }

        [Then(@"vou ter falha no sync")]
        public void ThenVouTerFalhaNoSync()
        {
            Assert.NotNull(_exception);
        }

        [Given(@"O processo de sync de pessoas falha")]
        public void GivenOProcessoDeSyncDePessoasFalha()
        {
            _deveFalharnoSyncUsuarios = true;
        }

        [Given(@"O processo de sync de post falha")]
        public void GivenOProcessoDeSyncDePostFalha()
        {
            _deveFalharnoSyncPosts = true;
        }

        [Then(@"vou ter sucesso no Sync")]
        public void ThenVouTerSucessoNoSync()
        {
            Assert.Null(_exception);
        }


        [When(@"Quando Sincronizar com o serviço")]
        public async void WhenQuandoSincronizarComOServico()
        {
            _pessoaRepository = new PessoaRepositoryMock();
            _empresarepository = new EmpresaRepositoryMock();
            _enderecorepository = new EnderecoRepositoryMock();
            _postRepository = new PostRepositoryMock();
            _coordenadasRepository = new CoordenadasRepositoryMock();

            var provedor = new RestProviderMock(_pessoas, _posts);
            provedor.DevefalharNoGetPessoas = _deveFalharnoSyncUsuarios;
            provedor.DevefalharNoGetPost = _deveFalharnoSyncPosts;
            _provedor = provedor;

            _pessoaService = new SyncService(_pessoaRepository,
                                               _empresarepository,
                                               _enderecorepository,
                                               _coordenadasRepository,
                                               _postRepository,
                                               _provedor);
            try
            {
                _pessoaService.SyncDados();

            }
            catch (Exception e)
            {
                _exception = e;
            }


        }
    }
}
