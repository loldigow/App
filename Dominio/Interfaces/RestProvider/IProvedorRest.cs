using Dominio.Provider.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.RestProvider
{
    public interface IProvedorRest
    {
        Task<Response<TEntity>> Get<TEntity>(string url);
    }
}
