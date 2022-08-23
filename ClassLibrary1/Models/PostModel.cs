using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Models
{
    public class PostModel
    {
        [JsonProperty("userId")]
        public int IdUsuario { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Titulo { get; set; }


        [JsonProperty("body")]
        public string Corpo { get; set; }

        public string CorpoReduzido
        {
            get
            {
                return Corpo.Substring(0, 20) + "...";
            }
        }

        public string ImagemUsuario { get; set; }
        public string NomeUsuario { get; set; }
    }
}
