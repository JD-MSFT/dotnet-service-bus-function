using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Azure.Messaging.ServiceBus
{
    public class ServiceBusQueueTrigger1
    {
        [FunctionName("ServiceBusQueueTrigger1")]
        public void Run(
            [ServiceBusTrigger("jdsq", Connection = "jdsservicebus_SERVICEBUS")]
            string myQueueItem,
            string MessageId,
            long SequenceNumber,
            [Blob("outcontainer/sample-blob", Connection = "jdsdatalakesa_BLOB")] out string blobContent,
            ILogger log)
        {
            blobContent = new
            {
                MessageId,
                SequenceNumber,
                myQueueItem
            }.ToString();
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {MessageId}");
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {SequenceNumber}");
        }
    }
}
