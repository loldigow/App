using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entidade
{
    public class Coordenadas : RealmObject
    {
        public int Id { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
