using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entidade
{
    public class Empresa : RealmObject
    {
        public int Id { get; set; }
        public string NomeEmresa { get; set; }
        public string CatchPhrase { get; set; }
        public string BS { get; set; }
    }
}
