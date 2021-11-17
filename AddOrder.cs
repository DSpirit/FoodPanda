using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FoodPanda
{
    public static class AddOrder
    {
        [FunctionName("AddOrder")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "orders/{orderId}")] HttpRequest req,
            [Blob("orders/{orderId}", FileAccess.Write, Connection = "AzureWebJobsStorage")] out string orders,
            [Queue("orders")] out string queueMessage,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = new StreamReader(req.Body).ReadToEndAsync().Result;
            orders = requestBody;
            queueMessage = requestBody;

            return new OkResult();
        }
    }
}
