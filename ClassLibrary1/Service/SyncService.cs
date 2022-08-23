using SuperCore.Entidade;
using SuperCore.Interfaces.Repository;
using SuperCore.Interfaces.Service;
using SuperCore.Provider;
using Dominio.Interfaces.RestProvider;
using Dominio.Models;
using Dominio.Provider.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SuperCore.Service
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
        public void SyncDados()
        {
            var respostaPessoas = _provedor.Get<List<PessoaModel>>(RouteApi.RotaPessoas).Result;
            var respostaPosts = _provedor.Get<List<PostModel>>(RouteApi.RotaPosts).Result;
            
            if (respostaPessoas.CodigoResposta == 200 && respostaPosts.CodigoResposta == 200)
            {
                var pessoas = respostaPessoas.Resposta;
                var post = respostaPosts.Resposta;
                if (pessoas.Any() && post.Any())
                {
                    ApagueTodosOsRegistrosDoBanco();
                    AtualizeDados(respostaPessoas, respostaPosts);
                }
            }
            else
            {
                var listaDeExceptions = respostaPessoas.Erros.Union(respostaPosts.Erros);
                throw new Exception(string.Join("", listaDeExceptions));
            }
        }

        private void ApagueTodosOsRegistrosDoBanco()
        {
            _pessoaRepository.RemovaTodos();
            _empresarepository.RemovaTodos();
            _enderecorepository.RemovaTodos();
            _coordenadasRepository.RemovaTodos();
            _postRepository.RemovaTodos();
        }

        private void AtualizeDados(Response<List<PessoaModel>> respostaPessoas, Response<List<PostModel>> respostaPosts)
        {
            try
            {
                var coordenadas = new List<Coordenadas>();
                var empresas = new List<Empresa>();
                var enderecos = new List<Endereco>();
                var pessoas = new List<Pessoa>();
                foreach(var pessoa in respostaPessoas.Resposta)
                {
                    var p = pessoa.Adapt<Pessoa>();
                    p.FotoUsuario = pessoa.FotoUsuario ?? "UserDefault";

                    var coordenada = pessoa.ExtraiaCoordenadas();
                    if (coordenada != null)
                        coordenadas.Add(coordenada);

                    var empresa = pessoa.ExtraiaEmpresa();
                    if (empresa != null)
                        empresas.Add(empresa);

                    var endereco = pessoa.ExtraiaEndereco();
                    if (endereco != null)
                        enderecos.Add(endereco);

                    pessoas.Add(p);
                }

                var posts = respostaPosts.Resposta.Adapt<IList<Post>>();

                _pessoaRepository.AdicioneTodos(pessoas);
                _empresarepository.AdicioneTodos(empresas);
                _enderecorepository.AdicioneTodos(enderecos);
                _coordenadasRepository.AdicioneTodos(coordenadas);
                _postRepository.AdicioneTodos(posts);
            }
            catch(Exception e)
            {
                throw new Exception("Não foi possivel atualizar o Banco de dados, favor entrar em contato com o suporte do aplicativo");
            }
            
        }

        public PessoaModel ObtenhaPessoasPeloId(int id)
        {
            var entidadePessoa = _pessoaRepository.ObtenhaPeloId(id);
            var entidadeEndereco = _enderecorepository.ObtenhaPeloId(entidadePessoa.Id);
            var entidadeEmpresa = _empresarepository.ObtenhaPeloId(entidadePessoa.Id);
            var entidadeCoordenadas = _coordenadasRepository.ObtenhaPeloId(entidadePessoa.Id);

            var pessoa = entidadePessoa.Adapt<PessoaModel>();
            var endereco = entidadeEndereco.Adapt<addressModel>();
            var empresa = entidadeEmpresa.Adapt<companyModel>();
            var coordenadas = entidadeCoordenadas.Adapt<GeoModel>();

            endereco.Localizacao = coordenadas;
            pessoa.Endereco = endereco;
            pessoa.Empresa = empresa;
            return pessoa;
        }

        public IList<PostModel> ObtenhaPosts()
        {
            var postModels = new List<PostModel>();
            var posts = _postRepository.ObtenhaTodos();
            var pessoas = _pessoaRepository.ObtenhaTodos();
            var juncoes = from post in posts
                        join pessoa in pessoas on post.IdUsuario equals pessoa.Id
                        select new { post, pessoa };
            foreach(var juncao in juncoes)
            {
                var postModel = juncao.post.Adapt<PostModel>();
                postModel.NomeUsuario = juncao.pessoa.NomeUsuario;
                postModel.ImagemUsuario = juncao.pessoa.FotoUsuario;
                postModels.Add(postModel);
            }
            return postModels;
        }

        public IList<PostModel> ObtenhaPostsDoUsuario(int idUsuario)
        {
            var EntidadePosts = _postRepository.ObtenhaTodos().Where(x => x.IdUsuario == idUsuario).ToList();
            var usuario = _pessoaRepository.ObtenhaPeloId(idUsuario);
            var posts = EntidadePosts.Adapt<List<PostModel>>().ToList();
            posts.ForEach(x => x.NomeUsuario = usuario.NomeUsuario);
            return posts;
        }

        public List<PessoaModel> ObtenhaPessoas()
        {
            var entidadepessoas = _pessoaRepository.ObtenhaTodos();
            return entidadepessoas.Adapt<List<PessoaModel>>();
        }
    }
}
