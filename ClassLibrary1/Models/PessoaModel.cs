using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Models
{
    public class PessoaModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Nome { get; set; }

        [JsonProperty("username")]
        public string NomeUsuario { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("address")]
        public addressModel Endereco { get; set; }

        [JsonProperty("Phone")]
        public string Contato { get; set; }

        [JsonProperty("website")]
        public string WebSite { get; set; }

        [JsonProperty("Company")]
        public companyModel Empresa { get; set; }

        public string FotoUsuario { get; set; }
    }
}

