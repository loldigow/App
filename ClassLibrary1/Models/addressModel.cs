using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Models
{
    public class addressModel
    {
        [JsonProperty("street")]
        public string Rua { get; set; }

        [JsonProperty("suite")]
        public string Quarto { get; set; }

        [JsonProperty("city")]
        public string Cidade { get; set; }

        [JsonProperty("zipcode")]
        public string CEP { get; set; }

        [JsonProperty("geo")]
        public GeoModel Localizacao { get; set; }
    }
}
