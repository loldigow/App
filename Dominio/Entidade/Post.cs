using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entidade
{
    public class Post : RealmObject
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Titulo { get; set; }
        public string Corpo { get; set; }
    }
}
