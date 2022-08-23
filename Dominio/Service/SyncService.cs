using Core.Entidade;
using Core.Interfaces.Repository;
using Core.Interfaces.Service;
using Core.Provider;
using Dominio.Interfaces.RestProvider;
using Dominio.Models;
using Dominio.Provider.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public class SyncService : ISyncService
    {
        readonly IPessoaRepository _pessoaRepository;
        readonly IEmpresaRepository _empresarepository;
        readonly IEnderecoRepository _enderecorepository;
        readonly ICoordenadasRepository _coordenadasRepository;
        readonly IPostRepository _postRepository;
        readonly IProvedorRest _provedor;

        public SyncService(IPessoaRepository pessoaRepository,
                             IEmpresaRepository empresarepository,
                             IEnderecoRepository enderecorepository,
                             ICoordenadasRepository coordenadasRepository,
                             IPostRepository postRepository,
                             IProvedorRest provedor)
        {

            _pessoaRepository = pessoaRepository;
            _empresarepository = empresarepository;
            _enderecorepository = enderecorepository;
            _coordenadasRepository = coordenadasRepository;
            _postRepository = postRepository;
            _provedor = provedor;
        }
        public async Task AtualizePessoas()
        {
            var respostaPessoas = await _provedor.Get<List<PessoaModel>>(RouteApi.RotaPessoas);
            var respostaPosts = await _provedor.Get<List<PostModel>>(RouteApi.RotaPosts);

            if (respostaPessoas.CodigoResposta == 200 && respostaPosts.CodigoResposta == 200)
            {
                var pessoas = respostaPessoas.Resposta;
                var post = respostaPosts.Resposta;
                if (pessoas.Any() && post.Any())
                {
                    AtualizeDados(respostaPessoas, respostaPosts);
                }
            }
            else
            {
                var listaDeExceptions = respostaPessoas.Erros.Union(respostaPosts.Erros);
                throw new Exception(string.Join("", listaDeExceptions));
            }

        }

        private void AtualizeDados(Response<List<PessoaModel>> respostaPessoas, Response<List<PostModel>> respostaPosts)
        {
            _pessoaRepository.RemovaTodos();
            _empresarepository.RemovaTodos();
            _enderecorepository.RemovaTodos();
            _coordenadasRepository.RemovaTodos();
            _postRepository.RemovaTodos();

            var pessoas = respostaPessoas.Resposta.Adapt<IList<Pessoa>>();
            var empresas = respostaPessoas.Resposta.Adapt<IList<Empresa>>();
            var enderecos = respostaPessoas.Resposta.Adapt<IList<Endereco>>();
            var coordenadas = respostaPessoas.Resposta.Adapt<IList<Coordenadas>>();

            var posts = respostaPosts.Resposta.Adapt<IList<Post>>();

            _pessoaRepository.AdicioneTodos(pessoas);
            _empresarepository.AdicioneTodos(empresas);
            _enderecorepository.AdicioneTodos(enderecos);
            _coordenadasRepository.AdicioneTodos(coordenadas);
            _postRepository.AdicioneTodos(posts);
        }

        public List<PessoaModel> ObtenhaPessoas()
        {
            var pessoas = _pessoaRepository.ObtenhaTodos();
            var enderecos = _enderecorepository.ObtenhaTodos();
            var empresas = _empresarepository.ObtenhaTodos();
            var coordenadas = _coordenadasRepository.ObtenhaTodos();
            List<PessoaModel> pessoasModel = new List<PessoaModel>();

            var pessoaModel = from pessoa in pessoas
                              join empresa in empresas on pessoa.Id equals empresa.Id
                              join endereco in enderecos on pessoa.Id equals endereco.Id
                              join coordenada in coordenadas on pessoa.Id equals coordenada.Id
                              select new
                              {
                                  pessoa,
                                  empresa,
                                  endereco,
                                  coordenada
                              };
            foreach (var pessoa in pessoaModel)
            {
                var pessoaViewModel = new PessoaModel();
            }
            return pessoasModel;
        }

        public PessoaModel ObtenhaPessoasPeloId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
