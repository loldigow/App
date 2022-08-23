using Core.Provider;
using Dominio.Models;
using Newtonsoft.Json;
using SuperCore.Interfaces.Service;
using SuperCore.Models;
using SuperCore.Repository;
using SuperCore.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Sigga.ViewModels
{
    public class ViewModelUsuarios : ViewModelBase
    {
        public ICommand AbraUsuarioSelecionado => new Command<PessoaModel>(async (e) => AbraDadosDeUsuario(e));

        private void AbraDadosDeUsuario(PessoaModel e)
        {
            var usuario = JsonConvert.SerializeObject(e);
            Shell.Current.GoToAsync($"Usuario/Detalhes?usuario={Uri.EscapeDataString(usuario)}");
        }

        private FiltrosPostModel _filtro;
        public ObservableCollection<PessoaModel> Itens { get; private set; }
        private ISyncService _syncService;
        public ViewModelUsuarios()
        {
            Itens = new ObservableCollection<PessoaModel>();
            _syncService = new SyncService(new PessoaRepository(),
                new EmpresaRepository(),
                new EnderecoRepository(),
                new CoordenadasRepository(),
                new PostRepository(),
                new ProvedorRest());
            CarregueTela();
        }

        private void CarregueTela()
        {
            Task.Run(() =>
            {
                try
                {
                    IEnumerable<PessoaModel> posts = _syncService.ObtenhaPessoas();
                    if (_filtro != null)
                    {
                        var filtroUsuario = _filtro.CodigoUsuario;
                        if (filtroUsuario != 0)
                        {
                            posts = posts.Where(x => x.Id == filtroUsuario);
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

        private void AtualizeDadosDaLista(IEnumerable<PessoaModel> posts)
        {
            Itens.Clear();
            foreach (var i in posts)
            {
                Itens.Add(i);
            }
        }
    }
}
