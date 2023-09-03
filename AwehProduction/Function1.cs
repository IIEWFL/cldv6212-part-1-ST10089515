using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AwehProduction
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "api/id/{id}")] HttpRequest req,
            string id,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            // Hard-code some valid ID or passport numbers
            var validIds = new List<string> { "0210015109080", "7112365012563" };

            if (validIds.Contains(id))
            {
                // Dummy vaccination data for valid ID/passport numbers
                var vaccinationData = new
                {
                
                    Status = "Vaccinated",
                    Date = DateTime.UtcNow.ToString("yyyy-MM-dd")
                };

                return new OkObjectResult(vaccinationData);
            }
            else
            {
                return new NotFoundObjectResult("ID or passport number not found.");
            }
        }
    }
}


/**

public static class VaccinationStatus
{
    private static Dictionary<string, string> dummyData = new Dictionary<string, string>
    {
        { "0210015109080", "Fully vaccinated" },
        { "0210119582230", "Partially vaccinated" },
        { "02130256333612", "Not vaccinated" }
    };

    [FunctionName("GetVaccinationStatus")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "id/{id}")] HttpRequest req,
        string id,
        ILogger log)
    {
        if (dummyData.ContainsKey(id))
        {
            var result = new
            {
                ID = id,
                VaccinationStatus = dummyData[id]
            };

            return new OkObjectResult(JsonConvert.SerializeObject(result));
        }

        return new NotFoundResult();
    }
}
**/