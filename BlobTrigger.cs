using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FoodPanda
{
    public static class BlobTrigger
    {
        [FunctionName("BlobTrigger")]
        public static void Run([BlobTrigger("orders/{id}", Connection = "AzureWebJobsStorage")]Stream myBlob, string id, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Order Id:{id} \n Size: {myBlob.Length} Bytes");
        }
    }
}
