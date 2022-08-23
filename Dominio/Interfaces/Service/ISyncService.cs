using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Service
{
    public interface ISyncService
    {
        Task AtualizePessoas();
        List<PessoaModel> ObtenhaPessoas();
        PessoaModel ObtenhaPessoasPeloId(int id);

    }
}
