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
        


            // Get all country names...

            logger.LogInformation($"Getting all countries from rest Countries api");

            return new OkObjectResult(countries);
        }

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
