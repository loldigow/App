using Dominio.Models;
using Mapster;
using SuperCore.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCore.Mapster
{
    public class EnderecoMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            TypeAdapterConfig<Endereco, addressModel>.NewConfig()
                .Map(dest => dest.Rua, src => src.Rua)
                .Map(dest => dest.Quarto, src => src.Quarto)
                .Map(dest => dest.Cidade, src => src.Cidade)
                .Map(dest => dest.CEP, src => src.CEP);

            TypeAdapterConfig<addressModel, Endereco>.NewConfig()
                .Map(dest => dest.Rua, src => src.Rua)
                .Map(dest => dest.Quarto, src => src.Quarto)
                .Map(dest => dest.Cidade, src => src.Cidade)
                .Map(dest => dest.CEP, src => src.CEP);
        }
    }
}
