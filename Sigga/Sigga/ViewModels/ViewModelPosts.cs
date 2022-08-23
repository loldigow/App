using Core.Provider;
using Dominio.Models;
using Newtonsoft.Json;
using SuperCore.Interfaces.Repository;
using SuperCore.Interfaces.Service;
using SuperCore.Models;
using SuperCore.Repository;
using SuperCore.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Sigga.ViewModels
{
    public class ViewModelPosts : ViewModelBase
    {
        private FiltrosPostModel _filtro;
        public ObservableCollection<PostModel> Itens { get; private set; }

        private readonly ISyncService _SyncService;

        public ICommand RefreshCommand => new Command(async () => AtualizeDados());
        public ICommand AbraPostSelecionado => new Command<PostModel>(async (e) => AbraPost(e));


        public void AbraPost(PostModel e)
        {
            var post = JsonConvert.SerializeObject(e);
            Shell.Current.GoToAsync($"Post/Detalhes?post={Uri.EscapeDataString(post)}");
        }

        public ViewModelPosts()
        {
            _filtro = new FiltrosPostModel();
            Itens = new ObservableCollection<PostModel>();
            _SyncService = new SyncService(new PessoaRepository(),
                new EmpresaRepository(),
                new EnderecoRepository(),
                new CoordenadasRepository(),
                new PostRepository(),
                new ProvedorRest());
            AtualizeDadosDaTela();
        }
        private void AtualizeDados()
        {
            AtualizeDadosDaTela();
        }

        private void AtualizeDadosDaTela()
        {
            Task.Run( () =>
            {
                try
                {

                    EstaOcupado = true;
                    _SyncService.SyncDados();

                    IEnumerable<PostModel> posts = _SyncService.ObtenhaPosts();


                    if (_filtro != null)
                    {
                        var filtroUsuario = _filtro.CodigoUsuario;
                        if (filtroUsuario != 0)
                        {
                            posts = posts.Where(x => x.IdUsuario == filtroUsuario);
                        }

                        var filtroTexto = _filtro.ConteudoTitulo;
                        if (filtroTexto != null)
                        {
                            posts = posts.Where(x => x.Titulo.Contains(filtroTexto));
                        }
                    }

                    Device.BeginInvokeOnMainThread(() =>
                    {
                        AtualizeDadosDaLista(posts);

                    });
                }
                catch (Exception e)
                {
                    MessagingCenter.Send(e.Message, "PopPupErro");
                }
                finally
                {
                    EstaOcupado = false;
                }

            });
        }

        private void AtualizeDadosDaLista(IEnumerable<PostModel> posts)
        {
            Itens.Clear();
            foreach (var i in posts)
            {
                Itens.Add(i);
            }
        }
    }
}
