using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entidade
{
    public class Endereco : RealmObject
    {
        public int Id { get; set; }
        public string Rua { get; set; }
        public string Quarto { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }
    }
}
