using System;
using System.Text;
using Bifrost.Serialization;
using Events;
using PowerBIDotNet;
using Microsoft.ServiceBus.Messaging;

namespace Desktop.Simulator
{
    public class ViewModel
    {
        static SerializationOptions SerializationOptions = new SerializationOptions { UseCamelCase = true };
        static Random Random = new Random();

        IConfigurationForTenants _configurationForTenants;
        IWorkspaces _workspaces;
        ISerializer _serializer;

        public ViewModel(IConfigurationForTenants configurationForTenants, IWorkspaces workspaces, ISerializer serializer)
        {
            _configurationForTenants = configurationForTenants;
            _workspaces = workspaces;
            _serializer = serializer;
        }

        public void AddToPowerBI()
        {
            var configuration = _configurationForTenants.GetFor("DnB");
            var workspace = _workspaces.GetFor("DnB");

            var dataset = workspace.Datasets.GetByName(configuration.Dataset);
            workspace.Rows.Add(dataset, new Message { ResponseInMinutes = Random.Next(0,45) });
        }

        public void AddEvent()
        {
            var connectionString = "";

            var client = EventHubClient.CreateFromConnectionString(connectionString,"filtered");

            var message = new Message
            {
                ResponseInMinutes = Random.Next(0, 45),
                Tenant = "DnB"
            };
            var json = _serializer.ToJson(message, SerializationOptions);
            var body = Encoding.UTF8.GetBytes(json);
            var eventData = new EventData(body);
            client.Send(eventData);
        }
    }
}
