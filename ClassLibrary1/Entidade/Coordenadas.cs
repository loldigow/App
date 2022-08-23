using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCore.Entidade
{
    public class Coordenadas : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
