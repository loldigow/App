using Core.Provider;
using Dominio.Models;
using SuperCore.Interfaces.Service;
using SuperCore.Repository;
using SuperCore.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Sigga.ViewModels
{
    [QueryProperty("usuario", "usuario")]
    public class SobreUsuarioViewModel : ViewModelBase
    {
        private ISyncService _syncService;
        private PessoaModel _pessoa = new PessoaModel();
        public PessoaModel PessoaModel
        {
            get
            {
                return _pessoa;
            }
        }
        public String usuario
        {
            set
            {
                if (int.TryParse(value, out int codigoPessoa))
                {
                    var pessoa = _syncService.ObtenhaPessoasPeloId(codigoPessoa);
                    _pessoa = pessoa;
                    OnPropertyChanged(nameof(PessoaModel));
                }
                else
                {
                    throw new Exception("Não foi possivel abrir os detalhes deste post.");
                }
            }
        }

        public SobreUsuarioViewModel()
        {
            _syncService = new SyncService(new PessoaRepository(),
                                new EmpresaRepository(),
                                new EnderecoRepository(),
                                new CoordenadasRepository(),
                                new PostRepository(),
                                new ProvedorRest());
        }

    }
}
