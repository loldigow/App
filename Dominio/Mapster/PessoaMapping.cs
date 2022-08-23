using Core.Entidade;
using Dominio.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Mapster
{
    public class PessoaMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            TypeAdapterConfig<PessoaModel, Coordenadas>.NewConfig()
                .Map(dest => dest.Id, src => src.Id);

            TypeAdapterConfig<PessoaModel, Empresa>.NewConfig()
                .Map(dest => dest.Id, src => src.Id);

            TypeAdapterConfig<PessoaModel, Endereco>.NewConfig()
                .Map(dest => dest.Id, src => src.Id);
        }
    }
}
