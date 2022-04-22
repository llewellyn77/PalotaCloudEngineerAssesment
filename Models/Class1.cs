using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RESTCountries.Models;

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


        public class Country
        {
            // Gets or sets the Name
            public string Name { get; set; }

            // Gets or sets the Top Level Domain
            public IList<string> TopLevelDomain { get; set; }

            // Gets or sets the Alpha2 Code
            public string Alpha2Code { get; set; }

            // Gets or sets the Alpha3 Code
            public string Alpha3Code { get; set; }

            // Gets or sets the Calling Codes
            public IList<string> CallingCodes { get; set; }

            // Gets or sets the Capital City
            public string Capital { get; set; }

            // Gets or sets the Alt Spellings
            public IList<string> AltSpellings { get; set; }

            // Gets or sets the Region
            public string Region { get; set; }

            // Gets or sets the Subregion
            public string Subregion { get; set; }

            // Gets or sets the Population
            public int Population { get; set; }

            // Gets or sets the Latlng(Latitude and Longitude)
            public IList<double> Latlng { get; set; }

            // Gets or sets the Demonym
            public string Demonym { get; set; }

            // Gets or sets the Area
            public double? Area { get; set; }

            // Gets or sets the Gini
            public double? Gini { get; set; }

            // Gets or sets the Timezones
            public IList<string> Timezones { get; set; }

            // Gets or sets the Borders
            public IList<string> Borders { get; set; }

            // Gets or sets the Native Name
            public string NativeName { get; set; }

            // Gets or sets the Numeric Code
            public string NumericCode { get; set; }

            // Gets or sets the Currencies
            public IList<Currency> Currencies { get; set; }

            // Gets or sets the Languages
            public IList<Language> Languages { get; set; }

            // Gets or sets the Translations
            public Translations Translations { get; set; }

            // Gets or sets the Flag (Svg and PNG format)
            public Flag Flag { get; set; }

            // Gets or sets the Regional Blocs
            public IList<RegionalBloc> RegionalBlocs { get; set; }

            // Gets or sets the Cioc(International Olympic Committee Code)
            public string Cioc { get; set; }
        }







    }


}