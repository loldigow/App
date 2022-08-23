using Core.Entidade;
using Dominio.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Mapster
{
    public class PostMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            TypeAdapterConfig<PostModel, Post>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.IdUsuario, src => src.IdUsuario)
                .Map(dest => dest.Titulo, src => src.Titulo)
                .Map(dest => dest.Corpo, src => src.Corpo);
        }
    }
}
