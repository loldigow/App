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
        PessoaModel ObtenhaPessoasPeloId(int id);
        IList<PostModel> ObtenhaPosts();
        IList<PostModel> ObtenhaPostsDoUsuario(int idUsuario);

    }
}
