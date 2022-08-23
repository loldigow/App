using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entidade
{
    public class Pessoa : RealmObject
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Contato { get; set; }
        public string WebSite { get; set; }
    }
}
