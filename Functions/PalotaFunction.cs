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
        //                //
        // FUNCTIONS CODE //
        //                //



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
            Console.Write("Status Code : 200");
            logger.LogInformation($"Getting all countries from rest Countries api succesfully");
            

            return new OkObjectResult(countries);
        }
        //List all countries given search
        [FunctionName("ListAllCountriesInSpecificContinent")]
        public static async Task<IActionResult> ListAllCountriesInSpecificContinent(
           [HttpTrigger(AuthorizationLevel.Function, "get", Route = "continents/{continentName}/countries/")] HttpRequest request,
           ILogger logger)
        {
            //Gets all countries from continentName search
            //Input
            string continentName = request.Query["continentName"];
            if (continentName == null)
            {
                return new OkObjectResult("Please enter the continentName as the query parameter in the url");

            }
            else
            {
                string requestBody = String.Empty;
                using (StreamReader streamReader = new StreamReader(request.Body))
                {
                    requestBody = await streamReader.ReadToEndAsync();
                }
                dynamic data = JsonConvert.DeserializeObject(requestBody);
                continentName = continentName ?? data?.continentName;
                var result = await RESTCountriesAPI.GetCountriesByContinentAsync(continentName);
                //  Error handling


                List<string> SearchContinentResults = result.Select(d => d.Name).ToList();
                //Debugging
                // Console.Write(SearchContinentResults);
                if (SearchContinentResults.Count == 0)
                {

                    logger.LogInformation($"404 Error Code");
                    return new OkObjectResult($"The continent with name {continentName} could not be found.");
                }
                else
                {
                    //return continentName != null
                    //    ? (ActionResult)new OkObjectResult($"{result}")
                    //    : new BadRequestObjectResult("Please pass a name of the continent the query string or in the request body");

                    Console.Write("Status Code : 200");
                    logger.LogInformation($"Searched continent succefully");
                    return new OkObjectResult(SearchContinentResults);
                }
            }
        }

        //List single country given iso3Code search
        [FunctionName("ListSingleCountryiso3Code")]
        public static async Task<IActionResult> GetASingleCountryByIso3Code(
           [HttpTrigger(AuthorizationLevel.Function, "get", Route = "countries/{iso3Code}")] HttpRequest request,
           ILogger logger)
        {
            //Gets single return country via input of iso3Code

            //input
            string iso3Code = request.Query["iso3Code"];
            if (iso3Code == null)
            {
                return new OkObjectResult("Please enter the iso3Code as the query parameter in the url to get the name of the country ");

            }
            else
            {
                string requestBody = String.Empty;
                using (StreamReader streamReader = new StreamReader(request.Body))
                {
                    requestBody = await streamReader.ReadToEndAsync();
                }
                //make data readable for searching
                dynamic data = JsonConvert.DeserializeObject(requestBody);
                iso3Code = iso3Code ?? data?.iso3Code;
                var result = await RESTCountriesAPI.GetCountriesByCodesAsync(iso3Code);

                //get the country name of
                List<string> Searchiso3CodeResults = result.Select(d => d.Name).ToList();
                //if searched list array = 0. This means that there is no search found
                if (Searchiso3CodeResults.Count == 0)
                {
                    //error code to debug
                    logger.LogInformation($"404 Error Code");
                    return new OkObjectResult($"The country with ISO 3166 Alpha 3 code {iso3Code} could not be found.");
                }
                else
                {

                    //return continentName != null
                    //    ? (ActionResult)new OkObjectResult($"{result}")
                    //    : new BadRequestObjectResult("Please pass a name of the continent the query string or in the request body");

                    Console.Write("Status Code : 200");
                    logger.LogInformation($"Searched with iso3Code succesfully");
                    return new OkObjectResult(Searchiso3CodeResults);

                }
            }


        }

        //List all countries bordering
        
        [FunctionName("GetListOfBorderingCountriesWithIso3Code")]
        public static async Task<IActionResult> GetListOfBorderingCountriesWithIso3Code(
           [HttpTrigger(AuthorizationLevel.Function, "get", Route = "countries/{iso3Code}/borders")] HttpRequest request,
           ILogger logger)
        {
            //Gets all countries bordering the iso3code
            //Inputs
            string iso3Code = request.Query["iso3Code"];
            if (iso3Code == null)
            {
                return new OkObjectResult("Please enter the iso3Code as the query parameter in the url to search for the borders");

            }
            else
            {

                string requestBody = String.Empty;
                using (StreamReader streamReader = new StreamReader(request.Body))
                {
                    requestBody = await streamReader.ReadToEndAsync();
                }
                dynamic data = JsonConvert.DeserializeObject(requestBody);
                iso3Code = iso3Code ?? data?.iso3Code;
                var result = await RESTCountriesAPI.GetCountriesByCodesAsync(iso3Code);
                //Get borders from the Iso3Code
                List<string> Searchiso3CodeResultsBorders = (List<string>)result.Select(d => d.Borders);

                Console.Write(Searchiso3CodeResultsBorders);
                //if searched list array = 0. This means that there is no search found
                if (Searchiso3CodeResultsBorders.Count == 0)
                {
                    //We then display the not found error

                    logger.LogInformation($"404 Error Code");
                    return new OkObjectResult($"The country with ISO 3166 Alpha 3 code {iso3Code} could not be found.");
                }
                else
                {

                    //return continentName != null
                    //    ? (ActionResult)new OkObjectResult($"{result}")
                    //    : new BadRequestObjectResult("Please pass a name of the continent the query string or in the request body");

                    Console.Write("Status Code : 200");
                    logger.LogInformation($"Searched with iso3Code succesfully");
                    return new OkObjectResult(Searchiso3CodeResultsBorders);

                }
            }
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
