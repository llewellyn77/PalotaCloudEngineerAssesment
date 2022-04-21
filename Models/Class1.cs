using System;
using Newtonsoft.Json;

namespace Palota.Assessment.Countries.Models
{//Model Code for countries
    public class Countries
    {
        [JsonProperty("countries")]
        public string countries { get; set; }

        
    }

    public class Iso3CodeSearch
    {
        //                    //
        // RESPONSE STRUCTURE //
        //                    //

        //Gets and sets for custom response
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("iso3Code")]
        public string iso3Code { get; set; }

        [JsonProperty("capital")]
        public string capital { get; set; }

        [JsonProperty("subregion")]
        public string subregion { get; set; }

        [JsonProperty("region")]
        public string region { get; set; }

        [JsonProperty("population")]
        public int population { get; set; }

        [JsonProperty("lattitude")]
        public int lattitude { get; set; }

        [JsonProperty("longitude")]
        public int longitude { get; set; }

        [JsonProperty("demonym")]
        public string demonym { get; set; }

        [JsonProperty("nativeName")]
        public string nativeName { get; set; }

        [JsonProperty("numericCode")]
        public int numericCode { get; set; }

        [JsonProperty("flag")]
        public string flag { get; set; }










    }
}