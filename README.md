Demonstration of Azure Service Bus and Azure Functions

Triggered from sending a message to a Service Bus Queue, this function will write the message to a Datalake Gen2 storage account.

The Function reads in custom data from the message and writes it to a file in the Datalake.

You will have to update the local.settings.json file with your own values, and update these values in the ServiceBusQueueTrigger.cs file along with the Azure Portal as configuration variables.