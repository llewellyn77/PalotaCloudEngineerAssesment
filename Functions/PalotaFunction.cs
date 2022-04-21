using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using RESTCountries.Services;
using RESTCountries.Models;
using System.Linq;
using Newtonsoft.Json;
using System;

namespace Palota.Assessment.Countries.Functions
{
    public static class PalotaCloudEngineerAssesmentFunctions
    {
        [FunctionName("ListAllCountries")]
        public static async Task<IActionResult> ListAllCountries(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "countries")] HttpRequest request,
            ILogger logger)
        {
            //Gets all countries
             var all = await RESTCountriesAPI.GetAllCountriesAsync(); //gets and returns all information about the country
             List<string> countries = all.Select(c => c.Name).ToList();

            //Test
            //var result = await RESTCountriesAPI.GetCountriesByContinentAsync("africa");

            // Get all country names...

            logger.LogInformation($"Getting all countries from rest Countries api");

            return new OkObjectResult(countries);
        }
        //List all countries given search
        [FunctionName("ListAllCountriesInSpecificContinent")]
        public static async Task<IActionResult> ListAllCountriesInSpecificContinent(
           [HttpTrigger(AuthorizationLevel.Function, "get", Route = "continents/{continentName}/countries/")] HttpRequest request,
           ILogger logger)
        {
            //Gets all countries from specific search
            string continentName = request.Query["continentName"];

            string requestBody = String.Empty;
            using (StreamReader streamReader = new StreamReader(request.Body))
            {
                requestBody = await streamReader.ReadToEndAsync();
            }
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            continentName = continentName ?? data?.nameOfContinent;
            var result = await RESTCountriesAPI.GetCountriesByContinentAsync(continentName);
            List<string> SearchContinentResults = result.Select(d=> d.Name).ToList();

            //return continentName != null
            //    ? (ActionResult)new OkObjectResult($"{result}")
            //    : new BadRequestObjectResult("Please pass a name of the continent the query string or in the request body");


            logger.LogInformation($"Search continent");
            return new OkObjectResult(SearchContinentResults);
        }

        //List all countries given iso3Code search
        [FunctionName("ListSingleCountryiso3Code")]
        public static async Task<IActionResult> GetASingleCountryByIso3Code(
           [HttpTrigger(AuthorizationLevel.Function, "get", Route = "countries/{iso3Code}")] HttpRequest request,
           ILogger logger)
        {
            //Gets all countries from specific search
            string iso3Code = request.Query["iso3Code"];

            string requestBody = String.Empty;
            using (StreamReader streamReader = new StreamReader(request.Body))
            {
                requestBody = await streamReader.ReadToEndAsync();
            }
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            iso3Code = iso3Code ?? data?.nameOfContinent;
            var result = await RESTCountriesAPI.GetCountriesByCodesAsync(iso3Code);
            List<string> Searchiso3CodeResults = result.Select(d => d.Name).ToList();

            //return continentName != null
            //    ? (ActionResult)new OkObjectResult($"{result}")
            //    : new BadRequestObjectResult("Please pass a name of the continent the query string or in the request body");


            logger.LogInformation($"Search with iso3Code");
            return new OkObjectResult(Searchiso3CodeResults);
        }




        // Get all country names...




        //  [FunctionName("GetASingleCountryByIso3Code")]
        //public static async Task<IActionResult> GetASingleCountryByIso3Code(
        //      [HttpTrigger(AuthorizationLevel.Function, "get", Route = "countries/{iso3Code}")] HttpRequest request,
        //     ILogger logger, string iso3Code)
        // {
        //      var data = @"{
        //           ""name"": "",
        //           ""iso3Code"": ""ZAF"",
        //           ""capital"": ""Pretoria"",
        //           ""subregion"": ""Southern Africa"",
        //           ""region"": ""Africa"",
        //           ""population"": 59308690,
        //       ""location"": {           
        //           ""lattitude"": -29.0,
        //           ""longitude"": 24.0
        //                   },
        //           ""demonym"": ""South African"",
        //           ""nativeName"": ""South Africa"",
        //           ""numericCode"": ""710"",
        //           ""flag"": ""https://flagcdn.com/za.svg""
        // }";

        //      // Get book by id from database..

        //      logger.LogInformation($"Get country  from database.");

        //  //   return new OkObjectResult(countries);
        //}
    }
}
