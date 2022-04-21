using System;
using Newtonsoft.Json;

namespace Palota.Assessment.Countries.Models
{//Model Code for countries
    public class Countries
    {
        [JsonProperty("countries")]
        public string countries { get; set; }

        
    }

    public class Iso3Code
    {
        [JsonProperty("iso3Code")]
        public string iso3Code { get; set; }


    }
}