using System;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Text.Json;

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
            Int32 deliveryCount,
            DateTime enqueuedTimeUtc,
            IDictionary<string, object> ApplicationProperties,
            [Blob("outcontainer/{MessageId}", Connection = "jdsdatalakesa_BLOB")] out string blobContent,
            ILogger log)

        {
            string myData = ApplicationProperties["data"].ToString();
            blobContent = JsonSerializer.Serialize(new
            {
                MessageId,
                SequenceNumber,
                myQueueItem,
                deliveryCount,
                enqueuedTimeUtc,
                myData,
            });

            log.LogInformation($"C# ServiceBus processed message: {myQueueItem}");
            log.LogInformation($"C# ServiceBus processed messageId: {MessageId}");
            log.LogInformation($"C# ServiceBus processed ApplicationProperties Data: {ApplicationProperties["data"]}");
            log.LogInformation($"C# ServiceBus processed SequenceNumber: {SequenceNumber}");
            log.LogError($"Error in the system");
            log.LogWarning($"Warning in the system");
        }
    }
}
