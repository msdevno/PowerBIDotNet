using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Bifrost.Serialization;
using Events;
using Infrastructure.PowerBI;
using Microsoft.ServiceBus.Messaging;

namespace TenantCoordinator
{
    public class EventProcessor : IEventProcessor
    {
        static SerializationOptions SerializationOptions = new SerializationOptions { UseCamelCase = true };
        ISerializer _serializer;
        IConfigurationForTenants _configurationForTenants;
        IWorkspaces _workspaces;



        public EventProcessor(ISerializer serializer, IConfigurationForTenants configurationForTenants, IWorkspaces workspaces)
        {
            _serializer = serializer;
            _configurationForTenants = configurationForTenants;
            _workspaces = workspaces;
        }


        public async Task CloseAsync(PartitionContext context, CloseReason reason)
        {
            Console.WriteLine($"Processor Shutting Down. Partition '{context.Lease.PartitionId}', Reason: '{reason}'.");
            if (reason == CloseReason.Shutdown)
            {
                await context.CheckpointAsync();
            }
        }

        Task IEventProcessor.OpenAsync(PartitionContext context)
        {
            Console.WriteLine($"SimpleEventProcessor initialized.  Partition: '{context.Lease.PartitionId}', Offset: '{context.Lease.Offset}'");
            return Task.FromResult<object>(null);
        }

        async Task IEventProcessor.ProcessEventsAsync(PartitionContext context, IEnumerable<EventData> messages)
        {
            foreach (EventData eventData in messages)
            {
                var json = Encoding.UTF8.GetString(eventData.GetBytes());
                Console.WriteLine($"Message received.  Partition: '{context.Lease.PartitionId}', Data: '{json}'");

                var message = _serializer.FromJson<Message>(json, SerializationOptions);

                try
                {
                    var tenantConfiguration = _configurationForTenants.GetFor(message.Tenant);
                    var workspace = _workspaces.GetFor(message.Tenant);
                    var dataset = workspace.Datasets.GetByName(tenantConfiguration.Dataset);
                    workspace.Rows.Add(dataset, tenantConfiguration.Table, message);
                }
                catch { }
            }

            await context.CheckpointAsync();
        }
    }
}
