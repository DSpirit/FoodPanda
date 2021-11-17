using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FoodPanda
{
    public static class QueueTrigger
    {
        [FunctionName("QueueTrigger")]
        public static void Run(
            [QueueTrigger("orders", Connection = "AzureWebJobsStorage")]string myQueueItem, 
            ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
