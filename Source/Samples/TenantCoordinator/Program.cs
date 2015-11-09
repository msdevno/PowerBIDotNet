using System;
#if(!DEBUG)
using Microsoft.Azure.WebJobs;
#endif
using Microsoft.ServiceBus.Messaging;

namespace TenantCoordinator
{
    class Program
    {
        static void Main(string[] args)
        {
            Bifrost.Configuration.Configure.DiscoverAndConfigure();

            var eventProcessorHostName = "";
            var eventHubConnectionString = "";
            var eventHubName = "";
            var storageAccountName = "";
            var storageAccountKey = "";
            var storageConnectionString = $"DefaultEndpointsProtocol=https;AccountName={storageAccountName};AccountKey={storageAccountKey}";

            var eventProcessorHost = new EventProcessorHost(
                eventProcessorHostName,
                eventHubName,
                EventHubConsumerGroup.DefaultGroupName,
                eventHubConnectionString,
                storageConnectionString);

            eventProcessorHost.RegisterEventProcessorFactoryAsync(new EventProcessorFactory());

            try
            {
#if (DEBUG)
                Console.WriteLine("Processing");
                Console.ReadLine();
#else
                var config = new JobHostConfiguration();

                var host = new JobHost(config);
                host.RunAndBlock();
#endif
            }
            finally
            {

                eventProcessorHost.UnregisterEventProcessorAsync().Wait();
            }
        }
    }
}
