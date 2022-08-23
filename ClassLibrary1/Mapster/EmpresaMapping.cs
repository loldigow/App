using Dominio.Models;
using Mapster;
using SuperCore.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCore.Mapster
{
    public class EmpresaMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            TypeAdapterConfig<Empresa, companyModel>.NewConfig()
                .Map(dest => dest.BS, src => src.BS)
                .Map(dest => dest.CatchPhrase, src => src.CatchPhrase)
                .Map(dest => dest.NomeEmresa, src => src.NomeEmresa);

            TypeAdapterConfig<companyModel, Empresa>.NewConfig()
                .Map(dest => dest.BS, src => src.BS)
                .Map(dest => dest.CatchPhrase, src => src.CatchPhrase)
                .Map(dest => dest.NomeEmresa, src => src.NomeEmresa);
        }
    }
}
