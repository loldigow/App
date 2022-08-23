using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCore.Entidade
{
    public class Endereco : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Rua { get; set; }
        public string Quarto { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }
    }
}
