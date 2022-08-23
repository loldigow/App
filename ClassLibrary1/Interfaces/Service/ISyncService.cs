using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperCore.Interfaces.Service
{
    public interface ISyncService
    {
        void SyncDados();
        List<PessoaModel> ObtenhaPessoas();
        List<PessoaModel> ObtenhaPessoasCompleto();
        PessoaModel ObtenhaPessoasPeloId(int id);
        IList<PostModel> ObtenhaPosts();
        IList<PostModel> ObtenhaPostsDoUsuario(int idUsuario);

    }
}
