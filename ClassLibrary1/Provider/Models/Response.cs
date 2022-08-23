using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Provider.Models
{
    public class Response<TEntity>
    {
        public int CodigoResposta { get; set; }
        public TEntity Resposta { get; set; }
        public IList<string> Erros { get; set; }
    }
}
