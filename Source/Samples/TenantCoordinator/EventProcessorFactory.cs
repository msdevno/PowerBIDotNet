using Bifrost.Configuration;
using Microsoft.ServiceBus.Messaging;

namespace TenantCoordinator
{
    public class EventProcessorFactory : IEventProcessorFactory
    {
        public IEventProcessor CreateEventProcessor(PartitionContext context)
        {
            var processor = Configure.Instance.Container.Get<EventProcessor>();
            return processor;
        }
    }
}
