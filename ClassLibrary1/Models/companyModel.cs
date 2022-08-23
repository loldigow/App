using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Models
{
    public class companyModel
    {
        [JsonProperty("name")]
        public string NomeEmresa { get; set; }

        [JsonProperty("catchPhrase")]
        public string CatchPhrase { get; set; }

        [JsonProperty("bs")]
        public string BS { get; set; }
    }
}
