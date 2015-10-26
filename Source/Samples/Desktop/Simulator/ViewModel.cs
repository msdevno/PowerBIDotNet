using System;
using System.Linq;
using System.Text;
using Bifrost.Serialization;
using Events;
using PowerBIDotNet;
using Microsoft.ServiceBus.Messaging;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Bifrost.Extensions;

namespace Desktop.Simulator
{
    public class ViewModel
    {
        static SerializationOptions SerializationOptions = new SerializationOptions { UseCamelCase = true };
        static Random Random = new Random();

        ObservableCollection<TenantConfiguration> _tenantsCollection = new ObservableCollection<TenantConfiguration>();

        IConfigurationForTenants _configurationForTenants;
        IWorkspaces _workspaces;
        ISerializer _serializer;

        public ViewModel(IConfigurationForTenants configurationForTenants, IWorkspaces workspaces, ISerializer serializer)
        {
            _configurationForTenants = configurationForTenants;
            _workspaces = workspaces;
            _serializer = serializer;

            configurationForTenants.GetAll().ForEach(_tenantsCollection.Add);
        }

        public IEnumerable<TenantConfiguration> Tenants { get { return _tenantsCollection; } }

        public virtual TenantConfiguration SelectedTenant { get; set; }


        public void AddToPowerBI()
        {
            var configuration = _configurationForTenants.GetFor(SelectedTenant.Tenant);
            var workspace = _workspaces.GetFor(SelectedTenant.Tenant);

            var dataset = workspace.Datasets.GetByName(configuration.Dataset);
            workspace.Rows.Add(dataset, new Message { ResponseInMinutes = Random.Next(0,45) });
        }

        public void AddEvent()
        {
            var connectionString = "Endpoint=sb://socialboards.servicebus.windows.net/;SharedAccessKeyName=Sender;SharedAccessKey=742kzJxgwFmy9xh8MIfVQeiqapiXqKh9GEXcR6Pm3NI=";

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

        const string AuthorityUri = "https://login.windows.net/common/oauth2/authorize";
        const string RedirectUri = "https://login.live.com/oauth20_desktop.srf";
        const string ResourceUri = "https://analysis.windows.net/powerbi/api";


        public void AuthenticateAndAddToPowerBI()
        {
            /*
            var tokenCache = new TokenCache();
            var authenticationContext = new AuthenticationContext(AuthorityUri, tokenCache);
            var result = authenticationContext.AcquireToken(ResourceUri, configuration.Client, new Uri(RedirectUri), PromptBehavior.RefreshSession);

            configuration.AuthorizationToken = result.AccessToken;
            configuration.RefreshToken = result.RefreshToken;
            */

        }
    }
}
