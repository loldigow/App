using Core.Provider;
using Dominio.Models;
using Newtonsoft.Json;
using SuperCore.Interfaces.Service;
using SuperCore.Repository;
using SuperCore.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Sigga.ViewModels
{
    [QueryProperty("usuario", "usuario")]
    public class ViewModelUsuario : ViewModelBase
    {
        public PessoaModel _usuario { get; set; }
        public PessoaModel Usuario
        {
            get
            {
                return _usuario;
            }
        }

        public String usuario
        {
            set
            {
                var dadosUsuario = Uri.UnescapeDataString(value);
                var usuarioDecodificado = JsonConvert.DeserializeObject<PessoaModel>(dadosUsuario);
                if (usuarioDecodificado != null)
                {
                    _usuario = usuarioDecodificado;
                    Posts = new ObservableCollection<PostModel>(_syncService.ObtenhaPostsDoUsuario(_usuario.Id));
                    OnPropertyChanged(nameof(Usuario));
                    OnPropertyChanged(nameof(Posts));
                    OnPropertyChanged(nameof(DescricaoPosts));
                }
                else
                {
                    throw new Exception("Não foi possivel abrir os detalhes deste post.");
                }
            }
        }
        public ObservableCollection<PostModel> Posts { get; set; }
        private ISyncService _syncService;
        public Command MaisSobreUsuario => new Command(AbraDetalhesUsuario);
        private void AbraDetalhesUsuario(object obj)
        {
            var usuario = JsonConvert.SerializeObject(_usuario);
            //Shell.Current.GoToAsync($"Usuario/Detalhes/Sobre?usuario={Uri.EscapeDataString(usuario)}");
            Shell.Current.GoToAsync($"Usuario/Detalhes/Sobre?usuario={_usuario.Id}");
        }

        public ViewModelUsuario()
        {
            _syncService = new SyncService(new PessoaRepository(),
                                            new EmpresaRepository(),
                                            new EnderecoRepository(),
                                            new CoordenadasRepository(),
                                            new PostRepository(),
                                            new ProvedorRest());
            _usuario = new PessoaModel();
            Posts = new ObservableCollection<PostModel>();
        }
        public string DescricaoPosts
        {
            get { return Posts.Count == 0 ? "Este usuario não tem publicações" : $"Este usuário possui {Posts.Count} posts"; }
        }
    }
}
