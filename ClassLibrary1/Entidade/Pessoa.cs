using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCore.Entidade
{
    public class Pessoa : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Contato { get; set; }
        public string WebSite { get; set; }
        public string FotoUsuario { get; internal set; }
    }
}
