using Dominio.Models;
using Mapster;
using SuperCore.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCore.Mapster
{
    public class CoordenadasMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            TypeAdapterConfig<Coordenadas, GeoModel>.NewConfig()
                .Map(dest => dest.Latitude, src => src.Latitude)
                .Map(dest => dest.Longitude, src => src.Longitude);

            TypeAdapterConfig<GeoModel, Coordenadas>.NewConfig()
                .Map(dest => dest.Latitude, src => src.Latitude)
                .Map(dest => dest.Longitude, src => src.Longitude);
        }
    }
}
