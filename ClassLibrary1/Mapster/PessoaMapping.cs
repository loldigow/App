using SuperCore.Entidade;
using Dominio.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCore.Mapster
{
    public class PessoaMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            TypeAdapterConfig<PessoaModel, Pessoa>.NewConfig()
                .Map(dest => dest.FotoUsuario ?? "UserDefault", src => src.FotoUsuario ?? "UserDefault");

        }
    }
}
