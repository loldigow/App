using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCore.Entidade
{
    public class Empresa : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string NomeEmresa { get; set; }
        public string CatchPhrase { get; set; }
        public string BS { get; set; }
    }
}
